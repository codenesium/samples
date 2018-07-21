using Microsoft.AspNetCore.JsonPatch;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace AdventureWorksNS.Api.Contracts
{
        public interface IApiUnitMeasureModelMapper
        {
                ApiUnitMeasureResponseModel MapRequestToResponse(
                        string unitMeasureCode,
                        ApiUnitMeasureRequestModel request);

                ApiUnitMeasureRequestModel MapResponseToRequest(
                        ApiUnitMeasureResponseModel response);

                JsonPatchDocument<ApiUnitMeasureRequestModel> CreatePatch(ApiUnitMeasureRequestModel model);
        }
}

/*<Codenesium>
    <Hash>cdd044d585ee46e682a0e5be8732a1b8</Hash>
</Codenesium>*/