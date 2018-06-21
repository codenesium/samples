using System;
using System.Collections.Generic;
using System.Linq.Expressions;
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
    <Hash>88876924c2c330fa521faa125f8c9744</Hash>
</Codenesium>*/