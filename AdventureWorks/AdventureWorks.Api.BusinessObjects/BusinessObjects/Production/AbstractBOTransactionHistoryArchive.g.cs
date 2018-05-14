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
		private IApiTransactionHistoryArchiveModelValidator transactionHistoryArchiveModelValidator;
		private ILogger logger;

		public AbstractBOTransactionHistoryArchive(
			ILogger logger,
			ITransactionHistoryArchiveRepository transactionHistoryArchiveRepository,
			IApiTransactionHistoryArchiveModelValidator transactionHistoryArchiveModelValidator)

		{
			this.transactionHistoryArchiveRepository = transactionHistoryArchiveRepository;
			this.transactionHistoryArchiveModelValidator = transactionHistoryArchiveModelValidator;
			this.logger = logger;
		}

		public virtual List<POCOTransactionHistoryArchive> All(int skip = 0, int take = int.MaxValue, string orderClause = "")
		{
			return this.transactionHistoryArchiveRepository.All(skip, take, orderClause);
		}

		public virtual POCOTransactionHistoryArchive Get(int transactionID)
		{
			return this.transactionHistoryArchiveRepository.Get(transactionID);
		}

		public virtual async Task<CreateResponse<POCOTransactionHistoryArchive>> Create(
			ApiTransactionHistoryArchiveModel model)
		{
			CreateResponse<POCOTransactionHistoryArchive> response = new CreateResponse<POCOTransactionHistoryArchive>(await this.transactionHistoryArchiveModelValidator.ValidateCreateAsync(model));
			if (response.Success)
			{
				POCOTransactionHistoryArchive record = this.transactionHistoryArchiveRepository.Create(model);
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

		public List<POCOTransactionHistoryArchive> GetProductID(int productID)
		{
			return this.transactionHistoryArchiveRepository.GetProductID(productID);
		}
		public List<POCOTransactionHistoryArchive> GetReferenceOrderIDReferenceOrderLineID(int referenceOrderID,int referenceOrderLineID)
		{
			return this.transactionHistoryArchiveRepository.GetReferenceOrderIDReferenceOrderLineID(referenceOrderID,referenceOrderLineID);
		}
	}
}

/*<Codenesium>
    <Hash>e1584734815d51600599076bf880d29f</Hash>
</Codenesium>*/