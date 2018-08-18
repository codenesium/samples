using AdventureWorksNS.Api.Contracts;
using AdventureWorksNS.Api.DataAccess;
using System;
using System.Collections.Generic;

namespace AdventureWorksNS.Api.Services
{
	public abstract class BOLAbstractPasswordMapper
	{
		public virtual BOPassword MapModelToBO(
			int businessEntityID,
			ApiPasswordRequestModel model
			)
		{
			BOPassword boPassword = new BOPassword();
			boPassword.SetProperties(
				businessEntityID,
				model.ModifiedDate,
				model.PasswordHash,
				model.PasswordSalt,
				model.Rowguid);
			return boPassword;
		}

		public virtual ApiPasswordResponseModel MapBOToModel(
			BOPassword boPassword)
		{
			var model = new ApiPasswordResponseModel();

			model.SetProperties(boPassword.BusinessEntityID, boPassword.ModifiedDate, boPassword.PasswordHash, boPassword.PasswordSalt, boPassword.Rowguid);

			return model;
		}

		public virtual List<ApiPasswordResponseModel> MapBOToModel(
			List<BOPassword> items)
		{
			List<ApiPasswordResponseModel> response = new List<ApiPasswordResponseModel>();

			items.ForEach(d =>
			{
				response.Add(this.MapBOToModel(d));
			});

			return response;
		}
	}
}

/*<Codenesium>
    <Hash>43d1da16575066d6569cc3721eb53f93</Hash>
</Codenesium>*/