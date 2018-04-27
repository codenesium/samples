using System;
using System.Linq.Expressions;
using System.Collections.Generic;
using PetShippingNS.Api.Contracts;

namespace PetShippingNS.Api.DataAccess
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
    <Hash>29a7405d59fc9ecbaee2850420a62a5d</Hash>
</Codenesium>*/