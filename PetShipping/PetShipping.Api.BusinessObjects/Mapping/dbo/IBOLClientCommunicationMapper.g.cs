using System;
using System.Collections.Generic;
using PetShippingNS.Api.Contracts;
using PetShippingNS.Api.DataAccess;
namespace PetShippingNS.Api.BusinessObjects
{
	public interface IBOLClientCommunicationMapper
	{
		DTOClientCommunication MapModelToDTO(
			int id,
			ApiClientCommunicationRequestModel model);

		ApiClientCommunicationResponseModel MapDTOToModel(
			DTOClientCommunication dtoClientCommunication);

		List<ApiClientCommunicationResponseModel> MapDTOToModel(
			List<DTOClientCommunication> dtos);
	}
}

/*<Codenesium>
    <Hash>6876048ffefd43a569499017d624fb6a</Hash>
</Codenesium>*/