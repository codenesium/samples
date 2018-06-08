using System;
using System.Collections.Generic;
using FileServiceNS.Api.Contracts;
using FileServiceNS.Api.DataAccess;

namespace FileServiceNS.Api.Services
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
    <Hash>279e61e9bdae5696c216a1463381b705</Hash>
</Codenesium>*/