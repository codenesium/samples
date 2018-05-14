using System;
using System.Linq.Expressions;
using System.Collections.Generic;
using System.Threading.Tasks;
using AdventureWorksNS.Api.Contracts;
using AdventureWorksNS.Api.DataAccess;

namespace AdventureWorksNS.Api.BusinessObjects
{
	public interface IBOBillOfMaterials
	{
		Task<CreateResponse<POCOBillOfMaterials>> Create(
			ApiBillOfMaterialsModel model);

		Task<ActionResponse> Update(int billOfMaterialsID,
		                            ApiBillOfMaterialsModel model);

		Task<ActionResponse> Delete(int billOfMaterialsID);

		POCOBillOfMaterials Get(int billOfMaterialsID);

		List<POCOBillOfMaterials> All(int skip = 0, int take = int.MaxValue, string orderClause = "");

		POCOBillOfMaterials GetProductAssemblyIDComponentIDStartDate(Nullable<int> productAssemblyID,int componentID,DateTime startDate);

		List<POCOBillOfMaterials> GetUnitMeasureCode(string unitMeasureCode);
	}
}

/*<Codenesium>
    <Hash>179f75d1a47089ba10e309f244be1082</Hash>
</Codenesium>*/