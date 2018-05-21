using System;
using System.Linq.Expressions;
using System.Collections.Generic;
using System.Threading.Tasks;
using PetShippingNS.Api.Contracts;

namespace PetShippingNS.Api.DataAccess
{
	public interface IPipelineStatusRepository
	{
		Task<POCOPipelineStatus> Create(ApiPipelineStatusModel model);

		Task Update(int id,
		            ApiPipelineStatusModel model);

		Task Delete(int id);

		Task<POCOPipelineStatus> Get(int id);

		Task<List<POCOPipelineStatus>> All(int skip = 0, int take = int.MaxValue, string orderClause = "");
	}
}

/*<Codenesium>
    <Hash>a70ea761e6f1612849eed96174967648</Hash>
</Codenesium>*/