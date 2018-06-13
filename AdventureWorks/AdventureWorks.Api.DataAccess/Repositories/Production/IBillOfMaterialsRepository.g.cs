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

                Task<List<BillOfMaterials>> All(int limit = int.MaxValue, int offset =  0, string orderClause = "");

                Task<BillOfMaterials> GetProductAssemblyIDComponentIDStartDate(Nullable<int> productAssemblyID, int componentID, DateTime startDate);
                Task<List<BillOfMaterials>> GetUnitMeasureCode(string unitMeasureCode);
        }
}

/*<Codenesium>
    <Hash>026c6116c47e354fbfd920988c2c2d22</Hash>
</Codenesium>*/