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
			ApiPipelineStatusModel model);

		Task<ActionResponse> Update(int id,
		                            ApiPipelineStatusModel model);

		Task<ActionResponse> Delete(int id);

		POCOPipelineStatus Get(int id);

		List<POCOPipelineStatus> All(int skip = 0, int take = int.MaxValue, string orderClause = "");
	}
}

/*<Codenesium>
    <Hash>9e89ebc23b7a87a278979d4ada1c43aa</Hash>
</Codenesium>*/