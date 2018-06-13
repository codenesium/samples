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

                Task<List<ApiShiftResponseModel>> All(int limit = int.MaxValue, int offset = 0, string orderClause = "");

                Task<ApiShiftResponseModel> GetName(string name);
                Task<ApiShiftResponseModel> GetStartTimeEndTime(TimeSpan startTime, TimeSpan endTime);

                Task<List<ApiEmployeeDepartmentHistoryResponseModel>> EmployeeDepartmentHistories(int shiftID, int limit = int.MaxValue, int offset = 0);
        }
}

/*<Codenesium>
    <Hash>219b5a7cf02019eb7882672577674a73</Hash>
</Codenesium>*/