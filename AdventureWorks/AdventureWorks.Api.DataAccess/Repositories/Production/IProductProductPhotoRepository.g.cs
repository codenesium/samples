using System;
using System.Linq.Expressions;
using System.Collections.Generic;
using AdventureWorksNS.Api.Contracts;

namespace AdventureWorksNS.Api.DataAccess
{
	public interface IProductProductPhotoRepository
	{
		int Create(int productPhotoID,
		           bool primary,
		           DateTime modifiedDate);

		void Update(int productID, int productPhotoID,
		            bool primary,
		            DateTime modifiedDate);

		void Delete(int productID);

		Response GetById(int productID);

		POCOProductProductPhoto GetByIdDirect(int productID);

		Response GetWhere(Expression<Func<EFProductProductPhoto, bool>> predicate, int skip = 0, int take = Int32.MaxValue, string orderClause = "");

		List<POCOProductProductPhoto> GetWhereDirect(Expression<Func<EFProductProductPhoto, bool>> predicate, int skip = 0, int take = Int32.MaxValue, string orderClause = "");

		Response GetWhereDynamic(string predicate, int skip = 0, int take = Int32.MaxValue, string orderClause = "");
	}
}

/*<Codenesium>
    <Hash>9076d836e95267a8588441f2af4a2e9c</Hash>
</Codenesium>*/