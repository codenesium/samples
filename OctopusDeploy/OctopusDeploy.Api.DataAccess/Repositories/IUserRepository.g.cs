using System;
using System.Linq.Expressions;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace OctopusDeployNS.Api.DataAccess
{
        public interface IUserRepository
        {
                Task<User> Create(User item);

                Task Update(User item);

                Task Delete(string id);

                Task<User> Get(string id);

                Task<List<User>> All(int skip = 0, int take = int.MaxValue, string orderClause = "");

                Task<User> GetUsername(string username);
                Task<List<User>> GetDisplayName(string displayName);
                Task<List<User>> GetEmailAddress(string emailAddress);
                Task<List<User>> GetExternalId(string externalId);
        }
}

/*<Codenesium>
    <Hash>e88db10eb22df2623aaac2c1c3cdfe3a</Hash>
</Codenesium>*/