using CQRSDemo.Context;
using CQRSDemo.Entities;
using Dapper;
using MediatR;
using System.Data;

namespace CQRSDemo.Feature.Products.Query;

#region query
public record GetAllProductsQuery : IRequest<List<Product>>;

#endregion


#region handler
public class GetAllProductsQueryHandler(DataContext _dataContext) 
    : IRequestHandler<GetAllProductsQuery, List<Product>>
{
    public async Task<List<Product>> Handle(GetAllProductsQuery request, CancellationToken cancellationToken)
    {
        var query = "select * from products";
        using(var cnx = _dataContext.GetSql())
        {
            var list = await cnx.QueryAsync<Product>(query, commandType: CommandType.Text);
            return list.ToList();
        }
    }
}

#endregion