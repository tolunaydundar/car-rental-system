using Core.Utilities.Results.Abstract;
using Entities.Concrete;
using System;
using System.Collections.Generic;
using System.Text;

namespace Business.Abstract
{
    public interface IUserService
    {
        IResult Add(User user);
        IResult Delete(User user);
        IDataResult<List<User>> GetAll();
        IDataResult<List<User>> GetAllByAge(int min, int max);
        IDataResult<List<User>> GetAllBySex(char sex);
        IDataResult<User> GetById(int userId);
        IResult Update(User user);
    }
}
