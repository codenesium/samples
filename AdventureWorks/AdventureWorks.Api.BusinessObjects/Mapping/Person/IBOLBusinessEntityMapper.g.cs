using System;
using System.Collections.Generic;
using AdventureWorksNS.Api.Contracts;
using AdventureWorksNS.Api.DataAccess;
namespace AdventureWorksNS.Api.BusinessObjects
{
	public interface IBOLBusinessEntityMapper
	{
		DTOBusinessEntity MapModelToDTO(
			int businessEntityID,
			ApiBusinessEntityRequestModel model);

		ApiBusinessEntityResponseModel MapDTOToModel(
			DTOBusinessEntity dtoBusinessEntity);

		List<ApiBusinessEntityResponseModel> MapDTOToModel(
			List<DTOBusinessEntity> dtos);
	}
}

/*<Codenesium>
    <Hash>0820706ab0e90d81d4341aa3170a5438</Hash>
</Codenesium>*/