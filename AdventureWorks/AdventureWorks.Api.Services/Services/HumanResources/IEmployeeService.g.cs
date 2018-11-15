using AdventureWorksNS.Api.Contracts;
using AdventureWorksNS.Api.DataAccess;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace AdventureWorksNS.Api.Services
{
	public partial interface IEmployeeService
	{
		Task<CreateResponse<ApiEmployeeServerResponseModel>> Create(
			ApiEmployeeServerRequestModel model);

		Task<UpdateResponse<ApiEmployeeServerResponseModel>> Update(int businessEntityID,
		                                                             ApiEmployeeServerRequestModel model);

		Task<ActionResponse> Delete(int businessEntityID);

		Task<ApiEmployeeServerResponseModel> Get(int businessEntityID);

		Task<List<ApiEmployeeServerResponseModel>> All(int limit = int.MaxValue, int offset = 0);

		Task<ApiEmployeeServerResponseModel> ByLoginID(string loginID);

		Task<ApiEmployeeServerResponseModel> ByNationalIDNumber(string nationalIDNumber);

		Task<ApiEmployeeServerResponseModel> ByRowguid(Guid rowguid);

		Task<List<ApiJobCandidateServerResponseModel>> JobCandidatesByBusinessEntityID(int businessEntityID, int limit = int.MaxValue, int offset = 0);
	}
}

/*<Codenesium>
    <Hash>70ae3df5286b173b93adf82968d67448</Hash>
</Codenesium>*/