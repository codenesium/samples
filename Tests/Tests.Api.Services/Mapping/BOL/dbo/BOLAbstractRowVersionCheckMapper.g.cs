using System;
using System.Collections.Generic;
using TestsNS.Api.DataAccess;

namespace TestsNS.Api.Services
{
	public abstract class BOLAbstractRowVersionCheckMapper
	{
		public virtual BORowVersionCheck MapModelToBO(
			int id,
			ApiRowVersionCheckServerRequestModel model
			)
		{
			BORowVersionCheck boRowVersionCheck = new BORowVersionCheck();
			boRowVersionCheck.SetProperties(
				id,
				model.Name,
				model.RowVersion);
			return boRowVersionCheck;
		}

		public virtual ApiRowVersionCheckServerResponseModel MapBOToModel(
			BORowVersionCheck boRowVersionCheck)
		{
			var model = new ApiRowVersionCheckServerResponseModel();

			model.SetProperties(boRowVersionCheck.Id, boRowVersionCheck.Name, boRowVersionCheck.RowVersion);

			return model;
		}

		public virtual List<ApiRowVersionCheckServerResponseModel> MapBOToModel(
			List<BORowVersionCheck> items)
		{
			List<ApiRowVersionCheckServerResponseModel> response = new List<ApiRowVersionCheckServerResponseModel>();

			items.ForEach(d =>
			{
				response.Add(this.MapBOToModel(d));
			});

			return response;
		}
	}
}

/*<Codenesium>
    <Hash>8895c19051753a1caa8420f972d6a908</Hash>
</Codenesium>*/