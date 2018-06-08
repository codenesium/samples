using System;
using System.Linq.Expressions;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace AdventureWorksNS.Api.DataAccess
{
        public interface IBusinessEntityRepository
        {
                Task<BusinessEntity> Create(BusinessEntity item);

                Task Update(BusinessEntity item);

                Task Delete(int businessEntityID);

                Task<BusinessEntity> Get(int businessEntityID);

                Task<List<BusinessEntity>> All(int skip = 0, int take = int.MaxValue, string orderClause = "");
        }
}

/*<Codenesium>
    <Hash>10f18831eabe12836225c9ebf6675233</Hash>
</Codenesium>*/