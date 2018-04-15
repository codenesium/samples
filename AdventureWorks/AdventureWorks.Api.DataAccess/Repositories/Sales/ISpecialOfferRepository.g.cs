using System;
using System.Linq.Expressions;
using System.Collections.Generic;
using AdventureWorksNS.Api.Contracts;

namespace AdventureWorksNS.Api.DataAccess
{
	public interface ISpecialOfferRepository
	{
		int Create(SpecialOfferModel model);

		void Update(int specialOfferID,
		            SpecialOfferModel model);

		void Delete(int specialOfferID);

		ApiResponse GetById(int specialOfferID);

		POCOSpecialOffer GetByIdDirect(int specialOfferID);

		ApiResponse GetWhere(Expression<Func<EFSpecialOffer, bool>> predicate, int skip = 0, int take = int.MaxValue, string orderClause = "");

		List<POCOSpecialOffer> GetWhereDirect(Expression<Func<EFSpecialOffer, bool>> predicate, int skip = 0, int take = int.MaxValue, string orderClause = "");

		ApiResponse GetWhereDynamic(string predicate, int skip = 0, int take = int.MaxValue, string orderClause = "");
	}
}

/*<Codenesium>
    <Hash>f5c04d3d4a589a56438d502779cfef15</Hash>
</Codenesium>*/