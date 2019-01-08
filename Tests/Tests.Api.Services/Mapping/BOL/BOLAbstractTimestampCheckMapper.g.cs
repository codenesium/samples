using System;
using System.Collections.Generic;
using TestsNS.Api.DataAccess;

namespace TestsNS.Api.Services
{
	public abstract class BOLAbstractTimestampCheckMapper
	{
		public virtual BOTimestampCheck MapModelToBO(
			int id,
			ApiTimestampCheckServerRequestModel model
			)
		{
			BOTimestampCheck boTimestampCheck = new BOTimestampCheck();
			boTimestampCheck.SetProperties(
				id,
				model.Name,
				model.Timestamp);
			return boTimestampCheck;
		}

		public virtual ApiTimestampCheckServerResponseModel MapBOToModel(
			BOTimestampCheck boTimestampCheck)
		{
			var model = new ApiTimestampCheckServerResponseModel();

			model.SetProperties(boTimestampCheck.Id, boTimestampCheck.Name, boTimestampCheck.Timestamp);

			return model;
		}

		public virtual List<ApiTimestampCheckServerResponseModel> MapBOToModel(
			List<BOTimestampCheck> items)
		{
			List<ApiTimestampCheckServerResponseModel> response = new List<ApiTimestampCheckServerResponseModel>();

			items.ForEach(d =>
			{
				response.Add(this.MapBOToModel(d));
			});

			return response;
		}
	}
}

/*<Codenesium>
    <Hash>fb65868e55cf6b18c9c5db658bfc31a8</Hash>
</Codenesium>*/