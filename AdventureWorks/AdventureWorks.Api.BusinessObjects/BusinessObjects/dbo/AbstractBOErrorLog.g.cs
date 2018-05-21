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
	public abstract class AbstractBOErrorLog: AbstractBOManager
	{
		private IErrorLogRepository errorLogRepository;
		private IApiErrorLogModelValidator errorLogModelValidator;
		private ILogger logger;

		public AbstractBOErrorLog(
			ILogger logger,
			IErrorLogRepository errorLogRepository,
			IApiErrorLogModelValidator errorLogModelValidator)
			: base()

		{
			this.errorLogRepository = errorLogRepository;
			this.errorLogModelValidator = errorLogModelValidator;
			this.logger = logger;
		}

		public virtual Task<List<POCOErrorLog>> All(int skip = 0, int take = int.MaxValue, string orderClause = "")
		{
			return this.errorLogRepository.All(skip, take, orderClause);
		}

		public virtual Task<POCOErrorLog> Get(int errorLogID)
		{
			return this.errorLogRepository.Get(errorLogID);
		}

		public virtual async Task<CreateResponse<POCOErrorLog>> Create(
			ApiErrorLogModel model)
		{
			CreateResponse<POCOErrorLog> response = new CreateResponse<POCOErrorLog>(await this.errorLogModelValidator.ValidateCreateAsync(model));
			if (response.Success)
			{
				POCOErrorLog record = await this.errorLogRepository.Create(model);

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
				await this.errorLogRepository.Update(errorLogID, model);
			}

			return response;
		}

		public virtual async Task<ActionResponse> Delete(
			int errorLogID)
		{
			ActionResponse response = new ActionResponse(await this.errorLogModelValidator.ValidateDeleteAsync(errorLogID));

			if (response.Success)
			{
				await this.errorLogRepository.Delete(errorLogID);
			}
			return response;
		}
	}
}

/*<Codenesium>
    <Hash>8a3c338ff95efc772a228b7906d42153</Hash>
</Codenesium>*/