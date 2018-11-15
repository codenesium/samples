using AdventureWorksNS.Api.DataAccess;
using System;
using System.Collections.Generic;

namespace AdventureWorksNS.Api.Services
{
	public abstract class BOLAbstractBusinessEntityMapper
	{
		public virtual BOBusinessEntity MapModelToBO(
			int businessEntityID,
			ApiBusinessEntityServerRequestModel model
			)
		{
			BOBusinessEntity boBusinessEntity = new BOBusinessEntity();
			boBusinessEntity.SetProperties(
				businessEntityID,
				model.ModifiedDate,
				model.Rowguid);
			return boBusinessEntity;
		}

		public virtual ApiBusinessEntityServerResponseModel MapBOToModel(
			BOBusinessEntity boBusinessEntity)
		{
			var model = new ApiBusinessEntityServerResponseModel();

			model.SetProperties(boBusinessEntity.BusinessEntityID, boBusinessEntity.ModifiedDate, boBusinessEntity.Rowguid);

			return model;
		}

		public virtual List<ApiBusinessEntityServerResponseModel> MapBOToModel(
			List<BOBusinessEntity> items)
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
    <Hash>a9393915eac2692c325088950fd1a617</Hash>
</Codenesium>*/