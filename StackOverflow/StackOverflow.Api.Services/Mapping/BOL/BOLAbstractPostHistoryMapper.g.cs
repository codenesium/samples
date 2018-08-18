using StackOverflowNS.Api.Contracts;
using StackOverflowNS.Api.DataAccess;
using System;
using System.Collections.Generic;

namespace StackOverflowNS.Api.Services
{
	public abstract class BOLAbstractPostHistoryMapper
	{
		public virtual BOPostHistory MapModelToBO(
			int id,
			ApiPostHistoryRequestModel model
			)
		{
			BOPostHistory boPostHistory = new BOPostHistory();
			boPostHistory.SetProperties(
				id,
				model.Comment,
				model.CreationDate,
				model.PostHistoryTypeId,
				model.PostId,
				model.RevisionGUID,
				model.Text,
				model.UserDisplayName,
				model.UserId);
			return boPostHistory;
		}

		public virtual ApiPostHistoryResponseModel MapBOToModel(
			BOPostHistory boPostHistory)
		{
			var model = new ApiPostHistoryResponseModel();

			model.SetProperties(boPostHistory.Id, boPostHistory.Comment, boPostHistory.CreationDate, boPostHistory.PostHistoryTypeId, boPostHistory.PostId, boPostHistory.RevisionGUID, boPostHistory.Text, boPostHistory.UserDisplayName, boPostHistory.UserId);

			return model;
		}

		public virtual List<ApiPostHistoryResponseModel> MapBOToModel(
			List<BOPostHistory> items)
		{
			List<ApiPostHistoryResponseModel> response = new List<ApiPostHistoryResponseModel>();

			items.ForEach(d =>
			{
				response.Add(this.MapBOToModel(d));
			});

			return response;
		}
	}
}

/*<Codenesium>
    <Hash>f26cc9df9e4ddc2136d9aad3a5a6d9f2</Hash>
</Codenesium>*/