using System;
using System.Linq.Expressions;
using System.Collections.Generic;
using PetShippingNS.Api.Contracts;

namespace PetShippingNS.Api.DataAccess
{
	public interface IPipelineStepStatusRepository
	{
		int Create(PipelineStepStatusModel model);

		void Update(int id,
		            PipelineStepStatusModel model);

		void Delete(int id);

		POCOPipelineStepStatus Get(int id);

		List<POCOPipelineStepStatus> All(int skip = 0, int take = int.MaxValue, string orderClause = "");
	}
}

/*<Codenesium>
    <Hash>df087fefb3bdae94e81d84f571ac319f</Hash>
</Codenesium>*/