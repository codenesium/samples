using AdventureWorksNS.Api.Contracts;
using AdventureWorksNS.Api.DataAccess;
using System;
using System.Collections.Generic;

namespace AdventureWorksNS.Api.Services
{
	public abstract class BOLAbstractAWBuildVersionMapper
	{
		public virtual BOAWBuildVersion MapModelToBO(
			int systemInformationID,
			ApiAWBuildVersionRequestModel model
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

		public virtual ApiAWBuildVersionResponseModel MapBOToModel(
			BOAWBuildVersion boAWBuildVersion)
		{
			var model = new ApiAWBuildVersionResponseModel();

			model.SetProperties(boAWBuildVersion.SystemInformationID, boAWBuildVersion.Database_Version, boAWBuildVersion.ModifiedDate, boAWBuildVersion.VersionDate);

			return model;
		}

		public virtual List<ApiAWBuildVersionResponseModel> MapBOToModel(
			List<BOAWBuildVersion> items)
		{
			List<ApiAWBuildVersionResponseModel> response = new List<ApiAWBuildVersionResponseModel>();

			items.ForEach(d =>
			{
				response.Add(this.MapBOToModel(d));
			});

			return response;
		}
	}
}

/*<Codenesium>
    <Hash>4acdd14e5a6a85f96e1fe319182cbff8</Hash>
</Codenesium>*/