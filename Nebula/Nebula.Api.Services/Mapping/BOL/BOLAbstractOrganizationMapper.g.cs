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
			BOOrganization BOOrganization = new BOOrganization();

			BOOrganization.SetProperties(
				id,
				model.Name);
			return BOOrganization;
		}

		public virtual ApiOrganizationResponseModel MapBOToModel(
			BOOrganization BOOrganization)
		{
			if (BOOrganization == null)
			{
				return null;
			}

			var model = new ApiOrganizationResponseModel();

			model.SetProperties(BOOrganization.Id, BOOrganization.Name);

			return model;
		}

		public virtual List<ApiOrganizationResponseModel> MapBOToModel(
			List<BOOrganization> BOs)
		{
			List<ApiOrganizationResponseModel> response = new List<ApiOrganizationResponseModel>();

			BOs.ForEach(d =>
			{
				response.Add(this.MapBOToModel(d));
			});

			return response;
		}
	}
}

/*<Codenesium>
    <Hash>1389a6436cbb1ee3d996393ef57b1f2b</Hash>
</Codenesium>*/