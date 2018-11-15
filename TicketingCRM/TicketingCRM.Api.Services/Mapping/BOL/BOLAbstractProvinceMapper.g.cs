using System;
using System.Collections.Generic;
using TicketingCRMNS.Api.DataAccess;

namespace TicketingCRMNS.Api.Services
{
	public abstract class BOLAbstractProvinceMapper
	{
		public virtual BOProvince MapModelToBO(
			int id,
			ApiProvinceServerRequestModel model
			)
		{
			BOProvince boProvince = new BOProvince();
			boProvince.SetProperties(
				id,
				model.CountryId,
				model.Name);
			return boProvince;
		}

		public virtual ApiProvinceServerResponseModel MapBOToModel(
			BOProvince boProvince)
		{
			var model = new ApiProvinceServerResponseModel();

			model.SetProperties(boProvince.Id, boProvince.CountryId, boProvince.Name);

			return model;
		}

		public virtual List<ApiProvinceServerResponseModel> MapBOToModel(
			List<BOProvince> items)
		{
			List<ApiProvinceServerResponseModel> response = new List<ApiProvinceServerResponseModel>();

			items.ForEach(d =>
			{
				response.Add(this.MapBOToModel(d));
			});

			return response;
		}
	}
}

/*<Codenesium>
    <Hash>6f848c5b1c0b3cfdea095393426ea6da</Hash>
</Codenesium>*/