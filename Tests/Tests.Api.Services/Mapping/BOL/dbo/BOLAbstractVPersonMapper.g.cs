using System;
using System.Collections.Generic;
using TestsNS.Api.Contracts;
using TestsNS.Api.DataAccess;

namespace TestsNS.Api.Services
{
	public abstract class BOLAbstractVPersonMapper
	{
		public virtual BOVPerson MapModelToBO(
			int personId,
			ApiVPersonRequestModel model
			)
		{
			BOVPerson boVPerson = new BOVPerson();
			boVPerson.SetProperties(
				personId,
				model.PersonName);
			return boVPerson;
		}

		public virtual ApiVPersonResponseModel MapBOToModel(
			BOVPerson boVPerson)
		{
			var model = new ApiVPersonResponseModel();

			model.SetProperties(boVPerson.PersonId, boVPerson.PersonName);

			return model;
		}

		public virtual List<ApiVPersonResponseModel> MapBOToModel(
			List<BOVPerson> items)
		{
			List<ApiVPersonResponseModel> response = new List<ApiVPersonResponseModel>();

			items.ForEach(d =>
			{
				response.Add(this.MapBOToModel(d));
			});

			return response;
		}
	}
}

/*<Codenesium>
    <Hash>0e9b4bb398bff3dcfd679f139dff110c</Hash>
</Codenesium>*/