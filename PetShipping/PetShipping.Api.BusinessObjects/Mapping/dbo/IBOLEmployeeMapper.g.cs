using System;
using System.Collections.Generic;
using PetShippingNS.Api.Contracts;
using PetShippingNS.Api.DataAccess;
namespace PetShippingNS.Api.BusinessObjects
{
	public interface IBOLEmployeeMapper
	{
		DTOEmployee MapModelToDTO(
			int id,
			ApiEmployeeRequestModel model);

		ApiEmployeeResponseModel MapDTOToModel(
			DTOEmployee dtoEmployee);

		List<ApiEmployeeResponseModel> MapDTOToModel(
			List<DTOEmployee> dtos);
	}
}

/*<Codenesium>
    <Hash>f48f14407b9709165009df520a2efae8</Hash>
</Codenesium>*/