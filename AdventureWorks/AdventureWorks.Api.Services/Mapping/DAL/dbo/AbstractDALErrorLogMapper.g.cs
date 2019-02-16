using AdventureWorksNS.Api.Contracts;
using AdventureWorksNS.Api.DataAccess;
using System;
using System.Collections.Generic;

namespace AdventureWorksNS.Api.Services
{
	public abstract class AbstractDALErrorLogMapper
	{
		public virtual ErrorLog MapModelToBO(
			int errorLogID,
			ApiErrorLogServerRequestModel model
			)
		{
			ErrorLog item = new ErrorLog();
			item.SetProperties(
				errorLogID,
				model.ErrorLine,
				model.ErrorMessage,
				model.ErrorNumber,
				model.ErrorProcedure,
				model.ErrorSeverity,
				model.ErrorState,
				model.ErrorTime,
				model.UserName);
			return item;
		}

		public virtual ApiErrorLogServerResponseModel MapBOToModel(
			ErrorLog item)
		{
			var model = new ApiErrorLogServerResponseModel();

			model.SetProperties(item.ErrorLogID, item.ErrorLine, item.ErrorMessage, item.ErrorNumber, item.ErrorProcedure, item.ErrorSeverity, item.ErrorState, item.ErrorTime, item.UserName);

			return model;
		}

		public virtual List<ApiErrorLogServerResponseModel> MapBOToModel(
			List<ErrorLog> items)
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
    <Hash>916195886e5ad2518224f19226c6b6d4</Hash>
</Codenesium>*/