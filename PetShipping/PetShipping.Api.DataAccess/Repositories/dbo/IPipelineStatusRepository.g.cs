using System;
using System.Linq.Expressions;
using System.Collections.Generic;
using PetShippingNS.Api.Contracts;

namespace PetShippingNS.Api.DataAccess
{
	public interface IPipelineStatusRepository
	{
		POCOPipelineStatus Create(ApiPipelineStatusModel model);

		void Update(int id,
		            ApiPipelineStatusModel model);

		void Delete(int id);

		POCOPipelineStatus Get(int id);

		List<POCOPipelineStatus> All(int skip = 0, int take = int.MaxValue, string orderClause = "");
	}
}

/*<Codenesium>
    <Hash>f92a8740d5c628bf6191ea9248f9a054</Hash>
</Codenesium>*/