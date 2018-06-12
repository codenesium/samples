using System;
using System.Collections.Generic;
using OctopusDeployNS.Api.Contracts;
using OctopusDeployNS.Api.DataAccess;

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
    <Hash>9013dee0bd092fba03ac8f6fa383a727</Hash>
</Codenesium>*/