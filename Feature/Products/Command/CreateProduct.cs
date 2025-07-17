using CQRSDemo.Context;
using CQRSDemo.Entities;
using Dapper;
using MediatR;
using System.Data;

namespace CQRSDemo.Feature.Products.Command;

#region command
public record CreateProductCommand(string Name, int Price) : IRequest<bool>;
#endregion


#region handler
public class CreateProductCommandHandler(DataContext _dataContext)
    : IRequestHandler<CreateProductCommand, bool>
{
    public async Task<bool> Handle(CreateProductCommand request, CancellationToken cancellationToken)
    {
        var query = "insert into products(Name, Price) values(@Name, @Price)";
        var parameters = new DynamicParameters();
        parameters.Add("@Name", request.Name, DbType.String);
        parameters.Add("@Price", request.Price, DbType.Int32);

        using(var cnx = _dataContext.GetSql())
        {
            var rowsAffected = await cnx.ExecuteAsync(query, parameters, commandType:CommandType.Text);
            return rowsAffected > 0;
        }
    }
}
#endregion
