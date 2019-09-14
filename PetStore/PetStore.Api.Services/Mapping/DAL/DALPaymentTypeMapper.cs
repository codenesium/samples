using PetStoreNS.Api.Contracts;
using PetStoreNS.Api.DataAccess;
using System;
using System.Collections.Generic;

namespace PetStoreNS.Api.Services
{
	public class DALPaymentTypeMapper : IDALPaymentTypeMapper
	{
		public virtual PaymentType MapModelToEntity(
			int id,
			ApiPaymentTypeServerRequestModel model
			)
		{
			PaymentType item = new PaymentType();
			item.SetProperties(
				id,
				model.Name);
			return item;
		}

		public virtual ApiPaymentTypeServerResponseModel MapEntityToModel(
			PaymentType item)
		{
			var model = new ApiPaymentTypeServerResponseModel();

			model.SetProperties(item.Id,
			                    item.Name);

			return model;
		}

		public virtual List<ApiPaymentTypeServerResponseModel> MapEntityToModel(
			List<PaymentType> items)
		{
			List<ApiPaymentTypeServerResponseModel> response = new List<ApiPaymentTypeServerResponseModel>();

			items.ForEach(x =>
			{
				response.Add(this.MapEntityToModel(x));
			});

			return response;
		}
	}
}

/*<Codenesium>
    <Hash>a75e504e3106a1bd90f129ade34355e9</Hash>
    <Hello>
		This code was generated using the Codenesium platform. You can visit our site at https://www.codenesium.com. 
	</Hello>
</Codenesium>*/