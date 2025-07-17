using CQRSDemo.Entities;
using MediatR;

namespace CQRSDemo.Feature.Products.Query;

//public class GetProductByIdQuery : IRequest<Product>
//{
//    public int Id { get; set; }
//}

public record GetProductByIdQuery(int Id) : IRequest<Product?>;