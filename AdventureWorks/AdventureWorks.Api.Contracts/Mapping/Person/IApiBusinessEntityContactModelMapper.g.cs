using System;
using System.Collections.Generic;

namespace AdventureWorksNS.Api.Contracts
{
        public interface IApiBusinessEntityContactModelMapper
        {
                ApiBusinessEntityContactResponseModel MapRequestToResponse(
                        int businessEntityID,
                        ApiBusinessEntityContactRequestModel request);

                ApiBusinessEntityContactRequestModel MapResponseToRequest(
                        ApiBusinessEntityContactResponseModel response);
        }
}

/*<Codenesium>
    <Hash>0fbc1ad68b5280a32bad85630c82ddeb</Hash>
</Codenesium>*/