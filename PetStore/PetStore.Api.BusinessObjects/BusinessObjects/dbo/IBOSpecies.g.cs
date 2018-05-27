using System;
using System.Linq.Expressions;
using System.Collections.Generic;
using System.Threading.Tasks;
using PetStoreNS.Api.Contracts;
using PetStoreNS.Api.DataAccess;

namespace PetStoreNS.Api.BusinessObjects
{
	public interface IBOSpecies
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
    <Hash>a15154ac3de760f96e06497c300f1694</Hash>
</Codenesium>*/