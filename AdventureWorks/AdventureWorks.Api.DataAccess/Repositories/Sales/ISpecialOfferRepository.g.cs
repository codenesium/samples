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

		Task<List<SpecialOfferProduct>> SpecialOfferProducts(int specialOfferID, int limit = int.MaxValue, int offset = 0);
	}
}

/*<Codenesium>
    <Hash>dee90ee94c28313a321e009e96b185b1</Hash>
</Codenesium>*/