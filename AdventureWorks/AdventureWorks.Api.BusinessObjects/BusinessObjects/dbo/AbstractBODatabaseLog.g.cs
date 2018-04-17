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
	public abstract class AbstractBODatabaseLog
	{
		private IDatabaseLogRepository databaseLogRepository;
		private IDatabaseLogModelValidator databaseLogModelValidator;
		private ILogger logger;

		public AbstractBODatabaseLog(
			ILogger logger,
			IDatabaseLogRepository databaseLogRepository,
			IDatabaseLogModelValidator databaseLogModelValidator)

		{
			this.databaseLogRepository = databaseLogRepository;
			this.databaseLogModelValidator = databaseLogModelValidator;
			this.logger = logger;
		}

		public virtual async Task<CreateResponse<int>> Create(
			DatabaseLogModel model)
		{
			CreateResponse<int> response = new CreateResponse<int>(await this.databaseLogModelValidator.ValidateCreateAsync(model));
			if (response.Success)
			{
				int id = this.databaseLogRepository.Create(model);
				response.SetId(id);
			}

			return response;
		}

		public virtual async Task<ActionResponse> Update(
			int databaseLogID,
			DatabaseLogModel model)
		{
			ActionResponse response = new ActionResponse(await this.databaseLogModelValidator.ValidateUpdateAsync(databaseLogID, model));

			if (response.Success)
			{
				this.databaseLogRepository.Update(databaseLogID, model);
			}

			return response;
		}

		public virtual async Task<ActionResponse> Delete(
			int databaseLogID)
		{
			ActionResponse response = new ActionResponse(await this.databaseLogModelValidator.ValidateDeleteAsync(databaseLogID));

			if (response.Success)
			{
				this.databaseLogRepository.Delete(databaseLogID);
			}
			return response;
		}

		public virtual ApiResponse GetById(int databaseLogID)
		{
			return this.databaseLogRepository.GetById(databaseLogID);
		}

		public virtual POCODatabaseLog GetByIdDirect(int databaseLogID)
		{
			return this.databaseLogRepository.GetByIdDirect(databaseLogID);
		}

		public virtual ApiResponse GetWhere(Expression<Func<EFDatabaseLog, bool>> predicate, int skip = 0, int take = int.MaxValue, string orderClause = "")
		{
			return this.databaseLogRepository.GetWhere(predicate, skip, take, orderClause);
		}

		public virtual ApiResponse GetWhereDynamic(string predicate, int skip = 0, int take = int.MaxValue, string orderClause = "")
		{
			return this.databaseLogRepository.GetWhereDynamic(predicate, skip, take, orderClause);
		}

		public virtual List<POCODatabaseLog> GetWhereDirect(Expression<Func<EFDatabaseLog, bool>> predicate, int skip = 0, int take = int.MaxValue, string orderClause = "")
		{
			return this.databaseLogRepository.GetWhereDirect(predicate, skip, take, orderClause);
		}
	}
}

/*<Codenesium>
    <Hash>f2c1f76007ed3a1c8af927211cfee052</Hash>
</Codenesium>*/