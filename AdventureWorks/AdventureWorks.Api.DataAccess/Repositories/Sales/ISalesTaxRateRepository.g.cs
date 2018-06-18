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

                Task<List<SalesTaxRate>> All(int limit = int.MaxValue, int offset = 0);

                Task<SalesTaxRate> ByStateProvinceIDTaxType(int stateProvinceID, int taxType);
        }
}

/*<Codenesium>
    <Hash>3c6750af73bc3f97155185d73a95df6e</Hash>
</Codenesium>*/