using FileServiceNS.Api.DataAccess;
using System;
using System.Collections.Generic;

namespace FileServiceNS.Api.Services
{
	public abstract class BOLAbstractFileMapper
	{
		public virtual BOFile MapModelToBO(
			int id,
			ApiFileServerRequestModel model
			)
		{
			BOFile boFile = new BOFile();
			boFile.SetProperties(
				id,
				model.BucketId,
				model.DateCreated,
				model.Description,
				model.Expiration,
				model.Extension,
				model.ExternalId,
				model.FileSizeInByte,
				model.FileTypeId,
				model.Location,
				model.PrivateKey,
				model.PublicKey);
			return boFile;
		}

		public virtual ApiFileServerResponseModel MapBOToModel(
			BOFile boFile)
		{
			var model = new ApiFileServerResponseModel();

			model.SetProperties(boFile.Id, boFile.BucketId, boFile.DateCreated, boFile.Description, boFile.Expiration, boFile.Extension, boFile.ExternalId, boFile.FileSizeInByte, boFile.FileTypeId, boFile.Location, boFile.PrivateKey, boFile.PublicKey);

			return model;
		}

		public virtual List<ApiFileServerResponseModel> MapBOToModel(
			List<BOFile> items)
		{
			List<ApiFileServerResponseModel> response = new List<ApiFileServerResponseModel>();

			items.ForEach(d =>
			{
				response.Add(this.MapBOToModel(d));
			});

			return response;
		}
	}
}

/*<Codenesium>
    <Hash>fd1dcca6e1b3144e394c6b0b18aeb3bb</Hash>
</Codenesium>*/