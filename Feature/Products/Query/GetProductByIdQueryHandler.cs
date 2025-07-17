using CQRSDemo.Context;
using CQRSDemo.Entities;
using Dapper;
using MediatR;
using System.Data;

namespace CQRSDemo.Feature.Products.Query;

public class GetProductByIdQueryHandler(DataContext _dataContext) : IRequestHandler<GetProductByIdQuery, Product?>
{
    //forma tradicional - aqui usamos la forma simplificada
    //private readonly DataContext dataContext;

    //public GetProductByIdQueryHandler(DataContext dataContext)
    //{
    //    this.dataContext = dataContext;
    //}

    public async Task<Product?> Handle(GetProductByIdQuery request, CancellationToken cancellationToken)
    {
        var quey = "select * from products where Id = @Id";
        var parameters = new DynamicParameters();
        parameters.Add("@Id", request.Id, DbType.Int32);

        using(var cnx = _dataContext.GetSql())
        {
            var result = await cnx.QueryFirstOrDefaultAsync<Product>(quey, parameters, commandType: CommandType.Text);
            return result;
        }
    }
}
