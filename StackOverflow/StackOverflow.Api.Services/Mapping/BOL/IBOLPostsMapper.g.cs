using StackOverflowNS.Api.Contracts;
using StackOverflowNS.Api.DataAccess;
using System;
using System.Collections.Generic;

namespace StackOverflowNS.Api.Services
{
        public interface IBOLPostsMapper
        {
                BOPosts MapModelToBO(
                        int id,
                        ApiPostsRequestModel model);

                ApiPostsResponseModel MapBOToModel(
                        BOPosts boPosts);

                List<ApiPostsResponseModel> MapBOToModel(
                        List<BOPosts> items);
        }
}

/*<Codenesium>
    <Hash>3f1b21c628a962be2f9530684d3e8e24</Hash>
</Codenesium>*/