using System;
using System.Linq.Expressions;
using System.Collections.Generic;
using AdventureWorksNS.Api.Contracts;

namespace AdventureWorksNS.Api.DataAccess
{
	public interface ISpecialOfferProductRepository
	{
		int Create(int productID,
		           Guid rowguid,
		           DateTime modifiedDate);

		void Update(int specialOfferID, int productID,
		            Guid rowguid,
		            DateTime modifiedDate);

		void Delete(int specialOfferID);

		Response GetById(int specialOfferID);

		POCOSpecialOfferProduct GetByIdDirect(int specialOfferID);

		Response GetWhere(Expression<Func<EFSpecialOfferProduct, bool>> predicate, int skip = 0, int take = Int32.MaxValue, string orderClause = "");

		List<POCOSpecialOfferProduct> GetWhereDirect(Expression<Func<EFSpecialOfferProduct, bool>> predicate, int skip = 0, int take = Int32.MaxValue, string orderClause = "");

		Response GetWhereDynamic(string predicate, int skip = 0, int take = Int32.MaxValue, string orderClause = "");
	}
}

/*<Codenesium>
    <Hash>4f65a913dcff00de768372fc0cff0acf</Hash>
</Codenesium>*/