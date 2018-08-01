using AdventureWorksNS.Api.Contracts;
using AdventureWorksNS.Api.DataAccess;
using System;
using System.Collections.Generic;

namespace AdventureWorksNS.Api.Services
{
	public abstract class BOLAbstractPhoneNumberTypeMapper
	{
		public virtual BOPhoneNumberType MapModelToBO(
			int phoneNumberTypeID,
			ApiPhoneNumberTypeRequestModel model
			)
		{
			BOPhoneNumberType boPhoneNumberType = new BOPhoneNumberType();
			boPhoneNumberType.SetProperties(
				phoneNumberTypeID,
				model.ModifiedDate,
				model.Name);
			return boPhoneNumberType;
		}

		public virtual ApiPhoneNumberTypeResponseModel MapBOToModel(
			BOPhoneNumberType boPhoneNumberType)
		{
			var model = new ApiPhoneNumberTypeResponseModel();

			model.SetProperties(boPhoneNumberType.PhoneNumberTypeID, boPhoneNumberType.ModifiedDate, boPhoneNumberType.Name);

			return model;
		}

		public virtual List<ApiPhoneNumberTypeResponseModel> MapBOToModel(
			List<BOPhoneNumberType> items)
		{
			List<ApiPhoneNumberTypeResponseModel> response = new List<ApiPhoneNumberTypeResponseModel>();

			items.ForEach(d =>
			{
				response.Add(this.MapBOToModel(d));
			});

			return response;
		}
	}
}

/*<Codenesium>
    <Hash>e54deb4ebcb8ed0d5496b37d53a7377e</Hash>
</Codenesium>*/