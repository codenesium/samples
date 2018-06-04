using System;
using System.Collections.Generic;
using NebulaNS.Api.Contracts;
using NebulaNS.Api.DataAccess;
namespace NebulaNS.Api.Services
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
    <Hash>27eb5101653a0bb7cfc01a60ec7eba23</Hash>
</Codenesium>*/