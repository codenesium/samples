using AdventureWorksNS.Api.Contracts;
using AdventureWorksNS.Api.DataAccess;
using System;
using System.Collections.Generic;

namespace AdventureWorksNS.Api.Services
{
	public abstract class AbstractDALErrorLogMapper
	{
		public virtual ErrorLog MapModelToEntity(
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

		public virtual ApiErrorLogServerResponseModel MapEntityToModel(
			ErrorLog item)
		{
			var model = new ApiErrorLogServerResponseModel();

			model.SetProperties(item.ErrorLogID,
			                    item.ErrorLine,
			                    item.ErrorMessage,
			                    item.ErrorNumber,
			                    item.ErrorProcedure,
			                    item.ErrorSeverity,
			                    item.ErrorState,
			                    item.ErrorTime,
			                    item.UserName);

			return model;
		}

		public virtual List<ApiErrorLogServerResponseModel> MapEntityToModel(
			List<ErrorLog> items)
		{
			List<ApiErrorLogServerResponseModel> response = new List<ApiErrorLogServerResponseModel>();

			items.ForEach(x =>
			{
				response.Add(this.MapEntityToModel(x));
			});

			return response;
		}
	}
}

/*<Codenesium>
    <Hash>b5aa5c13e00695c3194cbf1d3c8b8665</Hash>
</Codenesium>*/