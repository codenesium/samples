using System;
using System.Linq.Expressions;
using AdventureWorksNS.Api.Contracts;

namespace AdventureWorksNS.Api.DataAccess
{
	public interface ISpecialOfferRepository
	{
		int Create(string description,
		           decimal discountPct,
		           string type,
		           string category,
		           DateTime startDate,
		           DateTime endDate,
		           int minQty,
		           Nullable<int> maxQty,
		           Guid rowguid,
		           DateTime modifiedDate);

		void Update(int specialOfferID, string description,
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

		void GetById(int specialOfferID, Response response);

		void GetWhere(Expression<Func<EFSpecialOffer, bool>> predicate, Response response,int skip = 0, int take = Int32.MaxValue, string orderClause = "");

		void GetWhereDynamic(string predicate, Response response,int skip = 0, int take = Int32.MaxValue, string orderClause = "");
	}
}

/*<Codenesium>
    <Hash>54896d84d1e848fbadbecf92cef282e2</Hash>
</Codenesium>*/