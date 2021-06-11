using System;
using System.ComponentModel.DataAnnotations;
using AutoMapper;
using MovieRentalApp.Dtos;
using MovieRentalApp.Models;

public class BirthDateValidation : ValidationAttribute
{
    protected override ValidationResult IsValid(object value, System.ComponentModel.DataAnnotations.ValidationContext validationContext)
    {
        CustomerDto customerDto;
        Customer customer;
        try
        {
            customerDto = (CustomerDto)validationContext.ObjectInstance;
            customer = Mapper.Map<CustomerDto, Customer>(customerDto);
        }
        catch(Exception ex)
        {
            customer = (Customer)validationContext.ObjectInstance;
            customerDto = Mapper.Map<Customer, CustomerDto>(customer);
        }
        if (customer.MembershipTypeId  != Customer.Unknown && customer.MembershipTypeId != Customer.PayAsYouGo && customer.BirthDate == null)
            return new ValidationResult("Birth Date field is required");

        if(customer.BirthDate != null)
        {
            var age = System.DateTime.Today.Year - customer.BirthDate.Value.Year;

            return age >= 18 ? ValidationResult.Success : new ValidationResult("Customer must be atleast 18 years old to get a membership.");
        }
        return ValidationResult.Success;
    }
}