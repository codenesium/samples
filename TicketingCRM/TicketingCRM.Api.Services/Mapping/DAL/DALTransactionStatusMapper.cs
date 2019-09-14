using System;
using System.Collections.Generic;
using TicketingCRMNS.Api.Contracts;
using TicketingCRMNS.Api.DataAccess;

namespace TicketingCRMNS.Api.Services
{
	public class DALTransactionStatusMapper : IDALTransactionStatusMapper
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
    <Hash>fa7eb0b023ca32e19a37a2f3dc607884</Hash>
    <Hello>
		This code was generated using the Codenesium platform. You can visit our site at https://www.codenesium.com. 
	</Hello>
</Codenesium>*/