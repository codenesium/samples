using System;
using System.Collections.Generic;
using FileServiceNS.Api.Contracts;
using FileServiceNS.Api.DataAccess;
namespace FileServiceNS.Api.BusinessObjects
{
	public abstract class AbstractBOLFileMapper
	{
		public virtual DTOFile MapModelToDTO(
			int id,
			ApiFileRequestModel model
			)
		{
			DTOFile dtoFile = new DTOFile();

			dtoFile.SetProperties(
				id,
				model.BucketId,
				model.DateCreated,
				model.Description,
				model.Expiration,
				model.Extension,
				model.ExternalId,
				model.FileSizeInBytes,
				model.FileTypeId,
				model.Location,
				model.PrivateKey,
				model.PublicKey);
			return dtoFile;
		}

		public virtual ApiFileResponseModel MapDTOToModel(
			DTOFile dtoFile)
		{
			if (dtoFile == null)
			{
				return null;
			}

			var model = new ApiFileResponseModel();

			model.SetProperties(dtoFile.BucketId, dtoFile.DateCreated, dtoFile.Description, dtoFile.Expiration, dtoFile.Extension, dtoFile.ExternalId, dtoFile.FileSizeInBytes, dtoFile.FileTypeId, dtoFile.Id, dtoFile.Location, dtoFile.PrivateKey, dtoFile.PublicKey);

			return model;
		}

		public virtual List<ApiFileResponseModel> MapDTOToModel(
			List<DTOFile> dtos)
		{
			List<ApiFileResponseModel> response = new List<ApiFileResponseModel>();

			dtos.ForEach(d =>
			{
				response.Add(this.MapDTOToModel(d));
			});

			return response;
		}
	}
}

/*<Codenesium>
    <Hash>8a6604eb9a548f188f2eadd2e17a7ed2</Hash>
</Codenesium>*/