using System;
using System.Linq.Expressions;
using System.Collections.Generic;
using PetShippingNS.Api.Contracts;

namespace PetShippingNS.Api.DataAccess
{
	public interface IPipelineStepStatusRepository
	{
		POCOPipelineStepStatus Create(PipelineStepStatusModel model);

		void Update(int id,
		            PipelineStepStatusModel model);

		void Delete(int id);

		POCOPipelineStepStatus Get(int id);

		List<POCOPipelineStepStatus> All(int skip = 0, int take = int.MaxValue, string orderClause = "");
	}
}

/*<Codenesium>
    <Hash>67c41919d3d8418b4a158ce7a0a5836b</Hash>
</Codenesium>*/