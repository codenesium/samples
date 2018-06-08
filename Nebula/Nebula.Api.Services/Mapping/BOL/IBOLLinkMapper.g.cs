using System;
using System.Collections.Generic;
using NebulaNS.Api.Contracts;
using NebulaNS.Api.DataAccess;

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
    <Hash>06c1473191f99db7be804792314b2535</Hash>
</Codenesium>*/