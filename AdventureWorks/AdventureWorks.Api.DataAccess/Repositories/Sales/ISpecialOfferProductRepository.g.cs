using System;
using System.Linq.Expressions;
using System.Collections.Generic;
using System.Threading.Tasks;
using AdventureWorksNS.Api.Contracts;

namespace AdventureWorksNS.Api.DataAccess
{
	public interface ISpecialOfferProductRepository
	{
		Task<POCOSpecialOfferProduct> Create(ApiSpecialOfferProductModel model);

		Task Update(int specialOfferID,
		            ApiSpecialOfferProductModel model);

		Task Delete(int specialOfferID);

		Task<POCOSpecialOfferProduct> Get(int specialOfferID);

		Task<List<POCOSpecialOfferProduct>> All(int skip = 0, int take = int.MaxValue, string orderClause = "");

		Task<List<POCOSpecialOfferProduct>> GetProductID(int productID);
	}
}

/*<Codenesium>
    <Hash>577fe91285c741149ee6ab9c65435986</Hash>
</Codenesium>*/