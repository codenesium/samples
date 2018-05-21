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
		Task<CreateResponse<POCOProductProductPhoto>> Create(
			ApiProductProductPhotoModel model);

		Task<ActionResponse> Update(int productID,
		                            ApiProductProductPhotoModel model);

		Task<ActionResponse> Delete(int productID);

		Task<POCOProductProductPhoto> Get(int productID);

		Task<List<POCOProductProductPhoto>> All(int skip = 0, int take = int.MaxValue, string orderClause = "");
	}
}

/*<Codenesium>
    <Hash>7b66b05e4686dd6da33eaf2336406151</Hash>
</Codenesium>*/