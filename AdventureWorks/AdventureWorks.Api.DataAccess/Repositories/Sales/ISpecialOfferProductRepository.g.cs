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

		POCOSpecialOfferProduct Get(int specialOfferID);

		List<POCOSpecialOfferProduct> All(int skip = 0, int take = int.MaxValue, string orderClause = "");
	}
}

/*<Codenesium>
    <Hash>7f9982d650069001443271253563c6dd</Hash>
</Codenesium>*/