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

                Task<List<SalesTaxRate>> All(int limit = int.MaxValue, int offset =  0, string orderClause = "");

                Task<SalesTaxRate> GetStateProvinceIDTaxType(int stateProvinceID, int taxType);
        }
}

/*<Codenesium>
    <Hash>ecf7714b56c941517660e025d1f91a88</Hash>
</Codenesium>*/