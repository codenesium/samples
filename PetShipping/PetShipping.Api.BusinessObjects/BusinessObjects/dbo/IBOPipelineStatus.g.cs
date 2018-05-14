using System;
using System.Linq.Expressions;
using System.Collections.Generic;
using System.Threading.Tasks;
using PetShippingNS.Api.Contracts;
using PetShippingNS.Api.DataAccess;

namespace PetShippingNS.Api.BusinessObjects
{
	public interface IBOPipelineStatus
	{
		Task<CreateResponse<POCOPipelineStatus>> Create(
			PipelineStatusModel model);

		Task<ActionResponse> Update(int id,
		                            PipelineStatusModel model);

		Task<ActionResponse> Delete(int id);

		POCOPipelineStatus Get(int id);

		List<POCOPipelineStatus> All(int skip = 0, int take = int.MaxValue, string orderClause = "");
	}
}

/*<Codenesium>
    <Hash>0cc1ee75be61526f97e793a3234967ab</Hash>
</Codenesium>*/