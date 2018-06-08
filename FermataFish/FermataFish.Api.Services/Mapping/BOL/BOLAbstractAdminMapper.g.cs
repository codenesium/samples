using System;
using System.Collections.Generic;
using FermataFishNS.Api.Contracts;
using FermataFishNS.Api.DataAccess;

namespace FermataFishNS.Api.Services
{
        public abstract class BOLAbstractAdminMapper
        {
                public virtual BOAdmin MapModelToBO(
                        int id,
                        ApiAdminRequestModel model
                        )
                {
                        BOAdmin boAdmin = new BOAdmin();

                        boAdmin.SetProperties(
                                id,
                                model.Birthday,
                                model.Email,
                                model.FirstName,
                                model.LastName,
                                model.Phone,
                                model.StudioId);
                        return boAdmin;
                }

                public virtual ApiAdminResponseModel MapBOToModel(
                        BOAdmin boAdmin)
                {
                        var model = new ApiAdminResponseModel();

                        model.SetProperties(boAdmin.Birthday, boAdmin.Email, boAdmin.FirstName, boAdmin.Id, boAdmin.LastName, boAdmin.Phone, boAdmin.StudioId);

                        return model;
                }

                public virtual List<ApiAdminResponseModel> MapBOToModel(
                        List<BOAdmin> items)
                {
                        List<ApiAdminResponseModel> response = new List<ApiAdminResponseModel>();

                        items.ForEach(d =>
                        {
                                response.Add(this.MapBOToModel(d));
                        });

                        return response;
                }
        }
}

/*<Codenesium>
    <Hash>0ac255af57f16e0ee5c2dd85808458e3</Hash>
</Codenesium>*/