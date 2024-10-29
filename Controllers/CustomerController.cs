using Microsoft.AspNetCore.Mvc;
using EF.Data;
using EF.Dtos;
using EF.Models;
using AutoMapper;


namespace EF.Controllers;

[ApiController]
[Route("[controller]")]
public class CustomerController : ControllerBase
{
    ICustomerRepository _customerRepository;
    IMapper _mapper;
    
    public CustomerController(IConfiguration config, ICustomerRepository customerRepository) {
        _customerRepository = customerRepository;

        _mapper = new Mapper(new MapperConfiguration(cfg => {
            cfg.CreateMap<CustomerAddDto, Customer>();
        }));

    }

    [HttpGet("")]
    public IEnumerable<Customer> getAllCustomer() {
       IEnumerable<Customer> customers = _customerRepository.GetCustomers();
       return customers;
    }

    [HttpPost("")]
    public IActionResult AddCustomer(CustomerAddDto customer) {
        Customer customerDB = _mapper.Map<Customer>(customer);
        _customerRepository.AddEntity<Customer>(customerDB);
        if(_customerRepository.SaveChanges()){
            return Ok();
        }
        throw new Exception("Failed to add customer");
    }

    [HttpPut("{customerID}")]
    public IActionResult EditCustomer(int customerID, CustomerAddDto customer){
        Customer? customerDB = _customerRepository.GetSingleCustomer(customerID);

        if(customerDB != null) {
            customerDB.Name = customer.Name;
            customerDB.Email = customer.Email;

            if(_customerRepository.SaveChanges()){
                return Ok();
            }
            throw new Exception("Failed to update customer");
        }
        else {
            throw new Exception("customer ID invalid");
        }

    }


}
