using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using System.Threading.Tasks;

namespace AdventureWorksNS.Api.DataAccess
{
	public partial interface ISpecialOfferRepository
	{
		Task<SpecialOffer> Create(SpecialOffer item);

		Task Update(SpecialOffer item);

		Task Delete(int specialOfferID);

		Task<SpecialOffer> Get(int specialOfferID);

		Task<List<SpecialOffer>> All(int limit = int.MaxValue, int offset = 0);
	}
}

/*<Codenesium>
    <Hash>c065fc6010d3c37b6788eeafbe8ccbfb</Hash>
</Codenesium>*/