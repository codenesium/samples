using System;
using System.Linq.Expressions;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace AdventureWorksNS.Api.DataAccess
{
	public interface ISpecialOfferRepository
	{
		Task<SpecialOffer> Create(SpecialOffer item);

		Task Update(SpecialOffer item);

		Task Delete(int specialOfferID);

		Task<SpecialOffer> Get(int specialOfferID);

		Task<List<SpecialOffer>> All(int skip = 0, int take = int.MaxValue, string orderClause = "");
	}
}

/*<Codenesium>
    <Hash>b30850d46a66ab4a1b3e100f453e9f8a</Hash>
</Codenesium>*/