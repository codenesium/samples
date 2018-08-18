using OctopusDeployNS.Api.Contracts;
using OctopusDeployNS.Api.DataAccess;
using System;
using System.Collections.Generic;

namespace OctopusDeployNS.Api.Services
{
	public abstract class BOLAbstractUserRoleMapper
	{
		public virtual BOUserRole MapModelToBO(
			string id,
			ApiUserRoleRequestModel model
			)
		{
			BOUserRole boUserRole = new BOUserRole();
			boUserRole.SetProperties(
				id,
				model.JSON,
				model.Name);
			return boUserRole;
		}

		public virtual ApiUserRoleResponseModel MapBOToModel(
			BOUserRole boUserRole)
		{
			var model = new ApiUserRoleResponseModel();

			model.SetProperties(boUserRole.Id, boUserRole.JSON, boUserRole.Name);

			return model;
		}

		public virtual List<ApiUserRoleResponseModel> MapBOToModel(
			List<BOUserRole> items)
		{
			List<ApiUserRoleResponseModel> response = new List<ApiUserRoleResponseModel>();

			items.ForEach(d =>
			{
				response.Add(this.MapBOToModel(d));
			});

			return response;
		}
	}
}

/*<Codenesium>
    <Hash>0579fa48dcea950b931ae205458ec5d7</Hash>
</Codenesium>*/