using Business.Abstract;
using Business.BusinessAspects.Autofac;
using Business.ValidationRules.FluentValidation;
using Core.Aspects.Autofac.Validation;
using Core.Constanst;
using Core.Utilities.Results;
using DataAccess.Abstract;
using Entities.Concrete;
using Entities.DTOs;
using System;
using System.Collections.Generic;
using System.Text;

namespace Business.Concrete
{
    public class CustomerManager:ICustomerService
    {
        ICustomerDal _customerDal;

        public CustomerManager(ICustomerDal customerDal)
        {
            _customerDal = customerDal;
        }
        [SecuredOperation("Customer.add,admin")]
        [ValidationAspect(typeof(CustomerValidator))]
        public IResult Add(Customer customer)
        {
           // if ( customer.CompanyName.Length > 1)
           // {
                _customerDal.Add(customer);
                return new SuccessResult(Messages.CustomerAdded);
          //  }
          //  return new ErrorResult(Messages.Invalid);
        }
        
        public IResult Delete(Customer customer)
        {
            _customerDal.Delete(customer);
            return new SuccessResult(Messages.CustomerDeleted);
        }

        
        public IDataResult<List<Customer>> GetAll()
        {
            return new SuccessDataResult<List<Customer>>(_customerDal.GetAll(),Messages.CustomerListened);
        }
        
        public IDataResult<Customer> GetCustomerById(int customerId)
        {
            return new SuccessDataResult<Customer>(_customerDal.Get(c => c.CustomerId == customerId)
                , Messages.GetCustomer);
        }
        
        public IDataResult<List<Customer>> GetCustomerByUserId(int userId)
        {
            return new SuccessDataResult<List<Customer>>(_customerDal.GetAll(c => c.UserId == userId));
        }
        
        public IDataResult<List<CustomerDetailDto>> GetCustomerDetails()
        {
            if (DateTime.Now.Hour == 23)
            {
                return new ErrorDataResult<List<CustomerDetailDto>>(Messages.MaintenanceTime);
            }
            return new SuccessDataResult<List<CustomerDetailDto>>(_customerDal.GetCustomerDetails());
        }
        [ValidationAspect(typeof(CustomerValidator))]
        public IResult Update(Customer customer)
        {
           // if ( customer.CompanyName.Length > 1)
        //    {
                _customerDal.Update(customer);
                return new SuccessResult(Messages.CustomerUpdated);
        //    }
       //     return new ErrorResult(Messages.Invalid);
        }
    }
}
