using System;
using System.Linq.Expressions;
using System.Collections.Generic;
using System.Threading.Tasks;
using AdventureWorksNS.Api.Contracts;
using AdventureWorksNS.Api.DataAccess;

namespace AdventureWorksNS.Api.BusinessObjects
{
	public interface IBOShift
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
    <Hash>d91283bca4761a6b290f1cc681b1d93a</Hash>
</Codenesium>*/