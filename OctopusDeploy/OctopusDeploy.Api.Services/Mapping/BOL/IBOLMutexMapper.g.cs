using OctopusDeployNS.Api.Contracts;
using OctopusDeployNS.Api.DataAccess;
using System;
using System.Collections.Generic;

namespace OctopusDeployNS.Api.Services
{
        public interface IBOLMutexMapper
        {
                BOMutex MapModelToBO(
                        string id,
                        ApiMutexRequestModel model);

                ApiMutexResponseModel MapBOToModel(
                        BOMutex boMutex);

                List<ApiMutexResponseModel> MapBOToModel(
                        List<BOMutex> items);
        }
}

/*<Codenesium>
    <Hash>bb48491df78da0bb2624ddb661b14955</Hash>
</Codenesium>*/