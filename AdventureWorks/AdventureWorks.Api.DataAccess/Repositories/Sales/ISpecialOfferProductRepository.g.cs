using System;
using System.Linq.Expressions;
using System.Collections.Generic;
using AdventureWorksNS.Api.Contracts;

namespace AdventureWorksNS.Api.DataAccess
{
	public interface ISpecialOfferProductRepository
	{
		int Create(SpecialOfferProductModel model);

		void Update(int specialOfferID,
		            SpecialOfferProductModel model);

		void Delete(int specialOfferID);

		ApiResponse GetById(int specialOfferID);

		POCOSpecialOfferProduct GetByIdDirect(int specialOfferID);

		ApiResponse GetWhere(Expression<Func<EFSpecialOfferProduct, bool>> predicate, int skip = 0, int take = int.MaxValue, string orderClause = "");

		List<POCOSpecialOfferProduct> GetWhereDirect(Expression<Func<EFSpecialOfferProduct, bool>> predicate, int skip = 0, int take = int.MaxValue, string orderClause = "");

		ApiResponse GetWhereDynamic(string predicate, int skip = 0, int take = int.MaxValue, string orderClause = "");
	}
}

/*<Codenesium>
    <Hash>fd51bf3a54c0c1705de8c59cbfa2fb52</Hash>
</Codenesium>*/