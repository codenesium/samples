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
    <Hash>b0dac8cbb7b71cdbeecc2d634e8ce9e0</Hash>
</Codenesium>*/