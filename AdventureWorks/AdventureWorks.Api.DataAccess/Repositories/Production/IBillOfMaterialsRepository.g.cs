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

                Task<BillOfMaterials> ByProductAssemblyIDComponentIDStartDate(int? productAssemblyID, int componentID, DateTime startDate);

                Task<List<BillOfMaterials>> ByUnitMeasureCode(string unitMeasureCode);
        }
}

/*<Codenesium>
    <Hash>f1bea83a7f1751076916088e0724f800</Hash>
</Codenesium>*/