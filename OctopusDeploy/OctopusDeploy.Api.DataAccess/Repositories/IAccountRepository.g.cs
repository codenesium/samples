using System;
using System.Linq.Expressions;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace OctopusDeployNS.Api.DataAccess
{
        public interface IAccountRepository
        {
                Task<Account> Create(Account item);

                Task Update(Account item);

                Task Delete(string id);

                Task<Account> Get(string id);

                Task<List<Account>> All(int limit = int.MaxValue, int offset = 0);

                Task<Account> GetName(string name);
        }
}

/*<Codenesium>
    <Hash>e96e5f74057b739cfc301e7172e78788</Hash>
</Codenesium>*/