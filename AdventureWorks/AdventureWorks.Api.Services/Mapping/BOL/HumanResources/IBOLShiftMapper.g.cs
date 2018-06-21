using AdventureWorksNS.Api.Contracts;
using AdventureWorksNS.Api.DataAccess;
using System;
using System.Collections.Generic;

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
    <Hash>59e0d211edc11c01cd09fc6941712738</Hash>
</Codenesium>*/