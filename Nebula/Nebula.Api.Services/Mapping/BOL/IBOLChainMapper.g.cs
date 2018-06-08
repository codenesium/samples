using System;
using System.Collections.Generic;
using NebulaNS.Api.Contracts;
using NebulaNS.Api.DataAccess;

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
    <Hash>c141f3977694e4f1c17df1eaa75f5917</Hash>
</Codenesium>*/