using FileServiceNS.Api.Contracts;
using FileServiceNS.Api.DataAccess;
using System;
using System.Collections.Generic;

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
    <Hash>91708c168c08fea63dfe860ea87468c9</Hash>
</Codenesium>*/