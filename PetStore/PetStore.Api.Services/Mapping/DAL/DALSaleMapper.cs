using PetStoreNS.Api.Contracts;
using PetStoreNS.Api.DataAccess;
using System;
using System.Collections.Generic;

namespace PetStoreNS.Api.Services
{
	public class DALSaleMapper : IDALSaleMapper
	{
		public virtual Sale MapModelToEntity(
			int id,
			ApiSaleServerRequestModel model
			)
		{
			Sale item = new Sale();
			item.SetProperties(
				id,
				model.Amount,
				model.FirstName,
				model.LastName,
				model.PaymentTypeId,
				model.PetId,
				model.Phone);
			return item;
		}

		public virtual ApiSaleServerResponseModel MapEntityToModel(
			Sale item)
		{
			var model = new ApiSaleServerResponseModel();

			model.SetProperties(item.Id,
			                    item.Amount,
			                    item.FirstName,
			                    item.LastName,
			                    item.PaymentTypeId,
			                    item.PetId,
			                    item.Phone);
			if (item.PaymentTypeIdNavigation != null)
			{
				var paymentTypeIdModel = new ApiPaymentTypeServerResponseModel();
				paymentTypeIdModel.SetProperties(
					item.PaymentTypeIdNavigation.Id,
					item.PaymentTypeIdNavigation.Name);

				model.SetPaymentTypeIdNavigation(paymentTypeIdModel);
			}

			if (item.PetIdNavigation != null)
			{
				var petIdModel = new ApiPetServerResponseModel();
				petIdModel.SetProperties(
					item.PetIdNavigation.Id,
					item.PetIdNavigation.AcquiredDate,
					item.PetIdNavigation.BreedId,
					item.PetIdNavigation.Description,
					item.PetIdNavigation.PenId,
					item.PetIdNavigation.Price);

				model.SetPetIdNavigation(petIdModel);
			}

			return model;
		}

		public virtual List<ApiSaleServerResponseModel> MapEntityToModel(
			List<Sale> items)
		{
			List<ApiSaleServerResponseModel> response = new List<ApiSaleServerResponseModel>();

			items.ForEach(x =>
			{
				response.Add(this.MapEntityToModel(x));
			});

			return response;
		}
	}
}

/*<Codenesium>
    <Hash>9878cb62a39a565cb95f2481d380566c</Hash>
    <Hello>
		This code was generated using the Codenesium platform. You can visit our site at https://www.codenesium.com. 
	</Hello>
</Codenesium>*/