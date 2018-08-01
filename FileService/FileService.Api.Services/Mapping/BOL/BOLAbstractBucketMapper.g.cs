using FileServiceNS.Api.Contracts;
using FileServiceNS.Api.DataAccess;
using System;
using System.Collections.Generic;

namespace FileServiceNS.Api.Services
{
	public abstract class BOLAbstractBucketMapper
	{
		public virtual BOBucket MapModelToBO(
			int id,
			ApiBucketRequestModel model
			)
		{
			BOBucket boBucket = new BOBucket();
			boBucket.SetProperties(
				id,
				model.ExternalId,
				model.Name);
			return boBucket;
		}

		public virtual ApiBucketResponseModel MapBOToModel(
			BOBucket boBucket)
		{
			var model = new ApiBucketResponseModel();

			model.SetProperties(boBucket.Id, boBucket.ExternalId, boBucket.Name);

			return model;
		}

		public virtual List<ApiBucketResponseModel> MapBOToModel(
			List<BOBucket> items)
		{
			List<ApiBucketResponseModel> response = new List<ApiBucketResponseModel>();

			items.ForEach(d =>
			{
				response.Add(this.MapBOToModel(d));
			});

			return response;
		}
	}
}

/*<Codenesium>
    <Hash>684728cd3aa0d3886c38c75a532ccf5a</Hash>
</Codenesium>*/