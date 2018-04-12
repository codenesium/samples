using System;
using System.Linq.Expressions;
using System.Collections.Generic;
using AdventureWorksNS.Api.Contracts;

namespace AdventureWorksNS.Api.DataAccess
{
	public interface ISpecialOfferRepository
	{
		int Create(
			string description,
			decimal discountPct,
			string type,
			string category,
			DateTime startDate,
			DateTime endDate,
			int minQty,
			Nullable<int> maxQty,
			Guid rowguid,
			DateTime modifiedDate);

		void Update(int specialOfferID,
		            string description,
		            decimal discountPct,
		            string type,
		            string category,
		            DateTime startDate,
		            DateTime endDate,
		            int minQty,
		            Nullable<int> maxQty,
		            Guid rowguid,
		            DateTime modifiedDate);

		void Delete(int specialOfferID);

		Response GetById(int specialOfferID);

		POCOSpecialOffer GetByIdDirect(int specialOfferID);

		Response GetWhere(Expression<Func<EFSpecialOffer, bool>> predicate, int skip = 0, int take = int.MaxValue, string orderClause = "");

		List<POCOSpecialOffer> GetWhereDirect(Expression<Func<EFSpecialOffer, bool>> predicate, int skip = 0, int take = int.MaxValue, string orderClause = "");

		Response GetWhereDynamic(string predicate, int skip = 0, int take = int.MaxValue, string orderClause = "");
	}
}

/*<Codenesium>
    <Hash>572badce232f5297d82ae9a557a797df</Hash>
</Codenesium>*/