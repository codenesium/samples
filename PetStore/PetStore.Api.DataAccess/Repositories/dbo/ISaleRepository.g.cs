using System;
using System.Linq.Expressions;
using System.Collections.Generic;
using PetStoreNS.Api.Contracts;

namespace PetStoreNS.Api.DataAccess
{
	public interface ISaleRepository
	{
		int Create(SaleModel model);

		void Update(int id,
		            SaleModel model);

		void Delete(int id);

		ApiResponse GetById(int id);

		POCOSale GetByIdDirect(int id);

		ApiResponse GetWhere(Expression<Func<EFSale, bool>> predicate, int skip = 0, int take = int.MaxValue, string orderClause = "");

		List<POCOSale> GetWhereDirect(Expression<Func<EFSale, bool>> predicate, int skip = 0, int take = int.MaxValue, string orderClause = "");

		ApiResponse GetWhereDynamic(string predicate, int skip = 0, int take = int.MaxValue, string orderClause = "");
	}
}

/*<Codenesium>
    <Hash>e6e6ab05571dfb99b328ece416dcf1f6</Hash>
</Codenesium>*/