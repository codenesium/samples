using AdventureWorksNS.Api.DataAccess;
using System;
using System.Collections.Generic;

namespace AdventureWorksNS.Api.Services
{
	public abstract class BOLAbstractContactTypeMapper
	{
		public virtual BOContactType MapModelToBO(
			int contactTypeID,
			ApiContactTypeServerRequestModel model
			)
		{
			BOContactType boContactType = new BOContactType();
			boContactType.SetProperties(
				contactTypeID,
				model.ModifiedDate,
				model.Name);
			return boContactType;
		}

		public virtual ApiContactTypeServerResponseModel MapBOToModel(
			BOContactType boContactType)
		{
			var model = new ApiContactTypeServerResponseModel();

			model.SetProperties(boContactType.ContactTypeID, boContactType.ModifiedDate, boContactType.Name);

			return model;
		}

		public virtual List<ApiContactTypeServerResponseModel> MapBOToModel(
			List<BOContactType> items)
		{
			List<ApiContactTypeServerResponseModel> response = new List<ApiContactTypeServerResponseModel>();

			items.ForEach(d =>
			{
				response.Add(this.MapBOToModel(d));
			});

			return response;
		}
	}
}

/*<Codenesium>
    <Hash>6d39a32948ea97b176e5c5b4ddbaeee4</Hash>
</Codenesium>*/