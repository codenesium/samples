using OctopusDeployNS.Api.Contracts;
using OctopusDeployNS.Api.DataAccess;
using System;
using System.Collections.Generic;

namespace OctopusDeployNS.Api.Services
{
        public interface IBOLWorkerMapper
        {
                BOWorker MapModelToBO(
                        string id,
                        ApiWorkerRequestModel model);

                ApiWorkerResponseModel MapBOToModel(
                        BOWorker boWorker);

                List<ApiWorkerResponseModel> MapBOToModel(
                        List<BOWorker> items);
        }
}

/*<Codenesium>
    <Hash>75ed0dfe7ef0f1f58f11c41f411743d4</Hash>
</Codenesium>*/