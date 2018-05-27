using System;
using System.Collections.Generic;
using AdventureWorksNS.Api.Contracts;
using AdventureWorksNS.Api.DataAccess;
namespace AdventureWorksNS.Api.BusinessObjects
{
	public abstract class AbstractBOLErrorLogMapper
	{
		public virtual DTOErrorLog MapModelToDTO(
			int errorLogID,
			ApiErrorLogRequestModel model
			)
		{
			DTOErrorLog dtoErrorLog = new DTOErrorLog();

			dtoErrorLog.SetProperties(
				errorLogID,
				model.ErrorLine,
				model.ErrorMessage,
				model.ErrorNumber,
				model.ErrorProcedure,
				model.ErrorSeverity,
				model.ErrorState,
				model.ErrorTime,
				model.UserName);
			return dtoErrorLog;
		}

		public virtual ApiErrorLogResponseModel MapDTOToModel(
			DTOErrorLog dtoErrorLog)
		{
			if (dtoErrorLog == null)
			{
				return null;
			}

			var model = new ApiErrorLogResponseModel();

			model.SetProperties(dtoErrorLog.ErrorLine, dtoErrorLog.ErrorLogID, dtoErrorLog.ErrorMessage, dtoErrorLog.ErrorNumber, dtoErrorLog.ErrorProcedure, dtoErrorLog.ErrorSeverity, dtoErrorLog.ErrorState, dtoErrorLog.ErrorTime, dtoErrorLog.UserName);

			return model;
		}

		public virtual List<ApiErrorLogResponseModel> MapDTOToModel(
			List<DTOErrorLog> dtos)
		{
			List<ApiErrorLogResponseModel> response = new List<ApiErrorLogResponseModel>();

			dtos.ForEach(d =>
			{
				response.Add(this.MapDTOToModel(d));
			});

			return response;
		}
	}
}

/*<Codenesium>
    <Hash>fd225c8b3f3a5aa94342c928cd2d234f</Hash>
</Codenesium>*/