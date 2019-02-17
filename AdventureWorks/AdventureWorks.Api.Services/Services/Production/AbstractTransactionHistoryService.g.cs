using AdventureWorksNS.Api.Contracts;
using AdventureWorksNS.Api.DataAccess;
using MediatR;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace AdventureWorksNS.Api.Services
{
	public abstract class AbstractTransactionHistoryService : AbstractService
	{
		private IMediator mediator;

		protected ITransactionHistoryRepository TransactionHistoryRepository { get; private set; }

		protected IApiTransactionHistoryServerRequestModelValidator TransactionHistoryModelValidator { get; private set; }

		protected IDALTransactionHistoryMapper DalTransactionHistoryMapper { get; private set; }

		private ILogger logger;

		public AbstractTransactionHistoryService(
			ILogger logger,
			IMediator mediator,
			ITransactionHistoryRepository transactionHistoryRepository,
			IApiTransactionHistoryServerRequestModelValidator transactionHistoryModelValidator,
			IDALTransactionHistoryMapper dalTransactionHistoryMapper)
			: base()
		{
			this.TransactionHistoryRepository = transactionHistoryRepository;
			this.TransactionHistoryModelValidator = transactionHistoryModelValidator;
			this.DalTransactionHistoryMapper = dalTransactionHistoryMapper;
			this.logger = logger;

			this.mediator = mediator;
		}

		public virtual async Task<List<ApiTransactionHistoryServerResponseModel>> All(int limit = 0, int offset = int.MaxValue, string query = "")
		{
			List<TransactionHistory> records = await this.TransactionHistoryRepository.All(limit, offset, query);

			return this.DalTransactionHistoryMapper.MapEntityToModel(records);
		}

		public virtual async Task<ApiTransactionHistoryServerResponseModel> Get(int transactionID)
		{
			TransactionHistory record = await this.TransactionHistoryRepository.Get(transactionID);

			if (record == null)
			{
				return null;
			}
			else
			{
				return this.DalTransactionHistoryMapper.MapEntityToModel(record);
			}
		}

		public virtual async Task<CreateResponse<ApiTransactionHistoryServerResponseModel>> Create(
			ApiTransactionHistoryServerRequestModel model)
		{
			CreateResponse<ApiTransactionHistoryServerResponseModel> response = ValidationResponseFactory<ApiTransactionHistoryServerResponseModel>.CreateResponse(await this.TransactionHistoryModelValidator.ValidateCreateAsync(model));

			if (response.Success)
			{
				TransactionHistory record = this.DalTransactionHistoryMapper.MapModelToEntity(default(int), model);
				record = await this.TransactionHistoryRepository.Create(record);

				response.SetRecord(this.DalTransactionHistoryMapper.MapEntityToModel(record));
				await this.mediator.Publish(new TransactionHistoryCreatedNotification(response.Record));
			}

			return response;
		}

		public virtual async Task<UpdateResponse<ApiTransactionHistoryServerResponseModel>> Update(
			int transactionID,
			ApiTransactionHistoryServerRequestModel model)
		{
			var validationResult = await this.TransactionHistoryModelValidator.ValidateUpdateAsync(transactionID, model);

			if (validationResult.IsValid)
			{
				TransactionHistory record = this.DalTransactionHistoryMapper.MapModelToEntity(transactionID, model);
				await this.TransactionHistoryRepository.Update(record);

				record = await this.TransactionHistoryRepository.Get(transactionID);

				ApiTransactionHistoryServerResponseModel apiModel = this.DalTransactionHistoryMapper.MapEntityToModel(record);
				await this.mediator.Publish(new TransactionHistoryUpdatedNotification(apiModel));

				return ValidationResponseFactory<ApiTransactionHistoryServerResponseModel>.UpdateResponse(apiModel);
			}
			else
			{
				return ValidationResponseFactory<ApiTransactionHistoryServerResponseModel>.UpdateResponse(validationResult);
			}
		}

		public virtual async Task<ActionResponse> Delete(
			int transactionID)
		{
			ActionResponse response = ValidationResponseFactory<object>.ActionResponse(await this.TransactionHistoryModelValidator.ValidateDeleteAsync(transactionID));

			if (response.Success)
			{
				await this.TransactionHistoryRepository.Delete(transactionID);

				await this.mediator.Publish(new TransactionHistoryDeletedNotification(transactionID));
			}

			return response;
		}

		public async virtual Task<List<ApiTransactionHistoryServerResponseModel>> ByProductID(int productID, int limit = 0, int offset = int.MaxValue)
		{
			List<TransactionHistory> records = await this.TransactionHistoryRepository.ByProductID(productID, limit, offset);

			return this.DalTransactionHistoryMapper.MapEntityToModel(records);
		}

		public async virtual Task<List<ApiTransactionHistoryServerResponseModel>> ByReferenceOrderIDReferenceOrderLineID(int referenceOrderID, int referenceOrderLineID, int limit = 0, int offset = int.MaxValue)
		{
			List<TransactionHistory> records = await this.TransactionHistoryRepository.ByReferenceOrderIDReferenceOrderLineID(referenceOrderID, referenceOrderLineID, limit, offset);

			return this.DalTransactionHistoryMapper.MapEntityToModel(records);
		}
	}
}

/*<Codenesium>
    <Hash>4852794f20124ae360bf353a9f63c0c3</Hash>
</Codenesium>*/