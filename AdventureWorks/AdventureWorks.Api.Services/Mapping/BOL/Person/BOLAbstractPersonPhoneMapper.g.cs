using System;
using System.Collections.Generic;
using AdventureWorksNS.Api.Contracts;
using AdventureWorksNS.Api.DataAccess;
namespace AdventureWorksNS.Api.Services
{
	public abstract class BOLAbstractPersonPhoneMapper
	{
		public virtual BOPersonPhone MapModelToBO(
			int businessEntityID,
			ApiPersonPhoneRequestModel model
			)
		{
			BOPersonPhone BOPersonPhone = new BOPersonPhone();

			BOPersonPhone.SetProperties(
				businessEntityID,
				model.ModifiedDate,
				model.PhoneNumber,
				model.PhoneNumberTypeID);
			return BOPersonPhone;
		}

		public virtual ApiPersonPhoneResponseModel MapBOToModel(
			BOPersonPhone BOPersonPhone)
		{
			if (BOPersonPhone == null)
			{
				return null;
			}

			var model = new ApiPersonPhoneResponseModel();

			model.SetProperties(BOPersonPhone.BusinessEntityID, BOPersonPhone.ModifiedDate, BOPersonPhone.PhoneNumber, BOPersonPhone.PhoneNumberTypeID);

			return model;
		}

		public virtual List<ApiPersonPhoneResponseModel> MapBOToModel(
			List<BOPersonPhone> BOs)
		{
			List<ApiPersonPhoneResponseModel> response = new List<ApiPersonPhoneResponseModel>();

			BOs.ForEach(d =>
			{
				response.Add(this.MapBOToModel(d));
			});

			return response;
		}
	}
}

/*<Codenesium>
    <Hash>773a908ac8fa801aa5ccd2a31323ee04</Hash>
</Codenesium>*/