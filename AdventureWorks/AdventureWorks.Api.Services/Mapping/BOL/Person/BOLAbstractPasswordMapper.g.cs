using AdventureWorksNS.Api.DataAccess;
using System;
using System.Collections.Generic;

namespace AdventureWorksNS.Api.Services
{
	public abstract class BOLAbstractPasswordMapper
	{
		public virtual BOPassword MapModelToBO(
			int businessEntityID,
			ApiPasswordServerRequestModel model
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

		public virtual ApiPasswordServerResponseModel MapBOToModel(
			BOPassword boPassword)
		{
			var model = new ApiPasswordServerResponseModel();

			model.SetProperties(boPassword.BusinessEntityID, boPassword.ModifiedDate, boPassword.PasswordHash, boPassword.PasswordSalt, boPassword.Rowguid);

			return model;
		}

		public virtual List<ApiPasswordServerResponseModel> MapBOToModel(
			List<BOPassword> items)
		{
			List<ApiPasswordServerResponseModel> response = new List<ApiPasswordServerResponseModel>();

			items.ForEach(d =>
			{
				response.Add(this.MapBOToModel(d));
			});

			return response;
		}
	}
}

/*<Codenesium>
    <Hash>4eefe7576b42874fd7a29d9a2a1c9574</Hash>
</Codenesium>*/