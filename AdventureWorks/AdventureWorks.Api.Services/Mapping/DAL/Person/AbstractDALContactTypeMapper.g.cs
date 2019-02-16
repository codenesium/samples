using AdventureWorksNS.Api.Contracts;
using AdventureWorksNS.Api.DataAccess;
using System;
using System.Collections.Generic;

namespace AdventureWorksNS.Api.Services
{
	public abstract class AbstractDALContactTypeMapper
	{
		public virtual ContactType MapModelToBO(
			int contactTypeID,
			ApiContactTypeServerRequestModel model
			)
		{
			ContactType item = new ContactType();
			item.SetProperties(
				contactTypeID,
				model.ModifiedDate,
				model.Name);
			return item;
		}

		public virtual ApiContactTypeServerResponseModel MapBOToModel(
			ContactType item)
		{
			var model = new ApiContactTypeServerResponseModel();

			model.SetProperties(item.ContactTypeID, item.ModifiedDate, item.Name);

			return model;
		}

		public virtual List<ApiContactTypeServerResponseModel> MapBOToModel(
			List<ContactType> items)
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
    <Hash>e5f4a5ec12a9e91a832a7fbc31da1d3c</Hash>
</Codenesium>*/