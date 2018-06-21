using NebulaNS.Api.Contracts;
using NebulaNS.Api.DataAccess;
using System;
using System.Collections.Generic;

namespace NebulaNS.Api.Services
{
        public interface IBOLChainMapper
        {
                BOChain MapModelToBO(
                        int id,
                        ApiChainRequestModel model);

                ApiChainResponseModel MapBOToModel(
                        BOChain boChain);

                List<ApiChainResponseModel> MapBOToModel(
                        List<BOChain> items);
        }
}

/*<Codenesium>
    <Hash>4a7a44832e4ed5255e6c13ef7db2099f</Hash>
</Codenesium>*/