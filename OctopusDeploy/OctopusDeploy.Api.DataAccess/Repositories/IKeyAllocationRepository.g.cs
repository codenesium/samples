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

                Task<List<KeyAllocation>> All(int limit = int.MaxValue, int offset = 0);
        }
}

/*<Codenesium>
    <Hash>ebea784f9639644750d35835b1458516</Hash>
</Codenesium>*/