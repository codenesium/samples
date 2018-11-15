using System;
using System.Collections.Generic;
using TestsNS.Api.DataAccess;

namespace TestsNS.Api.Services
{
	public abstract class BOLAbstractVPersonMapper
	{
		public virtual BOVPerson MapModelToBO(
			int personId,
			ApiVPersonServerRequestModel model
			)
		{
			BOVPerson boVPerson = new BOVPerson();
			boVPerson.SetProperties(
				personId,
				model.PersonName);
			return boVPerson;
		}

		public virtual ApiVPersonServerResponseModel MapBOToModel(
			BOVPerson boVPerson)
		{
			var model = new ApiVPersonServerResponseModel();

			model.SetProperties(boVPerson.PersonId, boVPerson.PersonName);

			return model;
		}

		public virtual List<ApiVPersonServerResponseModel> MapBOToModel(
			List<BOVPerson> items)
		{
			List<ApiVPersonServerResponseModel> response = new List<ApiVPersonServerResponseModel>();

			items.ForEach(d =>
			{
				response.Add(this.MapBOToModel(d));
			});

			return response;
		}
	}
}

/*<Codenesium>
    <Hash>8299f6bb5182fc693813cb864b9e2d03</Hash>
</Codenesium>*/