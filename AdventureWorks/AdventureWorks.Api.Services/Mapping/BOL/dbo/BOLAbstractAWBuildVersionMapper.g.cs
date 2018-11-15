using AdventureWorksNS.Api.DataAccess;
using System;
using System.Collections.Generic;

namespace AdventureWorksNS.Api.Services
{
	public abstract class BOLAbstractAWBuildVersionMapper
	{
		public virtual BOAWBuildVersion MapModelToBO(
			int systemInformationID,
			ApiAWBuildVersionServerRequestModel model
			)
		{
			BOAWBuildVersion boAWBuildVersion = new BOAWBuildVersion();
			boAWBuildVersion.SetProperties(
				systemInformationID,
				model.Database_Version,
				model.ModifiedDate,
				model.VersionDate);
			return boAWBuildVersion;
		}

		public virtual ApiAWBuildVersionServerResponseModel MapBOToModel(
			BOAWBuildVersion boAWBuildVersion)
		{
			var model = new ApiAWBuildVersionServerResponseModel();

			model.SetProperties(boAWBuildVersion.SystemInformationID, boAWBuildVersion.Database_Version, boAWBuildVersion.ModifiedDate, boAWBuildVersion.VersionDate);

			return model;
		}

		public virtual List<ApiAWBuildVersionServerResponseModel> MapBOToModel(
			List<BOAWBuildVersion> items)
		{
			List<ApiAWBuildVersionServerResponseModel> response = new List<ApiAWBuildVersionServerResponseModel>();

			items.ForEach(d =>
			{
				response.Add(this.MapBOToModel(d));
			});

			return response;
		}
	}
}

/*<Codenesium>
    <Hash>ada52f2fb0835dcb1d72668377e01ac6</Hash>
</Codenesium>*/