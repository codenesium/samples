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
	public abstract class AbstractBOTransactionHistory
	{
		private ITransactionHistoryRepository transactionHistoryRepository;
		private ITransactionHistoryModelValidator transactionHistoryModelValidator;
		private ILogger logger;

		public AbstractBOTransactionHistory(
			ILogger logger,
			ITransactionHistoryRepository transactionHistoryRepository,
			ITransactionHistoryModelValidator transactionHistoryModelValidator)

		{
			this.transactionHistoryRepository = transactionHistoryRepository;
			this.transactionHistoryModelValidator = transactionHistoryModelValidator;
			this.logger = logger;
		}

		public virtual async Task<CreateResponse<int>> Create(
			TransactionHistoryModel model)
		{
			CreateResponse<int> response = new CreateResponse<int>(await this.transactionHistoryModelValidator.ValidateCreateAsync(model));
			if (response.Success)
			{
				int id = this.transactionHistoryRepository.Create(model);
				response.SetId(id);
			}

			return response;
		}

		public virtual async Task<ActionResponse> Update(
			int transactionID,
			TransactionHistoryModel model)
		{
			ActionResponse response = new ActionResponse(await this.transactionHistoryModelValidator.ValidateUpdateAsync(transactionID, model));

			if (response.Success)
			{
				this.transactionHistoryRepository.Update(transactionID, model);
			}

			return response;
		}

		public virtual async Task<ActionResponse> Delete(
			int transactionID)
		{
			ActionResponse response = new ActionResponse(await this.transactionHistoryModelValidator.ValidateDeleteAsync(transactionID));

			if (response.Success)
			{
				this.transactionHistoryRepository.Delete(transactionID);
			}
			return response;
		}

		public virtual POCOTransactionHistory Get(int transactionID)
		{
			return this.transactionHistoryRepository.Get(transactionID);
		}

		public virtual List<POCOTransactionHistory> All(int skip = 0, int take = int.MaxValue, string orderClause = "")
		{
			return this.transactionHistoryRepository.All(skip, take, orderClause);
		}
	}
}

/*<Codenesium>
    <Hash>e4fff5cbc538096a86f7d7640d617a55</Hash>
</Codenesium>*/