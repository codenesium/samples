using System;
using System.Collections.Generic;
using PetStoreNS.Api.Contracts;
using PetStoreNS.Api.DataAccess;
namespace PetStoreNS.Api.BusinessObjects
{
	public abstract class AbstractBOLPaymentTypeMapper
	{
		public virtual DTOPaymentType MapModelToDTO(
			int id,
			ApiPaymentTypeRequestModel model
			)
		{
			DTOPaymentType dtoPaymentType = new DTOPaymentType();

			dtoPaymentType.SetProperties(
				id,
				model.Name);
			return dtoPaymentType;
		}

		public virtual ApiPaymentTypeResponseModel MapDTOToModel(
			DTOPaymentType dtoPaymentType)
		{
			if (dtoPaymentType == null)
			{
				return null;
			}

			var model = new ApiPaymentTypeResponseModel();

			model.SetProperties(dtoPaymentType.Id, dtoPaymentType.Name);

			return model;
		}

		public virtual List<ApiPaymentTypeResponseModel> MapDTOToModel(
			List<DTOPaymentType> dtos)
		{
			List<ApiPaymentTypeResponseModel> response = new List<ApiPaymentTypeResponseModel>();

			dtos.ForEach(d =>
			{
				response.Add(this.MapDTOToModel(d));
			});

			return response;
		}
	}
}

/*<Codenesium>
    <Hash>baccb468bf04629418c9bf2b98d7cc51</Hash>
</Codenesium>*/