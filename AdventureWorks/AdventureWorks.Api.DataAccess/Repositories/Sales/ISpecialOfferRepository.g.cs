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

		POCOSpecialOffer Get(int specialOfferID);

		List<POCOSpecialOffer> All(int skip = 0, int take = int.MaxValue, string orderClause = "");
	}
}

/*<Codenesium>
    <Hash>7806ac00053dcf946d0e751c743a6c92</Hash>
</Codenesium>*/