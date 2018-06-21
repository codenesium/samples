using NebulaNS.Api.Contracts;
using NebulaNS.Api.DataAccess;
using System;
using System.Collections.Generic;

namespace NebulaNS.Api.Services
{
        public interface IBOLVersionInfoMapper
        {
                BOVersionInfo MapModelToBO(
                        long version,
                        ApiVersionInfoRequestModel model);

                ApiVersionInfoResponseModel MapBOToModel(
                        BOVersionInfo boVersionInfo);

                List<ApiVersionInfoResponseModel> MapBOToModel(
                        List<BOVersionInfo> items);
        }
}

/*<Codenesium>
    <Hash>bf3ad1058fe313c9a9cb220f43783a3b</Hash>
</Codenesium>*/