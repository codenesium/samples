using System;
using System.Collections.Generic;
using TestsNS.Api.Contracts;
using TestsNS.Api.DataAccess;

namespace TestsNS.Api.Services
{
	public abstract class BOLAbstractPersonRefMapper
	{
		public virtual BOPersonRef MapModelToBO(
			int id,
			ApiPersonRefRequestModel model
			)
		{
			BOPersonRef boPersonRef = new BOPersonRef();
			boPersonRef.SetProperties(
				id,
				model.PersonAId,
				model.PersonBId);
			return boPersonRef;
		}

		public virtual ApiPersonRefResponseModel MapBOToModel(
			BOPersonRef boPersonRef)
		{
			var model = new ApiPersonRefResponseModel();

			model.SetProperties(boPersonRef.Id, boPersonRef.PersonAId, boPersonRef.PersonBId);

			return model;
		}

		public virtual List<ApiPersonRefResponseModel> MapBOToModel(
			List<BOPersonRef> items)
		{
			List<ApiPersonRefResponseModel> response = new List<ApiPersonRefResponseModel>();

			items.ForEach(d =>
			{
				response.Add(this.MapBOToModel(d));
			});

			return response;
		}
	}
}

/*<Codenesium>
    <Hash>f44d481953c776814e9553c15a7b4bc0</Hash>
</Codenesium>*/