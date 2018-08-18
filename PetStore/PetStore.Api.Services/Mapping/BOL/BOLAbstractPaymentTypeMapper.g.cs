using PetStoreNS.Api.Contracts;
using PetStoreNS.Api.DataAccess;
using System;
using System.Collections.Generic;

namespace PetStoreNS.Api.Services
{
	public abstract class BOLAbstractPaymentTypeMapper
	{
		public virtual BOPaymentType MapModelToBO(
			int id,
			ApiPaymentTypeRequestModel model
			)
		{
			BOPaymentType boPaymentType = new BOPaymentType();
			boPaymentType.SetProperties(
				id,
				model.Name);
			return boPaymentType;
		}

		public virtual ApiPaymentTypeResponseModel MapBOToModel(
			BOPaymentType boPaymentType)
		{
			var model = new ApiPaymentTypeResponseModel();

			model.SetProperties(boPaymentType.Id, boPaymentType.Name);

			return model;
		}

		public virtual List<ApiPaymentTypeResponseModel> MapBOToModel(
			List<BOPaymentType> items)
		{
			List<ApiPaymentTypeResponseModel> response = new List<ApiPaymentTypeResponseModel>();

			items.ForEach(d =>
			{
				response.Add(this.MapBOToModel(d));
			});

			return response;
		}
	}
}

/*<Codenesium>
    <Hash>9c808455dd38dbc174bab8a369a837ed</Hash>
</Codenesium>*/