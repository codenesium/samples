using System;
using System.Linq.Expressions;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace AdventureWorksNS.Api.DataAccess
{
	public interface IVendorRepository
	{
		Task<Vendor> Create(Vendor item);

		Task Update(Vendor item);

		Task Delete(int businessEntityID);

		Task<Vendor> Get(int businessEntityID);

		Task<List<Vendor>> All(int skip = 0, int take = int.MaxValue, string orderClause = "");

		Task<Vendor> GetAccountNumber(string accountNumber);
	}
}

/*<Codenesium>
    <Hash>627f226648bfda16d4fbb96a6ea8277b</Hash>
</Codenesium>*/