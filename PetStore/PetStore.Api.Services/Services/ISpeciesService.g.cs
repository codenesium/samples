using System;
using System.Linq.Expressions;
using System.Collections.Generic;
using System.Threading.Tasks;
using PetStoreNS.Api.Contracts;
using PetStoreNS.Api.DataAccess;

namespace PetStoreNS.Api.Services
{
	public interface ISpeciesService
	{
		Task<CreateResponse<ApiSpeciesResponseModel>> Create(
			ApiSpeciesRequestModel model);

		Task<ActionResponse> Update(int id,
		                            ApiSpeciesRequestModel model);

		Task<ActionResponse> Delete(int id);

		Task<ApiSpeciesResponseModel> Get(int id);

		Task<List<ApiSpeciesResponseModel>> All(int skip = 0, int take = int.MaxValue, string orderClause = "");
	}
}

/*<Codenesium>
    <Hash>60223a848b470631ec658f1c3c9a34db</Hash>
</Codenesium>*/