using System;
using System.Linq.Expressions;
using System.Collections.Generic;
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
    <Hash>161917d1e16e2e1c881f109b9d2fcdc7</Hash>
</Codenesium>*/