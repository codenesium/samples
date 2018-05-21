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
	public abstract class AbstractBOTransactionHistoryArchive: AbstractBOManager
	{
		private ITransactionHistoryArchiveRepository transactionHistoryArchiveRepository;
		private IApiTransactionHistoryArchiveModelValidator transactionHistoryArchiveModelValidator;
		private ILogger logger;

		public AbstractBOTransactionHistoryArchive(
			ILogger logger,
			ITransactionHistoryArchiveRepository transactionHistoryArchiveRepository,
			IApiTransactionHistoryArchiveModelValidator transactionHistoryArchiveModelValidator)
			: base()

		{
			this.transactionHistoryArchiveRepository = transactionHistoryArchiveRepository;
			this.transactionHistoryArchiveModelValidator = transactionHistoryArchiveModelValidator;
			this.logger = logger;
		}

		public virtual Task<List<POCOTransactionHistoryArchive>> All(int skip = 0, int take = int.MaxValue, string orderClause = "")
		{
			return this.transactionHistoryArchiveRepository.All(skip, take, orderClause);
		}

		public virtual Task<POCOTransactionHistoryArchive> Get(int transactionID)
		{
			return this.transactionHistoryArchiveRepository.Get(transactionID);
		}

		public virtual async Task<CreateResponse<POCOTransactionHistoryArchive>> Create(
			ApiTransactionHistoryArchiveModel model)
		{
			CreateResponse<POCOTransactionHistoryArchive> response = new CreateResponse<POCOTransactionHistoryArchive>(await this.transactionHistoryArchiveModelValidator.ValidateCreateAsync(model));
			if (response.Success)
			{
				POCOTransactionHistoryArchive record = await this.transactionHistoryArchiveRepository.Create(model);

				response.SetRecord(record);
			}

			return response;
		}

		public virtual async Task<ActionResponse> Update(
			int transactionID,
			ApiTransactionHistoryArchiveModel model)
		{
			ActionResponse response = new ActionResponse(await this.transactionHistoryArchiveModelValidator.ValidateUpdateAsync(transactionID, model));

			if (response.Success)
			{
				await this.transactionHistoryArchiveRepository.Update(transactionID, model);
			}

			return response;
		}

		public virtual async Task<ActionResponse> Delete(
			int transactionID)
		{
			ActionResponse response = new ActionResponse(await this.transactionHistoryArchiveModelValidator.ValidateDeleteAsync(transactionID));

			if (response.Success)
			{
				await this.transactionHistoryArchiveRepository.Delete(transactionID);
			}
			return response;
		}

		public async Task<List<POCOTransactionHistoryArchive>> GetProductID(int productID)
		{
			return await this.transactionHistoryArchiveRepository.GetProductID(productID);
		}
		public async Task<List<POCOTransactionHistoryArchive>> GetReferenceOrderIDReferenceOrderLineID(int referenceOrderID,int referenceOrderLineID)
		{
			return await this.transactionHistoryArchiveRepository.GetReferenceOrderIDReferenceOrderLineID(referenceOrderID,referenceOrderLineID);
		}
	}
}

/*<Codenesium>
    <Hash>4a7edaf0082b1f3a8a6934df809de0e0</Hash>
</Codenesium>*/