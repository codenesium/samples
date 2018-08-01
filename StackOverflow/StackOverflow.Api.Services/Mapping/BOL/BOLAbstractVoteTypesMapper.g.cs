using StackOverflowNS.Api.Contracts;
using StackOverflowNS.Api.DataAccess;
using System;
using System.Collections.Generic;

namespace StackOverflowNS.Api.Services
{
	public abstract class BOLAbstractVoteTypesMapper
	{
		public virtual BOVoteTypes MapModelToBO(
			int id,
			ApiVoteTypesRequestModel model
			)
		{
			BOVoteTypes boVoteTypes = new BOVoteTypes();
			boVoteTypes.SetProperties(
				id,
				model.Name);
			return boVoteTypes;
		}

		public virtual ApiVoteTypesResponseModel MapBOToModel(
			BOVoteTypes boVoteTypes)
		{
			var model = new ApiVoteTypesResponseModel();

			model.SetProperties(boVoteTypes.Id, boVoteTypes.Name);

			return model;
		}

		public virtual List<ApiVoteTypesResponseModel> MapBOToModel(
			List<BOVoteTypes> items)
		{
			List<ApiVoteTypesResponseModel> response = new List<ApiVoteTypesResponseModel>();

			items.ForEach(d =>
			{
				response.Add(this.MapBOToModel(d));
			});

			return response;
		}
	}
}

/*<Codenesium>
    <Hash>1df56dabbb9102e4a8a5d24ed34d06e6</Hash>
</Codenesium>*/