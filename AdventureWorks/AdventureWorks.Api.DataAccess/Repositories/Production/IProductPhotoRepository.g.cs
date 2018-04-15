using System;
using System.Linq.Expressions;
using System.Collections.Generic;
using AdventureWorksNS.Api.Contracts;

namespace AdventureWorksNS.Api.DataAccess
{
	public interface IProductPhotoRepository
	{
		int Create(ProductPhotoModel model);

		void Update(int productPhotoID,
		            ProductPhotoModel model);

		void Delete(int productPhotoID);

		ApiResponse GetById(int productPhotoID);

		POCOProductPhoto GetByIdDirect(int productPhotoID);

		ApiResponse GetWhere(Expression<Func<EFProductPhoto, bool>> predicate, int skip = 0, int take = int.MaxValue, string orderClause = "");

		List<POCOProductPhoto> GetWhereDirect(Expression<Func<EFProductPhoto, bool>> predicate, int skip = 0, int take = int.MaxValue, string orderClause = "");

		ApiResponse GetWhereDynamic(string predicate, int skip = 0, int take = int.MaxValue, string orderClause = "");
	}
}

/*<Codenesium>
    <Hash>7378d69058e9ff0fc9609a6dc6029dcf</Hash>
</Codenesium>*/