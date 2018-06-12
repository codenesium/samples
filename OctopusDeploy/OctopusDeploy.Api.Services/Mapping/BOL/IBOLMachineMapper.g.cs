using System;
using System.Collections.Generic;
using OctopusDeployNS.Api.Contracts;
using OctopusDeployNS.Api.DataAccess;

namespace OctopusDeployNS.Api.Services
{
        public interface IBOLMachineMapper
        {
                BOMachine MapModelToBO(
                        string id,
                        ApiMachineRequestModel model);

                ApiMachineResponseModel MapBOToModel(
                        BOMachine boMachine);

                List<ApiMachineResponseModel> MapBOToModel(
                        List<BOMachine> items);
        }
}

/*<Codenesium>
    <Hash>0c3925ba0d74643dd5695071790ed774</Hash>
</Codenesium>*/