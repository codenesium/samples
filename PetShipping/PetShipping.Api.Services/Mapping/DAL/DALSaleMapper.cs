using PetShippingNS.Api.Contracts;
using PetShippingNS.Api.DataAccess;
using System;
using System.Collections.Generic;

namespace PetShippingNS.Api.Services
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
				model.CutomerId,
				model.Note,
				model.PetId,
				model.SaleDate,
				model.SalesPersonId);
			return item;
		}

		public virtual ApiSaleServerResponseModel MapEntityToModel(
			Sale item)
		{
			var model = new ApiSaleServerResponseModel();

			model.SetProperties(item.Id,
			                    item.Amount,
			                    item.CutomerId,
			                    item.Note,
			                    item.PetId,
			                    item.SaleDate,
			                    item.SalesPersonId);
			if (item.PetIdNavigation != null)
			{
				var petIdModel = new ApiPetServerResponseModel();
				petIdModel.SetProperties(
					item.PetIdNavigation.Id,
					item.PetIdNavigation.BreedId,
					item.PetIdNavigation.ClientId,
					item.PetIdNavigation.Name,
					item.PetIdNavigation.Weight);

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
    <Hash>ef5e0607a24cd1e0c1ecb4ab7f95de73</Hash>
    <Hello>
		This code was generated using the Codenesium platform. You can visit our site at https://www.codenesium.com. 
	</Hello>
</Codenesium>*/