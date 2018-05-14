using System;
using System.Linq.Expressions;
using System.Collections.Generic;
using PetShippingNS.Api.Contracts;

namespace PetShippingNS.Api.DataAccess
{
	public interface ISaleRepository
	{
		POCOSale Create(SaleModel model);

		void Update(int id,
		            SaleModel model);

		void Delete(int id);

		POCOSale Get(int id);

		List<POCOSale> All(int skip = 0, int take = int.MaxValue, string orderClause = "");
	}
}

/*<Codenesium>
    <Hash>078a0353c4b65dda96f3e125f49b197d</Hash>
</Codenesium>*/