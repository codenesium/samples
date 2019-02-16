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

		Task<List<ApiShiftServerResponseModel>> All(int limit = int.MaxValue, int offset = 0, string query = "");

		Task<ApiShiftServerResponseModel> ByName(string name);

		Task<ApiShiftServerResponseModel> ByStartTimeEndTime(TimeSpan startTime, TimeSpan endTime);
	}
}

/*<Codenesium>
    <Hash>47d24e826700b94630ef146ab8a9226b</Hash>
</Codenesium>*/