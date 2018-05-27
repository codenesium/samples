using System;
using System.Collections.Generic;
using NebulaNS.Api.Contracts;
using NebulaNS.Api.DataAccess;
namespace NebulaNS.Api.BusinessObjects
{
	public interface IBOLChainMapper
	{
		DTOChain MapModelToDTO(
			int id,
			ApiChainRequestModel model);

		ApiChainResponseModel MapDTOToModel(
			DTOChain dtoChain);

		List<ApiChainResponseModel> MapDTOToModel(
			List<DTOChain> dtos);
	}
}

/*<Codenesium>
    <Hash>e8baa40e72061f8d599f412857989cc4</Hash>
</Codenesium>*/