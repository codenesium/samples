using OctopusDeployNS.Api.Contracts;
using OctopusDeployNS.Api.DataAccess;
using System;
using System.Collections.Generic;

namespace OctopusDeployNS.Api.Services
{
        public interface IBOLWorkerPoolMapper
        {
                BOWorkerPool MapModelToBO(
                        string id,
                        ApiWorkerPoolRequestModel model);

                ApiWorkerPoolResponseModel MapBOToModel(
                        BOWorkerPool boWorkerPool);

                List<ApiWorkerPoolResponseModel> MapBOToModel(
                        List<BOWorkerPool> items);
        }
}

/*<Codenesium>
    <Hash>000e2f50891b784011fa81526a83946e</Hash>
</Codenesium>*/