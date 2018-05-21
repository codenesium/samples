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

		Task<POCOBillOfMaterials> Get(int billOfMaterialsID);

		Task<List<POCOBillOfMaterials>> All(int skip = 0, int take = int.MaxValue, string orderClause = "");

		Task<POCOBillOfMaterials> GetProductAssemblyIDComponentIDStartDate(Nullable<int> productAssemblyID,int componentID,DateTime startDate);
		Task<List<POCOBillOfMaterials>> GetUnitMeasureCode(string unitMeasureCode);
	}
}

/*<Codenesium>
    <Hash>4fa038525080976f9235553034410f26</Hash>
</Codenesium>*/