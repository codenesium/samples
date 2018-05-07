using System;
using System.Linq.Expressions;
using System.Collections.Generic;
using PetShippingNS.Api.Contracts;

namespace PetShippingNS.Api.DataAccess
{
	public interface IPipelineStepRepository
	{
		int Create(PipelineStepModel model);

		void Update(int id,
		            PipelineStepModel model);

		void Delete(int id);

		POCOPipelineStep Get(int id);

		List<POCOPipelineStep> All(int skip = 0, int take = int.MaxValue, string orderClause = "");
	}
}

/*<Codenesium>
    <Hash>e2c0143fa2e35f51e6d4eb87d62fca52</Hash>
</Codenesium>*/