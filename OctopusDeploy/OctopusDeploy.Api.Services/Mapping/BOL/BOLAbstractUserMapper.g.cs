using OctopusDeployNS.Api.Contracts;
using OctopusDeployNS.Api.DataAccess;
using System;
using System.Collections.Generic;

namespace OctopusDeployNS.Api.Services
{
        public abstract class BOLAbstractUserMapper
        {
                public virtual BOUser MapModelToBO(
                        string id,
                        ApiUserRequestModel model
                        )
                {
                        BOUser boUser = new BOUser();
                        boUser.SetProperties(
                                id,
                                model.DisplayName,
                                model.EmailAddress,
                                model.ExternalId,
                                model.ExternalIdentifiers,
                                model.IdentificationToken,
                                model.IsActive,
                                model.IsService,
                                model.JSON,
                                model.Username);
                        return boUser;
                }

                public virtual ApiUserResponseModel MapBOToModel(
                        BOUser boUser)
                {
                        var model = new ApiUserResponseModel();

                        model.SetProperties(boUser.DisplayName, boUser.EmailAddress, boUser.ExternalId, boUser.ExternalIdentifiers, boUser.Id, boUser.IdentificationToken, boUser.IsActive, boUser.IsService, boUser.JSON, boUser.Username);

                        return model;
                }

                public virtual List<ApiUserResponseModel> MapBOToModel(
                        List<BOUser> items)
                {
                        List<ApiUserResponseModel> response = new List<ApiUserResponseModel>();

                        items.ForEach(d =>
                        {
                                response.Add(this.MapBOToModel(d));
                        });

                        return response;
                }
        }
}

/*<Codenesium>
    <Hash>6dab95d9b6a09e5cb230eed6932a40cf</Hash>
</Codenesium>*/