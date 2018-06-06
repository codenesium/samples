using System;
using System.Collections.Generic;
using AdventureWorksNS.Api.Contracts;
using AdventureWorksNS.Api.DataAccess;
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

			model.SetProperties(boPhoneNumberType.ModifiedDate, boPhoneNumberType.Name, boPhoneNumberType.PhoneNumberTypeID);

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
    <Hash>26b85fc77ae87e63415bdd225fb62efc</Hash>
</Codenesium>*/