using System;
using System.Collections.Generic;
using AdventureWorksNS.Api.Contracts;
using AdventureWorksNS.Api.DataAccess;
namespace AdventureWorksNS.Api.BusinessObjects
{
	public abstract class AbstractBOLPersonPhoneMapper
	{
		public virtual DTOPersonPhone MapModelToDTO(
			int businessEntityID,
			ApiPersonPhoneRequestModel model
			)
		{
			DTOPersonPhone dtoPersonPhone = new DTOPersonPhone();

			dtoPersonPhone.SetProperties(
				businessEntityID,
				model.ModifiedDate,
				model.PhoneNumber,
				model.PhoneNumberTypeID);
			return dtoPersonPhone;
		}

		public virtual ApiPersonPhoneResponseModel MapDTOToModel(
			DTOPersonPhone dtoPersonPhone)
		{
			if (dtoPersonPhone == null)
			{
				return null;
			}

			var model = new ApiPersonPhoneResponseModel();

			model.SetProperties(dtoPersonPhone.BusinessEntityID, dtoPersonPhone.ModifiedDate, dtoPersonPhone.PhoneNumber, dtoPersonPhone.PhoneNumberTypeID);

			return model;
		}

		public virtual List<ApiPersonPhoneResponseModel> MapDTOToModel(
			List<DTOPersonPhone> dtos)
		{
			List<ApiPersonPhoneResponseModel> response = new List<ApiPersonPhoneResponseModel>();

			dtos.ForEach(d =>
			{
				response.Add(this.MapDTOToModel(d));
			});

			return response;
		}
	}
}

/*<Codenesium>
    <Hash>218e748a8b73f9149c142f0cc2af0068</Hash>
</Codenesium>*/