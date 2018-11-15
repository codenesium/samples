using PetStoreNS.Api.DataAccess;
using System;
using System.Collections.Generic;

namespace PetStoreNS.Api.Services
{
	public abstract class BOLAbstractPaymentTypeMapper
	{
		public virtual BOPaymentType MapModelToBO(
			int id,
			ApiPaymentTypeServerRequestModel model
			)
		{
			BOPaymentType boPaymentType = new BOPaymentType();
			boPaymentType.SetProperties(
				id,
				model.Name);
			return boPaymentType;
		}

		public virtual ApiPaymentTypeServerResponseModel MapBOToModel(
			BOPaymentType boPaymentType)
		{
			var model = new ApiPaymentTypeServerResponseModel();

			model.SetProperties(boPaymentType.Id, boPaymentType.Name);

			return model;
		}

		public virtual List<ApiPaymentTypeServerResponseModel> MapBOToModel(
			List<BOPaymentType> items)
		{
			List<ApiPaymentTypeServerResponseModel> response = new List<ApiPaymentTypeServerResponseModel>();

			items.ForEach(d =>
			{
				response.Add(this.MapBOToModel(d));
			});

			return response;
		}
	}
}

/*<Codenesium>
    <Hash>0cc958f251fe96adc3d5e9676bb27ebf</Hash>
</Codenesium>*/