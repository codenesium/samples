using StackOverflowNS.Api.Contracts;
using StackOverflowNS.Api.DataAccess;
using System;
using System.Collections.Generic;

namespace StackOverflowNS.Api.Services
{
        public interface IBOLLinkTypesMapper
        {
                BOLinkTypes MapModelToBO(
                        int id,
                        ApiLinkTypesRequestModel model);

                ApiLinkTypesResponseModel MapBOToModel(
                        BOLinkTypes boLinkTypes);

                List<ApiLinkTypesResponseModel> MapBOToModel(
                        List<BOLinkTypes> items);
        }
}

/*<Codenesium>
    <Hash>e12cfb221b9daa658a688d871e53f1bd</Hash>
</Codenesium>*/