using System;
using System.Collections.Generic;
using FileServiceNS.Api.Contracts;
using FileServiceNS.Api.DataAccess;
namespace FileServiceNS.Api.BusinessObjects
{
	public abstract class AbstractBOLFileTypeMapper
	{
		public virtual DTOFileType MapModelToDTO(
			int id,
			ApiFileTypeRequestModel model
			)
		{
			DTOFileType dtoFileType = new DTOFileType();

			dtoFileType.SetProperties(
				id,
				model.Name);
			return dtoFileType;
		}

		public virtual ApiFileTypeResponseModel MapDTOToModel(
			DTOFileType dtoFileType)
		{
			if (dtoFileType == null)
			{
				return null;
			}

			var model = new ApiFileTypeResponseModel();

			model.SetProperties(dtoFileType.Id, dtoFileType.Name);

			return model;
		}

		public virtual List<ApiFileTypeResponseModel> MapDTOToModel(
			List<DTOFileType> dtos)
		{
			List<ApiFileTypeResponseModel> response = new List<ApiFileTypeResponseModel>();

			dtos.ForEach(d =>
			{
				response.Add(this.MapDTOToModel(d));
			});

			return response;
		}
	}
}

/*<Codenesium>
    <Hash>13d6f4f67b175885fd49187d05d46a47</Hash>
</Codenesium>*/