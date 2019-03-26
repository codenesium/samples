using AdventureWorksNS.Api.Contracts;
using AdventureWorksNS.Api.DataAccess;
using System;
using System.Collections.Generic;

namespace AdventureWorksNS.Api.Services
{
	public abstract class AbstractDALPhoneNumberTypeMapper
	{
		public virtual PhoneNumberType MapModelToEntity(
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

		public virtual ApiPhoneNumberTypeServerResponseModel MapEntityToModel(
			PhoneNumberType item)
		{
			var model = new ApiPhoneNumberTypeServerResponseModel();

			model.SetProperties(item.PhoneNumberTypeID,
			                    item.ModifiedDate,
			                    item.Name);

			return model;
		}

		public virtual List<ApiPhoneNumberTypeServerResponseModel> MapEntityToModel(
			List<PhoneNumberType> items)
		{
			List<ApiPhoneNumberTypeServerResponseModel> response = new List<ApiPhoneNumberTypeServerResponseModel>();

			items.ForEach(x =>
			{
				response.Add(this.MapEntityToModel(x));
			});

			return response;
		}
	}
}

/*<Codenesium>
    <Hash>5364f60e7a4a6fa7c00389ab8404fa03</Hash>
</Codenesium>*/