using System;
using System.Collections.Generic;
using PetStoreNS.Api.Contracts;
using PetStoreNS.Api.DataAccess;
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
    <Hash>1f1f43a04be9deabefc344460e044200</Hash>
</Codenesium>*/