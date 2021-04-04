using Core.Entities.Concrete;
using Core.Utilities.Results;

using System;
using System.Collections.Generic;
using System.Text;

namespace Business.Abstract
{
    public interface IUserService
    {
        IDataResult<List<User>> GetAll();

        IDataResult<User> GetUserById(int userId);

        IResult Delete(User user);

        IResult Update(User user);
        IResult Add(User user);

        void Add2(User user);

        List<OperationClaim> GetClaims(User user);
        User GetByEmail(string email);

    }
}
