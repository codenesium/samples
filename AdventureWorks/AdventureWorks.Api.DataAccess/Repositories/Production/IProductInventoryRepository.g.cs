using System;
using System.Linq.Expressions;
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

		void GetById(int productID, Response response);

		void GetWhere(Expression<Func<EFProductInventory, bool>> predicate, Response response,int skip = 0, int take = Int32.MaxValue, string orderClause = "");

		void GetWhereDynamic(string predicate, Response response,int skip = 0, int take = Int32.MaxValue, string orderClause = "");
	}
}

/*<Codenesium>
    <Hash>997612a4bb41a58aa4e2eb27dc1d1e1e</Hash>
</Codenesium>*/