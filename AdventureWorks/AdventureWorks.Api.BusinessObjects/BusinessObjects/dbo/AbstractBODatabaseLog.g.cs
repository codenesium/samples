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

		public virtual POCODatabaseLog Get(int databaseLogID)
		{
			return this.databaseLogRepository.Get(databaseLogID);
		}

		public virtual List<POCODatabaseLog> All(int skip = 0, int take = int.MaxValue, string orderClause = "")
		{
			return this.databaseLogRepository.All(skip, take, orderClause);
		}
	}
}

/*<Codenesium>
    <Hash>dc9e7896255f1f38f33b5351b19e6a69</Hash>
</Codenesium>*/