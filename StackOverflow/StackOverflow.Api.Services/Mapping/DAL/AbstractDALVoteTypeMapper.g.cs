using StackOverflowNS.Api.Contracts;
using StackOverflowNS.Api.DataAccess;
using System;
using System.Collections.Generic;

namespace StackOverflowNS.Api.Services
{
	public abstract class AbstractDALVoteTypeMapper
	{
		public virtual VoteType MapModelToEntity(
			int id,
			ApiVoteTypeServerRequestModel model
			)
		{
			VoteType item = new VoteType();
			item.SetProperties(
				id,
				model.Name);
			return item;
		}

		public virtual ApiVoteTypeServerResponseModel MapEntityToModel(
			VoteType item)
		{
			var model = new ApiVoteTypeServerResponseModel();

			model.SetProperties(item.Id,
			                    item.Name);

			return model;
		}

		public virtual List<ApiVoteTypeServerResponseModel> MapEntityToModel(
			List<VoteType> items)
		{
			List<ApiVoteTypeServerResponseModel> response = new List<ApiVoteTypeServerResponseModel>();

			items.ForEach(x =>
			{
				response.Add(this.MapEntityToModel(x));
			});

			return response;
		}
	}
}

/*<Codenesium>
    <Hash>9941788410cefa51c53ad91c7321a4c8</Hash>
</Codenesium>*/