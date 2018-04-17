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

		ApiResponse GetById(int billOfMaterialsID);

		POCOBillOfMaterials GetByIdDirect(int billOfMaterialsID);

		ApiResponse GetWhere(Expression<Func<EFBillOfMaterials, bool>> predicate, int skip = 0, int take = int.MaxValue, string orderClause = "");

		List<POCOBillOfMaterials> GetWhereDirect(Expression<Func<EFBillOfMaterials, bool>> predicate, int skip = 0, int take = int.MaxValue, string orderClause = "");

		ApiResponse GetWhereDynamic(string predicate, int skip = 0, int take = int.MaxValue, string orderClause = "");
	}
}

/*<Codenesium>
    <Hash>ce7908cd8a95960e4c2ad495c24eac4d</Hash>
</Codenesium>*/