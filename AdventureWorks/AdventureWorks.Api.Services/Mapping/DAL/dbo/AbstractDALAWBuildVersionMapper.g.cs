using AdventureWorksNS.Api.Contracts;
using AdventureWorksNS.Api.DataAccess;
using System;
using System.Collections.Generic;

namespace AdventureWorksNS.Api.Services
{
	public abstract class AbstractDALAWBuildVersionMapper
	{
		public virtual AWBuildVersion MapModelToEntity(
			int systemInformationID,
			ApiAWBuildVersionServerRequestModel model
			)
		{
			AWBuildVersion item = new AWBuildVersion();
			item.SetProperties(
				systemInformationID,
				model.Database_Version,
				model.ModifiedDate,
				model.VersionDate);
			return item;
		}

		public virtual ApiAWBuildVersionServerResponseModel MapEntityToModel(
			AWBuildVersion item)
		{
			var model = new ApiAWBuildVersionServerResponseModel();

			model.SetProperties(item.SystemInformationID,
			                    item.Database_Version,
			                    item.ModifiedDate,
			                    item.VersionDate);

			return model;
		}

		public virtual List<ApiAWBuildVersionServerResponseModel> MapEntityToModel(
			List<AWBuildVersion> items)
		{
			List<ApiAWBuildVersionServerResponseModel> response = new List<ApiAWBuildVersionServerResponseModel>();

			items.ForEach(x =>
			{
				response.Add(this.MapEntityToModel(x));
			});

			return response;
		}
	}
}

/*<Codenesium>
    <Hash>69a1ae663d5c3bafbbfb1eedd87c342f</Hash>
</Codenesium>*/