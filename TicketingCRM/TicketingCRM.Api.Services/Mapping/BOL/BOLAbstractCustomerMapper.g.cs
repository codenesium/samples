using System;
using System.Collections.Generic;
using TicketingCRMNS.Api.Contracts;
using TicketingCRMNS.Api.DataAccess;

namespace TicketingCRMNS.Api.Services
{
        public abstract class BOLAbstractCustomerMapper
        {
                public virtual BOCustomer MapModelToBO(
                        int id,
                        ApiCustomerRequestModel model
                        )
                {
                        BOCustomer boCustomer = new BOCustomer();
                        boCustomer.SetProperties(
                                id,
                                model.Email,
                                model.FirstName,
                                model.LastName,
                                model.Phone);
                        return boCustomer;
                }

                public virtual ApiCustomerResponseModel MapBOToModel(
                        BOCustomer boCustomer)
                {
                        var model = new ApiCustomerResponseModel();

                        model.SetProperties(boCustomer.Email, boCustomer.FirstName, boCustomer.Id, boCustomer.LastName, boCustomer.Phone);

                        return model;
                }

                public virtual List<ApiCustomerResponseModel> MapBOToModel(
                        List<BOCustomer> items)
                {
                        List<ApiCustomerResponseModel> response = new List<ApiCustomerResponseModel>();

                        items.ForEach(d =>
                        {
                                response.Add(this.MapBOToModel(d));
                        });

                        return response;
                }
        }
}

/*<Codenesium>
    <Hash>9d5ceac7876c8d38969f1b12802b701d</Hash>
</Codenesium>*/