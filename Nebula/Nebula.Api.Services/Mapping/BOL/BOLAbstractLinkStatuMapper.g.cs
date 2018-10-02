using NebulaNS.Api.Contracts;
using NebulaNS.Api.DataAccess;
using System;
using System.Collections.Generic;

namespace NebulaNS.Api.Services
{
	public abstract class BOLAbstractLinkStatuMapper
	{
		public virtual BOLinkStatu MapModelToBO(
			int id,
			ApiLinkStatuRequestModel model
			)
		{
			BOLinkStatu boLinkStatu = new BOLinkStatu();
			boLinkStatu.SetProperties(
				id,
				model.Name);
			return boLinkStatu;
		}

		public virtual ApiLinkStatuResponseModel MapBOToModel(
			BOLinkStatu boLinkStatu)
		{
			var model = new ApiLinkStatuResponseModel();

			model.SetProperties(boLinkStatu.Id, boLinkStatu.Name);

			return model;
		}

		public virtual List<ApiLinkStatuResponseModel> MapBOToModel(
			List<BOLinkStatu> items)
		{
			List<ApiLinkStatuResponseModel> response = new List<ApiLinkStatuResponseModel>();

			items.ForEach(d =>
			{
				response.Add(this.MapBOToModel(d));
			});

			return response;
		}
	}
}

/*<Codenesium>
    <Hash>216c4fb7c2b6725dcb324ba50f8b3ef2</Hash>
</Codenesium>*/