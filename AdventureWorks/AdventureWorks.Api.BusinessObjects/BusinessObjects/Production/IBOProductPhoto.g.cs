using System;
using System.Linq.Expressions;
using System.Collections.Generic;
using System.Threading.Tasks;
using AdventureWorksNS.Api.Contracts;
using AdventureWorksNS.Api.DataAccess;

namespace AdventureWorksNS.Api.BusinessObjects
{
	public interface IBOProductPhoto
	{
		Task<CreateResponse<int>> Create(
			ProductPhotoModel model);

		Task<ActionResponse> Update(int productPhotoID,
		                            ProductPhotoModel model);

		Task<ActionResponse> Delete(int productPhotoID);

		ApiResponse GetById(int productPhotoID);

		POCOProductPhoto GetByIdDirect(int productPhotoID);

		ApiResponse GetWhere(Expression<Func<EFProductPhoto, bool>> predicate, int skip = 0, int take = int.MaxValue, string orderClause = "");

		List<POCOProductPhoto> GetWhereDirect(Expression<Func<EFProductPhoto, bool>> predicate, int skip = 0, int take = int.MaxValue, string orderClause = "");

		ApiResponse GetWhereDynamic(string predicate, int skip = 0, int take = int.MaxValue, string orderClause = "");
	}
}

/*<Codenesium>
    <Hash>6e5008924ae773a11bb144739534fd77</Hash>
</Codenesium>*/