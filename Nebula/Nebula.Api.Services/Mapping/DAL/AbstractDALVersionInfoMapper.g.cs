using NebulaNS.Api.Contracts;
using NebulaNS.Api.DataAccess;
using System;
using System.Collections.Generic;

namespace NebulaNS.Api.Services
{
	public abstract class AbstractDALVersionInfoMapper
	{
		public virtual VersionInfo MapModelToEntity(
			long version,
			ApiVersionInfoServerRequestModel model
			)
		{
			VersionInfo item = new VersionInfo();
			item.SetProperties(
				version,
				model.AppliedOn,
				model.Description);
			return item;
		}

		public virtual ApiVersionInfoServerResponseModel MapEntityToModel(
			VersionInfo item)
		{
			var model = new ApiVersionInfoServerResponseModel();

			model.SetProperties(item.Version,
			                    item.AppliedOn,
			                    item.Description);

			return model;
		}

		public virtual List<ApiVersionInfoServerResponseModel> MapEntityToModel(
			List<VersionInfo> items)
		{
			List<ApiVersionInfoServerResponseModel> response = new List<ApiVersionInfoServerResponseModel>();

			items.ForEach(x =>
			{
				response.Add(this.MapEntityToModel(x));
			});

			return response;
		}
	}
}

/*<Codenesium>
    <Hash>5ef8a7c7952a6c28e615a6a71a66ef25</Hash>
</Codenesium>*/