using System;
using System.Collections.Generic;
using AdventureWorksNS.Api.Contracts;
using AdventureWorksNS.Api.DataAccess;

namespace AdventureWorksNS.Api.Services
{
        public interface IBOLShiftMapper
        {
                BOShift MapModelToBO(
                        int shiftID,
                        ApiShiftRequestModel model);

                ApiShiftResponseModel MapBOToModel(
                        BOShift boShift);

                List<ApiShiftResponseModel> MapBOToModel(
                        List<BOShift> items);
        }
}

/*<Codenesium>
    <Hash>d8bc23d03c6694798b6e2e6dfff85e48</Hash>
</Codenesium>*/