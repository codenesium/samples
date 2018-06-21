using System;
using System.Collections.Generic;
using TicketingCRMNS.Api.Contracts;
using TicketingCRMNS.Api.DataAccess;

namespace TicketingCRMNS.Api.Services
{
        public abstract class BOLAbstractEventMapper
        {
                public virtual BOEvent MapModelToBO(
                        int id,
                        ApiEventRequestModel model
                        )
                {
                        BOEvent boEvent = new BOEvent();
                        boEvent.SetProperties(
                                id,
                                model.Address1,
                                model.Address2,
                                model.CityId,
                                model.Date,
                                model.Description,
                                model.EndDate,
                                model.Facebook,
                                model.Name,
                                model.StartDate,
                                model.Website);
                        return boEvent;
                }

                public virtual ApiEventResponseModel MapBOToModel(
                        BOEvent boEvent)
                {
                        var model = new ApiEventResponseModel();

                        model.SetProperties(boEvent.Address1, boEvent.Address2, boEvent.CityId, boEvent.Date, boEvent.Description, boEvent.EndDate, boEvent.Facebook, boEvent.Id, boEvent.Name, boEvent.StartDate, boEvent.Website);

                        return model;
                }

                public virtual List<ApiEventResponseModel> MapBOToModel(
                        List<BOEvent> items)
                {
                        List<ApiEventResponseModel> response = new List<ApiEventResponseModel>();

                        items.ForEach(d =>
                        {
                                response.Add(this.MapBOToModel(d));
                        });

                        return response;
                }
        }
}

/*<Codenesium>
    <Hash>5a411997809ed78cb233032531d6848c</Hash>
</Codenesium>*/