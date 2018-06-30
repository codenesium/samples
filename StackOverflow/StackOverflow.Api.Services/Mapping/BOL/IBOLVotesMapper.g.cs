using StackOverflowNS.Api.Contracts;
using StackOverflowNS.Api.DataAccess;
using System;
using System.Collections.Generic;

namespace StackOverflowNS.Api.Services
{
        public interface IBOLVotesMapper
        {
                BOVotes MapModelToBO(
                        int id,
                        ApiVotesRequestModel model);

                ApiVotesResponseModel MapBOToModel(
                        BOVotes boVotes);

                List<ApiVotesResponseModel> MapBOToModel(
                        List<BOVotes> items);
        }
}

/*<Codenesium>
    <Hash>500e232553dbdeda5e4be6e9728f4b08</Hash>
</Codenesium>*/