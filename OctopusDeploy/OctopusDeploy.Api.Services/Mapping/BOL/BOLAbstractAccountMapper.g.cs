using System;
using System.Collections.Generic;
using OctopusDeployNS.Api.Contracts;
using OctopusDeployNS.Api.DataAccess;

namespace OctopusDeployNS.Api.Services
{
        public abstract class BOLAbstractAccountMapper
        {
                public virtual BOAccount MapModelToBO(
                        string id,
                        ApiAccountRequestModel model
                        )
                {
                        BOAccount boAccount = new BOAccount();

                        boAccount.SetProperties(
                                id,
                                model.AccountType,
                                model.EnvironmentIds,
                                model.JSON,
                                model.Name,
                                model.TenantIds,
                                model.TenantTags);
                        return boAccount;
                }

                public virtual ApiAccountResponseModel MapBOToModel(
                        BOAccount boAccount)
                {
                        var model = new ApiAccountResponseModel();

                        model.SetProperties(boAccount.AccountType, boAccount.EnvironmentIds, boAccount.Id, boAccount.JSON, boAccount.Name, boAccount.TenantIds, boAccount.TenantTags);

                        return model;
                }

                public virtual List<ApiAccountResponseModel> MapBOToModel(
                        List<BOAccount> items)
                {
                        List<ApiAccountResponseModel> response = new List<ApiAccountResponseModel>();

                        items.ForEach(d =>
                        {
                                response.Add(this.MapBOToModel(d));
                        });

                        return response;
                }
        }
}

/*<Codenesium>
    <Hash>0b6ad964f25c5cdd8fbcf1b25dac7fcc</Hash>
</Codenesium>*/