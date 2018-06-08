using System;
using System.Collections.Generic;
using NebulaNS.Api.Contracts;
using NebulaNS.Api.DataAccess;

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
    <Hash>a0c54b528587dceffe9fa17bd34ed9b8</Hash>
</Codenesium>*/