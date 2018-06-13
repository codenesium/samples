using System;
using System.Linq.Expressions;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace OctopusDeployNS.Api.DataAccess
{
        public interface IMutexRepository
        {
                Task<Mutex> Create(Mutex item);

                Task Update(Mutex item);

                Task Delete(string id);

                Task<Mutex> Get(string id);

                Task<List<Mutex>> All(int limit = int.MaxValue, int offset =  0, string orderClause = "");
        }
}

/*<Codenesium>
    <Hash>3754819a62b3fe85b0bd5203bc66e700</Hash>
</Codenesium>*/