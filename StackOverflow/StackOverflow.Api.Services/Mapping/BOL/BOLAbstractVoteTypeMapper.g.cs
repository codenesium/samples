using StackOverflowNS.Api.Contracts;
using StackOverflowNS.Api.DataAccess;
using System;
using System.Collections.Generic;

namespace StackOverflowNS.Api.Services
{
	public abstract class BOLAbstractVoteTypeMapper
	{
		public virtual BOVoteType MapModelToBO(
			int id,
			ApiVoteTypeRequestModel model
			)
		{
			BOVoteType boVoteType = new BOVoteType();
			boVoteType.SetProperties(
				id,
				model.Name);
			return boVoteType;
		}

		public virtual ApiVoteTypeResponseModel MapBOToModel(
			BOVoteType boVoteType)
		{
			var model = new ApiVoteTypeResponseModel();

			model.SetProperties(boVoteType.Id, boVoteType.Name);

			return model;
		}

		public virtual List<ApiVoteTypeResponseModel> MapBOToModel(
			List<BOVoteType> items)
		{
			List<ApiVoteTypeResponseModel> response = new List<ApiVoteTypeResponseModel>();

			items.ForEach(d =>
			{
				response.Add(this.MapBOToModel(d));
			});

			return response;
		}
	}
}

/*<Codenesium>
    <Hash>1f955747836346709e73b488b702cdb6</Hash>
</Codenesium>*/