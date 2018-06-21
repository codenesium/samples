using AdventureWorksNS.Api.Contracts;
using AdventureWorksNS.Api.DataAccess;
using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using System.Threading.Tasks;

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

                Task<List<ApiShiftResponseModel>> All(int limit = int.MaxValue, int offset = 0);

                Task<ApiShiftResponseModel> ByName(string name);

                Task<ApiShiftResponseModel> ByStartTimeEndTime(TimeSpan startTime, TimeSpan endTime);

                Task<List<ApiEmployeeDepartmentHistoryResponseModel>> EmployeeDepartmentHistories(int shiftID, int limit = int.MaxValue, int offset = 0);
        }
}

/*<Codenesium>
    <Hash>448f7e5914643adbed02cf92a70c22c7</Hash>
</Codenesium>*/