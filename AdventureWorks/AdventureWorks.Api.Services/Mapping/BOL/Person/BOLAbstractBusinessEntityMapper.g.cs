using AdventureWorksNS.Api.Contracts;
using AdventureWorksNS.Api.DataAccess;
using System;
using System.Collections.Generic;

namespace AdventureWorksNS.Api.Services
{
	public abstract class BOLAbstractBusinessEntityMapper
	{
		public virtual BOBusinessEntity MapModelToBO(
			int businessEntityID,
			ApiBusinessEntityRequestModel model
			)
		{
			BOBusinessEntity boBusinessEntity = new BOBusinessEntity();
			boBusinessEntity.SetProperties(
				businessEntityID,
				model.ModifiedDate,
				model.Rowguid);
			return boBusinessEntity;
		}

		public virtual ApiBusinessEntityResponseModel MapBOToModel(
			BOBusinessEntity boBusinessEntity)
		{
			var model = new ApiBusinessEntityResponseModel();

			model.SetProperties(boBusinessEntity.BusinessEntityID, boBusinessEntity.ModifiedDate, boBusinessEntity.Rowguid);

			return model;
		}

		public virtual List<ApiBusinessEntityResponseModel> MapBOToModel(
			List<BOBusinessEntity> items)
		{
			List<ApiBusinessEntityResponseModel> response = new List<ApiBusinessEntityResponseModel>();

			items.ForEach(d =>
			{
				response.Add(this.MapBOToModel(d));
			});

			return response;
		}
	}
}

/*<Codenesium>
    <Hash>13d4caab16fcda028339cca6148ff443</Hash>
</Codenesium>*/