using NebulaNS.Api.DataAccess;
using System;
using System.Collections.Generic;

namespace NebulaNS.Api.Services
{
	public abstract class BOLAbstractLinkLogMapper
	{
		public virtual BOLinkLog MapModelToBO(
			int id,
			ApiLinkLogServerRequestModel model
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

		public virtual ApiLinkLogServerResponseModel MapBOToModel(
			BOLinkLog boLinkLog)
		{
			var model = new ApiLinkLogServerResponseModel();

			model.SetProperties(boLinkLog.Id, boLinkLog.DateEntered, boLinkLog.LinkId, boLinkLog.Log);

			return model;
		}

		public virtual List<ApiLinkLogServerResponseModel> MapBOToModel(
			List<BOLinkLog> items)
		{
			List<ApiLinkLogServerResponseModel> response = new List<ApiLinkLogServerResponseModel>();

			items.ForEach(d =>
			{
				response.Add(this.MapBOToModel(d));
			});

			return response;
		}
	}
}

/*<Codenesium>
    <Hash>8ea33923d1112c5efbc9860aa8773a88</Hash>
</Codenesium>*/