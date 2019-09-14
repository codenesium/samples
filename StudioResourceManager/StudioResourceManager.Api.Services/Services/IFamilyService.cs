using StudioResourceManagerNS.Api.Contracts;
using StudioResourceManagerNS.Api.DataAccess;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace StudioResourceManagerNS.Api.Services
{
	public partial interface IFamilyService
	{
		Task<CreateResponse<ApiFamilyServerResponseModel>> Create(
			ApiFamilyServerRequestModel model);

		Task<UpdateResponse<ApiFamilyServerResponseModel>> Update(int id,
		                                                           ApiFamilyServerRequestModel model);

		Task<ActionResponse> Delete(int id);

		Task<ApiFamilyServerResponseModel> Get(int id);

		Task<List<ApiFamilyServerResponseModel>> All(int limit = int.MaxValue, int offset = 0, string query = "");

		Task<List<ApiStudentServerResponseModel>> StudentsByFamilyId(int familyId, int limit = int.MaxValue, int offset = 0);
	}
}

/*<Codenesium>
    <Hash>4fa254b95b228399e000630485193ce6</Hash>
    <Hello>
		This code was generated using the Codenesium platform. You can visit our site at https://www.codenesium.com. 
	</Hello>
</Codenesium>*/