using System;
using System.Linq.Expressions;
using System.Collections.Generic;
using PetShippingNS.Api.Contracts;

namespace PetShippingNS.Api.DataAccess
{
	public interface ISaleRepository
	{
		POCOSale Create(ApiSaleModel model);

		void Update(int id,
		            ApiSaleModel model);

		void Delete(int id);

		POCOSale Get(int id);

		List<POCOSale> All(int skip = 0, int take = int.MaxValue, string orderClause = "");
	}
}

/*<Codenesium>
    <Hash>69c32b74f470ed7b3a86057ec05e1397</Hash>
</Codenesium>*/