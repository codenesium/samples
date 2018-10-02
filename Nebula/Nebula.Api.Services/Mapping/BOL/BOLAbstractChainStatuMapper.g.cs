using NebulaNS.Api.Contracts;
using NebulaNS.Api.DataAccess;
using System;
using System.Collections.Generic;

namespace NebulaNS.Api.Services
{
	public abstract class BOLAbstractChainStatuMapper
	{
		public virtual BOChainStatu MapModelToBO(
			int id,
			ApiChainStatuRequestModel model
			)
		{
			BOChainStatu boChainStatu = new BOChainStatu();
			boChainStatu.SetProperties(
				id,
				model.Name);
			return boChainStatu;
		}

		public virtual ApiChainStatuResponseModel MapBOToModel(
			BOChainStatu boChainStatu)
		{
			var model = new ApiChainStatuResponseModel();

			model.SetProperties(boChainStatu.Id, boChainStatu.Name);

			return model;
		}

		public virtual List<ApiChainStatuResponseModel> MapBOToModel(
			List<BOChainStatu> items)
		{
			List<ApiChainStatuResponseModel> response = new List<ApiChainStatuResponseModel>();

			items.ForEach(d =>
			{
				response.Add(this.MapBOToModel(d));
			});

			return response;
		}
	}
}

/*<Codenesium>
    <Hash>b3dce652298d71780ec6431d9b4f903b</Hash>
</Codenesium>*/