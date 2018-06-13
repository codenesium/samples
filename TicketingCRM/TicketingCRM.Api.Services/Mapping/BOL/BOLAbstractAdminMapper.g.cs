using System;
using System.Collections.Generic;
using TicketingCRMNS.Api.Contracts;
using TicketingCRMNS.Api.DataAccess;

namespace TicketingCRMNS.Api.Services
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
                                model.Email,
                                model.FirstName,
                                model.LastName,
                                model.Password,
                                model.Phone,
                                model.Username);
                        return boAdmin;
                }

                public virtual ApiAdminResponseModel MapBOToModel(
                        BOAdmin boAdmin)
                {
                        var model = new ApiAdminResponseModel();

                        model.SetProperties(boAdmin.Email, boAdmin.FirstName, boAdmin.Id, boAdmin.LastName, boAdmin.Password, boAdmin.Phone, boAdmin.Username);

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
    <Hash>ee743db2bff6d1e22351d872dc326f4a</Hash>
</Codenesium>*/