using FermataFishNS.Api.Contracts;
using FermataFishNS.Api.DataAccess;
using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using System.Threading.Tasks;

namespace FermataFishNS.Api.Services
{
	public partial interface IFamilyService
	{
		Task<CreateResponse<ApiFamilyResponseModel>> Create(
			ApiFamilyRequestModel model);

		Task<UpdateResponse<ApiFamilyResponseModel>> Update(int id,
		                                                     ApiFamilyRequestModel model);

		Task<ActionResponse> Delete(int id);

		Task<ApiFamilyResponseModel> Get(int id);

		Task<List<ApiFamilyResponseModel>> All(int limit = int.MaxValue, int offset = 0);

		Task<List<ApiFamilyResponseModel>> ByStudioId(int studioId, int limit = int.MaxValue, int offset = 0);

		Task<List<ApiStudentResponseModel>> Students(int familyId, int limit = int.MaxValue, int offset = 0);

		Task<List<ApiStudentXFamilyResponseModel>> StudentXFamilies(int familyId, int limit = int.MaxValue, int offset = 0);
	}
}

/*<Codenesium>
    <Hash>9e89adf3e7b5366d0f9a573e002afa17</Hash>
</Codenesium>*/