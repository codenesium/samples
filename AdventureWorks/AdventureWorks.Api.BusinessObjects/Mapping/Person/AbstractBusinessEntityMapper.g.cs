using System;
using System.Collections.Generic;
using AdventureWorksNS.Api.Contracts;
using AdventureWorksNS.Api.DataAccess;
namespace AdventureWorksNS.Api.BusinessObjects
{
	public abstract class AbstractBOLBusinessEntityMapper
	{
		public virtual DTOBusinessEntity MapModelToDTO(
			int businessEntityID,
			ApiBusinessEntityRequestModel model
			)
		{
			DTOBusinessEntity dtoBusinessEntity = new DTOBusinessEntity();

			dtoBusinessEntity.SetProperties(
				businessEntityID,
				model.ModifiedDate,
				model.Rowguid);
			return dtoBusinessEntity;
		}

		public virtual ApiBusinessEntityResponseModel MapDTOToModel(
			DTOBusinessEntity dtoBusinessEntity)
		{
			if (dtoBusinessEntity == null)
			{
				return null;
			}

			var model = new ApiBusinessEntityResponseModel();

			model.SetProperties(dtoBusinessEntity.BusinessEntityID, dtoBusinessEntity.ModifiedDate, dtoBusinessEntity.Rowguid);

			return model;
		}

		public virtual List<ApiBusinessEntityResponseModel> MapDTOToModel(
			List<DTOBusinessEntity> dtos)
		{
			List<ApiBusinessEntityResponseModel> response = new List<ApiBusinessEntityResponseModel>();

			dtos.ForEach(d =>
			{
				response.Add(this.MapDTOToModel(d));
			});

			return response;
		}
	}
}

/*<Codenesium>
    <Hash>93609e9978b40e6d19d860d21000dfc4</Hash>
</Codenesium>*/