using Microsoft.AspNetCore.JsonPatch;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace AdventureWorksNS.Api.Contracts
{
        public interface IApiBillOfMaterialModelMapper
        {
                ApiBillOfMaterialResponseModel MapRequestToResponse(
                        int billOfMaterialsID,
                        ApiBillOfMaterialRequestModel request);

                ApiBillOfMaterialRequestModel MapResponseToRequest(
                        ApiBillOfMaterialResponseModel response);

                JsonPatchDocument<ApiBillOfMaterialRequestModel> CreatePatch(ApiBillOfMaterialRequestModel model);
        }
}

/*<Codenesium>
    <Hash>48a058f53db63d7800ca2291518bd86c</Hash>
</Codenesium>*/