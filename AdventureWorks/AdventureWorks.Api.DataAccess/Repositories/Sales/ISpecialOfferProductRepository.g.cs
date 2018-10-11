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

		Task<List<SpecialOfferProduct>> ByProductID(int productID, int limit = int.MaxValue, int offset = 0);

		Task<List<SalesOrderDetail>> SalesOrderDetails(int specialOfferID, int limit = int.MaxValue, int offset = 0);

		Task<SpecialOffer> SpecialOfferBySpecialOfferID(int specialOfferID);
	}
}

/*<Codenesium>
    <Hash>e116d2706610038c9e2ceaef46fc153a</Hash>
</Codenesium>*/