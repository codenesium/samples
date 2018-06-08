using System;
using System.Collections.Generic;
using NebulaNS.Api.Contracts;
using NebulaNS.Api.DataAccess;

namespace NebulaNS.Api.Services
{
        public abstract class BOLAbstractTeamMapper
        {
                public virtual BOTeam MapModelToBO(
                        int id,
                        ApiTeamRequestModel model
                        )
                {
                        BOTeam boTeam = new BOTeam();

                        boTeam.SetProperties(
                                id,
                                model.Name,
                                model.OrganizationId);
                        return boTeam;
                }

                public virtual ApiTeamResponseModel MapBOToModel(
                        BOTeam boTeam)
                {
                        var model = new ApiTeamResponseModel();

                        model.SetProperties(boTeam.Id, boTeam.Name, boTeam.OrganizationId);

                        return model;
                }

                public virtual List<ApiTeamResponseModel> MapBOToModel(
                        List<BOTeam> items)
                {
                        List<ApiTeamResponseModel> response = new List<ApiTeamResponseModel>();

                        items.ForEach(d =>
                        {
                                response.Add(this.MapBOToModel(d));
                        });

                        return response;
                }
        }
}

/*<Codenesium>
    <Hash>c54ab48b522c4238dc0be0aa84dde976</Hash>
</Codenesium>*/