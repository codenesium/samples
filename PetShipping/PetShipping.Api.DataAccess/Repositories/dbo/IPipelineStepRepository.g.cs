using System;
using System.Linq.Expressions;
using System.Collections.Generic;
using PetShippingNS.Api.Contracts;

namespace PetShippingNS.Api.DataAccess
{
	public interface IPipelineStepRepository
	{
		POCOPipelineStep Create(ApiPipelineStepModel model);

		void Update(int id,
		            ApiPipelineStepModel model);

		void Delete(int id);

		POCOPipelineStep Get(int id);

		List<POCOPipelineStep> All(int skip = 0, int take = int.MaxValue, string orderClause = "");
	}
}

/*<Codenesium>
    <Hash>16bd1a0e5c546a89367ae563dbd270e7</Hash>
</Codenesium>*/