using System;
using System.Collections.Generic;
using AdventureWorksNS.Api.Contracts;
using AdventureWorksNS.Api.DataAccess;
namespace AdventureWorksNS.Api.BusinessObjects
{
	public interface IBOLUnitMeasureMapper
	{
		DTOUnitMeasure MapModelToDTO(
			string unitMeasureCode,
			ApiUnitMeasureRequestModel model);

		ApiUnitMeasureResponseModel MapDTOToModel(
			DTOUnitMeasure dtoUnitMeasure);

		List<ApiUnitMeasureResponseModel> MapDTOToModel(
			List<DTOUnitMeasure> dtos);
	}
}

/*<Codenesium>
    <Hash>925c40dfea935cb9ef35643e542e6d82</Hash>
</Codenesium>*/