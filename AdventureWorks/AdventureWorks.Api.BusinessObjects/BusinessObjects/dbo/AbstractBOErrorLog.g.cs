using Codenesium.DataConversionExtensions.AspNetCore;
using System;
using System.Collections.Generic;
using Microsoft.Extensions.Logging;
using Microsoft.EntityFrameworkCore;
using System.Linq;
using System.Linq.Dynamic.Core;
using System.Linq.Expressions;
using System.Threading.Tasks;
using AdventureWorksNS.Api.Contracts;
using AdventureWorksNS.Api.DataAccess;

namespace AdventureWorksNS.Api.BusinessObjects
{
	public abstract class AbstractBOErrorLog
	{
		private IErrorLogRepository errorLogRepository;
		private IApiErrorLogModelValidator errorLogModelValidator;
		private ILogger logger;

		public AbstractBOErrorLog(
			ILogger logger,
			IErrorLogRepository errorLogRepository,
			IApiErrorLogModelValidator errorLogModelValidator)

		{
			this.errorLogRepository = errorLogRepository;
			this.errorLogModelValidator = errorLogModelValidator;
			this.logger = logger;
		}

		public virtual List<POCOErrorLog> All(int skip = 0, int take = int.MaxValue, string orderClause = "")
		{
			return this.errorLogRepository.All(skip, take, orderClause);
		}

		public virtual POCOErrorLog Get(int errorLogID)
		{
			return this.errorLogRepository.Get(errorLogID);
		}

		public virtual async Task<CreateResponse<POCOErrorLog>> Create(
			ApiErrorLogModel model)
		{
			CreateResponse<POCOErrorLog> response = new CreateResponse<POCOErrorLog>(await this.errorLogModelValidator.ValidateCreateAsync(model));
			if (response.Success)
			{
				POCOErrorLog record = this.errorLogRepository.Create(model);
				response.SetRecord(record);
			}

			return response;
		}

		public virtual async Task<ActionResponse> Update(
			int errorLogID,
			ApiErrorLogModel model)
		{
			ActionResponse response = new ActionResponse(await this.errorLogModelValidator.ValidateUpdateAsync(errorLogID, model));

			if (response.Success)
			{
				this.errorLogRepository.Update(errorLogID, model);
			}

			return response;
		}

		public virtual async Task<ActionResponse> Delete(
			int errorLogID)
		{
			ActionResponse response = new ActionResponse(await this.errorLogModelValidator.ValidateDeleteAsync(errorLogID));

			if (response.Success)
			{
				this.errorLogRepository.Delete(errorLogID);
			}
			return response;
		}
	}
}

/*<Codenesium>
    <Hash>12973a65371fd68a5143df836ca48742</Hash>
</Codenesium>*/