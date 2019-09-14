using PetStoreNS.Api.Contracts;
using PetStoreNS.Api.DataAccess;
using System;
using System.Collections.Generic;

namespace PetStoreNS.Api.Services
{
	public class DALSpeciesMapper : IDALSpeciesMapper
	{
		public virtual Species MapModelToEntity(
			int id,
			ApiSpeciesServerRequestModel model
			)
		{
			Species item = new Species();
			item.SetProperties(
				id,
				model.Name);
			return item;
		}

		public virtual ApiSpeciesServerResponseModel MapEntityToModel(
			Species item)
		{
			var model = new ApiSpeciesServerResponseModel();

			model.SetProperties(item.Id,
			                    item.Name);

			return model;
		}

		public virtual List<ApiSpeciesServerResponseModel> MapEntityToModel(
			List<Species> items)
		{
			List<ApiSpeciesServerResponseModel> response = new List<ApiSpeciesServerResponseModel>();

			items.ForEach(x =>
			{
				response.Add(this.MapEntityToModel(x));
			});

			return response;
		}
	}
}

/*<Codenesium>
    <Hash>86323713e1a096f519e1616b90f7e2dd</Hash>
    <Hello>
		This code was generated using the Codenesium platform. You can visit our site at https://www.codenesium.com. 
	</Hello>
</Codenesium>*/