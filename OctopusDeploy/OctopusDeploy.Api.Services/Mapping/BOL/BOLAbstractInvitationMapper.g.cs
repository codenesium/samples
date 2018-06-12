using System;
using System.Collections.Generic;
using OctopusDeployNS.Api.Contracts;
using OctopusDeployNS.Api.DataAccess;

namespace OctopusDeployNS.Api.Services
{
        public abstract class BOLAbstractInvitationMapper
        {
                public virtual BOInvitation MapModelToBO(
                        string id,
                        ApiInvitationRequestModel model
                        )
                {
                        BOInvitation boInvitation = new BOInvitation();

                        boInvitation.SetProperties(
                                id,
                                model.InvitationCode,
                                model.JSON);
                        return boInvitation;
                }

                public virtual ApiInvitationResponseModel MapBOToModel(
                        BOInvitation boInvitation)
                {
                        var model = new ApiInvitationResponseModel();

                        model.SetProperties(boInvitation.Id, boInvitation.InvitationCode, boInvitation.JSON);

                        return model;
                }

                public virtual List<ApiInvitationResponseModel> MapBOToModel(
                        List<BOInvitation> items)
                {
                        List<ApiInvitationResponseModel> response = new List<ApiInvitationResponseModel>();

                        items.ForEach(d =>
                        {
                                response.Add(this.MapBOToModel(d));
                        });

                        return response;
                }
        }
}

/*<Codenesium>
    <Hash>c4a9289d2915f3d0213ee6ca53c0f4c0</Hash>
</Codenesium>*/