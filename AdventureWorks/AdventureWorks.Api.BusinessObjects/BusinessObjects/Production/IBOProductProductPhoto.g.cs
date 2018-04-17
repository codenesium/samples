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

		ApiResponse GetById(int productID);

		POCOProductProductPhoto GetByIdDirect(int productID);

		ApiResponse GetWhere(Expression<Func<EFProductProductPhoto, bool>> predicate, int skip = 0, int take = int.MaxValue, string orderClause = "");

		List<POCOProductProductPhoto> GetWhereDirect(Expression<Func<EFProductProductPhoto, bool>> predicate, int skip = 0, int take = int.MaxValue, string orderClause = "");

		ApiResponse GetWhereDynamic(string predicate, int skip = 0, int take = int.MaxValue, string orderClause = "");
	}
}

/*<Codenesium>
    <Hash>e1fb174a5a4bafdc43e92308e5fe54bc</Hash>
</Codenesium>*/