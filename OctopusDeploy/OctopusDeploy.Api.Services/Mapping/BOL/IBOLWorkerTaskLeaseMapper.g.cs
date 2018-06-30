using OctopusDeployNS.Api.Contracts;
using OctopusDeployNS.Api.DataAccess;
using System;
using System.Collections.Generic;

namespace OctopusDeployNS.Api.Services
{
        public interface IBOLWorkerTaskLeaseMapper
        {
                BOWorkerTaskLease MapModelToBO(
                        string id,
                        ApiWorkerTaskLeaseRequestModel model);

                ApiWorkerTaskLeaseResponseModel MapBOToModel(
                        BOWorkerTaskLease boWorkerTaskLease);

                List<ApiWorkerTaskLeaseResponseModel> MapBOToModel(
                        List<BOWorkerTaskLease> items);
        }
}

/*<Codenesium>
    <Hash>eb5967e53fc9dc84ec3412e8f6cb2285</Hash>
</Codenesium>*/