using System;
using System.Collections.Generic;
using AdventureWorksNS.Api.Contracts;
using AdventureWorksNS.Api.DataAccess;
namespace AdventureWorksNS.Api.Services
{
	public abstract class BOLAbstractBusinessEntityMapper
	{
		public virtual BOBusinessEntity MapModelToBO(
			int businessEntityID,
			ApiBusinessEntityRequestModel model
			)
		{
			BOBusinessEntity BOBusinessEntity = new BOBusinessEntity();

			BOBusinessEntity.SetProperties(
				businessEntityID,
				model.ModifiedDate,
				model.Rowguid);
			return BOBusinessEntity;
		}

		public virtual ApiBusinessEntityResponseModel MapBOToModel(
			BOBusinessEntity BOBusinessEntity)
		{
			if (BOBusinessEntity == null)
			{
				return null;
			}

			var model = new ApiBusinessEntityResponseModel();

			model.SetProperties(BOBusinessEntity.BusinessEntityID, BOBusinessEntity.ModifiedDate, BOBusinessEntity.Rowguid);

			return model;
		}

		public virtual List<ApiBusinessEntityResponseModel> MapBOToModel(
			List<BOBusinessEntity> BOs)
		{
			List<ApiBusinessEntityResponseModel> response = new List<ApiBusinessEntityResponseModel>();

			BOs.ForEach(d =>
			{
				response.Add(this.MapBOToModel(d));
			});

			return response;
		}
	}
}

/*<Codenesium>
    <Hash>eb1f78bb8806c5266df4058b322606b2</Hash>
</Codenesium>*/