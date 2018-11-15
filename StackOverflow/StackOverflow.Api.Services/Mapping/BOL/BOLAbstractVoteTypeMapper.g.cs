using StackOverflowNS.Api.DataAccess;
using System;
using System.Collections.Generic;

namespace StackOverflowNS.Api.Services
{
	public abstract class BOLAbstractVoteTypeMapper
	{
		public virtual BOVoteType MapModelToBO(
			int id,
			ApiVoteTypeServerRequestModel model
			)
		{
			BOVoteType boVoteType = new BOVoteType();
			boVoteType.SetProperties(
				id,
				model.Name);
			return boVoteType;
		}

		public virtual ApiVoteTypeServerResponseModel MapBOToModel(
			BOVoteType boVoteType)
		{
			var model = new ApiVoteTypeServerResponseModel();

			model.SetProperties(boVoteType.Id, boVoteType.Name);

			return model;
		}

		public virtual List<ApiVoteTypeServerResponseModel> MapBOToModel(
			List<BOVoteType> items)
		{
			List<ApiVoteTypeServerResponseModel> response = new List<ApiVoteTypeServerResponseModel>();

			items.ForEach(d =>
			{
				response.Add(this.MapBOToModel(d));
			});

			return response;
		}
	}
}

/*<Codenesium>
    <Hash>8ee98b0eb393daba2c806d701d779682</Hash>
</Codenesium>*/