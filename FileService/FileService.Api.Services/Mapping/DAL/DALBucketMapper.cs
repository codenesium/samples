using FileServiceNS.Api.Contracts;
using FileServiceNS.Api.DataAccess;
using System;
using System.Collections.Generic;

namespace FileServiceNS.Api.Services
{
	public class DALBucketMapper : IDALBucketMapper
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
    <Hash>475b159c602d0fef26a1dde4a14ecee7</Hash>
    <Hello>
		This code was generated using the Codenesium platform. You can visit our site at https://www.codenesium.com. 
	</Hello>
</Codenesium>*/