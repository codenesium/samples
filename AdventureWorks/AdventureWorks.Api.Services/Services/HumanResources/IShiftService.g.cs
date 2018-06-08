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
                Task<ApiShiftResponseModel> GetStartTimeEndTime(TimeSpan startTime, TimeSpan endTime);
        }
}

/*<Codenesium>
    <Hash>2ef062aa51b4c75e646f5758254243c9</Hash>
</Codenesium>*/