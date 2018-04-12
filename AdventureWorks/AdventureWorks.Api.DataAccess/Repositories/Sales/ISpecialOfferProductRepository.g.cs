using System;
using System.Linq.Expressions;
using System.Collections.Generic;
using AdventureWorksNS.Api.Contracts;

namespace AdventureWorksNS.Api.DataAccess
{
	public interface ISpecialOfferProductRepository
	{
		int Create(
			int productID,
			Guid rowguid,
			DateTime modifiedDate);

		void Update(int specialOfferID,
		            int productID,
		            Guid rowguid,
		            DateTime modifiedDate);

		void Delete(int specialOfferID);

		Response GetById(int specialOfferID);

		POCOSpecialOfferProduct GetByIdDirect(int specialOfferID);

		Response GetWhere(Expression<Func<EFSpecialOfferProduct, bool>> predicate, int skip = 0, int take = int.MaxValue, string orderClause = "");

		List<POCOSpecialOfferProduct> GetWhereDirect(Expression<Func<EFSpecialOfferProduct, bool>> predicate, int skip = 0, int take = int.MaxValue, string orderClause = "");

		Response GetWhereDynamic(string predicate, int skip = 0, int take = int.MaxValue, string orderClause = "");
	}
}

/*<Codenesium>
    <Hash>f78cfd55a7e80e48c0a75d9aa6aae7a7</Hash>
</Codenesium>*/