using NebulaNS.Api.DataAccess;
using System;
using System.Collections.Generic;

namespace NebulaNS.Api.Services
{
	public abstract class BOLAbstractLinkStatusMapper
	{
		public virtual BOLinkStatus MapModelToBO(
			int id,
			ApiLinkStatusServerRequestModel model
			)
		{
			BOLinkStatus boLinkStatus = new BOLinkStatus();
			boLinkStatus.SetProperties(
				id,
				model.Name);
			return boLinkStatus;
		}

		public virtual ApiLinkStatusServerResponseModel MapBOToModel(
			BOLinkStatus boLinkStatus)
		{
			var model = new ApiLinkStatusServerResponseModel();

			model.SetProperties(boLinkStatus.Id, boLinkStatus.Name);

			return model;
		}

		public virtual List<ApiLinkStatusServerResponseModel> MapBOToModel(
			List<BOLinkStatus> items)
		{
			List<ApiLinkStatusServerResponseModel> response = new List<ApiLinkStatusServerResponseModel>();

			items.ForEach(d =>
			{
				response.Add(this.MapBOToModel(d));
			});

			return response;
		}
	}
}

/*<Codenesium>
    <Hash>c81ee4d9f2a0813f3f2f20371ec96a41</Hash>
</Codenesium>*/