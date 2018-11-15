using System;
using System.Collections.Generic;
using TicketingCRMNS.Api.DataAccess;

namespace TicketingCRMNS.Api.Services
{
	public abstract class BOLAbstractTicketStatuMapper
	{
		public virtual BOTicketStatu MapModelToBO(
			int id,
			ApiTicketStatuServerRequestModel model
			)
		{
			BOTicketStatu boTicketStatu = new BOTicketStatu();
			boTicketStatu.SetProperties(
				id,
				model.Name);
			return boTicketStatu;
		}

		public virtual ApiTicketStatuServerResponseModel MapBOToModel(
			BOTicketStatu boTicketStatu)
		{
			var model = new ApiTicketStatuServerResponseModel();

			model.SetProperties(boTicketStatu.Id, boTicketStatu.Name);

			return model;
		}

		public virtual List<ApiTicketStatuServerResponseModel> MapBOToModel(
			List<BOTicketStatu> items)
		{
			List<ApiTicketStatuServerResponseModel> response = new List<ApiTicketStatuServerResponseModel>();

			items.ForEach(d =>
			{
				response.Add(this.MapBOToModel(d));
			});

			return response;
		}
	}
}

/*<Codenesium>
    <Hash>f7c7ead39290ceb4d3841156524224ce</Hash>
</Codenesium>*/