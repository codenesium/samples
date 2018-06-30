using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using System.Threading.Tasks;

namespace StackOverflowNS.Api.DataAccess
{
        public interface IUsersRepository
        {
                Task<Users> Create(Users item);

                Task Update(Users item);

                Task Delete(int id);

                Task<Users> Get(int id);

                Task<List<Users>> All(int limit = int.MaxValue, int offset = 0);
        }
}

/*<Codenesium>
    <Hash>e28b1eade441413c44ecdd8af16ba971</Hash>
</Codenesium>*/