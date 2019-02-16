using AdventureWorksNS.Api.Contracts;
using AdventureWorksNS.Api.DataAccess;
using System;
using System.Collections.Generic;

namespace AdventureWorksNS.Api.Services
{
	public abstract class AbstractDALIllustrationMapper
	{
		public virtual Illustration MapModelToBO(
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

		public virtual ApiIllustrationServerResponseModel MapBOToModel(
			Illustration item)
		{
			var model = new ApiIllustrationServerResponseModel();

			model.SetProperties(item.IllustrationID, item.Diagram, item.ModifiedDate);

			return model;
		}

		public virtual List<ApiIllustrationServerResponseModel> MapBOToModel(
			List<Illustration> items)
		{
			List<ApiIllustrationServerResponseModel> response = new List<ApiIllustrationServerResponseModel>();

			items.ForEach(d =>
			{
				response.Add(this.MapBOToModel(d));
			});

			return response;
		}
	}
}

/*<Codenesium>
    <Hash>257b5c71e551bbbc37be3ff1c88ce636</Hash>
</Codenesium>*/