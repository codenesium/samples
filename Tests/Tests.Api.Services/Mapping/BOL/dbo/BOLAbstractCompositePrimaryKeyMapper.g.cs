using System;
using System.Collections.Generic;
using TestsNS.Api.Contracts;
using TestsNS.Api.DataAccess;

namespace TestsNS.Api.Services
{
	public abstract class BOLAbstractCompositePrimaryKeyMapper
	{
		public virtual BOCompositePrimaryKey MapModelToBO(
			int id,
			ApiCompositePrimaryKeyRequestModel model
			)
		{
			BOCompositePrimaryKey boCompositePrimaryKey = new BOCompositePrimaryKey();
			boCompositePrimaryKey.SetProperties(
				id,
				model.Id2);
			return boCompositePrimaryKey;
		}

		public virtual ApiCompositePrimaryKeyResponseModel MapBOToModel(
			BOCompositePrimaryKey boCompositePrimaryKey)
		{
			var model = new ApiCompositePrimaryKeyResponseModel();

			model.SetProperties(boCompositePrimaryKey.Id, boCompositePrimaryKey.Id2);

			return model;
		}

		public virtual List<ApiCompositePrimaryKeyResponseModel> MapBOToModel(
			List<BOCompositePrimaryKey> items)
		{
			List<ApiCompositePrimaryKeyResponseModel> response = new List<ApiCompositePrimaryKeyResponseModel>();

			items.ForEach(d =>
			{
				response.Add(this.MapBOToModel(d));
			});

			return response;
		}
	}
}

/*<Codenesium>
    <Hash>635bcf69f90de8701877c3e1c7c3e99c</Hash>
</Codenesium>*/