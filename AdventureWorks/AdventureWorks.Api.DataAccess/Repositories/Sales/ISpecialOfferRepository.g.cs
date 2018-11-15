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

		Task<SpecialOffer> ByRowguid(Guid rowguid);
	}
}

/*<Codenesium>
    <Hash>64076999f865b24156ec9be2a7892d52</Hash>
</Codenesium>*/