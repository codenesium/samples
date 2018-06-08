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

                Task<List<BillOfMaterials>> All(int skip = 0, int take = int.MaxValue, string orderClause = "");

                Task<BillOfMaterials> GetProductAssemblyIDComponentIDStartDate(Nullable<int> productAssemblyID, int componentID, DateTime startDate);
                Task<List<BillOfMaterials>> GetUnitMeasureCode(string unitMeasureCode);
        }
}

/*<Codenesium>
    <Hash>fce3e67bbe8e224c4b5eb45efc9a9951</Hash>
</Codenesium>*/