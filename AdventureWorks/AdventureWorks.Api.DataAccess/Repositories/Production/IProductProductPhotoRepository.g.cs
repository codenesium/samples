using System;
using System.Linq.Expressions;
using System.Collections.Generic;
using AdventureWorksNS.Api.Contracts;

namespace AdventureWorksNS.Api.DataAccess
{
	public interface IProductProductPhotoRepository
	{
		int Create(ProductProductPhotoModel model);

		void Update(int productID,
		            ProductProductPhotoModel model);

		void Delete(int productID);

		ApiResponse GetById(int productID);

		POCOProductProductPhoto GetByIdDirect(int productID);

		ApiResponse GetWhere(Expression<Func<EFProductProductPhoto, bool>> predicate, int skip = 0, int take = int.MaxValue, string orderClause = "");

		List<POCOProductProductPhoto> GetWhereDirect(Expression<Func<EFProductProductPhoto, bool>> predicate, int skip = 0, int take = int.MaxValue, string orderClause = "");

		ApiResponse GetWhereDynamic(string predicate, int skip = 0, int take = int.MaxValue, string orderClause = "");
	}
}

/*<Codenesium>
    <Hash>1f099b7f23a5fca611f65eedb9a81363</Hash>
</Codenesium>*/