using NebulaNS.Api.Contracts;
using NebulaNS.Api.DataAccess;
using System;
using System.Collections.Generic;

namespace NebulaNS.Api.Services
{
        public interface IBOLChainStatusMapper
        {
                BOChainStatus MapModelToBO(
                        int id,
                        ApiChainStatusRequestModel model);

                ApiChainStatusResponseModel MapBOToModel(
                        BOChainStatus boChainStatus);

                List<ApiChainStatusResponseModel> MapBOToModel(
                        List<BOChainStatus> items);
        }
}

/*<Codenesium>
    <Hash>66fa4a3cea14eaefea0181ceb73bae70</Hash>
</Codenesium>*/