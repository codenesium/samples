using System;
using System.Collections.Generic;
using TicketingCRMNS.Api.Contracts;
using TicketingCRMNS.Api.DataAccess;

namespace TicketingCRMNS.Api.Services
{
	public abstract class AbstractDALTransactionStatuMapper
	{
		public virtual TransactionStatu MapModelToEntity(
			int id,
			ApiTransactionStatuServerRequestModel model
			)
		{
			TransactionStatu item = new TransactionStatu();
			item.SetProperties(
				id,
				model.Name);
			return item;
		}

		public virtual ApiTransactionStatuServerResponseModel MapEntityToModel(
			TransactionStatu item)
		{
			var model = new ApiTransactionStatuServerResponseModel();

			model.SetProperties(item.Id,
			                    item.Name);

			return model;
		}

		public virtual List<ApiTransactionStatuServerResponseModel> MapEntityToModel(
			List<TransactionStatu> items)
		{
			List<ApiTransactionStatuServerResponseModel> response = new List<ApiTransactionStatuServerResponseModel>();

			items.ForEach(x =>
			{
				response.Add(this.MapEntityToModel(x));
			});

			return response;
		}
	}
}

/*<Codenesium>
    <Hash>6e116b9f586469c4753701edfb5b04ee</Hash>
</Codenesium>*/