using StackOverflowNS.Api.DataAccess;
using System;
using System.Collections.Generic;

namespace StackOverflowNS.Api.Services
{
	public abstract class BOLAbstractPostHistoryMapper
	{
		public virtual BOPostHistory MapModelToBO(
			int id,
			ApiPostHistoryServerRequestModel model
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

		public virtual ApiPostHistoryServerResponseModel MapBOToModel(
			BOPostHistory boPostHistory)
		{
			var model = new ApiPostHistoryServerResponseModel();

			model.SetProperties(boPostHistory.Id, boPostHistory.Comment, boPostHistory.CreationDate, boPostHistory.PostHistoryTypeId, boPostHistory.PostId, boPostHistory.RevisionGUID, boPostHistory.Text, boPostHistory.UserDisplayName, boPostHistory.UserId);

			return model;
		}

		public virtual List<ApiPostHistoryServerResponseModel> MapBOToModel(
			List<BOPostHistory> items)
		{
			List<ApiPostHistoryServerResponseModel> response = new List<ApiPostHistoryServerResponseModel>();

			items.ForEach(d =>
			{
				response.Add(this.MapBOToModel(d));
			});

			return response;
		}
	}
}

/*<Codenesium>
    <Hash>b7f624573e9ca0e5d57b6f713500cf23</Hash>
</Codenesium>*/