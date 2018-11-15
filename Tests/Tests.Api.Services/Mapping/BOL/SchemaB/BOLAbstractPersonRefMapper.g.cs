using System;
using System.Collections.Generic;
using TestsNS.Api.DataAccess;

namespace TestsNS.Api.Services
{
	public abstract class BOLAbstractPersonRefMapper
	{
		public virtual BOPersonRef MapModelToBO(
			int id,
			ApiPersonRefServerRequestModel model
			)
		{
			BOPersonRef boPersonRef = new BOPersonRef();
			boPersonRef.SetProperties(
				id,
				model.PersonAId,
				model.PersonBId);
			return boPersonRef;
		}

		public virtual ApiPersonRefServerResponseModel MapBOToModel(
			BOPersonRef boPersonRef)
		{
			var model = new ApiPersonRefServerResponseModel();

			model.SetProperties(boPersonRef.Id, boPersonRef.PersonAId, boPersonRef.PersonBId);

			return model;
		}

		public virtual List<ApiPersonRefServerResponseModel> MapBOToModel(
			List<BOPersonRef> items)
		{
			List<ApiPersonRefServerResponseModel> response = new List<ApiPersonRefServerResponseModel>();

			items.ForEach(d =>
			{
				response.Add(this.MapBOToModel(d));
			});

			return response;
		}
	}
}

/*<Codenesium>
    <Hash>5d4cdeab17feae10aabcf7282fc61417</Hash>
</Codenesium>*/