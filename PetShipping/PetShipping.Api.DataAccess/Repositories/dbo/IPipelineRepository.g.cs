using System;
using System.Linq.Expressions;
using System.Collections.Generic;
using PetShippingNS.Api.Contracts;

namespace PetShippingNS.Api.DataAccess
{
	public interface IPipelineRepository
	{
		POCOPipeline Create(PipelineModel model);

		void Update(int id,
		            PipelineModel model);

		void Delete(int id);

		POCOPipeline Get(int id);

		List<POCOPipeline> All(int skip = 0, int take = int.MaxValue, string orderClause = "");
	}
}

/*<Codenesium>
    <Hash>242fbb99fe6c63facb57060f32ed638c</Hash>
</Codenesium>*/