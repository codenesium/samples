using System;
using System.Collections.Generic;
using AdventureWorksNS.Api.Contracts;
using AdventureWorksNS.Api.DataAccess;
namespace AdventureWorksNS.Api.Services
{
	public abstract class BOLAbstractAWBuildVersionMapper
	{
		public virtual BOAWBuildVersion MapModelToBO(
			int systemInformationID,
			ApiAWBuildVersionRequestModel model
			)
		{
			BOAWBuildVersion BOAWBuildVersion = new BOAWBuildVersion();

			BOAWBuildVersion.SetProperties(
				systemInformationID,
				model.Database_Version,
				model.ModifiedDate,
				model.VersionDate);
			return BOAWBuildVersion;
		}

		public virtual ApiAWBuildVersionResponseModel MapBOToModel(
			BOAWBuildVersion BOAWBuildVersion)
		{
			if (BOAWBuildVersion == null)
			{
				return null;
			}

			var model = new ApiAWBuildVersionResponseModel();

			model.SetProperties(BOAWBuildVersion.Database_Version, BOAWBuildVersion.ModifiedDate, BOAWBuildVersion.SystemInformationID, BOAWBuildVersion.VersionDate);

			return model;
		}

		public virtual List<ApiAWBuildVersionResponseModel> MapBOToModel(
			List<BOAWBuildVersion> BOs)
		{
			List<ApiAWBuildVersionResponseModel> response = new List<ApiAWBuildVersionResponseModel>();

			BOs.ForEach(d =>
			{
				response.Add(this.MapBOToModel(d));
			});

			return response;
		}
	}
}

/*<Codenesium>
    <Hash>5c1c658ac9a5b8da2555b225c85c0a10</Hash>
</Codenesium>*/