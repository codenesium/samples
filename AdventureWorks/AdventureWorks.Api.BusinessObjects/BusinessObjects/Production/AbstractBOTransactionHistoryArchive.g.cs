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

		public virtual ApiResponse GetById(int transactionID)
		{
			return this.transactionHistoryArchiveRepository.GetById(transactionID);
		}

		public virtual POCOTransactionHistoryArchive GetByIdDirect(int transactionID)
		{
			return this.transactionHistoryArchiveRepository.GetByIdDirect(transactionID);
		}

		public virtual ApiResponse GetWhere(Expression<Func<EFTransactionHistoryArchive, bool>> predicate, int skip = 0, int take = int.MaxValue, string orderClause = "")
		{
			return this.transactionHistoryArchiveRepository.GetWhere(predicate, skip, take, orderClause);
		}

		public virtual ApiResponse GetWhereDynamic(string predicate, int skip = 0, int take = int.MaxValue, string orderClause = "")
		{
			return this.transactionHistoryArchiveRepository.GetWhereDynamic(predicate, skip, take, orderClause);
		}

		public virtual List<POCOTransactionHistoryArchive> GetWhereDirect(Expression<Func<EFTransactionHistoryArchive, bool>> predicate, int skip = 0, int take = int.MaxValue, string orderClause = "")
		{
			return this.transactionHistoryArchiveRepository.GetWhereDirect(predicate, skip, take, orderClause);
		}
	}
}

/*<Codenesium>
    <Hash>157e489445bd13141361e1d17fcc8fc5</Hash>
</Codenesium>*/