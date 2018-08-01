using NebulaNS.Api.Contracts;
using NebulaNS.Api.DataAccess;
using System;
using System.Collections.Generic;

namespace NebulaNS.Api.Services
{
	public abstract class BOLAbstractLinkLogMapper
	{
		public virtual BOLinkLog MapModelToBO(
			int id,
			ApiLinkLogRequestModel model
			)
		{
			BOLinkLog boLinkLog = new BOLinkLog();
			boLinkLog.SetProperties(
				id,
				model.DateEntered,
				model.LinkId,
				model.Log);
			return boLinkLog;
		}

		public virtual ApiLinkLogResponseModel MapBOToModel(
			BOLinkLog boLinkLog)
		{
			var model = new ApiLinkLogResponseModel();

			model.SetProperties(boLinkLog.Id, boLinkLog.DateEntered, boLinkLog.LinkId, boLinkLog.Log);

			return model;
		}

		public virtual List<ApiLinkLogResponseModel> MapBOToModel(
			List<BOLinkLog> items)
		{
			List<ApiLinkLogResponseModel> response = new List<ApiLinkLogResponseModel>();

			items.ForEach(d =>
			{
				response.Add(this.MapBOToModel(d));
			});

			return response;
		}
	}
}

/*<Codenesium>
    <Hash>212c2d8ea2f39689a45c887e0a0c0af9</Hash>
</Codenesium>*/