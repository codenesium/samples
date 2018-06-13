using System;
using System.Collections.Generic;
using TicketingCRMNS.Api.Contracts;
using TicketingCRMNS.Api.DataAccess;

namespace TicketingCRMNS.Api.Services
{
        public abstract class BOLAbstractSaleTicketsMapper
        {
                public virtual BOSaleTickets MapModelToBO(
                        int id,
                        ApiSaleTicketsRequestModel model
                        )
                {
                        BOSaleTickets boSaleTickets = new BOSaleTickets();

                        boSaleTickets.SetProperties(
                                id,
                                model.SaleId,
                                model.TicketId);
                        return boSaleTickets;
                }

                public virtual ApiSaleTicketsResponseModel MapBOToModel(
                        BOSaleTickets boSaleTickets)
                {
                        var model = new ApiSaleTicketsResponseModel();

                        model.SetProperties(boSaleTickets.Id, boSaleTickets.SaleId, boSaleTickets.TicketId);

                        return model;
                }

                public virtual List<ApiSaleTicketsResponseModel> MapBOToModel(
                        List<BOSaleTickets> items)
                {
                        List<ApiSaleTicketsResponseModel> response = new List<ApiSaleTicketsResponseModel>();

                        items.ForEach(d =>
                        {
                                response.Add(this.MapBOToModel(d));
                        });

                        return response;
                }
        }
}

/*<Codenesium>
    <Hash>c37a0770456934d2ccb622e6480fdec0</Hash>
</Codenesium>*/