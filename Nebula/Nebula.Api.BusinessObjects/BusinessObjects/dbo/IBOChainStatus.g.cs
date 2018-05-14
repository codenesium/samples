using System;
using System.Linq.Expressions;
using System.Collections.Generic;
using System.Threading.Tasks;
using NebulaNS.Api.Contracts;
using NebulaNS.Api.DataAccess;

namespace NebulaNS.Api.BusinessObjects
{
	public interface IBOChainStatus
	{
		Task<CreateResponse<POCOChainStatus>> Create(
			ApiChainStatusModel model);

		Task<ActionResponse> Update(int id,
		                            ApiChainStatusModel model);

		Task<ActionResponse> Delete(int id);

		POCOChainStatus Get(int id);

		List<POCOChainStatus> All(int skip = 0, int take = int.MaxValue, string orderClause = "");

		POCOChainStatus Name(string name);
	}
}

/*<Codenesium>
    <Hash>9a7811407ec27a0879101192982f27ed</Hash>
</Codenesium>*/