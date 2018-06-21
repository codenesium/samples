using NebulaNS.Api.Contracts;
using NebulaNS.Api.DataAccess;
using System;
using System.Collections.Generic;

namespace NebulaNS.Api.Services
{
        public interface IBOLLinkLogMapper
        {
                BOLinkLog MapModelToBO(
                        int id,
                        ApiLinkLogRequestModel model);

                ApiLinkLogResponseModel MapBOToModel(
                        BOLinkLog boLinkLog);

                List<ApiLinkLogResponseModel> MapBOToModel(
                        List<BOLinkLog> items);
        }
}

/*<Codenesium>
    <Hash>072cb4cd3b5d47d2f3437e95180108ab</Hash>
</Codenesium>*/