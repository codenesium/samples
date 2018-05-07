using System;
using System.Linq.Expressions;
using System.Collections.Generic;
using System.Threading.Tasks;
using AdventureWorksNS.Api.Contracts;
using AdventureWorksNS.Api.DataAccess;

namespace AdventureWorksNS.Api.BusinessObjects
{
	public interface IBOCustomer
	{
		Task<CreateResponse<int>> Create(
			CustomerModel model);

		Task<ActionResponse> Update(int customerID,
		                            CustomerModel model);

		Task<ActionResponse> Delete(int customerID);

		POCOCustomer Get(int customerID);

		List<POCOCustomer> All(int skip = 0, int take = int.MaxValue, string orderClause = "");
	}
}

/*<Codenesium>
    <Hash>228c7a253df68ab5a7b8f762e2cbd1f2</Hash>
</Codenesium>*/