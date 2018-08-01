using PetStoreNS.Api.Contracts;
using PetStoreNS.Api.DataAccess;
using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using System.Threading.Tasks;

namespace PetStoreNS.Api.Services
{
	public interface IPenService
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
    <Hash>b3baddc16b767dd5cb8bb2f1c372fc7b</Hash>
</Codenesium>*/