using NebulaNS.Api.Contracts;
using NebulaNS.Api.DataAccess;
using System;
using System.Collections.Generic;

namespace NebulaNS.Api.Services
{
        public interface IBOLMachineMapper
        {
                BOMachine MapModelToBO(
                        int id,
                        ApiMachineRequestModel model);

                ApiMachineResponseModel MapBOToModel(
                        BOMachine boMachine);

                List<ApiMachineResponseModel> MapBOToModel(
                        List<BOMachine> items);
        }
}

/*<Codenesium>
    <Hash>b853c7033c85e48568fefb53c161517c</Hash>
</Codenesium>*/