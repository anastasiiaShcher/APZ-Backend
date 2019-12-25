using System.Collections.Generic;
using System.Linq;
using CryptoHelper;
using Dvor.Common.Entities;
using Dvor.Common.Enums;
using Dvor.Common.Interfaces;
using Dvor.Common.Interfaces.Services;

namespace Dvor.BLL.Services
{
    public class UserService : IUserService
    {
        private readonly IUnitOfWork _unitOfWork;

        public UserService(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }

        public IList<User> GetAll()
        {
            return _unitOfWork.GetRepository<User>()
                .GetMany(u => !u.IsDeleted, null, TrackingState.Disabled).ToList();
        }

        public User Get(string id)
        {
            return _unitOfWork.GetRepository<User>().Get(g => g.UserId == id, TrackingState.Disabled);
        }

        public void Create(User item)
        {
            var passwordHash = Crypto.HashPassword(item.PasswordHash);
                item.PasswordHash = passwordHash;
                _unitOfWork.GetRepository<User>().Create(item);
                _unitOfWork.Save();
        }

        public void Update(User item)
        {
            var user = Get(item.UserId);
            var repository = _unitOfWork.GetRepository<User>();

            if (repository.IsExist(us => us.UserId.Equals(item.UserId)) && !user.IsDeleted)
            {
                var oldItem = Get(item.UserId);
                repository.Update(item);
                _unitOfWork.Save();
            }
        }

        public void Delete(string id)
        {
            var user = Get(id);
            user.IsDeleted = true;
            Update(user);
        }

        public User GetByEmail(string email)
        {
            return _unitOfWork.GetRepository<User>()
                .Get(u => u.Email.Equals(email), TrackingState.Disabled);
        }
    }
}