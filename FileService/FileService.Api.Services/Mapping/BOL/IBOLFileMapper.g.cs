using FileServiceNS.Api.Contracts;
using FileServiceNS.Api.DataAccess;
using System;
using System.Collections.Generic;

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
    <Hash>964a299d245710a87274d440cb06416a</Hash>
</Codenesium>*/