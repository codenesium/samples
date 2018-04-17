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

		public virtual ApiResponse GetById(int transactionID)
		{
			return this.transactionHistoryRepository.GetById(transactionID);
		}

		public virtual POCOTransactionHistory GetByIdDirect(int transactionID)
		{
			return this.transactionHistoryRepository.GetByIdDirect(transactionID);
		}

		public virtual ApiResponse GetWhere(Expression<Func<EFTransactionHistory, bool>> predicate, int skip = 0, int take = int.MaxValue, string orderClause = "")
		{
			return this.transactionHistoryRepository.GetWhere(predicate, skip, take, orderClause);
		}

		public virtual ApiResponse GetWhereDynamic(string predicate, int skip = 0, int take = int.MaxValue, string orderClause = "")
		{
			return this.transactionHistoryRepository.GetWhereDynamic(predicate, skip, take, orderClause);
		}

		public virtual List<POCOTransactionHistory> GetWhereDirect(Expression<Func<EFTransactionHistory, bool>> predicate, int skip = 0, int take = int.MaxValue, string orderClause = "")
		{
			return this.transactionHistoryRepository.GetWhereDirect(predicate, skip, take, orderClause);
		}
	}
}

/*<Codenesium>
    <Hash>d4ba32011709569179d4a266b96ea2db</Hash>
</Codenesium>*/