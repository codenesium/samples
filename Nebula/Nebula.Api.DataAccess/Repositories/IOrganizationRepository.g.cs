using System;
using System.Linq.Expressions;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace NebulaNS.Api.DataAccess
{
        public interface IOrganizationRepository
        {
                Task<Organization> Create(Organization item);

                Task Update(Organization item);

                Task Delete(int id);

                Task<Organization> Get(int id);

                Task<List<Organization>> All(int skip = 0, int take = int.MaxValue, string orderClause = "");
        }
}

/*<Codenesium>
    <Hash>45c364cd15982929d7d5d18a9cf46e36</Hash>
</Codenesium>*/