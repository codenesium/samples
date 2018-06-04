using System;
using System.Collections.Generic;
using AdventureWorksNS.Api.Contracts;
using AdventureWorksNS.Api.DataAccess;
namespace AdventureWorksNS.Api.Services
{
	public abstract class BOLAbstractErrorLogMapper
	{
		public virtual BOErrorLog MapModelToBO(
			int errorLogID,
			ApiErrorLogRequestModel model
			)
		{
			BOErrorLog BOErrorLog = new BOErrorLog();

			BOErrorLog.SetProperties(
				errorLogID,
				model.ErrorLine,
				model.ErrorMessage,
				model.ErrorNumber,
				model.ErrorProcedure,
				model.ErrorSeverity,
				model.ErrorState,
				model.ErrorTime,
				model.UserName);
			return BOErrorLog;
		}

		public virtual ApiErrorLogResponseModel MapBOToModel(
			BOErrorLog BOErrorLog)
		{
			if (BOErrorLog == null)
			{
				return null;
			}

			var model = new ApiErrorLogResponseModel();

			model.SetProperties(BOErrorLog.ErrorLine, BOErrorLog.ErrorLogID, BOErrorLog.ErrorMessage, BOErrorLog.ErrorNumber, BOErrorLog.ErrorProcedure, BOErrorLog.ErrorSeverity, BOErrorLog.ErrorState, BOErrorLog.ErrorTime, BOErrorLog.UserName);

			return model;
		}

		public virtual List<ApiErrorLogResponseModel> MapBOToModel(
			List<BOErrorLog> BOs)
		{
			List<ApiErrorLogResponseModel> response = new List<ApiErrorLogResponseModel>();

			BOs.ForEach(d =>
			{
				response.Add(this.MapBOToModel(d));
			});

			return response;
		}
	}
}

/*<Codenesium>
    <Hash>3a56204202c0308a08508d23b0fbe73a</Hash>
</Codenesium>*/