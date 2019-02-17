using AdventureWorksNS.Api.Contracts;
using AdventureWorksNS.Api.DataAccess;
using MediatR;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace AdventureWorksNS.Api.Services
{
	public abstract class AbstractTransactionHistoryArchiveService : AbstractService
	{
		private IMediator mediator;

		protected ITransactionHistoryArchiveRepository TransactionHistoryArchiveRepository { get; private set; }

		protected IApiTransactionHistoryArchiveServerRequestModelValidator TransactionHistoryArchiveModelValidator { get; private set; }

		protected IDALTransactionHistoryArchiveMapper DalTransactionHistoryArchiveMapper { get; private set; }

		private ILogger logger;

		public AbstractTransactionHistoryArchiveService(
			ILogger logger,
			IMediator mediator,
			ITransactionHistoryArchiveRepository transactionHistoryArchiveRepository,
			IApiTransactionHistoryArchiveServerRequestModelValidator transactionHistoryArchiveModelValidator,
			IDALTransactionHistoryArchiveMapper dalTransactionHistoryArchiveMapper)
			: base()
		{
			this.TransactionHistoryArchiveRepository = transactionHistoryArchiveRepository;
			this.TransactionHistoryArchiveModelValidator = transactionHistoryArchiveModelValidator;
			this.DalTransactionHistoryArchiveMapper = dalTransactionHistoryArchiveMapper;
			this.logger = logger;

			this.mediator = mediator;
		}

		public virtual async Task<List<ApiTransactionHistoryArchiveServerResponseModel>> All(int limit = 0, int offset = int.MaxValue, string query = "")
		{
			List<TransactionHistoryArchive> records = await this.TransactionHistoryArchiveRepository.All(limit, offset, query);

			return this.DalTransactionHistoryArchiveMapper.MapEntityToModel(records);
		}

		public virtual async Task<ApiTransactionHistoryArchiveServerResponseModel> Get(int transactionID)
		{
			TransactionHistoryArchive record = await this.TransactionHistoryArchiveRepository.Get(transactionID);

			if (record == null)
			{
				return null;
			}
			else
			{
				return this.DalTransactionHistoryArchiveMapper.MapEntityToModel(record);
			}
		}

		public virtual async Task<CreateResponse<ApiTransactionHistoryArchiveServerResponseModel>> Create(
			ApiTransactionHistoryArchiveServerRequestModel model)
		{
			CreateResponse<ApiTransactionHistoryArchiveServerResponseModel> response = ValidationResponseFactory<ApiTransactionHistoryArchiveServerResponseModel>.CreateResponse(await this.TransactionHistoryArchiveModelValidator.ValidateCreateAsync(model));

			if (response.Success)
			{
				TransactionHistoryArchive record = this.DalTransactionHistoryArchiveMapper.MapModelToEntity(default(int), model);
				record = await this.TransactionHistoryArchiveRepository.Create(record);

				response.SetRecord(this.DalTransactionHistoryArchiveMapper.MapEntityToModel(record));
				await this.mediator.Publish(new TransactionHistoryArchiveCreatedNotification(response.Record));
			}

			return response;
		}

		public virtual async Task<UpdateResponse<ApiTransactionHistoryArchiveServerResponseModel>> Update(
			int transactionID,
			ApiTransactionHistoryArchiveServerRequestModel model)
		{
			var validationResult = await this.TransactionHistoryArchiveModelValidator.ValidateUpdateAsync(transactionID, model);

			if (validationResult.IsValid)
			{
				TransactionHistoryArchive record = this.DalTransactionHistoryArchiveMapper.MapModelToEntity(transactionID, model);
				await this.TransactionHistoryArchiveRepository.Update(record);

				record = await this.TransactionHistoryArchiveRepository.Get(transactionID);

				ApiTransactionHistoryArchiveServerResponseModel apiModel = this.DalTransactionHistoryArchiveMapper.MapEntityToModel(record);
				await this.mediator.Publish(new TransactionHistoryArchiveUpdatedNotification(apiModel));

				return ValidationResponseFactory<ApiTransactionHistoryArchiveServerResponseModel>.UpdateResponse(apiModel);
			}
			else
			{
				return ValidationResponseFactory<ApiTransactionHistoryArchiveServerResponseModel>.UpdateResponse(validationResult);
			}
		}

		public virtual async Task<ActionResponse> Delete(
			int transactionID)
		{
			ActionResponse response = ValidationResponseFactory<object>.ActionResponse(await this.TransactionHistoryArchiveModelValidator.ValidateDeleteAsync(transactionID));

			if (response.Success)
			{
				await this.TransactionHistoryArchiveRepository.Delete(transactionID);

				await this.mediator.Publish(new TransactionHistoryArchiveDeletedNotification(transactionID));
			}

			return response;
		}

		public async virtual Task<List<ApiTransactionHistoryArchiveServerResponseModel>> ByProductID(int productID, int limit = 0, int offset = int.MaxValue)
		{
			List<TransactionHistoryArchive> records = await this.TransactionHistoryArchiveRepository.ByProductID(productID, limit, offset);

			return this.DalTransactionHistoryArchiveMapper.MapEntityToModel(records);
		}

		public async virtual Task<List<ApiTransactionHistoryArchiveServerResponseModel>> ByReferenceOrderIDReferenceOrderLineID(int referenceOrderID, int referenceOrderLineID, int limit = 0, int offset = int.MaxValue)
		{
			List<TransactionHistoryArchive> records = await this.TransactionHistoryArchiveRepository.ByReferenceOrderIDReferenceOrderLineID(referenceOrderID, referenceOrderLineID, limit, offset);

			return this.DalTransactionHistoryArchiveMapper.MapEntityToModel(records);
		}
	}
}

/*<Codenesium>
    <Hash>612e714bf80551b516679c7a98c978a4</Hash>
</Codenesium>*/