using System;
using System.Collections.Generic;
using NebulaNS.Api.Contracts;
using NebulaNS.Api.DataAccess;

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
    <Hash>bfd4739e9fdc281fcd074d3a2d465573</Hash>
</Codenesium>*/