using System;
using System.Linq.Expressions;
using System.Collections.Generic;
using System.Threading.Tasks;
using AdventureWorksNS.Api.Contracts;
using AdventureWorksNS.Api.DataAccess;

namespace AdventureWorksNS.Api.BusinessObjects
{
	public interface IBOAddress
	{
		Task<CreateResponse<int>> Create(
			AddressModel model);

		Task<ActionResponse> Update(int addressID,
		                            AddressModel model);

		Task<ActionResponse> Delete(int addressID);

		POCOAddress Get(int addressID);

		List<POCOAddress> All(int skip = 0, int take = int.MaxValue, string orderClause = "");
	}
}

/*<Codenesium>
    <Hash>a115cd7bf469daaded90649b5f1ca5c4</Hash>
</Codenesium>*/