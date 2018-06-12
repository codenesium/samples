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

                Task<List<KeyAllocation>> All(int skip = 0, int take = int.MaxValue, string orderClause = "");
        }
}

/*<Codenesium>
    <Hash>4255d7d9ce26562a8a5c02a19be559ab</Hash>
</Codenesium>*/