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
		private IApiDatabaseLogModelValidator databaseLogModelValidator;
		private ILogger logger;

		public AbstractBODatabaseLog(
			ILogger logger,
			IDatabaseLogRepository databaseLogRepository,
			IApiDatabaseLogModelValidator databaseLogModelValidator)

		{
			this.databaseLogRepository = databaseLogRepository;
			this.databaseLogModelValidator = databaseLogModelValidator;
			this.logger = logger;
		}

		public virtual List<POCODatabaseLog> All(int skip = 0, int take = int.MaxValue, string orderClause = "")
		{
			return this.databaseLogRepository.All(skip, take, orderClause);
		}

		public virtual POCODatabaseLog Get(int databaseLogID)
		{
			return this.databaseLogRepository.Get(databaseLogID);
		}

		public virtual async Task<CreateResponse<POCODatabaseLog>> Create(
			ApiDatabaseLogModel model)
		{
			CreateResponse<POCODatabaseLog> response = new CreateResponse<POCODatabaseLog>(await this.databaseLogModelValidator.ValidateCreateAsync(model));
			if (response.Success)
			{
				POCODatabaseLog record = this.databaseLogRepository.Create(model);
				response.SetRecord(record);
			}

			return response;
		}

		public virtual async Task<ActionResponse> Update(
			int databaseLogID,
			ApiDatabaseLogModel model)
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
	}
}

/*<Codenesium>
    <Hash>37cd1181db0813624bbb5bed28ed6c62</Hash>
</Codenesium>*/