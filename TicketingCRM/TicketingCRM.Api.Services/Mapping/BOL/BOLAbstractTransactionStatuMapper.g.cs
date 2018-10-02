using System;
using System.Collections.Generic;
using TicketingCRMNS.Api.Contracts;
using TicketingCRMNS.Api.DataAccess;

namespace TicketingCRMNS.Api.Services
{
	public abstract class BOLAbstractTransactionStatuMapper
	{
		public virtual BOTransactionStatu MapModelToBO(
			int id,
			ApiTransactionStatuRequestModel model
			)
		{
			BOTransactionStatu boTransactionStatu = new BOTransactionStatu();
			boTransactionStatu.SetProperties(
				id,
				model.Name);
			return boTransactionStatu;
		}

		public virtual ApiTransactionStatuResponseModel MapBOToModel(
			BOTransactionStatu boTransactionStatu)
		{
			var model = new ApiTransactionStatuResponseModel();

			model.SetProperties(boTransactionStatu.Id, boTransactionStatu.Name);

			return model;
		}

		public virtual List<ApiTransactionStatuResponseModel> MapBOToModel(
			List<BOTransactionStatu> items)
		{
			List<ApiTransactionStatuResponseModel> response = new List<ApiTransactionStatuResponseModel>();

			items.ForEach(d =>
			{
				response.Add(this.MapBOToModel(d));
			});

			return response;
		}
	}
}

/*<Codenesium>
    <Hash>2a5223007a1795edc25f7499df03c7ed</Hash>
</Codenesium>*/