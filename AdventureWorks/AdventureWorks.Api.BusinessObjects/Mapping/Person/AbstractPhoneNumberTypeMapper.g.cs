using System;
using System.Collections.Generic;
using AdventureWorksNS.Api.Contracts;
using AdventureWorksNS.Api.DataAccess;
namespace AdventureWorksNS.Api.BusinessObjects
{
	public abstract class AbstractBOLPhoneNumberTypeMapper
	{
		public virtual DTOPhoneNumberType MapModelToDTO(
			int phoneNumberTypeID,
			ApiPhoneNumberTypeRequestModel model
			)
		{
			DTOPhoneNumberType dtoPhoneNumberType = new DTOPhoneNumberType();

			dtoPhoneNumberType.SetProperties(
				phoneNumberTypeID,
				model.ModifiedDate,
				model.Name);
			return dtoPhoneNumberType;
		}

		public virtual ApiPhoneNumberTypeResponseModel MapDTOToModel(
			DTOPhoneNumberType dtoPhoneNumberType)
		{
			if (dtoPhoneNumberType == null)
			{
				return null;
			}

			var model = new ApiPhoneNumberTypeResponseModel();

			model.SetProperties(dtoPhoneNumberType.ModifiedDate, dtoPhoneNumberType.Name, dtoPhoneNumberType.PhoneNumberTypeID);

			return model;
		}

		public virtual List<ApiPhoneNumberTypeResponseModel> MapDTOToModel(
			List<DTOPhoneNumberType> dtos)
		{
			List<ApiPhoneNumberTypeResponseModel> response = new List<ApiPhoneNumberTypeResponseModel>();

			dtos.ForEach(d =>
			{
				response.Add(this.MapDTOToModel(d));
			});

			return response;
		}
	}
}

/*<Codenesium>
    <Hash>eb803134b61b54ae04fb504165b23da7</Hash>
</Codenesium>*/