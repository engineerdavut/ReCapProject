﻿using Core.Utilities.Results;
using Entities.Concrete;
using Entities.DTOs;
using System;
using System.Collections.Generic;
using System.Text;

namespace Business.Abstract
{
    public interface ICustomerService
    {
        IDataResult<List<Customer>> GetAll();


        IDataResult<Customer> GetCustomerById(int customerId);

        IDataResult<List<Customer>> GetCustomerByUserId(int userId);

        IResult Delete(Customer customer);
        IDataResult<List<CustomerDetailDto>> GetCustomerDetails();

        IResult Update(Customer customer);
        IResult Add(Customer customer);
    }
}
