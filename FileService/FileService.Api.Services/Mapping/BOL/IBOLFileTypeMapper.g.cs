using System;
using System.Collections.Generic;
using FileServiceNS.Api.Contracts;
using FileServiceNS.Api.DataAccess;

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
    <Hash>4e4019c899e221d58fba539f621d6d58</Hash>
</Codenesium>*/