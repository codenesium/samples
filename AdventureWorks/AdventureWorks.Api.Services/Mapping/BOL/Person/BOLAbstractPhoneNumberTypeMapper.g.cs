using AdventureWorksNS.Api.DataAccess;
using System;
using System.Collections.Generic;

namespace AdventureWorksNS.Api.Services
{
	public abstract class BOLAbstractPhoneNumberTypeMapper
	{
		public virtual BOPhoneNumberType MapModelToBO(
			int phoneNumberTypeID,
			ApiPhoneNumberTypeServerRequestModel model
			)
		{
			BOPhoneNumberType boPhoneNumberType = new BOPhoneNumberType();
			boPhoneNumberType.SetProperties(
				phoneNumberTypeID,
				model.ModifiedDate,
				model.Name);
			return boPhoneNumberType;
		}

		public virtual ApiPhoneNumberTypeServerResponseModel MapBOToModel(
			BOPhoneNumberType boPhoneNumberType)
		{
			var model = new ApiPhoneNumberTypeServerResponseModel();

			model.SetProperties(boPhoneNumberType.PhoneNumberTypeID, boPhoneNumberType.ModifiedDate, boPhoneNumberType.Name);

			return model;
		}

		public virtual List<ApiPhoneNumberTypeServerResponseModel> MapBOToModel(
			List<BOPhoneNumberType> items)
		{
			List<ApiPhoneNumberTypeServerResponseModel> response = new List<ApiPhoneNumberTypeServerResponseModel>();

			items.ForEach(d =>
			{
				response.Add(this.MapBOToModel(d));
			});

			return response;
		}
	}
}

/*<Codenesium>
    <Hash>963c500c3338b46008f2852842333d04</Hash>
</Codenesium>*/