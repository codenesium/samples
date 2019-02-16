using AdventureWorksNS.Api.Contracts;
using AdventureWorksNS.Api.DataAccess;
using System;
using System.Collections.Generic;

namespace AdventureWorksNS.Api.Services
{
	public abstract class AbstractDALBusinessEntityMapper
	{
		public virtual BusinessEntity MapModelToBO(
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

		public virtual ApiBusinessEntityServerResponseModel MapBOToModel(
			BusinessEntity item)
		{
			var model = new ApiBusinessEntityServerResponseModel();

			model.SetProperties(item.BusinessEntityID, item.ModifiedDate, item.Rowguid);

			return model;
		}

		public virtual List<ApiBusinessEntityServerResponseModel> MapBOToModel(
			List<BusinessEntity> items)
		{
			List<ApiBusinessEntityServerResponseModel> response = new List<ApiBusinessEntityServerResponseModel>();

			items.ForEach(d =>
			{
				response.Add(this.MapBOToModel(d));
			});

			return response;
		}
	}
}

/*<Codenesium>
    <Hash>9a6ac560ac7aa4519d887a128c22a293</Hash>
</Codenesium>*/