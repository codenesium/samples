using System;
using System.Collections.Generic;
using AdventureWorksNS.Api.Contracts;
using AdventureWorksNS.Api.DataAccess;
namespace AdventureWorksNS.Api.BusinessObjects
{
	public interface IBOLPersonMapper
	{
		DTOPerson MapModelToDTO(
			int businessEntityID,
			ApiPersonRequestModel model);

		ApiPersonResponseModel MapDTOToModel(
			DTOPerson dtoPerson);

		List<ApiPersonResponseModel> MapDTOToModel(
			List<DTOPerson> dtos);
	}
}

/*<Codenesium>
    <Hash>a1020d6dee5f3f181f0d69b303fc881b</Hash>
</Codenesium>*/