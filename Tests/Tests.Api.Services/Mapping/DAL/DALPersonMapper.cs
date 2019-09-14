using System;
using System.Collections.Generic;
using TestsNS.Api.Contracts;
using TestsNS.Api.DataAccess;

namespace TestsNS.Api.Services
{
	public class DALPersonMapper : IDALPersonMapper
	{
		public virtual Person MapModelToEntity(
			int personId,
			ApiPersonServerRequestModel model
			)
		{
			Person item = new Person();
			item.SetProperties(
				personId,
				model.PersonName);
			return item;
		}

		public virtual ApiPersonServerResponseModel MapEntityToModel(
			Person item)
		{
			var model = new ApiPersonServerResponseModel();

			model.SetProperties(item.PersonId,
			                    item.PersonName);

			return model;
		}

		public virtual List<ApiPersonServerResponseModel> MapEntityToModel(
			List<Person> items)
		{
			List<ApiPersonServerResponseModel> response = new List<ApiPersonServerResponseModel>();

			items.ForEach(x =>
			{
				response.Add(this.MapEntityToModel(x));
			});

			return response;
		}
	}
}

/*<Codenesium>
    <Hash>27a0b7f91bb7fb3d4674432f2c7b7fec</Hash>
    <Hello>
		This code was generated using the Codenesium platform. You can visit our site at https://www.codenesium.com. 
	</Hello>
</Codenesium>*/