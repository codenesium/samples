using System;
using System.Collections.Generic;
using TestsNS.Api.Contracts;
using TestsNS.Api.DataAccess;

namespace TestsNS.Api.Services
{
        public interface IBOLPersonRefMapper
        {
                BOPersonRef MapModelToBO(
                        int id,
                        ApiPersonRefRequestModel model);

                ApiPersonRefResponseModel MapBOToModel(
                        BOPersonRef boPersonRef);

                List<ApiPersonRefResponseModel> MapBOToModel(
                        List<BOPersonRef> items);
        }
}

/*<Codenesium>
    <Hash>e6c0599387c2e2e1e044812bd60ccd54</Hash>
</Codenesium>*/