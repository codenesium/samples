using System;
using System.Linq.Expressions;
using System.Collections.Generic;
using System.Threading.Tasks;
using AdventureWorksNS.Api.Contracts;
using AdventureWorksNS.Api.DataAccess;

namespace AdventureWorksNS.Api.BusinessObjects
{
	public interface IBOProductModel
	{
		Task<CreateResponse<int>> Create(
			ProductModelModel model);

		Task<ActionResponse> Update(int productModelID,
		                            ProductModelModel model);

		Task<ActionResponse> Delete(int productModelID);

		POCOProductModel Get(int productModelID);

		List<POCOProductModel> All(int skip = 0, int take = int.MaxValue, string orderClause = "");
	}
}

/*<Codenesium>
    <Hash>af5865a519f79b04c3ec3e411b645f32</Hash>
</Codenesium>*/