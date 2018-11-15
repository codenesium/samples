using System;
using System.Collections.Generic;
using TicketingCRMNS.Api.DataAccess;

namespace TicketingCRMNS.Api.Services
{
	public abstract class BOLAbstractTransactionStatuMapper
	{
		public virtual BOTransactionStatu MapModelToBO(
			int id,
			ApiTransactionStatuServerRequestModel model
			)
		{
			BOTransactionStatu boTransactionStatu = new BOTransactionStatu();
			boTransactionStatu.SetProperties(
				id,
				model.Name);
			return boTransactionStatu;
		}

		public virtual ApiTransactionStatuServerResponseModel MapBOToModel(
			BOTransactionStatu boTransactionStatu)
		{
			var model = new ApiTransactionStatuServerResponseModel();

			model.SetProperties(boTransactionStatu.Id, boTransactionStatu.Name);

			return model;
		}

		public virtual List<ApiTransactionStatuServerResponseModel> MapBOToModel(
			List<BOTransactionStatu> items)
		{
			List<ApiTransactionStatuServerResponseModel> response = new List<ApiTransactionStatuServerResponseModel>();

			items.ForEach(d =>
			{
				response.Add(this.MapBOToModel(d));
			});

			return response;
		}
	}
}

/*<Codenesium>
    <Hash>27b09f2c68d1fed4d5f1a08a52717228</Hash>
</Codenesium>*/