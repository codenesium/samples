using FileServiceNS.Api.Contracts;
using FileServiceNS.Api.DataAccess;
using System;
using System.Collections.Generic;

namespace FileServiceNS.Api.Services
{
	public abstract class AbstractDALFileTypeMapper
	{
		public virtual FileType MapModelToEntity(
			int id,
			ApiFileTypeServerRequestModel model
			)
		{
			FileType item = new FileType();
			item.SetProperties(
				id,
				model.Name);
			return item;
		}

		public virtual ApiFileTypeServerResponseModel MapEntityToModel(
			FileType item)
		{
			var model = new ApiFileTypeServerResponseModel();

			model.SetProperties(item.Id,
			                    item.Name);

			return model;
		}

		public virtual List<ApiFileTypeServerResponseModel> MapEntityToModel(
			List<FileType> items)
		{
			List<ApiFileTypeServerResponseModel> response = new List<ApiFileTypeServerResponseModel>();

			items.ForEach(x =>
			{
				response.Add(this.MapEntityToModel(x));
			});

			return response;
		}
	}
}

/*<Codenesium>
    <Hash>044c8723281e6f9774f78b3e76f5d3f4</Hash>
</Codenesium>*/