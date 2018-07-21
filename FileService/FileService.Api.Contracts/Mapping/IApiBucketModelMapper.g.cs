using Microsoft.AspNetCore.JsonPatch;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace FileServiceNS.Api.Contracts
{
        public interface IApiBucketModelMapper
        {
                ApiBucketResponseModel MapRequestToResponse(
                        int id,
                        ApiBucketRequestModel request);

                ApiBucketRequestModel MapResponseToRequest(
                        ApiBucketResponseModel response);

                JsonPatchDocument<ApiBucketRequestModel> CreatePatch(ApiBucketRequestModel model);
        }
}

/*<Codenesium>
    <Hash>b070427bda3ed9e5e7030c5d384e469e</Hash>
</Codenesium>*/