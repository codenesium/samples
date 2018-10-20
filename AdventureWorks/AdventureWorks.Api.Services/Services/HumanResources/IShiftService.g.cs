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

		Task<List<ApiEmployeeDepartmentHistoryResponseModel>> EmployeeDepartmentHistoriesByShiftID(int shiftID, int limit = int.MaxValue, int offset = 0);
	}
}

/*<Codenesium>
    <Hash>bc925c3c2318f523f00f1387907d1a1e</Hash>
</Codenesium>*/