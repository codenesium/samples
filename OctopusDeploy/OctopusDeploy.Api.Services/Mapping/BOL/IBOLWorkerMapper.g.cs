using System;
using System.Collections.Generic;
using OctopusDeployNS.Api.Contracts;
using OctopusDeployNS.Api.DataAccess;

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
    <Hash>1824851708d3d5b9c0bd3c6a247b2462</Hash>
</Codenesium>*/