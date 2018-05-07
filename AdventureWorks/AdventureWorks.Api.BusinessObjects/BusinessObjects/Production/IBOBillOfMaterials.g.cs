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
		Task<CreateResponse<int>> Create(
			BillOfMaterialsModel model);

		Task<ActionResponse> Update(int billOfMaterialsID,
		                            BillOfMaterialsModel model);

		Task<ActionResponse> Delete(int billOfMaterialsID);

		POCOBillOfMaterials Get(int billOfMaterialsID);

		List<POCOBillOfMaterials> All(int skip = 0, int take = int.MaxValue, string orderClause = "");
	}
}

/*<Codenesium>
    <Hash>e3655724f6a3175dd7bc082d7a3004cc</Hash>
</Codenesium>*/