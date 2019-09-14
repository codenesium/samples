using CADNS.Api.Contracts;
using CADNS.Api.DataAccess;
using System;
using System.Collections.Generic;

namespace CADNS.Api.Services
{
	public class DALOfficerMapper : IDALOfficerMapper
	{
		public virtual Officer MapModelToEntity(
			int id,
			ApiOfficerServerRequestModel model
			)
		{
			Officer item = new Officer();
			item.SetProperties(
				id,
				model.Badge,
				model.Email,
				model.FirstName,
				model.LastName,
				model.Password);
			return item;
		}

		public virtual ApiOfficerServerResponseModel MapEntityToModel(
			Officer item)
		{
			var model = new ApiOfficerServerResponseModel();

			model.SetProperties(item.Id,
			                    item.Badge,
			                    item.Email,
			                    item.FirstName,
			                    item.LastName,
			                    item.Password);

			return model;
		}

		public virtual List<ApiOfficerServerResponseModel> MapEntityToModel(
			List<Officer> items)
		{
			List<ApiOfficerServerResponseModel> response = new List<ApiOfficerServerResponseModel>();

			items.ForEach(x =>
			{
				response.Add(this.MapEntityToModel(x));
			});

			return response;
		}
	}
}

/*<Codenesium>
    <Hash>7f13dba6d3f48d1aad998caab33ad295</Hash>
    <Hello>
		This code was generated using the Codenesium platform. You can visit our site at https://www.codenesium.com. 
	</Hello>
</Codenesium>*/