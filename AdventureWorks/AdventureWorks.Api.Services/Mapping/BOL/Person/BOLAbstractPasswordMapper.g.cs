using System;
using System.Collections.Generic;
using AdventureWorksNS.Api.Contracts;
using AdventureWorksNS.Api.DataAccess;

namespace AdventureWorksNS.Api.Services
{
        public abstract class BOLAbstractPasswordMapper
        {
                public virtual BOPassword MapModelToBO(
                        int businessEntityID,
                        ApiPasswordRequestModel model
                        )
                {
                        BOPassword boPassword = new BOPassword();

                        boPassword.SetProperties(
                                businessEntityID,
                                model.ModifiedDate,
                                model.PasswordHash,
                                model.PasswordSalt,
                                model.Rowguid);
                        return boPassword;
                }

                public virtual ApiPasswordResponseModel MapBOToModel(
                        BOPassword boPassword)
                {
                        var model = new ApiPasswordResponseModel();

                        model.SetProperties(boPassword.BusinessEntityID, boPassword.ModifiedDate, boPassword.PasswordHash, boPassword.PasswordSalt, boPassword.Rowguid);

                        return model;
                }

                public virtual List<ApiPasswordResponseModel> MapBOToModel(
                        List<BOPassword> items)
                {
                        List<ApiPasswordResponseModel> response = new List<ApiPasswordResponseModel>();

                        items.ForEach(d =>
                        {
                                response.Add(this.MapBOToModel(d));
                        });

                        return response;
                }
        }
}

/*<Codenesium>
    <Hash>d1ffd81e573a97bc3e9c2a717a6dd903</Hash>
</Codenesium>*/