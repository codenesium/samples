using System;
using System.Collections.Generic;
using AdventureWorksNS.Api.Contracts;
using AdventureWorksNS.Api.DataAccess;
namespace AdventureWorksNS.Api.BusinessObjects
{
	public abstract class AbstractBOLContactTypeMapper
	{
		public virtual DTOContactType MapModelToDTO(
			int contactTypeID,
			ApiContactTypeRequestModel model
			)
		{
			DTOContactType dtoContactType = new DTOContactType();

			dtoContactType.SetProperties(
				contactTypeID,
				model.ModifiedDate,
				model.Name);
			return dtoContactType;
		}

		public virtual ApiContactTypeResponseModel MapDTOToModel(
			DTOContactType dtoContactType)
		{
			if (dtoContactType == null)
			{
				return null;
			}

			var model = new ApiContactTypeResponseModel();

			model.SetProperties(dtoContactType.ContactTypeID, dtoContactType.ModifiedDate, dtoContactType.Name);

			return model;
		}

		public virtual List<ApiContactTypeResponseModel> MapDTOToModel(
			List<DTOContactType> dtos)
		{
			List<ApiContactTypeResponseModel> response = new List<ApiContactTypeResponseModel>();

			dtos.ForEach(d =>
			{
				response.Add(this.MapDTOToModel(d));
			});

			return response;
		}
	}
}

/*<Codenesium>
    <Hash>4ddf66e56aaedbee0b90a858c2c67ff3</Hash>
</Codenesium>*/