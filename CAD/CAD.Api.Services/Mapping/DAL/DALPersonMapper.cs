using CADNS.Api.Contracts;
using CADNS.Api.DataAccess;
using System;
using System.Collections.Generic;

namespace CADNS.Api.Services
{
	public class DALPersonMapper : IDALPersonMapper
	{
		public virtual Person MapModelToEntity(
			int id,
			ApiPersonServerRequestModel model
			)
		{
			Person item = new Person();
			item.SetProperties(
				id,
				model.FirstName,
				model.LastName,
				model.Phone,
				model.Ssn);
			return item;
		}

		public virtual ApiPersonServerResponseModel MapEntityToModel(
			Person item)
		{
			var model = new ApiPersonServerResponseModel();

			model.SetProperties(item.Id,
			                    item.FirstName,
			                    item.LastName,
			                    item.Phone,
			                    item.Ssn);

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
    <Hash>8dfdc47f12bfadf2767891f92e18f950</Hash>
    <Hello>
		This code was generated using the Codenesium platform. You can visit our site at https://www.codenesium.com. 
	</Hello>
</Codenesium>*/