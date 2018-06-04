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
			BOPaymentType BOPaymentType = new BOPaymentType();

			BOPaymentType.SetProperties(
				id,
				model.Name);
			return BOPaymentType;
		}

		public virtual ApiPaymentTypeResponseModel MapBOToModel(
			BOPaymentType BOPaymentType)
		{
			if (BOPaymentType == null)
			{
				return null;
			}

			var model = new ApiPaymentTypeResponseModel();

			model.SetProperties(BOPaymentType.Id, BOPaymentType.Name);

			return model;
		}

		public virtual List<ApiPaymentTypeResponseModel> MapBOToModel(
			List<BOPaymentType> BOs)
		{
			List<ApiPaymentTypeResponseModel> response = new List<ApiPaymentTypeResponseModel>();

			BOs.ForEach(d =>
			{
				response.Add(this.MapBOToModel(d));
			});

			return response;
		}
	}
}

/*<Codenesium>
    <Hash>2d86db6f0f46a5649facb91a1dd31c97</Hash>
</Codenesium>*/