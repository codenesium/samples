using AdventureWorksNS.Api.Contracts;
using AdventureWorksNS.Api.DataAccess;
using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using System.Threading.Tasks;

namespace AdventureWorksNS.Api.Services
{
	public partial interface IShiftService
	{
		Task<CreateResponse<ApiShiftResponseModel>> Create(
			ApiShiftRequestModel model);

		Task<UpdateResponse<ApiShiftResponseModel>> Update(int shiftID,
		                                                    ApiShiftRequestModel model);

		Task<ActionResponse> Delete(int shiftID);

		Task<ApiShiftResponseModel> Get(int shiftID);

		Task<List<ApiShiftResponseModel>> All(int limit = int.MaxValue, int offset = 0);

		Task<ApiShiftResponseModel> ByName(string name);

		Task<ApiShiftResponseModel> ByStartTimeEndTime(TimeSpan startTime, TimeSpan endTime);

		Task<List<ApiEmployeeDepartmentHistoryResponseModel>> EmployeeDepartmentHistories(int shiftID, int limit = int.MaxValue, int offset = 0);
	}
}

/*<Codenesium>
    <Hash>3721491b6a486010edc4b923af5b22cf</Hash>
</Codenesium>*/