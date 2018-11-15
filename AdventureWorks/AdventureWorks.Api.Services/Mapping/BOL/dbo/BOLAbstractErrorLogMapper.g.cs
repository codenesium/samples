using AdventureWorksNS.Api.DataAccess;
using System;
using System.Collections.Generic;

namespace AdventureWorksNS.Api.Services
{
	public abstract class BOLAbstractErrorLogMapper
	{
		public virtual BOErrorLog MapModelToBO(
			int errorLogID,
			ApiErrorLogServerRequestModel model
			)
		{
			BOErrorLog boErrorLog = new BOErrorLog();
			boErrorLog.SetProperties(
				errorLogID,
				model.ErrorLine,
				model.ErrorMessage,
				model.ErrorNumber,
				model.ErrorProcedure,
				model.ErrorSeverity,
				model.ErrorState,
				model.ErrorTime,
				model.UserName);
			return boErrorLog;
		}

		public virtual ApiErrorLogServerResponseModel MapBOToModel(
			BOErrorLog boErrorLog)
		{
			var model = new ApiErrorLogServerResponseModel();

			model.SetProperties(boErrorLog.ErrorLogID, boErrorLog.ErrorLine, boErrorLog.ErrorMessage, boErrorLog.ErrorNumber, boErrorLog.ErrorProcedure, boErrorLog.ErrorSeverity, boErrorLog.ErrorState, boErrorLog.ErrorTime, boErrorLog.UserName);

			return model;
		}

		public virtual List<ApiErrorLogServerResponseModel> MapBOToModel(
			List<BOErrorLog> items)
		{
			List<ApiErrorLogServerResponseModel> response = new List<ApiErrorLogServerResponseModel>();

			items.ForEach(d =>
			{
				response.Add(this.MapBOToModel(d));
			});

			return response;
		}
	}
}

/*<Codenesium>
    <Hash>7ca58bec32f95181986a4f84fbcc6b39</Hash>
</Codenesium>*/