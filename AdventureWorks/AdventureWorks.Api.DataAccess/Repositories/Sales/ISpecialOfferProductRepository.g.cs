using System;
using System.Linq.Expressions;
using System.Collections.Generic;
using AdventureWorksNS.Api.Contracts;

namespace AdventureWorksNS.Api.DataAccess
{
	public interface ISpecialOfferProductRepository
	{
		POCOSpecialOfferProduct Create(ApiSpecialOfferProductModel model);

		void Update(int specialOfferID,
		            ApiSpecialOfferProductModel model);

		void Delete(int specialOfferID);

		POCOSpecialOfferProduct Get(int specialOfferID);

		List<POCOSpecialOfferProduct> All(int skip = 0, int take = int.MaxValue, string orderClause = "");

		List<POCOSpecialOfferProduct> GetProductID(int productID);
	}
}

/*<Codenesium>
    <Hash>b33931b6225e26fc5f4f43028ca86b01</Hash>
</Codenesium>*/