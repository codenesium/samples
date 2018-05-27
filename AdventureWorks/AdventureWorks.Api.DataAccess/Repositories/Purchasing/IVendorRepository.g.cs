using System;
using System.Linq.Expressions;
using System.Collections.Generic;
using System.Threading.Tasks;
using AdventureWorksNS.Api.Contracts;

namespace AdventureWorksNS.Api.DataAccess
{
	public interface IVendorRepository
	{
		Task<DTOVendor> Create(DTOVendor dto);

		Task Update(int businessEntityID,
		            DTOVendor dto);

		Task Delete(int businessEntityID);

		Task<DTOVendor> Get(int businessEntityID);

		Task<List<DTOVendor>> All(int skip = 0, int take = int.MaxValue, string orderClause = "");

		Task<DTOVendor> GetAccountNumber(string accountNumber);
	}
}

/*<Codenesium>
    <Hash>6130541698acb5552e62793119ea258e</Hash>
</Codenesium>*/