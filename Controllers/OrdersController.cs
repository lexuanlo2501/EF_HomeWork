using Microsoft.AspNetCore.Mvc;
using EF.Data;
using EF.Dtos;
using EF.Models;
using AutoMapper;


namespace EF.Controllers;

[ApiController]
[Route("[controller]")]
public class OrdersController : ControllerBase
{
    IOrdersRepository _ordersRepository;
    IMapper _mapper;
    
    public OrdersController(IConfiguration config, IOrdersRepository OrdersRepository) {
        _ordersRepository = OrdersRepository;

        _mapper = new Mapper(new MapperConfiguration(cfg => {
            cfg.CreateMap<OrderDto, Orders>();
        }));

    }

    [HttpGet("")]
    public IEnumerable<OrderDto> getAllOrders() {
       IEnumerable<Orders> orders = _ordersRepository.GetOrders();

        IEnumerable<OrderDto> orderDtos = orders.Select(order => new OrderDto
        {
            ID = order.ID,
            Product = order.Product,
            Customer = order.Customer,
            CreatedDate = order.CreatedDate
        });
       return orderDtos;
    }

    [HttpGet("customer/{customerID}")]
     public IEnumerable<Orders> getAllOrdersByCusmtomerID(int customerID) {
       IEnumerable<Orders> orders = _ordersRepository.GetSingleOrderByCustomerID(customerID);
       return orders;
    }

    [HttpGet("product/{productID}")]
     public IEnumerable<Orders> getAllOrdersByProductID(int productID) {
       IEnumerable<Orders> orders = _ordersRepository.GetSingleOrderByProductID(productID);
       return orders;
    }

    [HttpPost("")]
    public IActionResult AddOrder(OrderDto order) {
        Orders orderDB = _mapper.Map<Orders>(order);
        _ordersRepository.AddEntity<Orders>(orderDB);
        if(_ordersRepository.SaveChanges()){
            return Ok();
        }
        throw new Exception("Failed to add Orders");
    }



}
