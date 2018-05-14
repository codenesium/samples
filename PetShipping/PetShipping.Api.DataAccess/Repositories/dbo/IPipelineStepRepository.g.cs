using System;
using System.Linq.Expressions;
using System.Collections.Generic;
using PetShippingNS.Api.Contracts;

namespace PetShippingNS.Api.DataAccess
{
	public interface IPipelineStepRepository
	{
		POCOPipelineStep Create(PipelineStepModel model);

		void Update(int id,
		            PipelineStepModel model);

		void Delete(int id);

		POCOPipelineStep Get(int id);

		List<POCOPipelineStep> All(int skip = 0, int take = int.MaxValue, string orderClause = "");
	}
}

/*<Codenesium>
    <Hash>8d51cc9e2a6b43e17130fa6af7f89cad</Hash>
</Codenesium>*/