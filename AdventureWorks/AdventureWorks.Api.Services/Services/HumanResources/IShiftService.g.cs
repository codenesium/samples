using System;
using System.Linq.Expressions;
using System.Collections.Generic;
using System.Threading.Tasks;
using AdventureWorksNS.Api.Contracts;
using AdventureWorksNS.Api.DataAccess;

namespace AdventureWorksNS.Api.Services
{
	public interface IShiftService
	{
		Task<CreateResponse<ApiShiftResponseModel>> Create(
			ApiShiftRequestModel model);

		Task<ActionResponse> Update(int shiftID,
		                            ApiShiftRequestModel model);

		Task<ActionResponse> Delete(int shiftID);

		Task<ApiShiftResponseModel> Get(int shiftID);

		Task<List<ApiShiftResponseModel>> All(int skip = 0, int take = int.MaxValue, string orderClause = "");

		Task<ApiShiftResponseModel> GetName(string name);
		Task<ApiShiftResponseModel> GetStartTimeEndTime(TimeSpan startTime,TimeSpan endTime);
	}
}

/*<Codenesium>
    <Hash>2385e62a9b73a98935caefc368a11b62</Hash>
</Codenesium>*/