using FileServiceNS.Api.Contracts;
using FileServiceNS.Api.DataAccess;
using System;
using System.Collections.Generic;

namespace FileServiceNS.Api.Services
{
	public class DALFileMapper : IDALFileMapper
	{
		public virtual File MapModelToEntity(
			int id,
			ApiFileServerRequestModel model
			)
		{
			File item = new File();
			item.SetProperties(
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
			return item;
		}

		public virtual ApiFileServerResponseModel MapEntityToModel(
			File item)
		{
			var model = new ApiFileServerResponseModel();

			model.SetProperties(item.Id,
			                    item.BucketId,
			                    item.DateCreated,
			                    item.Description,
			                    item.Expiration,
			                    item.Extension,
			                    item.ExternalId,
			                    item.FileSizeInByte,
			                    item.FileTypeId,
			                    item.Location,
			                    item.PrivateKey,
			                    item.PublicKey);
			if (item.BucketIdNavigation != null)
			{
				var bucketIdModel = new ApiBucketServerResponseModel();
				bucketIdModel.SetProperties(
					item.BucketIdNavigation.Id,
					item.BucketIdNavigation.ExternalId,
					item.BucketIdNavigation.Name);

				model.SetBucketIdNavigation(bucketIdModel);
			}

			if (item.FileTypeIdNavigation != null)
			{
				var fileTypeIdModel = new ApiFileTypeServerResponseModel();
				fileTypeIdModel.SetProperties(
					item.FileTypeIdNavigation.Id,
					item.FileTypeIdNavigation.Name);

				model.SetFileTypeIdNavigation(fileTypeIdModel);
			}

			return model;
		}

		public virtual List<ApiFileServerResponseModel> MapEntityToModel(
			List<File> items)
		{
			List<ApiFileServerResponseModel> response = new List<ApiFileServerResponseModel>();

			items.ForEach(x =>
			{
				response.Add(this.MapEntityToModel(x));
			});

			return response;
		}
	}
}

/*<Codenesium>
    <Hash>6cb875693adb67fe354d7d7b13f5e032</Hash>
    <Hello>
		This code was generated using the Codenesium platform. You can visit our site at https://www.codenesium.com. 
	</Hello>
</Codenesium>*/