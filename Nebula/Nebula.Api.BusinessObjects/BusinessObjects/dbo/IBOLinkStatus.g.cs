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

		POCOLinkStatus Get(int id);

		List<POCOLinkStatus> All(int skip = 0, int take = int.MaxValue, string orderClause = "");

		POCOLinkStatus Name(string name);
	}
}

/*<Codenesium>
    <Hash>90faeed323a49bb2ea6da7c76050163c</Hash>
</Codenesium>*/