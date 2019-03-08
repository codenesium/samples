using StackOverflowNS.Api.Contracts;
using StackOverflowNS.Api.DataAccess;
using System;
using System.Collections.Generic;

namespace StackOverflowNS.Api.Services
{
	public abstract class AbstractDALVoteTypesMapper
	{
		public virtual VoteTypes MapModelToEntity(
			int id,
			ApiVoteTypesServerRequestModel model
			)
		{
			VoteTypes item = new VoteTypes();
			item.SetProperties(
				id,
				model.Name);
			return item;
		}

		public virtual ApiVoteTypesServerResponseModel MapEntityToModel(
			VoteTypes item)
		{
			var model = new ApiVoteTypesServerResponseModel();

			model.SetProperties(item.Id,
			                    item.Name);

			return model;
		}

		public virtual List<ApiVoteTypesServerResponseModel> MapEntityToModel(
			List<VoteTypes> items)
		{
			List<ApiVoteTypesServerResponseModel> response = new List<ApiVoteTypesServerResponseModel>();

			items.ForEach(x =>
			{
				response.Add(this.MapEntityToModel(x));
			});

			return response;
		}
	}
}

/*<Codenesium>
    <Hash>ea82dd2b62ddf94c612c36a47af3e8b9</Hash>
</Codenesium>*/