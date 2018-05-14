using System;
using System.Linq.Expressions;
using System.Collections.Generic;
using PetShippingNS.Api.Contracts;

namespace PetShippingNS.Api.DataAccess
{
	public interface IPipelineStatusRepository
	{
		POCOPipelineStatus Create(PipelineStatusModel model);

		void Update(int id,
		            PipelineStatusModel model);

		void Delete(int id);

		POCOPipelineStatus Get(int id);

		List<POCOPipelineStatus> All(int skip = 0, int take = int.MaxValue, string orderClause = "");
	}
}

/*<Codenesium>
    <Hash>2209a3be16ff14ae340f36055d1787c7</Hash>
</Codenesium>*/