using System;
using System.Collections.Generic;
using AdventureWorksNS.Api.Contracts;
using AdventureWorksNS.Api.DataAccess;
namespace AdventureWorksNS.Api.Services
{
	public abstract class BOLAbstractPasswordMapper
	{
		public virtual BOPassword MapModelToBO(
			int businessEntityID,
			ApiPasswordRequestModel model
			)
		{
			BOPassword BOPassword = new BOPassword();

			BOPassword.SetProperties(
				businessEntityID,
				model.ModifiedDate,
				model.PasswordHash,
				model.PasswordSalt,
				model.Rowguid);
			return BOPassword;
		}

		public virtual ApiPasswordResponseModel MapBOToModel(
			BOPassword BOPassword)
		{
			if (BOPassword == null)
			{
				return null;
			}

			var model = new ApiPasswordResponseModel();

			model.SetProperties(BOPassword.BusinessEntityID, BOPassword.ModifiedDate, BOPassword.PasswordHash, BOPassword.PasswordSalt, BOPassword.Rowguid);

			return model;
		}

		public virtual List<ApiPasswordResponseModel> MapBOToModel(
			List<BOPassword> BOs)
		{
			List<ApiPasswordResponseModel> response = new List<ApiPasswordResponseModel>();

			BOs.ForEach(d =>
			{
				response.Add(this.MapBOToModel(d));
			});

			return response;
		}
	}
}

/*<Codenesium>
    <Hash>0e70ec5eba3838cb0fcf319dbb29d316</Hash>
</Codenesium>*/