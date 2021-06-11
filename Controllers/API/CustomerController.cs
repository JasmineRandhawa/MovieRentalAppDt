
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Web.Http;
using AutoMapper;
using MovieRentalApp.Dtos;
using MovieRentalApp.Models;
using MovieRentalApp.Data;
using Microsoft.EntityFrameworkCore;

namespace MovieRentalApp.Controllers.API
{
    public class CustomerController : ApiController
    {
        private ApplicationDbContext _context;

        public CustomerController(ApplicationDbContext context)
        {
            _context = context;
        }

        //GET /api/customer
        [HttpGet]
        public IEnumerable<CustomerDto> GetAll()
        {
            return _context.Customers.Include(c => c.MembershipType).ToList().Select(m => Mapper.Map<Customer, CustomerDto>(m)).ToList(); 
        }

        //GET /api/customer/1
        [HttpGet]
        public CustomerDto Get(int id)
        {
            var customer = _context.Customers.Include(c => c.MembershipType).ToList().SingleOrDefault(c => c.Id == id);

            if (customer == null)
                throw new HttpResponseException(HttpStatusCode.NotFound);

            return Mapper.Map<Customer, CustomerDto>(customer);
        }

        //POST api/customer
        [HttpPost]
        public CustomerDto Add(CustomerDto customerDto)
        {
            if(!ModelState.IsValid)
                throw new HttpResponseException(HttpStatusCode.BadRequest);

            var customer = Mapper.Map<CustomerDto, Customer>(customerDto);
            _context.Customers.Add(customer);
            _context.SaveChanges();

            customerDto.Id = customer.Id;
            customer.MembershipType = _context.MembershipTypes.SingleOrDefault(c => c.Id == customer.MembershipTypeId);
            customerDto.MembershipType = Mapper.Map<MembershipType, MembershipTypeDto>(customer.MembershipType);
            return customerDto;
        }

        //PUT api/customer/1
        [HttpPut]
        public CustomerDto Update(int id , CustomerDto customerDto)
        {
            if (!ModelState.IsValid)
                throw new HttpResponseException(HttpStatusCode.BadRequest);

            var customerInDb = _context.Customers.Include(c => c.MembershipType).ToList().SingleOrDefault(c => c.Id == id);

            if (customerInDb == null)
                throw new HttpResponseException(HttpStatusCode.NotFound);

           Mapper.Map<CustomerDto, Customer>(customerDto, customerInDb);

            /* if (!string.IsNullOrEmpty(customerDto.Name) && !customerDto.Name.Equals(customerInDb.Name))
                customerInDb.Name = customerDto.Name;

            if (customerDto.MembershipTypeId != cus tomerInDb.MembershipTypeId)
            {
                customerInDb.MembershipTypeId = customerDto.MembershipTypeId;
            }
         
            if (!string.IsNullOrEmpty(customerDto.Email) && !customerDto.Email.Equals(customerInDb.Email))
                customerInDb.Email = customerDto.Email;

            if (customerDto.IsSubscribedToNewsLetter!=customerInDb.IsSubscribedToNewsLetter)
                customerInDb.IsSubscribedToNewsLetter = customerDto.IsSubscribedToNewsLetter;

            if (customerDto.BirthDate != customerInDb.BirthDate)
                customerInDb.BirthDate = customerDto.BirthDate;
*/
            _context.SaveChanges();
            customerInDb.MembershipType = _context.MembershipTypes.SingleOrDefault(c => c.Id == customerInDb.MembershipTypeId);
            customerDto.MembershipType = Mapper.Map<MembershipType, MembershipTypeDto>(customerInDb.MembershipType);
            return customerDto;
        }

        //DELETE api/customer/1
        [HttpDelete]
  
        public void Delete(int id)
        {
            var customer = _context.Customers.Single(m => m.Id == id);
            if (customer == null)
                throw new HttpResponseException(HttpStatusCode.NotFound);

            _context.Customers.Remove(customer);

            _context.SaveChanges();
        }
    }
}