using System;
using System.Collections.Generic;
using FileServiceNS.Api.Contracts;
using FileServiceNS.Api.DataAccess;
namespace FileServiceNS.Api.BusinessObjects
{
	public abstract class AbstractBOLBucketMapper
	{
		public virtual DTOBucket MapModelToDTO(
			int id,
			ApiBucketRequestModel model
			)
		{
			DTOBucket dtoBucket = new DTOBucket();

			dtoBucket.SetProperties(
				id,
				model.ExternalId,
				model.Name);
			return dtoBucket;
		}

		public virtual ApiBucketResponseModel MapDTOToModel(
			DTOBucket dtoBucket)
		{
			if (dtoBucket == null)
			{
				return null;
			}

			var model = new ApiBucketResponseModel();

			model.SetProperties(dtoBucket.ExternalId, dtoBucket.Id, dtoBucket.Name);

			return model;
		}

		public virtual List<ApiBucketResponseModel> MapDTOToModel(
			List<DTOBucket> dtos)
		{
			List<ApiBucketResponseModel> response = new List<ApiBucketResponseModel>();

			dtos.ForEach(d =>
			{
				response.Add(this.MapDTOToModel(d));
			});

			return response;
		}
	}
}

/*<Codenesium>
    <Hash>2dce6804b20d6530bf6e7b717d971794</Hash>
</Codenesium>*/