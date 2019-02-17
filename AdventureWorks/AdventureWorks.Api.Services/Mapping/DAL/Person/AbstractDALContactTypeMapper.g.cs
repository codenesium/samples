using AdventureWorksNS.Api.Contracts;
using AdventureWorksNS.Api.DataAccess;
using System;
using System.Collections.Generic;

namespace AdventureWorksNS.Api.Services
{
	public abstract class AbstractDALContactTypeMapper
	{
		public virtual ContactType MapModelToEntity(
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

		public virtual ApiContactTypeServerResponseModel MapEntityToModel(
			ContactType item)
		{
			var model = new ApiContactTypeServerResponseModel();

			model.SetProperties(item.ContactTypeID,
			                    item.ModifiedDate,
			                    item.Name);

			return model;
		}

		public virtual List<ApiContactTypeServerResponseModel> MapEntityToModel(
			List<ContactType> items)
		{
			List<ApiContactTypeServerResponseModel> response = new List<ApiContactTypeServerResponseModel>();

			items.ForEach(x =>
			{
				response.Add(this.MapEntityToModel(x));
			});

			return response;
		}
	}
}

/*<Codenesium>
    <Hash>4681d525b3fd762d41d3cab56496bf7d</Hash>
</Codenesium>*/