using System;
using System.Collections.Generic;
using AdventureWorksNS.Api.Contracts;
using AdventureWorksNS.Api.DataAccess;
namespace AdventureWorksNS.Api.BusinessObjects
{
	public interface IBOLSalesPersonMapper
	{
		DTOSalesPerson MapModelToDTO(
			int businessEntityID,
			ApiSalesPersonRequestModel model);

		ApiSalesPersonResponseModel MapDTOToModel(
			DTOSalesPerson dtoSalesPerson);

		List<ApiSalesPersonResponseModel> MapDTOToModel(
			List<DTOSalesPerson> dtos);
	}
}

/*<Codenesium>
    <Hash>74afc721cc97e10d28f72dc945e86b8c</Hash>
</Codenesium>*/