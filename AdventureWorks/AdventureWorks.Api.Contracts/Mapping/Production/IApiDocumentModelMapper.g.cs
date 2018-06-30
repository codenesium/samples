using System;
using System.Collections.Generic;

namespace AdventureWorksNS.Api.Contracts
{
        public interface IApiDocumentModelMapper
        {
                ApiDocumentResponseModel MapRequestToResponse(
                        Guid rowguid,
                        ApiDocumentRequestModel request);

                ApiDocumentRequestModel MapResponseToRequest(
                        ApiDocumentResponseModel response);
        }
}

/*<Codenesium>
    <Hash>66aa4c43d42805966991221d9195486e</Hash>
</Codenesium>*/