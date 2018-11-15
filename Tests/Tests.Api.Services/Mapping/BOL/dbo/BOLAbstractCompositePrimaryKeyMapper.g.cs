using System;
using System.Collections.Generic;
using TestsNS.Api.DataAccess;

namespace TestsNS.Api.Services
{
	public abstract class BOLAbstractCompositePrimaryKeyMapper
	{
		public virtual BOCompositePrimaryKey MapModelToBO(
			int id,
			ApiCompositePrimaryKeyServerRequestModel model
			)
		{
			BOCompositePrimaryKey boCompositePrimaryKey = new BOCompositePrimaryKey();
			boCompositePrimaryKey.SetProperties(
				id,
				model.Id2);
			return boCompositePrimaryKey;
		}

		public virtual ApiCompositePrimaryKeyServerResponseModel MapBOToModel(
			BOCompositePrimaryKey boCompositePrimaryKey)
		{
			var model = new ApiCompositePrimaryKeyServerResponseModel();

			model.SetProperties(boCompositePrimaryKey.Id, boCompositePrimaryKey.Id2);

			return model;
		}

		public virtual List<ApiCompositePrimaryKeyServerResponseModel> MapBOToModel(
			List<BOCompositePrimaryKey> items)
		{
			List<ApiCompositePrimaryKeyServerResponseModel> response = new List<ApiCompositePrimaryKeyServerResponseModel>();

			items.ForEach(d =>
			{
				response.Add(this.MapBOToModel(d));
			});

			return response;
		}
	}
}

/*<Codenesium>
    <Hash>618c9d4dbcb0277440ab83f3fc651b02</Hash>
</Codenesium>*/