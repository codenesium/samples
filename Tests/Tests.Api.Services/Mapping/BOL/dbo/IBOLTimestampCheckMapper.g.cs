using System;
using System.Collections.Generic;
using TestsNS.Api.Contracts;
using TestsNS.Api.DataAccess;

namespace TestsNS.Api.Services
{
        public interface IBOLTimestampCheckMapper
        {
                BOTimestampCheck MapModelToBO(
                        int id,
                        ApiTimestampCheckRequestModel model);

                ApiTimestampCheckResponseModel MapBOToModel(
                        BOTimestampCheck boTimestampCheck);

                List<ApiTimestampCheckResponseModel> MapBOToModel(
                        List<BOTimestampCheck> items);
        }
}

/*<Codenesium>
    <Hash>0c21e9368c4994eae13e6b5e129b13a3</Hash>
</Codenesium>*/