using System;
using System.Linq.Expressions;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace AdventureWorksNS.Api.DataAccess
{
        public interface ISalesTaxRateRepository
        {
                Task<SalesTaxRate> Create(SalesTaxRate item);

                Task Update(SalesTaxRate item);

                Task Delete(int salesTaxRateID);

                Task<SalesTaxRate> Get(int salesTaxRateID);

                Task<List<SalesTaxRate>> All(int skip = 0, int take = int.MaxValue, string orderClause = "");

                Task<SalesTaxRate> GetStateProvinceIDTaxType(int stateProvinceID, int taxType);
        }
}

/*<Codenesium>
    <Hash>34c3376b23b6461536145a117db7e972</Hash>
</Codenesium>*/