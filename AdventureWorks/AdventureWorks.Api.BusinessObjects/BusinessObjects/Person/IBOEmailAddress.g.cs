using System;
using System.Linq.Expressions;
using System.Collections.Generic;
using System.Threading.Tasks;
using AdventureWorksNS.Api.Contracts;
using AdventureWorksNS.Api.DataAccess;

namespace AdventureWorksNS.Api.BusinessObjects
{
	public interface IBOEmailAddress
	{
		Task<CreateResponse<int>> Create(
			EmailAddressModel model);

		Task<ActionResponse> Update(int businessEntityID,
		                            EmailAddressModel model);

		Task<ActionResponse> Delete(int businessEntityID);

		POCOEmailAddress Get(int businessEntityID);

		List<POCOEmailAddress> All(int skip = 0, int take = int.MaxValue, string orderClause = "");
	}
}

/*<Codenesium>
    <Hash>c0881ddf9a29d964326c03745a0f09ca</Hash>
</Codenesium>*/