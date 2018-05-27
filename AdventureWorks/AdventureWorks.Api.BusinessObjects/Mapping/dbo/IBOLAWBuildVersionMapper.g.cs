using System;
using System.Collections.Generic;
using AdventureWorksNS.Api.Contracts;
using AdventureWorksNS.Api.DataAccess;
namespace AdventureWorksNS.Api.BusinessObjects
{
	public interface IBOLAWBuildVersionMapper
	{
		DTOAWBuildVersion MapModelToDTO(
			int systemInformationID,
			ApiAWBuildVersionRequestModel model);

		ApiAWBuildVersionResponseModel MapDTOToModel(
			DTOAWBuildVersion dtoAWBuildVersion);

		List<ApiAWBuildVersionResponseModel> MapDTOToModel(
			List<DTOAWBuildVersion> dtos);
	}
}

/*<Codenesium>
    <Hash>19ddb68a7c59187c10ef4ad13bf7f152</Hash>
</Codenesium>*/