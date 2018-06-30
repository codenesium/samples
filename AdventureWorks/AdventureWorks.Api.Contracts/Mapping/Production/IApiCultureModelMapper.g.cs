using System;
using System.Collections.Generic;

namespace AdventureWorksNS.Api.Contracts
{
        public interface IApiCultureModelMapper
        {
                ApiCultureResponseModel MapRequestToResponse(
                        string cultureID,
                        ApiCultureRequestModel request);

                ApiCultureRequestModel MapResponseToRequest(
                        ApiCultureResponseModel response);
        }
}

/*<Codenesium>
    <Hash>b20e622377cab594c2756f37c796510e</Hash>
</Codenesium>*/