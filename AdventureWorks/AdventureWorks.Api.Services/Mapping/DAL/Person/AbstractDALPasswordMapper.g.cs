using AdventureWorksNS.Api.Contracts;
using AdventureWorksNS.Api.DataAccess;
using System;
using System.Collections.Generic;

namespace AdventureWorksNS.Api.Services
{
	public abstract class AbstractDALPasswordMapper
	{
		public virtual Password MapModelToEntity(
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

		public virtual ApiPasswordServerResponseModel MapEntityToModel(
			Password item)
		{
			var model = new ApiPasswordServerResponseModel();

			model.SetProperties(item.BusinessEntityID,
			                    item.ModifiedDate,
			                    item.PasswordHash,
			                    item.PasswordSalt,
			                    item.Rowguid);

			return model;
		}

		public virtual List<ApiPasswordServerResponseModel> MapEntityToModel(
			List<Password> items)
		{
			List<ApiPasswordServerResponseModel> response = new List<ApiPasswordServerResponseModel>();

			items.ForEach(x =>
			{
				response.Add(this.MapEntityToModel(x));
			});

			return response;
		}
	}
}

/*<Codenesium>
    <Hash>e3ee24125a65386c0a7da290931d3cc1</Hash>
</Codenesium>*/