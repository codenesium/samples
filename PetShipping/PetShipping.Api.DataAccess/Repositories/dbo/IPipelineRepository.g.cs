using System;
using System.Linq.Expressions;
using System.Collections.Generic;
using PetShippingNS.Api.Contracts;

namespace PetShippingNS.Api.DataAccess
{
	public interface IPipelineRepository
	{
		int Create(PipelineModel model);

		void Update(int id,
		            PipelineModel model);

		void Delete(int id);

		POCOPipeline Get(int id);

		List<POCOPipeline> All(int skip = 0, int take = int.MaxValue, string orderClause = "");
	}
}

/*<Codenesium>
    <Hash>c46b8b190cde838a21ebf66e7cc778fa</Hash>
</Codenesium>*/