using MediatR;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using TicketingCRMNS.Api.Contracts;
using TicketingCRMNS.Api.DataAccess;

namespace TicketingCRMNS.Api.Services
{
	public abstract class AbstractTransactionStatusService : AbstractService
	{
		private IMediator mediator;

		protected ITransactionStatusRepository TransactionStatusRepository { get; private set; }

		protected IApiTransactionStatusServerRequestModelValidator TransactionStatusModelValidator { get; private set; }

		protected IDALTransactionStatusMapper DalTransactionStatusMapper { get; private set; }

		protected IDALTransactionMapper DalTransactionMapper { get; private set; }

		private ILogger logger;

		public AbstractTransactionStatusService(
			ILogger logger,
			IMediator mediator,
			ITransactionStatusRepository transactionStatusRepository,
			IApiTransactionStatusServerRequestModelValidator transactionStatusModelValidator,
			IDALTransactionStatusMapper dalTransactionStatusMapper,
			IDALTransactionMapper dalTransactionMapper)
			: base()
		{
			this.TransactionStatusRepository = transactionStatusRepository;
			this.TransactionStatusModelValidator = transactionStatusModelValidator;
			this.DalTransactionStatusMapper = dalTransactionStatusMapper;
			this.DalTransactionMapper = dalTransactionMapper;
			this.logger = logger;

			this.mediator = mediator;
		}

		public virtual async Task<List<ApiTransactionStatusServerResponseModel>> All(int limit = 0, int offset = int.MaxValue, string query = "")
		{
			List<TransactionStatus> records = await this.TransactionStatusRepository.All(limit, offset, query);

			return this.DalTransactionStatusMapper.MapEntityToModel(records);
		}

		public virtual async Task<ApiTransactionStatusServerResponseModel> Get(int id)
		{
			TransactionStatus record = await this.TransactionStatusRepository.Get(id);

			if (record == null)
			{
				return null;
			}
			else
			{
				return this.DalTransactionStatusMapper.MapEntityToModel(record);
			}
		}

		public virtual async Task<CreateResponse<ApiTransactionStatusServerResponseModel>> Create(
			ApiTransactionStatusServerRequestModel model)
		{
			CreateResponse<ApiTransactionStatusServerResponseModel> response = ValidationResponseFactory<ApiTransactionStatusServerResponseModel>.CreateResponse(await this.TransactionStatusModelValidator.ValidateCreateAsync(model));

			if (response.Success)
			{
				TransactionStatus record = this.DalTransactionStatusMapper.MapModelToEntity(default(int), model);
				record = await this.TransactionStatusRepository.Create(record);

				response.SetRecord(this.DalTransactionStatusMapper.MapEntityToModel(record));
				await this.mediator.Publish(new TransactionStatusCreatedNotification(response.Record));
			}

			return response;
		}

		public virtual async Task<UpdateResponse<ApiTransactionStatusServerResponseModel>> Update(
			int id,
			ApiTransactionStatusServerRequestModel model)
		{
			var validationResult = await this.TransactionStatusModelValidator.ValidateUpdateAsync(id, model);

			if (validationResult.IsValid)
			{
				TransactionStatus record = this.DalTransactionStatusMapper.MapModelToEntity(id, model);
				await this.TransactionStatusRepository.Update(record);

				record = await this.TransactionStatusRepository.Get(id);

				ApiTransactionStatusServerResponseModel apiModel = this.DalTransactionStatusMapper.MapEntityToModel(record);
				await this.mediator.Publish(new TransactionStatusUpdatedNotification(apiModel));

				return ValidationResponseFactory<ApiTransactionStatusServerResponseModel>.UpdateResponse(apiModel);
			}
			else
			{
				return ValidationResponseFactory<ApiTransactionStatusServerResponseModel>.UpdateResponse(validationResult);
			}
		}

		public virtual async Task<ActionResponse> Delete(
			int id)
		{
			ActionResponse response = ValidationResponseFactory<object>.ActionResponse(await this.TransactionStatusModelValidator.ValidateDeleteAsync(id));

			if (response.Success)
			{
				await this.TransactionStatusRepository.Delete(id);

				await this.mediator.Publish(new TransactionStatusDeletedNotification(id));
			}

			return response;
		}

		public async virtual Task<List<ApiTransactionServerResponseModel>> TransactionsByTransactionStatusId(int transactionStatusId, int limit = int.MaxValue, int offset = 0)
		{
			List<Transaction> records = await this.TransactionStatusRepository.TransactionsByTransactionStatusId(transactionStatusId, limit, offset);

			return this.DalTransactionMapper.MapEntityToModel(records);
		}
	}
}

/*<Codenesium>
    <Hash>ae0f2fa5a4069a71f104c44f884e8335</Hash>
</Codenesium>*/