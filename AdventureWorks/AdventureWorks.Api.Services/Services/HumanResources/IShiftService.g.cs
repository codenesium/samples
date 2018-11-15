using AdventureWorksNS.Api.Contracts;
using AdventureWorksNS.Api.DataAccess;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace AdventureWorksNS.Api.Services
{
	public partial interface IShiftService
	{
		Task<CreateResponse<ApiShiftServerResponseModel>> Create(
			ApiShiftServerRequestModel model);

		Task<UpdateResponse<ApiShiftServerResponseModel>> Update(int shiftID,
		                                                          ApiShiftServerRequestModel model);

		Task<ActionResponse> Delete(int shiftID);

		Task<ApiShiftServerResponseModel> Get(int shiftID);

		Task<List<ApiShiftServerResponseModel>> All(int limit = int.MaxValue, int offset = 0);

		Task<ApiShiftServerResponseModel> ByName(string name);

		Task<ApiShiftServerResponseModel> ByStartTimeEndTime(TimeSpan startTime, TimeSpan endTime);
	}
}

/*<Codenesium>
    <Hash>cb314c6b95a2a23ecf2e526b77929fb6</Hash>
</Codenesium>*/