using NebulaNS.Api.Contracts;
using NebulaNS.Api.DataAccess;
using System;
using System.Collections.Generic;

namespace NebulaNS.Api.Services
{
        public abstract class BOLAbstractOrganizationMapper
        {
                public virtual BOOrganization MapModelToBO(
                        int id,
                        ApiOrganizationRequestModel model
                        )
                {
                        BOOrganization boOrganization = new BOOrganization();
                        boOrganization.SetProperties(
                                id,
                                model.Name);
                        return boOrganization;
                }

                public virtual ApiOrganizationResponseModel MapBOToModel(
                        BOOrganization boOrganization)
                {
                        var model = new ApiOrganizationResponseModel();

                        model.SetProperties(boOrganization.Id, boOrganization.Name);

                        return model;
                }

                public virtual List<ApiOrganizationResponseModel> MapBOToModel(
                        List<BOOrganization> items)
                {
                        List<ApiOrganizationResponseModel> response = new List<ApiOrganizationResponseModel>();

                        items.ForEach(d =>
                        {
                                response.Add(this.MapBOToModel(d));
                        });

                        return response;
                }
        }
}

/*<Codenesium>
    <Hash>e576169153c34604acd78e51fbf36415</Hash>
</Codenesium>*/