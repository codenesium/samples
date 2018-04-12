using System;
using System.Linq.Expressions;
using System.Collections.Generic;
using AdventureWorksNS.Api.Contracts;

namespace AdventureWorksNS.Api.DataAccess
{
	public interface IProductInventoryRepository
	{
		int Create(
			short locationID,
			string shelf,
			int bin,
			short quantity,
			Guid rowguid,
			DateTime modifiedDate);

		void Update(int productID,
		            short locationID,
		            string shelf,
		            int bin,
		            short quantity,
		            Guid rowguid,
		            DateTime modifiedDate);

		void Delete(int productID);

		Response GetById(int productID);

		POCOProductInventory GetByIdDirect(int productID);

		Response GetWhere(Expression<Func<EFProductInventory, bool>> predicate, int skip = 0, int take = int.MaxValue, string orderClause = "");

		List<POCOProductInventory> GetWhereDirect(Expression<Func<EFProductInventory, bool>> predicate, int skip = 0, int take = int.MaxValue, string orderClause = "");

		Response GetWhereDynamic(string predicate, int skip = 0, int take = int.MaxValue, string orderClause = "");
	}
}

/*<Codenesium>
    <Hash>a0c08da2a8bffa7ee0ef24aaede7be6d</Hash>
</Codenesium>*/