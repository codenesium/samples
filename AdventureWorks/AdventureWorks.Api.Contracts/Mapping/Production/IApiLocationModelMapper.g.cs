using Microsoft.AspNetCore.JsonPatch;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace AdventureWorksNS.Api.Contracts
{
        public interface IApiLocationModelMapper
        {
                ApiLocationResponseModel MapRequestToResponse(
                        short locationID,
                        ApiLocationRequestModel request);

                ApiLocationRequestModel MapResponseToRequest(
                        ApiLocationResponseModel response);

                JsonPatchDocument<ApiLocationRequestModel> CreatePatch(ApiLocationRequestModel model);
        }
}

/*<Codenesium>
    <Hash>b87a3730e7ebf2b6ad419a8d1942fb43</Hash>
</Codenesium>*/