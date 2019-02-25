using AdventureWorksNS.Api.Contracts;
using AdventureWorksNS.Api.DataAccess;
using System;
using System.Collections.Generic;

namespace AdventureWorksNS.Api.Services
{
	public abstract class AbstractDALBusinessEntityMapper
	{
		public virtual BusinessEntity MapModelToEntity(
			int businessEntityID,
			ApiBusinessEntityServerRequestModel model
			)
		{
			BusinessEntity item = new BusinessEntity();
			item.SetProperties(
				businessEntityID,
				model.ModifiedDate,
				model.Rowguid);
			return item;
		}

		public virtual ApiBusinessEntityServerResponseModel MapEntityToModel(
			BusinessEntity item)
		{
			var model = new ApiBusinessEntityServerResponseModel();

			model.SetProperties(item.BusinessEntityID,
			                    item.ModifiedDate,
			                    item.Rowguid);

			return model;
		}

		public virtual List<ApiBusinessEntityServerResponseModel> MapEntityToModel(
			List<BusinessEntity> items)
		{
			List<ApiBusinessEntityServerResponseModel> response = new List<ApiBusinessEntityServerResponseModel>();

			items.ForEach(x =>
			{
				response.Add(this.MapEntityToModel(x));
			});

			return response;
		}
	}
}

/*<Codenesium>
    <Hash>6057108233cbb022f7afd55a7d5b7f4a</Hash>
</Codenesium>*/