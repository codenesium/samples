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

		Task<POCOLinkStatus> GetName(string name);
	}
}

/*<Codenesium>
    <Hash>cd3c19edc9cc42b09f732899a1c7fe2a</Hash>
</Codenesium>*/