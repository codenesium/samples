using NebulaNS.Api.DataAccess;
using System;
using System.Collections.Generic;

namespace NebulaNS.Api.Services
{
	public abstract class BOLAbstractVersionInfoMapper
	{
		public virtual BOVersionInfo MapModelToBO(
			long version,
			ApiVersionInfoServerRequestModel model
			)
		{
			BOVersionInfo boVersionInfo = new BOVersionInfo();
			boVersionInfo.SetProperties(
				version,
				model.AppliedOn,
				model.Description);
			return boVersionInfo;
		}

		public virtual ApiVersionInfoServerResponseModel MapBOToModel(
			BOVersionInfo boVersionInfo)
		{
			var model = new ApiVersionInfoServerResponseModel();

			model.SetProperties(boVersionInfo.Version, boVersionInfo.AppliedOn, boVersionInfo.Description);

			return model;
		}

		public virtual List<ApiVersionInfoServerResponseModel> MapBOToModel(
			List<BOVersionInfo> items)
		{
			List<ApiVersionInfoServerResponseModel> response = new List<ApiVersionInfoServerResponseModel>();

			items.ForEach(d =>
			{
				response.Add(this.MapBOToModel(d));
			});

			return response;
		}
	}
}

/*<Codenesium>
    <Hash>adb5ce7b9b6890f2bb68dbdceb62d1d8</Hash>
</Codenesium>*/