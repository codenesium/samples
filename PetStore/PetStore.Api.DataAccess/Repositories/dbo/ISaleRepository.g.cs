using System;
using System.Linq.Expressions;
using System.Collections.Generic;
using PetStoreNS.Api.Contracts;

namespace PetStoreNS.Api.DataAccess
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
    <Hash>9e17be0bbaf79ce427db38e084cbbbc4</Hash>
</Codenesium>*/