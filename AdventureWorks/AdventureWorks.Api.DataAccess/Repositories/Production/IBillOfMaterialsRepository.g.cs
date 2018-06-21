using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using System.Threading.Tasks;

namespace AdventureWorksNS.Api.DataAccess
{
        public interface IBillOfMaterialsRepository
        {
                Task<BillOfMaterials> Create(BillOfMaterials item);

                Task Update(BillOfMaterials item);

                Task Delete(int billOfMaterialsID);

                Task<BillOfMaterials> Get(int billOfMaterialsID);

                Task<List<BillOfMaterials>> All(int limit = int.MaxValue, int offset = 0);

                Task<BillOfMaterials> ByProductAssemblyIDComponentIDStartDate(Nullable<int> productAssemblyID, int componentID, DateTime startDate);

                Task<List<BillOfMaterials>> ByUnitMeasureCode(string unitMeasureCode);
        }
}

/*<Codenesium>
    <Hash>6f9824654f215ffa80cb89d2226e5389</Hash>
</Codenesium>*/