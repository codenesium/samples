using System;
using System.Collections.Generic;
using FileServiceNS.Api.Contracts;
using FileServiceNS.Api.DataAccess;

namespace FileServiceNS.Api.Services
{
        public interface IBOLFileMapper
        {
                BOFile MapModelToBO(
                        int id,
                        ApiFileRequestModel model);

                ApiFileResponseModel MapBOToModel(
                        BOFile boFile);

                List<ApiFileResponseModel> MapBOToModel(
                        List<BOFile> items);
        }
}

/*<Codenesium>
    <Hash>edaa0577bc4eaede04678050b40a80f9</Hash>
</Codenesium>*/