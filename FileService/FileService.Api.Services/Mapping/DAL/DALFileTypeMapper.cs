using FileServiceNS.Api.Contracts;
using FileServiceNS.Api.DataAccess;
using System;
using System.Collections.Generic;

namespace FileServiceNS.Api.Services
{
	public class DALFileTypeMapper : IDALFileTypeMapper
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
    <Hash>b404eda3f4c456bc30a26d87b0088bb8</Hash>
    <Hello>
		This code was generated using the Codenesium platform. You can visit our site at https://www.codenesium.com. 
	</Hello>
</Codenesium>*/