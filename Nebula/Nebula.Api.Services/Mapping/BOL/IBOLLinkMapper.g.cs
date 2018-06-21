using NebulaNS.Api.Contracts;
using NebulaNS.Api.DataAccess;
using System;
using System.Collections.Generic;

namespace NebulaNS.Api.Services
{
        public interface IBOLLinkMapper
        {
                BOLink MapModelToBO(
                        int id,
                        ApiLinkRequestModel model);

                ApiLinkResponseModel MapBOToModel(
                        BOLink boLink);

                List<ApiLinkResponseModel> MapBOToModel(
                        List<BOLink> items);
        }
}

/*<Codenesium>
    <Hash>0a4f46ef28f4e87c226974bb4d3c3074</Hash>
</Codenesium>*/