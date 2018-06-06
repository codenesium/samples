using System;
using System.Collections.Generic;
using NebulaNS.Api.Contracts;
using NebulaNS.Api.DataAccess;
namespace NebulaNS.Api.Services
{
	public abstract class BOLAbstractOrganizationMapper
	{
		public virtual BOOrganization MapModelToBO(
			int id,
			ApiOrganizationRequestModel model
			)
		{
			BOOrganization boOrganization = new BOOrganization();

			boOrganization.SetProperties(
				id,
				model.Name);
			return boOrganization;
		}

		public virtual ApiOrganizationResponseModel MapBOToModel(
			BOOrganization boOrganization)
		{
			var model = new ApiOrganizationResponseModel();

			model.SetProperties(boOrganization.Id, boOrganization.Name);

			return model;
		}

		public virtual List<ApiOrganizationResponseModel> MapBOToModel(
			List<BOOrganization> items)
		{
			List<ApiOrganizationResponseModel> response = new List<ApiOrganizationResponseModel>();

			items.ForEach(d =>
			{
				response.Add(this.MapBOToModel(d));
			});

			return response;
		}
	}
}

/*<Codenesium>
    <Hash>fbbbb4f8fa673eeb4612a992a438461f</Hash>
</Codenesium>*/