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
			BOBucket BOBucket = new BOBucket();

			BOBucket.SetProperties(
				id,
				model.ExternalId,
				model.Name);
			return BOBucket;
		}

		public virtual ApiBucketResponseModel MapBOToModel(
			BOBucket BOBucket)
		{
			if (BOBucket == null)
			{
				return null;
			}

			var model = new ApiBucketResponseModel();

			model.SetProperties(BOBucket.ExternalId, BOBucket.Id, BOBucket.Name);

			return model;
		}

		public virtual List<ApiBucketResponseModel> MapBOToModel(
			List<BOBucket> BOs)
		{
			List<ApiBucketResponseModel> response = new List<ApiBucketResponseModel>();

			BOs.ForEach(d =>
			{
				response.Add(this.MapBOToModel(d));
			});

			return response;
		}
	}
}

/*<Codenesium>
    <Hash>19fe7a651dd3a8a38169c531d5ade425</Hash>
</Codenesium>*/