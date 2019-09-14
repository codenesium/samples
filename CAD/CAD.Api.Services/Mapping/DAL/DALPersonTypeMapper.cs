using CADNS.Api.Contracts;
using CADNS.Api.DataAccess;
using System;
using System.Collections.Generic;

namespace CADNS.Api.Services
{
	public class DALPersonTypeMapper : IDALPersonTypeMapper
	{
		public virtual PersonType MapModelToEntity(
			int id,
			ApiPersonTypeServerRequestModel model
			)
		{
			PersonType item = new PersonType();
			item.SetProperties(
				id,
				model.Name);
			return item;
		}

		public virtual ApiPersonTypeServerResponseModel MapEntityToModel(
			PersonType item)
		{
			var model = new ApiPersonTypeServerResponseModel();

			model.SetProperties(item.Id,
			                    item.Name);

			return model;
		}

		public virtual List<ApiPersonTypeServerResponseModel> MapEntityToModel(
			List<PersonType> items)
		{
			List<ApiPersonTypeServerResponseModel> response = new List<ApiPersonTypeServerResponseModel>();

			items.ForEach(x =>
			{
				response.Add(this.MapEntityToModel(x));
			});

			return response;
		}
	}
}

/*<Codenesium>
    <Hash>0e13da77e8b3bf5076e4e6af5151cdfd</Hash>
    <Hello>
		This code was generated using the Codenesium platform. You can visit our site at https://www.codenesium.com. 
	</Hello>
</Codenesium>*/