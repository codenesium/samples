using System;
using System.Collections.Generic;
using System.Linq.Expressions;
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
    <Hash>36d7cc8ed4153e3a0f1054162be937a4</Hash>
</Codenesium>*/