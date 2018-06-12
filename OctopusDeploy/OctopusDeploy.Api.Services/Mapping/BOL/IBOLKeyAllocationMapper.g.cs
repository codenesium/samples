using System;
using System.Collections.Generic;
using OctopusDeployNS.Api.Contracts;
using OctopusDeployNS.Api.DataAccess;

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
    <Hash>1bc27246704859cfb4bc9e7fa7dfa87a</Hash>
</Codenesium>*/