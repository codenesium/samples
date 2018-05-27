using System;
using System.Collections.Generic;
using AdventureWorksNS.Api.Contracts;
using AdventureWorksNS.Api.DataAccess;
namespace AdventureWorksNS.Api.BusinessObjects
{
	public interface IBOLStateProvinceMapper
	{
		DTOStateProvince MapModelToDTO(
			int stateProvinceID,
			ApiStateProvinceRequestModel model);

		ApiStateProvinceResponseModel MapDTOToModel(
			DTOStateProvince dtoStateProvince);

		List<ApiStateProvinceResponseModel> MapDTOToModel(
			List<DTOStateProvince> dtos);
	}
}

/*<Codenesium>
    <Hash>3f19385f0e16e8866aff10fe0561d34a</Hash>
</Codenesium>*/