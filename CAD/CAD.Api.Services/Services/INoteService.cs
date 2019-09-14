using CADNS.Api.Contracts;
using CADNS.Api.DataAccess;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace CADNS.Api.Services
{
	public partial interface INoteService
	{
		Task<CreateResponse<ApiNoteServerResponseModel>> Create(
			ApiNoteServerRequestModel model);

		Task<UpdateResponse<ApiNoteServerResponseModel>> Update(int id,
		                                                         ApiNoteServerRequestModel model);

		Task<ActionResponse> Delete(int id);

		Task<ApiNoteServerResponseModel> Get(int id);

		Task<List<ApiNoteServerResponseModel>> All(int limit = int.MaxValue, int offset = 0, string query = "");
	}
}

/*<Codenesium>
    <Hash>4a10d45fd93a2aaedc38f0a83b6134f7</Hash>
    <Hello>
		This code was generated using the Codenesium platform. You can visit our site at https://www.codenesium.com. 
	</Hello>
</Codenesium>*/