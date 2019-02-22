using CADNS.Api.Contracts;
using CADNS.Api.DataAccess;
using System;
using System.Collections.Generic;

namespace CADNS.Api.Services
{
	public abstract class AbstractDALOfficerMapper
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
    <Hash>0bdd4d847c98b5b2d38864a0b8aff95d</Hash>
</Codenesium>*/