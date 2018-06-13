using System;
using System.Linq.Expressions;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace OctopusDeployNS.Api.DataAccess
{
        public interface IKeyAllocationRepository
        {
                Task<KeyAllocation> Create(KeyAllocation item);

                Task Update(KeyAllocation item);

                Task Delete(string collectionName);

                Task<KeyAllocation> Get(string collectionName);

                Task<List<KeyAllocation>> All(int limit = int.MaxValue, int offset =  0, string orderClause = "");
        }
}

/*<Codenesium>
    <Hash>15c56fe1ccd1b0f570c92b8a9ed0cb45</Hash>
</Codenesium>*/