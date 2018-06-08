using System;
using System.Collections.Generic;
using NebulaNS.Api.Contracts;
using NebulaNS.Api.DataAccess;

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
    <Hash>8a520156438aab588e774a45cc806782</Hash>
</Codenesium>*/