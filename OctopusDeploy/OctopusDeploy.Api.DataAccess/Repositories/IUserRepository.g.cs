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

                Task<List<User>> All(int limit = int.MaxValue, int offset = 0);

                Task<User> GetUsername(string username);
                Task<List<User>> GetDisplayName(string displayName);
                Task<List<User>> GetEmailAddress(string emailAddress);
                Task<List<User>> GetExternalId(string externalId);
        }
}

/*<Codenesium>
    <Hash>f201b0c367ae34a995a6fdf8e559dda0</Hash>
</Codenesium>*/