using FileServiceNS.Api.Contracts;
using FileServiceNS.Api.DataAccess;
using System;
using System.Collections.Generic;

namespace FileServiceNS.Api.Services
{
	public abstract class AbstractDALBucketMapper
	{
		public virtual Bucket MapModelToEntity(
			int id,
			ApiBucketServerRequestModel model
			)
		{
			Bucket item = new Bucket();
			item.SetProperties(
				id,
				model.ExternalId,
				model.Name);
			return item;
		}

		public virtual ApiBucketServerResponseModel MapEntityToModel(
			Bucket item)
		{
			var model = new ApiBucketServerResponseModel();

			model.SetProperties(item.Id,
			                    item.ExternalId,
			                    item.Name);

			return model;
		}

		public virtual List<ApiBucketServerResponseModel> MapEntityToModel(
			List<Bucket> items)
		{
			List<ApiBucketServerResponseModel> response = new List<ApiBucketServerResponseModel>();

			items.ForEach(x =>
			{
				response.Add(this.MapEntityToModel(x));
			});

			return response;
		}
	}
}

/*<Codenesium>
    <Hash>b83ffdbc82224d448670079f32d61965</Hash>
</Codenesium>*/