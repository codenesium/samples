using System;
using System.Collections.Generic;
using NebulaNS.Api.Contracts;
using NebulaNS.Api.DataAccess;
namespace NebulaNS.Api.Services
{
	public abstract class BOLAbstractLinkLogMapper
	{
		public virtual BOLinkLog MapModelToBO(
			int id,
			ApiLinkLogRequestModel model
			)
		{
			BOLinkLog BOLinkLog = new BOLinkLog();

			BOLinkLog.SetProperties(
				id,
				model.DateEntered,
				model.LinkId,
				model.Log);
			return BOLinkLog;
		}

		public virtual ApiLinkLogResponseModel MapBOToModel(
			BOLinkLog BOLinkLog)
		{
			if (BOLinkLog == null)
			{
				return null;
			}

			var model = new ApiLinkLogResponseModel();

			model.SetProperties(BOLinkLog.DateEntered, BOLinkLog.Id, BOLinkLog.LinkId, BOLinkLog.Log);

			return model;
		}

		public virtual List<ApiLinkLogResponseModel> MapBOToModel(
			List<BOLinkLog> BOs)
		{
			List<ApiLinkLogResponseModel> response = new List<ApiLinkLogResponseModel>();

			BOs.ForEach(d =>
			{
				response.Add(this.MapBOToModel(d));
			});

			return response;
		}
	}
}

/*<Codenesium>
    <Hash>53ba80825f904c6f86d9dffa78767e88</Hash>
</Codenesium>*/