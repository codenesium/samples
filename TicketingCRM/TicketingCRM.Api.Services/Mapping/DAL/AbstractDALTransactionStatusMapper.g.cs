using System;
using System.Collections.Generic;
using TicketingCRMNS.Api.Contracts;
using TicketingCRMNS.Api.DataAccess;

namespace TicketingCRMNS.Api.Services
{
	public abstract class AbstractDALTransactionStatusMapper
	{
		public virtual TransactionStatus MapModelToEntity(
			int id,
			ApiTransactionStatusServerRequestModel model
			)
		{
			TransactionStatus item = new TransactionStatus();
			item.SetProperties(
				id,
				model.Name);
			return item;
		}

		public virtual ApiTransactionStatusServerResponseModel MapEntityToModel(
			TransactionStatus item)
		{
			var model = new ApiTransactionStatusServerResponseModel();

			model.SetProperties(item.Id,
			                    item.Name);

			return model;
		}

		public virtual List<ApiTransactionStatusServerResponseModel> MapEntityToModel(
			List<TransactionStatus> items)
		{
			List<ApiTransactionStatusServerResponseModel> response = new List<ApiTransactionStatusServerResponseModel>();

			items.ForEach(x =>
			{
				response.Add(this.MapEntityToModel(x));
			});

			return response;
		}
	}
}

/*<Codenesium>
    <Hash>5d3909d86a14408f02ecb3b38f9f774e</Hash>
</Codenesium>*/