using System;
using System.Linq.Expressions;
using System.Collections.Generic;
using System.Threading.Tasks;
using AdventureWorksNS.Api.Contracts;

namespace AdventureWorksNS.Api.DataAccess
{
	public interface ISpecialOfferProductRepository
	{
		Task<DTOSpecialOfferProduct> Create(DTOSpecialOfferProduct dto);

		Task Update(int specialOfferID,
		            DTOSpecialOfferProduct dto);

		Task Delete(int specialOfferID);

		Task<DTOSpecialOfferProduct> Get(int specialOfferID);

		Task<List<DTOSpecialOfferProduct>> All(int skip = 0, int take = int.MaxValue, string orderClause = "");

		Task<List<DTOSpecialOfferProduct>> GetProductID(int productID);
	}
}

/*<Codenesium>
    <Hash>1f527092d81af465e3785104085422d6</Hash>
</Codenesium>*/