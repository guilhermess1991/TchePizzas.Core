using System;
using System.Collections.Generic;
using TchePizzas.Domain.Commands.Results;
using TchePizzas.Domain.Entities;

namespace TchePizzas.Domain.Repositories
{
    public interface IUserRepository
    {
        User Get(Guid id);

        IEnumerable<GetUserResult> GetAll();

        void Save(User user);

		void Update(User user);

        void Delete(Guid id);
    }
}
