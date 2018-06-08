using System;
using System.Collections.Generic;
using NebulaNS.Api.Contracts;
using NebulaNS.Api.DataAccess;

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
    <Hash>544148a632dca7d368719e479154f8c2</Hash>
</Codenesium>*/