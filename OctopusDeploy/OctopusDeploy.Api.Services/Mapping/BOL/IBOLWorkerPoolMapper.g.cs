using System;
using System.Collections.Generic;
using OctopusDeployNS.Api.Contracts;
using OctopusDeployNS.Api.DataAccess;

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
    <Hash>647dfd0e733bca2fa0c069ce71e6e8e3</Hash>
</Codenesium>*/