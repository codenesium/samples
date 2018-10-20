using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using System.Threading.Tasks;

namespace AdventureWorksNS.Api.DataAccess
{
	public partial interface ISpecialOfferProductRepository
	{
		Task<SpecialOfferProduct> Create(SpecialOfferProduct item);

		Task Update(SpecialOfferProduct item);

		Task Delete(int specialOfferID);

		Task<SpecialOfferProduct> Get(int specialOfferID);

		Task<List<SpecialOfferProduct>> All(int limit = int.MaxValue, int offset = 0);
	}
}

/*<Codenesium>
    <Hash>f689e687260c316134f74bc480741030</Hash>
</Codenesium>*/