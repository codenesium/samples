using PetStoreNS.Api.Contracts;
using PetStoreNS.Api.DataAccess;
using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using System.Threading.Tasks;

namespace PetStoreNS.Api.Services
{
	public partial interface IPenService
	{
		Task<CreateResponse<ApiPenResponseModel>> Create(
			ApiPenRequestModel model);

		Task<UpdateResponse<ApiPenResponseModel>> Update(int id,
		                                                  ApiPenRequestModel model);

		Task<ActionResponse> Delete(int id);

		Task<ApiPenResponseModel> Get(int id);

		Task<List<ApiPenResponseModel>> All(int limit = int.MaxValue, int offset = 0);

		Task<List<ApiPetResponseModel>> Pets(int penId, int limit = int.MaxValue, int offset = 0);
	}
}

/*<Codenesium>
    <Hash>2562371b7a31d4dc1ad5b9a1c9587601</Hash>
</Codenesium>*/