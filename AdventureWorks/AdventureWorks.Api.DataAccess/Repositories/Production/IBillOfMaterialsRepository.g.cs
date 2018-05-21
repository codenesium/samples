using System;
using System.Linq.Expressions;
using System.Collections.Generic;
using System.Threading.Tasks;
using AdventureWorksNS.Api.Contracts;

namespace AdventureWorksNS.Api.DataAccess
{
	public interface IBillOfMaterialsRepository
	{
		Task<POCOBillOfMaterials> Create(ApiBillOfMaterialsModel model);

		Task Update(int billOfMaterialsID,
		            ApiBillOfMaterialsModel model);

		Task Delete(int billOfMaterialsID);

		Task<POCOBillOfMaterials> Get(int billOfMaterialsID);

		Task<List<POCOBillOfMaterials>> All(int skip = 0, int take = int.MaxValue, string orderClause = "");

		Task<POCOBillOfMaterials> GetProductAssemblyIDComponentIDStartDate(Nullable<int> productAssemblyID,int componentID,DateTime startDate);
		Task<List<POCOBillOfMaterials>> GetUnitMeasureCode(string unitMeasureCode);
	}
}

/*<Codenesium>
    <Hash>9141a876319a5b182aa29179495f1922</Hash>
</Codenesium>*/