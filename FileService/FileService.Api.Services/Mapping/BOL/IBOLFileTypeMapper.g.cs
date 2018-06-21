using FileServiceNS.Api.Contracts;
using FileServiceNS.Api.DataAccess;
using System;
using System.Collections.Generic;

namespace FileServiceNS.Api.Services
{
        public interface IBOLFileTypeMapper
        {
                BOFileType MapModelToBO(
                        int id,
                        ApiFileTypeRequestModel model);

                ApiFileTypeResponseModel MapBOToModel(
                        BOFileType boFileType);

                List<ApiFileTypeResponseModel> MapBOToModel(
                        List<BOFileType> items);
        }
}

/*<Codenesium>
    <Hash>6381a6e9bf1118a98b042080e6bb7959</Hash>
</Codenesium>*/