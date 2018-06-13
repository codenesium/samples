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

                Task<List<Account>> All(int limit = int.MaxValue, int offset =  0, string orderClause = "");

                Task<Account> GetName(string name);
        }
}

/*<Codenesium>
    <Hash>9760ccf3604a7c958c7fcb1494ac8daa</Hash>
</Codenesium>*/