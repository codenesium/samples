using System;
using System.Linq.Expressions;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace AdventureWorksNS.Api.DataAccess
{
	public interface ISpecialOfferProductRepository
	{
		Task<SpecialOfferProduct> Create(SpecialOfferProduct item);

		Task Update(SpecialOfferProduct item);

		Task Delete(int specialOfferID);

		Task<SpecialOfferProduct> Get(int specialOfferID);

		Task<List<SpecialOfferProduct>> All(int skip = 0, int take = int.MaxValue, string orderClause = "");

		Task<List<SpecialOfferProduct>> GetProductID(int productID);
	}
}

/*<Codenesium>
    <Hash>ffc42dbd59f16406352970d7d938fa4a</Hash>
</Codenesium>*/