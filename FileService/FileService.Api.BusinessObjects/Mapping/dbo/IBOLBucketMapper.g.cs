using System;
using System.Collections.Generic;
using FileServiceNS.Api.Contracts;
using FileServiceNS.Api.DataAccess;
namespace FileServiceNS.Api.BusinessObjects
{
	public interface IBOLBucketMapper
	{
		DTOBucket MapModelToDTO(
			int id,
			ApiBucketRequestModel model);

		ApiBucketResponseModel MapDTOToModel(
			DTOBucket dtoBucket);

		List<ApiBucketResponseModel> MapDTOToModel(
			List<DTOBucket> dtos);
	}
}

/*<Codenesium>
    <Hash>f13304ed5b37defaadd8f368b6351c72</Hash>
</Codenesium>*/