using System;
using System.Linq.Expressions;
using System.Collections.Generic;
using System.Threading.Tasks;
using NebulaNS.Api.Contracts;
using NebulaNS.Api.DataAccess;

namespace NebulaNS.Api.BusinessObjects
{
	public interface IBOLinkStatus
	{
		Task<CreateResponse<POCOLinkStatus>> Create(
			ApiLinkStatusModel model);

		Task<ActionResponse> Update(int id,
		                            ApiLinkStatusModel model);

		Task<ActionResponse> Delete(int id);

		Task<POCOLinkStatus> Get(int id);

		Task<List<POCOLinkStatus>> All(int skip = 0, int take = int.MaxValue, string orderClause = "");

		Task<POCOLinkStatus> Name(string name);
	}
}

/*<Codenesium>
    <Hash>b173ba37639755a3a57db5f72f6c0ebe</Hash>
</Codenesium>*/