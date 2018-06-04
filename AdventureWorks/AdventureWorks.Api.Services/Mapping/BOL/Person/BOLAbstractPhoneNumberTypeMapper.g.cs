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
			BOPhoneNumberType BOPhoneNumberType = new BOPhoneNumberType();

			BOPhoneNumberType.SetProperties(
				phoneNumberTypeID,
				model.ModifiedDate,
				model.Name);
			return BOPhoneNumberType;
		}

		public virtual ApiPhoneNumberTypeResponseModel MapBOToModel(
			BOPhoneNumberType BOPhoneNumberType)
		{
			if (BOPhoneNumberType == null)
			{
				return null;
			}

			var model = new ApiPhoneNumberTypeResponseModel();

			model.SetProperties(BOPhoneNumberType.ModifiedDate, BOPhoneNumberType.Name, BOPhoneNumberType.PhoneNumberTypeID);

			return model;
		}

		public virtual List<ApiPhoneNumberTypeResponseModel> MapBOToModel(
			List<BOPhoneNumberType> BOs)
		{
			List<ApiPhoneNumberTypeResponseModel> response = new List<ApiPhoneNumberTypeResponseModel>();

			BOs.ForEach(d =>
			{
				response.Add(this.MapBOToModel(d));
			});

			return response;
		}
	}
}

/*<Codenesium>
    <Hash>bab3cc5fd8726050260aee570b225c41</Hash>
</Codenesium>*/