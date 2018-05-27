using System;
using System.Collections.Generic;
using AdventureWorksNS.Api.Contracts;
using AdventureWorksNS.Api.DataAccess;
namespace AdventureWorksNS.Api.BusinessObjects
{
	public interface IBOLCustomerMapper
	{
		DTOCustomer MapModelToDTO(
			int customerID,
			ApiCustomerRequestModel model);

		ApiCustomerResponseModel MapDTOToModel(
			DTOCustomer dtoCustomer);

		List<ApiCustomerResponseModel> MapDTOToModel(
			List<DTOCustomer> dtos);
	}
}

/*<Codenesium>
    <Hash>023576d2849ac6fdaa9bab3780a9da3e</Hash>
</Codenesium>*/