using OctopusDeployNS.Api.Contracts;
using OctopusDeployNS.Api.DataAccess;
using System;
using System.Collections.Generic;

namespace OctopusDeployNS.Api.Services
{
	public abstract class BOLAbstractAccountMapper
	{
		public virtual BOAccount MapModelToBO(
			string id,
			ApiAccountRequestModel model
			)
		{
			BOAccount boAccount = new BOAccount();
			boAccount.SetProperties(
				id,
				model.AccountType,
				model.EnvironmentIds,
				model.JSON,
				model.Name,
				model.TenantIds,
				model.TenantTags);
			return boAccount;
		}

		public virtual ApiAccountResponseModel MapBOToModel(
			BOAccount boAccount)
		{
			var model = new ApiAccountResponseModel();

			model.SetProperties(boAccount.Id, boAccount.AccountType, boAccount.EnvironmentIds, boAccount.JSON, boAccount.Name, boAccount.TenantIds, boAccount.TenantTags);

			return model;
		}

		public virtual List<ApiAccountResponseModel> MapBOToModel(
			List<BOAccount> items)
		{
			List<ApiAccountResponseModel> response = new List<ApiAccountResponseModel>();

			items.ForEach(d =>
			{
				response.Add(this.MapBOToModel(d));
			});

			return response;
		}
	}
}

/*<Codenesium>
    <Hash>fba8d1a68eea6224b3497c451696d6fc</Hash>
</Codenesium>*/