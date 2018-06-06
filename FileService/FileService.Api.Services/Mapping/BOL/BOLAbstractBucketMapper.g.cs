using System;
using System.Collections.Generic;
using FileServiceNS.Api.Contracts;
using FileServiceNS.Api.DataAccess;
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

			model.SetProperties(boBucket.ExternalId, boBucket.Id, boBucket.Name);

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
    <Hash>c9e870553fb0d348611c70ec01ac3647</Hash>
</Codenesium>*/