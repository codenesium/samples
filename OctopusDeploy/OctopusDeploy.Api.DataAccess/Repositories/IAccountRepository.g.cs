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

                Task<List<Account>> All(int skip = 0, int take = int.MaxValue, string orderClause = "");

                Task<Account> GetName(string name);
        }
}

/*<Codenesium>
    <Hash>f7ad995314816e628132019bf645e5fa</Hash>
</Codenesium>*/