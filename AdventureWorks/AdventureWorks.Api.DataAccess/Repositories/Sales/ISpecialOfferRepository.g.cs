using System;
using System.Linq.Expressions;
using System.Collections.Generic;
using AdventureWorksNS.Api.Contracts;

namespace AdventureWorksNS.Api.DataAccess
{
	public interface ISpecialOfferRepository
	{
		POCOSpecialOffer Create(ApiSpecialOfferModel model);

		void Update(int specialOfferID,
		            ApiSpecialOfferModel model);

		void Delete(int specialOfferID);

		POCOSpecialOffer Get(int specialOfferID);

		List<POCOSpecialOffer> All(int skip = 0, int take = int.MaxValue, string orderClause = "");
	}
}

/*<Codenesium>
    <Hash>cbbe9e15b1a885bb7ba468aba729e3ce</Hash>
</Codenesium>*/