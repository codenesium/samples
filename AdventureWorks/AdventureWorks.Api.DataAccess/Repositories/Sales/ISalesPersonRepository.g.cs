using System;
using System.Linq.Expressions;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace AdventureWorksNS.Api.DataAccess
{
        public interface ISalesPersonRepository
        {
                Task<SalesPerson> Create(SalesPerson item);

                Task Update(SalesPerson item);

                Task Delete(int businessEntityID);

                Task<SalesPerson> Get(int businessEntityID);

                Task<List<SalesPerson>> All(int skip = 0, int take = int.MaxValue, string orderClause = "");
        }
}

/*<Codenesium>
    <Hash>5472ee3510fd11fb25992a8996d804e3</Hash>
</Codenesium>*/