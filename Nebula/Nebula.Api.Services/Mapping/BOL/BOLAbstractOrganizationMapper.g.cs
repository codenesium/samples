using NebulaNS.Api.DataAccess;
using System;
using System.Collections.Generic;

namespace NebulaNS.Api.Services
{
	public abstract class BOLAbstractOrganizationMapper
	{
		public virtual BOOrganization MapModelToBO(
			int id,
			ApiOrganizationServerRequestModel model
			)
		{
			BOOrganization boOrganization = new BOOrganization();
			boOrganization.SetProperties(
				id,
				model.Name);
			return boOrganization;
		}

		public virtual ApiOrganizationServerResponseModel MapBOToModel(
			BOOrganization boOrganization)
		{
			var model = new ApiOrganizationServerResponseModel();

			model.SetProperties(boOrganization.Id, boOrganization.Name);

			return model;
		}

		public virtual List<ApiOrganizationServerResponseModel> MapBOToModel(
			List<BOOrganization> items)
		{
			List<ApiOrganizationServerResponseModel> response = new List<ApiOrganizationServerResponseModel>();

			items.ForEach(d =>
			{
				response.Add(this.MapBOToModel(d));
			});

			return response;
		}
	}
}

/*<Codenesium>
    <Hash>b6b2baea55b5b2e067e523b3100b9668</Hash>
</Codenesium>*/