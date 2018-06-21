using StackOverflowNS.Api.Contracts;
using StackOverflowNS.Api.DataAccess;
using System;
using System.Collections.Generic;

namespace StackOverflowNS.Api.Services
{
        public interface IBOLVoteTypesMapper
        {
                BOVoteTypes MapModelToBO(
                        int id,
                        ApiVoteTypesRequestModel model);

                ApiVoteTypesResponseModel MapBOToModel(
                        BOVoteTypes boVoteTypes);

                List<ApiVoteTypesResponseModel> MapBOToModel(
                        List<BOVoteTypes> items);
        }
}

/*<Codenesium>
    <Hash>54d99e3cc41ac87f216c53fbf6b6deb7</Hash>
</Codenesium>*/