using System;
using System.Linq.Expressions;
using System.Collections.Generic;
using System.Threading.Tasks;
using AdventureWorksNS.Api.Contracts;

namespace AdventureWorksNS.Api.DataAccess
{
	public interface ISpecialOfferRepository
	{
		Task<POCOSpecialOffer> Create(ApiSpecialOfferModel model);

		Task Update(int specialOfferID,
		            ApiSpecialOfferModel model);

		Task Delete(int specialOfferID);

		Task<POCOSpecialOffer> Get(int specialOfferID);

		Task<List<POCOSpecialOffer>> All(int skip = 0, int take = int.MaxValue, string orderClause = "");
	}
}

/*<Codenesium>
    <Hash>a7a6370c767999f67714f7c3883b812a</Hash>
</Codenesium>*/