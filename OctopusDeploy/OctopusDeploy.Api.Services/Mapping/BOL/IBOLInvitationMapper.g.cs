using OctopusDeployNS.Api.Contracts;
using OctopusDeployNS.Api.DataAccess;
using System;
using System.Collections.Generic;

namespace OctopusDeployNS.Api.Services
{
        public interface IBOLInvitationMapper
        {
                BOInvitation MapModelToBO(
                        string id,
                        ApiInvitationRequestModel model);

                ApiInvitationResponseModel MapBOToModel(
                        BOInvitation boInvitation);

                List<ApiInvitationResponseModel> MapBOToModel(
                        List<BOInvitation> items);
        }
}

/*<Codenesium>
    <Hash>bbd42828cc7912daf3fadc03747545d8</Hash>
</Codenesium>*/