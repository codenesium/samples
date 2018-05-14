using System;
using System.Linq.Expressions;
using System.Collections.Generic;
using PetShippingNS.Api.Contracts;

namespace PetShippingNS.Api.DataAccess
{
	public interface IPipelineStepStatusRepository
	{
		POCOPipelineStepStatus Create(ApiPipelineStepStatusModel model);

		void Update(int id,
		            ApiPipelineStepStatusModel model);

		void Delete(int id);

		POCOPipelineStepStatus Get(int id);

		List<POCOPipelineStepStatus> All(int skip = 0, int take = int.MaxValue, string orderClause = "");
	}
}

/*<Codenesium>
    <Hash>d142bd45bee0c7712ca85b011229e11c</Hash>
</Codenesium>*/