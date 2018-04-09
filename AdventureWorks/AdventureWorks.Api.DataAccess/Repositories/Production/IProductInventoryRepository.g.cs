using System;
using System.Linq.Expressions;
using System.Collections.Generic;
using AdventureWorksNS.Api.Contracts;

namespace AdventureWorksNS.Api.DataAccess
{
	public interface IProductInventoryRepository
	{
		int Create(short locationID,
		           string shelf,
		           int bin,
		           short quantity,
		           Guid rowguid,
		           DateTime modifiedDate);

		void Update(int productID, short locationID,
		            string shelf,
		            int bin,
		            short quantity,
		            Guid rowguid,
		            DateTime modifiedDate);

		void Delete(int productID);

		Response GetById(int productID);

		POCOProductInventory GetByIdDirect(int productID);

		Response GetWhere(Expression<Func<EFProductInventory, bool>> predicate, int skip = 0, int take = Int32.MaxValue, string orderClause = "");

		List<POCOProductInventory> GetWhereDirect(Expression<Func<EFProductInventory, bool>> predicate, int skip = 0, int take = Int32.MaxValue, string orderClause = "");

		Response GetWhereDynamic(string predicate, int skip = 0, int take = Int32.MaxValue, string orderClause = "");
	}
}

/*<Codenesium>
    <Hash>acff983dcfc5defbcec448bba179bd98</Hash>
</Codenesium>*/