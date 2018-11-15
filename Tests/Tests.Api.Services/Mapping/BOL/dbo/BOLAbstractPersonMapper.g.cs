using System;
using System.Collections.Generic;
using TestsNS.Api.DataAccess;

namespace TestsNS.Api.Services
{
	public abstract class BOLAbstractPersonMapper
	{
		public virtual BOPerson MapModelToBO(
			int personId,
			ApiPersonServerRequestModel model
			)
		{
			BOPerson boPerson = new BOPerson();
			boPerson.SetProperties(
				personId,
				model.PersonName);
			return boPerson;
		}

		public virtual ApiPersonServerResponseModel MapBOToModel(
			BOPerson boPerson)
		{
			var model = new ApiPersonServerResponseModel();

			model.SetProperties(boPerson.PersonId, boPerson.PersonName);

			return model;
		}

		public virtual List<ApiPersonServerResponseModel> MapBOToModel(
			List<BOPerson> items)
		{
			List<ApiPersonServerResponseModel> response = new List<ApiPersonServerResponseModel>();

			items.ForEach(d =>
			{
				response.Add(this.MapBOToModel(d));
			});

			return response;
		}
	}
}

/*<Codenesium>
    <Hash>e439ecb261a494961e28a1d9642b44f3</Hash>
</Codenesium>*/