using System;
using System.Linq.Expressions;
using System.Collections.Generic;
using PetShippingNS.Api.Contracts;

namespace PetShippingNS.Api.DataAccess
{
	public interface IPipelineRepository
	{
		POCOPipeline Create(ApiPipelineModel model);

		void Update(int id,
		            ApiPipelineModel model);

		void Delete(int id);

		POCOPipeline Get(int id);

		List<POCOPipeline> All(int skip = 0, int take = int.MaxValue, string orderClause = "");
	}
}

/*<Codenesium>
    <Hash>226f4b0e2c800e70b2c9aac60cd03068</Hash>
</Codenesium>*/