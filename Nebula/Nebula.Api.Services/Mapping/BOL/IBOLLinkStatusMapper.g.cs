using NebulaNS.Api.Contracts;
using NebulaNS.Api.DataAccess;
using System;
using System.Collections.Generic;

namespace NebulaNS.Api.Services
{
        public interface IBOLLinkStatusMapper
        {
                BOLinkStatus MapModelToBO(
                        int id,
                        ApiLinkStatusRequestModel model);

                ApiLinkStatusResponseModel MapBOToModel(
                        BOLinkStatus boLinkStatus);

                List<ApiLinkStatusResponseModel> MapBOToModel(
                        List<BOLinkStatus> items);
        }
}

/*<Codenesium>
    <Hash>96388de705eb4fbbc33fc91e5e879e8b</Hash>
</Codenesium>*/