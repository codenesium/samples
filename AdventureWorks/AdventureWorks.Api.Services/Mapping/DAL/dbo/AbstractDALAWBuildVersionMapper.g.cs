using AdventureWorksNS.Api.Contracts;
using AdventureWorksNS.Api.DataAccess;
using System;
using System.Collections.Generic;

namespace AdventureWorksNS.Api.Services
{
	public abstract class AbstractDALAWBuildVersionMapper
	{
		public virtual AWBuildVersion MapModelToBO(
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

		public virtual ApiAWBuildVersionServerResponseModel MapBOToModel(
			AWBuildVersion item)
		{
			var model = new ApiAWBuildVersionServerResponseModel();

			model.SetProperties(item.SystemInformationID, item.Database_Version, item.ModifiedDate, item.VersionDate);

			return model;
		}

		public virtual List<ApiAWBuildVersionServerResponseModel> MapBOToModel(
			List<AWBuildVersion> items)
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
    <Hash>d5cd38ac38a4c2965ac59ad48d6675cc</Hash>
</Codenesium>*/