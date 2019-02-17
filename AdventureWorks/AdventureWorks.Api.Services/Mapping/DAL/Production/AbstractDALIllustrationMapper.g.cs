using AdventureWorksNS.Api.Contracts;
using AdventureWorksNS.Api.DataAccess;
using System;
using System.Collections.Generic;

namespace AdventureWorksNS.Api.Services
{
	public abstract class AbstractDALIllustrationMapper
	{
		public virtual Illustration MapModelToEntity(
			int illustrationID,
			ApiIllustrationServerRequestModel model
			)
		{
			Illustration item = new Illustration();
			item.SetProperties(
				illustrationID,
				model.Diagram,
				model.ModifiedDate);
			return item;
		}

		public virtual ApiIllustrationServerResponseModel MapEntityToModel(
			Illustration item)
		{
			var model = new ApiIllustrationServerResponseModel();

			model.SetProperties(item.IllustrationID,
			                    item.Diagram,
			                    item.ModifiedDate);

			return model;
		}

		public virtual List<ApiIllustrationServerResponseModel> MapEntityToModel(
			List<Illustration> items)
		{
			List<ApiIllustrationServerResponseModel> response = new List<ApiIllustrationServerResponseModel>();

			items.ForEach(x =>
			{
				response.Add(this.MapEntityToModel(x));
			});

			return response;
		}
	}
}

/*<Codenesium>
    <Hash>dccbae91f8a40705beab9d69c5cc04c0</Hash>
</Codenesium>*/