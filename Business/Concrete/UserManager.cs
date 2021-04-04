using Business.Abstract;
using Business.ValidationRules.FluentValidation;
using Core.Aspects.Autofac.Validation;
using Core.Constanst;
using Core.Entities.Concrete;
using Core.Utilities.Results;
using DataAccess.Abstract;

using System;
using System.Collections.Generic;
using System.Text;

namespace Business.Concrete
{
    public class UserManager:IUserService
    {
        IUserDal _userDal;

        public UserManager(IUserDal userDal)
        {
            _userDal = userDal;
        }
        [ValidationAspect(typeof(UserValidator))]
        public IDataResult<List<User>> GetAll()
        {
            if (DateTime.Now.Hour == 23)
            {
                return new ErrorDataResult<List<User>>(Messages.MaintenanceTime);
            }
            return new SuccessDataResult<List<User>>(_userDal.GetAll(), Messages.UserListened);
        }
        [ValidationAspect(typeof(UserValidator))]
        public IResult Add(User user)
        {
          //  if (user.FirstName.Length > 2 && user.LastName.Length > 1
         //       && user.Password.Length > 6 && user.Password.Length < 17)
         //   {
                _userDal.Add(user);
                return new SuccessResult(Messages.UserAdded);

         //   }
         //   return new ErrorResult(Messages.Invalid);
        }
        [ValidationAspect(typeof(UserValidator))]
        public IDataResult<User> GetUserById(int userId)
        {
            return new SuccessDataResult<User>(_userDal.Get(u => u.UserId == userId),Messages.GetUser);
        }
        [ValidationAspect(typeof(UserValidator))]
        public IResult Delete(User user)
        {
            _userDal.Delete(user);
            return new SuccessResult(Messages.UserDeleted);
        }
        [ValidationAspect(typeof(UserValidator))]
        public IResult Update(User user)
        {
          //  if (user.FirstName.Length > 2 && user.LastName.Length > 1
        //             && user.Password.Length > 6 && user.Password.Length < 17)
        //    {
                _userDal.Update(user);
                return new SuccessResult(Messages.UserUpdated);

         //   }
        //    return new ErrorResult(Messages.Invalid);
        }

        public void Add2(User user)
        {
            _userDal.Add(user);
        }

        public List<OperationClaim> GetClaims(User user)
        {
            return _userDal.GetClaims(user);
        }

        public User GetByEmail(string email)
        {
            return _userDal.Get(u => u.Email == email);
        }


    }
}
