using StackOverflowNS.Api.Contracts;
using StackOverflowNS.Api.DataAccess;
using System;
using System.Collections.Generic;

namespace StackOverflowNS.Api.Services
{
        public interface IBOLTagsMapper
        {
                BOTags MapModelToBO(
                        int id,
                        ApiTagsRequestModel model);

                ApiTagsResponseModel MapBOToModel(
                        BOTags boTags);

                List<ApiTagsResponseModel> MapBOToModel(
                        List<BOTags> items);
        }
}

/*<Codenesium>
    <Hash>3b8aa6d10fc7423700bb2a628de4d989</Hash>
</Codenesium>*/