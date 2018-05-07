using System;
using System.Linq.Expressions;
using System.Collections.Generic;
using PetShippingNS.Api.Contracts;

namespace PetShippingNS.Api.DataAccess
{
	public interface IPipelineStatusRepository
	{
		int Create(PipelineStatusModel model);

		void Update(int id,
		            PipelineStatusModel model);

		void Delete(int id);

		POCOPipelineStatus Get(int id);

		List<POCOPipelineStatus> All(int skip = 0, int take = int.MaxValue, string orderClause = "");
	}
}

/*<Codenesium>
    <Hash>66827ee429bc7a684ecfc24d655bf411</Hash>
</Codenesium>*/