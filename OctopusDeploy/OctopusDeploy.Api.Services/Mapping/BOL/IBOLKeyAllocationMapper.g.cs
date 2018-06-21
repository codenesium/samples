using OctopusDeployNS.Api.Contracts;
using OctopusDeployNS.Api.DataAccess;
using System;
using System.Collections.Generic;

namespace OctopusDeployNS.Api.Services
{
        public interface IBOLKeyAllocationMapper
        {
                BOKeyAllocation MapModelToBO(
                        string collectionName,
                        ApiKeyAllocationRequestModel model);

                ApiKeyAllocationResponseModel MapBOToModel(
                        BOKeyAllocation boKeyAllocation);

                List<ApiKeyAllocationResponseModel> MapBOToModel(
                        List<BOKeyAllocation> items);
        }
}

/*<Codenesium>
    <Hash>188b7f18659783b7c1dc34bc732e30e7</Hash>
</Codenesium>*/