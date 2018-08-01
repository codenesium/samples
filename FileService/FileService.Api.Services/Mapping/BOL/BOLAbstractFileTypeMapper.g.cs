using FileServiceNS.Api.Contracts;
using FileServiceNS.Api.DataAccess;
using System;
using System.Collections.Generic;

namespace FileServiceNS.Api.Services
{
	public abstract class BOLAbstractFileTypeMapper
	{
		public virtual BOFileType MapModelToBO(
			int id,
			ApiFileTypeRequestModel model
			)
		{
			BOFileType boFileType = new BOFileType();
			boFileType.SetProperties(
				id,
				model.Name);
			return boFileType;
		}

		public virtual ApiFileTypeResponseModel MapBOToModel(
			BOFileType boFileType)
		{
			var model = new ApiFileTypeResponseModel();

			model.SetProperties(boFileType.Id, boFileType.Name);

			return model;
		}

		public virtual List<ApiFileTypeResponseModel> MapBOToModel(
			List<BOFileType> items)
		{
			List<ApiFileTypeResponseModel> response = new List<ApiFileTypeResponseModel>();

			items.ForEach(d =>
			{
				response.Add(this.MapBOToModel(d));
			});

			return response;
		}
	}
}

/*<Codenesium>
    <Hash>120d9e8dd73ee36bcfe78caca6d2cf88</Hash>
</Codenesium>*/