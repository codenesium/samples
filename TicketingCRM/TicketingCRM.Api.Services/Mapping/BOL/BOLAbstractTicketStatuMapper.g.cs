using System;
using System.Collections.Generic;
using TicketingCRMNS.Api.Contracts;
using TicketingCRMNS.Api.DataAccess;

namespace TicketingCRMNS.Api.Services
{
	public abstract class BOLAbstractTicketStatuMapper
	{
		public virtual BOTicketStatu MapModelToBO(
			int id,
			ApiTicketStatuRequestModel model
			)
		{
			BOTicketStatu boTicketStatu = new BOTicketStatu();
			boTicketStatu.SetProperties(
				id,
				model.Name);
			return boTicketStatu;
		}

		public virtual ApiTicketStatuResponseModel MapBOToModel(
			BOTicketStatu boTicketStatu)
		{
			var model = new ApiTicketStatuResponseModel();

			model.SetProperties(boTicketStatu.Id, boTicketStatu.Name);

			return model;
		}

		public virtual List<ApiTicketStatuResponseModel> MapBOToModel(
			List<BOTicketStatu> items)
		{
			List<ApiTicketStatuResponseModel> response = new List<ApiTicketStatuResponseModel>();

			items.ForEach(d =>
			{
				response.Add(this.MapBOToModel(d));
			});

			return response;
		}
	}
}

/*<Codenesium>
    <Hash>abbfaed106f2c58b66b75d15541132ab</Hash>
</Codenesium>*/