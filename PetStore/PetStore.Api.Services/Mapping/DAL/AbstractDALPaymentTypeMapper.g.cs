using PetStoreNS.Api.Contracts;
using PetStoreNS.Api.DataAccess;
using System;
using System.Collections.Generic;

namespace PetStoreNS.Api.Services
{
	public abstract class AbstractDALPaymentTypeMapper
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
    <Hash>5f09ff48e6e22c9f7154c01d113552be</Hash>
</Codenesium>*/