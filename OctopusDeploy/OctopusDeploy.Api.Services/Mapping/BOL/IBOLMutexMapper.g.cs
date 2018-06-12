using System;
using System.Collections.Generic;
using OctopusDeployNS.Api.Contracts;
using OctopusDeployNS.Api.DataAccess;

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
    <Hash>7af7d66c482cd0885f7a6e241c676c8d</Hash>
</Codenesium>*/