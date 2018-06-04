using System;
using System.Collections.Generic;
using FileServiceNS.Api.Contracts;
using FileServiceNS.Api.DataAccess;
namespace FileServiceNS.Api.Services
{
	public abstract class BOLAbstractVersionInfoMapper
	{
		public virtual BOVersionInfo MapModelToBO(
			long version,
			ApiVersionInfoRequestModel model
			)
		{
			BOVersionInfo BOVersionInfo = new BOVersionInfo();

			BOVersionInfo.SetProperties(
				version,
				model.AppliedOn,
				model.Description);
			return BOVersionInfo;
		}

		public virtual ApiVersionInfoResponseModel MapBOToModel(
			BOVersionInfo BOVersionInfo)
		{
			if (BOVersionInfo == null)
			{
				return null;
			}

			var model = new ApiVersionInfoResponseModel();

			model.SetProperties(BOVersionInfo.AppliedOn, BOVersionInfo.Description, BOVersionInfo.Version);

			return model;
		}

		public virtual List<ApiVersionInfoResponseModel> MapBOToModel(
			List<BOVersionInfo> BOs)
		{
			List<ApiVersionInfoResponseModel> response = new List<ApiVersionInfoResponseModel>();

			BOs.ForEach(d =>
			{
				response.Add(this.MapBOToModel(d));
			});

			return response;
		}
	}
}

/*<Codenesium>
    <Hash>d16fcc657f10897331fa0e7ba7f4af5f</Hash>
</Codenesium>*/