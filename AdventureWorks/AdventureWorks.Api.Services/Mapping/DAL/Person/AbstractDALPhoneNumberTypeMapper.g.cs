using AdventureWorksNS.Api.Contracts;
using AdventureWorksNS.Api.DataAccess;
using System;
using System.Collections.Generic;

namespace AdventureWorksNS.Api.Services
{
	public abstract class AbstractDALPhoneNumberTypeMapper
	{
		public virtual PhoneNumberType MapModelToBO(
			int phoneNumberTypeID,
			ApiPhoneNumberTypeServerRequestModel model
			)
		{
			PhoneNumberType item = new PhoneNumberType();
			item.SetProperties(
				phoneNumberTypeID,
				model.ModifiedDate,
				model.Name);
			return item;
		}

		public virtual ApiPhoneNumberTypeServerResponseModel MapBOToModel(
			PhoneNumberType item)
		{
			var model = new ApiPhoneNumberTypeServerResponseModel();

			model.SetProperties(item.PhoneNumberTypeID, item.ModifiedDate, item.Name);

			return model;
		}

		public virtual List<ApiPhoneNumberTypeServerResponseModel> MapBOToModel(
			List<PhoneNumberType> items)
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
    <Hash>9be665eb076f676001102ca13a0d9f3e</Hash>
</Codenesium>*/