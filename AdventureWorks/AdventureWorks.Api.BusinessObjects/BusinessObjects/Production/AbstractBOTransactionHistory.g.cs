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
	public abstract class AbstractBOTransactionHistory: AbstractBOManager
	{
		private ITransactionHistoryRepository transactionHistoryRepository;
		private IApiTransactionHistoryModelValidator transactionHistoryModelValidator;
		private ILogger logger;

		public AbstractBOTransactionHistory(
			ILogger logger,
			ITransactionHistoryRepository transactionHistoryRepository,
			IApiTransactionHistoryModelValidator transactionHistoryModelValidator)
			: base()

		{
			this.transactionHistoryRepository = transactionHistoryRepository;
			this.transactionHistoryModelValidator = transactionHistoryModelValidator;
			this.logger = logger;
		}

		public virtual Task<List<POCOTransactionHistory>> All(int skip = 0, int take = int.MaxValue, string orderClause = "")
		{
			return this.transactionHistoryRepository.All(skip, take, orderClause);
		}

		public virtual Task<POCOTransactionHistory> Get(int transactionID)
		{
			return this.transactionHistoryRepository.Get(transactionID);
		}

		public virtual async Task<CreateResponse<POCOTransactionHistory>> Create(
			ApiTransactionHistoryModel model)
		{
			CreateResponse<POCOTransactionHistory> response = new CreateResponse<POCOTransactionHistory>(await this.transactionHistoryModelValidator.ValidateCreateAsync(model));
			if (response.Success)
			{
				POCOTransactionHistory record = await this.transactionHistoryRepository.Create(model);

				response.SetRecord(record);
			}

			return response;
		}

		public virtual async Task<ActionResponse> Update(
			int transactionID,
			ApiTransactionHistoryModel model)
		{
			ActionResponse response = new ActionResponse(await this.transactionHistoryModelValidator.ValidateUpdateAsync(transactionID, model));

			if (response.Success)
			{
				await this.transactionHistoryRepository.Update(transactionID, model);
			}

			return response;
		}

		public virtual async Task<ActionResponse> Delete(
			int transactionID)
		{
			ActionResponse response = new ActionResponse(await this.transactionHistoryModelValidator.ValidateDeleteAsync(transactionID));

			if (response.Success)
			{
				await this.transactionHistoryRepository.Delete(transactionID);
			}
			return response;
		}

		public async Task<List<POCOTransactionHistory>> GetProductID(int productID)
		{
			return await this.transactionHistoryRepository.GetProductID(productID);
		}
		public async Task<List<POCOTransactionHistory>> GetReferenceOrderIDReferenceOrderLineID(int referenceOrderID,int referenceOrderLineID)
		{
			return await this.transactionHistoryRepository.GetReferenceOrderIDReferenceOrderLineID(referenceOrderID,referenceOrderLineID);
		}
	}
}

/*<Codenesium>
    <Hash>f896ad09c6bd839937b894b5b26f28d3</Hash>
</Codenesium>*/