using System;
using System.Linq.Expressions;
using System.Collections.Generic;
using System.Threading.Tasks;
using AdventureWorksNS.Api.Contracts;
using AdventureWorksNS.Api.DataAccess;

namespace AdventureWorksNS.Api.BusinessObjects
{
	public interface IBOProductProductPhoto
	{
		Task<CreateResponse<int>> Create(
			ProductProductPhotoModel model);

		Task<ActionResponse> Update(int productID,
		                            ProductProductPhotoModel model);

		Task<ActionResponse> Delete(int productID);

		POCOProductProductPhoto Get(int productID);

		List<POCOProductProductPhoto> All(int skip = 0, int take = int.MaxValue, string orderClause = "");
	}
}

/*<Codenesium>
    <Hash>5f0d3bab3472552ceab0f7f28b216023</Hash>
</Codenesium>*/