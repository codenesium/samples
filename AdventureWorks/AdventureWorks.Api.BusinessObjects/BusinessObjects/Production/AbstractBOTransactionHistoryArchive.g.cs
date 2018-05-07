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
	public abstract class AbstractBOTransactionHistoryArchive
	{
		private ITransactionHistoryArchiveRepository transactionHistoryArchiveRepository;
		private ITransactionHistoryArchiveModelValidator transactionHistoryArchiveModelValidator;
		private ILogger logger;

		public AbstractBOTransactionHistoryArchive(
			ILogger logger,
			ITransactionHistoryArchiveRepository transactionHistoryArchiveRepository,
			ITransactionHistoryArchiveModelValidator transactionHistoryArchiveModelValidator)

		{
			this.transactionHistoryArchiveRepository = transactionHistoryArchiveRepository;
			this.transactionHistoryArchiveModelValidator = transactionHistoryArchiveModelValidator;
			this.logger = logger;
		}

		public virtual async Task<CreateResponse<int>> Create(
			TransactionHistoryArchiveModel model)
		{
			CreateResponse<int> response = new CreateResponse<int>(await this.transactionHistoryArchiveModelValidator.ValidateCreateAsync(model));
			if (response.Success)
			{
				int id = this.transactionHistoryArchiveRepository.Create(model);
				response.SetId(id);
			}

			return response;
		}

		public virtual async Task<ActionResponse> Update(
			int transactionID,
			TransactionHistoryArchiveModel model)
		{
			ActionResponse response = new ActionResponse(await this.transactionHistoryArchiveModelValidator.ValidateUpdateAsync(transactionID, model));

			if (response.Success)
			{
				this.transactionHistoryArchiveRepository.Update(transactionID, model);
			}

			return response;
		}

		public virtual async Task<ActionResponse> Delete(
			int transactionID)
		{
			ActionResponse response = new ActionResponse(await this.transactionHistoryArchiveModelValidator.ValidateDeleteAsync(transactionID));

			if (response.Success)
			{
				this.transactionHistoryArchiveRepository.Delete(transactionID);
			}
			return response;
		}

		public virtual POCOTransactionHistoryArchive Get(int transactionID)
		{
			return this.transactionHistoryArchiveRepository.Get(transactionID);
		}

		public virtual List<POCOTransactionHistoryArchive> All(int skip = 0, int take = int.MaxValue, string orderClause = "")
		{
			return this.transactionHistoryArchiveRepository.All(skip, take, orderClause);
		}
	}
}

/*<Codenesium>
    <Hash>abbf50f421bd5e56d1e34e7f0fd39701</Hash>
</Codenesium>*/