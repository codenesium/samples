using System;
using System.Collections.Generic;

namespace FileServiceNS.Api.Contracts
{
        public interface IApiFileTypeModelMapper
        {
                ApiFileTypeResponseModel MapRequestToResponse(
                        int id,
                        ApiFileTypeRequestModel request);

                ApiFileTypeRequestModel MapResponseToRequest(
                        ApiFileTypeResponseModel response);
        }
}

/*<Codenesium>
    <Hash>3906a78500eb4026af465afec9377f9c</Hash>
</Codenesium>*/