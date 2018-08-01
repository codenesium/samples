using OctopusDeployNS.Api.Contracts;
using OctopusDeployNS.Api.DataAccess;
using System;
using System.Collections.Generic;

namespace OctopusDeployNS.Api.Services
{
	public abstract class BOLAbstractInvitationMapper
	{
		public virtual BOInvitation MapModelToBO(
			string id,
			ApiInvitationRequestModel model
			)
		{
			BOInvitation boInvitation = new BOInvitation();
			boInvitation.SetProperties(
				id,
				model.InvitationCode,
				model.JSON);
			return boInvitation;
		}

		public virtual ApiInvitationResponseModel MapBOToModel(
			BOInvitation boInvitation)
		{
			var model = new ApiInvitationResponseModel();

			model.SetProperties(boInvitation.Id, boInvitation.InvitationCode, boInvitation.JSON);

			return model;
		}

		public virtual List<ApiInvitationResponseModel> MapBOToModel(
			List<BOInvitation> items)
		{
			List<ApiInvitationResponseModel> response = new List<ApiInvitationResponseModel>();

			items.ForEach(d =>
			{
				response.Add(this.MapBOToModel(d));
			});

			return response;
		}
	}
}

/*<Codenesium>
    <Hash>bfc016ae35bfc3712e87aa68899929c3</Hash>
</Codenesium>*/