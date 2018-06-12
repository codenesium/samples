using System;
using System.Collections.Generic;
using OctopusDeployNS.Api.Contracts;
using OctopusDeployNS.Api.DataAccess;

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
    <Hash>3814235279edb687cbd74881287b2361</Hash>
</Codenesium>*/