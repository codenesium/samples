using AdventureWorksNS.Api.Contracts;
using AdventureWorksNS.Api.DataAccess;
using System;
using System.Collections.Generic;

namespace AdventureWorksNS.Api.Services
{
	public abstract class AbstractDALPasswordMapper
	{
		public virtual Password MapModelToBO(
			int businessEntityID,
			ApiPasswordServerRequestModel model
			)
		{
			Password item = new Password();
			item.SetProperties(
				businessEntityID,
				model.ModifiedDate,
				model.PasswordHash,
				model.PasswordSalt,
				model.Rowguid);
			return item;
		}

		public virtual ApiPasswordServerResponseModel MapBOToModel(
			Password item)
		{
			var model = new ApiPasswordServerResponseModel();

			model.SetProperties(item.BusinessEntityID, item.ModifiedDate, item.PasswordHash, item.PasswordSalt, item.Rowguid);

			return model;
		}

		public virtual List<ApiPasswordServerResponseModel> MapBOToModel(
			List<Password> items)
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
    <Hash>934cf0958b7cc4d2f018e99875ae6dfc</Hash>
</Codenesium>*/