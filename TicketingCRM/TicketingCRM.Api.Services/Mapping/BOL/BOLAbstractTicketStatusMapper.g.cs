using System;
using System.Collections.Generic;
using TicketingCRMNS.Api.Contracts;
using TicketingCRMNS.Api.DataAccess;

namespace TicketingCRMNS.Api.Services
{
        public abstract class BOLAbstractTicketStatusMapper
        {
                public virtual BOTicketStatus MapModelToBO(
                        int id,
                        ApiTicketStatusRequestModel model
                        )
                {
                        BOTicketStatus boTicketStatus = new BOTicketStatus();
                        boTicketStatus.SetProperties(
                                id,
                                model.Name);
                        return boTicketStatus;
                }

                public virtual ApiTicketStatusResponseModel MapBOToModel(
                        BOTicketStatus boTicketStatus)
                {
                        var model = new ApiTicketStatusResponseModel();

                        model.SetProperties(boTicketStatus.Id, boTicketStatus.Name);

                        return model;
                }

                public virtual List<ApiTicketStatusResponseModel> MapBOToModel(
                        List<BOTicketStatus> items)
                {
                        List<ApiTicketStatusResponseModel> response = new List<ApiTicketStatusResponseModel>();

                        items.ForEach(d =>
                        {
                                response.Add(this.MapBOToModel(d));
                        });

                        return response;
                }
        }
}

/*<Codenesium>
    <Hash>05afed99eefdc6fcaaac5ff41c1c018f</Hash>
</Codenesium>*/