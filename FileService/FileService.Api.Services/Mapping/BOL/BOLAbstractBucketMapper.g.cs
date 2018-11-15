using FileServiceNS.Api.DataAccess;
using System;
using System.Collections.Generic;

namespace FileServiceNS.Api.Services
{
	public abstract class BOLAbstractBucketMapper
	{
		public virtual BOBucket MapModelToBO(
			int id,
			ApiBucketServerRequestModel model
			)
		{
			BOBucket boBucket = new BOBucket();
			boBucket.SetProperties(
				id,
				model.ExternalId,
				model.Name);
			return boBucket;
		}

		public virtual ApiBucketServerResponseModel MapBOToModel(
			BOBucket boBucket)
		{
			var model = new ApiBucketServerResponseModel();

			model.SetProperties(boBucket.Id, boBucket.ExternalId, boBucket.Name);

			return model;
		}

		public virtual List<ApiBucketServerResponseModel> MapBOToModel(
			List<BOBucket> items)
		{
			List<ApiBucketServerResponseModel> response = new List<ApiBucketServerResponseModel>();

			items.ForEach(d =>
			{
				response.Add(this.MapBOToModel(d));
			});

			return response;
		}
	}
}

/*<Codenesium>
    <Hash>a691178a83f4b19fd3ca7b88455c0165</Hash>
</Codenesium>*/