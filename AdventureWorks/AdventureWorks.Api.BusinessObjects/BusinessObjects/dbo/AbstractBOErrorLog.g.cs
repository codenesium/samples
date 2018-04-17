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
		private IErrorLogModelValidator errorLogModelValidator;
		private ILogger logger;

		public AbstractBOErrorLog(
			ILogger logger,
			IErrorLogRepository errorLogRepository,
			IErrorLogModelValidator errorLogModelValidator)

		{
			this.errorLogRepository = errorLogRepository;
			this.errorLogModelValidator = errorLogModelValidator;
			this.logger = logger;
		}

		public virtual async Task<CreateResponse<int>> Create(
			ErrorLogModel model)
		{
			CreateResponse<int> response = new CreateResponse<int>(await this.errorLogModelValidator.ValidateCreateAsync(model));
			if (response.Success)
			{
				int id = this.errorLogRepository.Create(model);
				response.SetId(id);
			}

			return response;
		}

		public virtual async Task<ActionResponse> Update(
			int errorLogID,
			ErrorLogModel model)
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

		public virtual ApiResponse GetById(int errorLogID)
		{
			return this.errorLogRepository.GetById(errorLogID);
		}

		public virtual POCOErrorLog GetByIdDirect(int errorLogID)
		{
			return this.errorLogRepository.GetByIdDirect(errorLogID);
		}

		public virtual ApiResponse GetWhere(Expression<Func<EFErrorLog, bool>> predicate, int skip = 0, int take = int.MaxValue, string orderClause = "")
		{
			return this.errorLogRepository.GetWhere(predicate, skip, take, orderClause);
		}

		public virtual ApiResponse GetWhereDynamic(string predicate, int skip = 0, int take = int.MaxValue, string orderClause = "")
		{
			return this.errorLogRepository.GetWhereDynamic(predicate, skip, take, orderClause);
		}

		public virtual List<POCOErrorLog> GetWhereDirect(Expression<Func<EFErrorLog, bool>> predicate, int skip = 0, int take = int.MaxValue, string orderClause = "")
		{
			return this.errorLogRepository.GetWhereDirect(predicate, skip, take, orderClause);
		}
	}
}

/*<Codenesium>
    <Hash>aa3ed286144b57db4268878fdbb6a222</Hash>
</Codenesium>*/