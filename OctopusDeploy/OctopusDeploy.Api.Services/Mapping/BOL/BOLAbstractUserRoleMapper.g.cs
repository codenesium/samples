using System;
using System.Collections.Generic;
using OctopusDeployNS.Api.Contracts;
using OctopusDeployNS.Api.DataAccess;

namespace OctopusDeployNS.Api.Services
{
        public abstract class BOLAbstractUserRoleMapper
        {
                public virtual BOUserRole MapModelToBO(
                        string id,
                        ApiUserRoleRequestModel model
                        )
                {
                        BOUserRole boUserRole = new BOUserRole();

                        boUserRole.SetProperties(
                                id,
                                model.JSON,
                                model.Name);
                        return boUserRole;
                }

                public virtual ApiUserRoleResponseModel MapBOToModel(
                        BOUserRole boUserRole)
                {
                        var model = new ApiUserRoleResponseModel();

                        model.SetProperties(boUserRole.Id, boUserRole.JSON, boUserRole.Name);

                        return model;
                }

                public virtual List<ApiUserRoleResponseModel> MapBOToModel(
                        List<BOUserRole> items)
                {
                        List<ApiUserRoleResponseModel> response = new List<ApiUserRoleResponseModel>();

                        items.ForEach(d =>
                        {
                                response.Add(this.MapBOToModel(d));
                        });

                        return response;
                }
        }
}

/*<Codenesium>
    <Hash>5c1e637940c29f2efc07445d9a01095d</Hash>
</Codenesium>*/