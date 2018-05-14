using System;
using System.Linq.Expressions;
using System.Collections.Generic;
using PetStoreNS.Api.Contracts;

namespace PetStoreNS.Api.DataAccess
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
    <Hash>3e5e1d930c799c1a8b87b7179e8f937a</Hash>
</Codenesium>*/