using OctopusDeployNS.Api.Contracts;
using OctopusDeployNS.Api.DataAccess;
using System;
using System.Collections.Generic;

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
    <Hash>6683e477a6a33e1bc0240a8177b2a184</Hash>
</Codenesium>*/