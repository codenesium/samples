using System;
using System.Collections.Generic;

namespace OctopusDeployNS.Api.Contracts
{
        public interface IApiSchemaVersionsModelMapper
        {
                ApiSchemaVersionsResponseModel MapRequestToResponse(
                        int id,
                        ApiSchemaVersionsRequestModel request);

                ApiSchemaVersionsRequestModel MapResponseToRequest(
                        ApiSchemaVersionsResponseModel response);
        }
}

/*<Codenesium>
    <Hash>632331a29dfb55efd6db5b29b1f5fee9</Hash>
</Codenesium>*/