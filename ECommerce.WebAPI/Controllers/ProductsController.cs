using ECommerce.WebAPI.Contens;
using ECommerce.WebAPI.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace ECommerce.WebAPI.Controllers;

//@RestController -> Java
//@RequestMapping ("api/products/")  -> Java

[Route("api/[controller]")]
[ApiController]
public class ProductsController : ControllerBase
{

    MsSqlContext context = new MsSqlContext();


    [HttpPost("add")]
    public Product Add([FromBody] Product product) //http isteğinin gövdesinden gitmesi, urlde gözükmez
    {
        //insert into Products(kolonlar) values(değerler)
        context.Products.Add(product);
        context.SaveChanges();

        return product;
    }

    [HttpGet("getall")]
    public List<Product> GetAll()
    {
        //SELECT*FROM PRODUCTS
        return context.Products.ToList();
    }

    [HttpGet("getbyid/{id:int}")]
    public IActionResult GetById([FromRoute] int id)  //urlden almak için     Object=herhangi bir tip
    {
        Product product = context.Products.SingleOrDefault(x => x.Id == id);
        if(product == null)
        {
            return NotFound("Aradığınız ürün bulunamadı");
        }
        return Ok(product);
    }

    //static List<Product> Products = new List<Product>()
    //{
    //    new Product{ Id=1, Name="Dyson Süpürge", Price=2500, Stock=50},
    //    new Product{ Id=2, Name="Iphone 16", Price=8700, Stock=100},
    //    new Product{ Id=3, Name="SteelSeries Alpha 7", Price=8700, Stock=850},
    //    new Product{ Id=4, Name="Piyano", Price=9999, Stock=1},
    //    new Product{ Id=5, Name="Lisanslı Fb Forması", Price=5000, Stock=50},
    //};

    //[HttpGet]
    //public List<Product> GetAll()
    //{
    //    return Products;    
    //}

    //[HttpGet("getbyid")]
    //public Product GetById(int id)
    //{
    //    Product product = Products.SingleOrDefault(x=> x.Id==id);
    //    return product;
    //}

    // http://localhost:5098/api/products/getproduct

    //[HttpGet("getproduct")]
    //public Product GetProduct()
    //{
    //    return new Product
    //    {
    //        Id = 1,
    //        Name = "Test",  
    //        Price = 1535,
    //        Stock = 56
    //    };
    //}



}
