using System;
using System.Collections.Generic;
using TestsNS.Api.Contracts;
using TestsNS.Api.DataAccess;

namespace TestsNS.Api.Services
{
	public abstract class BOLAbstractPersonMapper
	{
		public virtual BOPerson MapModelToBO(
			int personId,
			ApiPersonRequestModel model
			)
		{
			BOPerson boPerson = new BOPerson();
			boPerson.SetProperties(
				personId,
				model.PersonName);
			return boPerson;
		}

		public virtual ApiPersonResponseModel MapBOToModel(
			BOPerson boPerson)
		{
			var model = new ApiPersonResponseModel();

			model.SetProperties(boPerson.PersonId, boPerson.PersonName);

			return model;
		}

		public virtual List<ApiPersonResponseModel> MapBOToModel(
			List<BOPerson> items)
		{
			List<ApiPersonResponseModel> response = new List<ApiPersonResponseModel>();

			items.ForEach(d =>
			{
				response.Add(this.MapBOToModel(d));
			});

			return response;
		}
	}
}

/*<Codenesium>
    <Hash>bd25bce1d833db15332f9d0f3c364f77</Hash>
</Codenesium>*/