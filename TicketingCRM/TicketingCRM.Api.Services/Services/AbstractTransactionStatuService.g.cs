using MediatR;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using TicketingCRMNS.Api.Contracts;
using TicketingCRMNS.Api.DataAccess;

namespace TicketingCRMNS.Api.Services
{
	public abstract class AbstractTransactionStatuService : AbstractService
	{
		private IMediator mediator;

		protected ITransactionStatuRepository TransactionStatuRepository { get; private set; }

		protected IApiTransactionStatuServerRequestModelValidator TransactionStatuModelValidator { get; private set; }

		protected IDALTransactionStatuMapper DalTransactionStatuMapper { get; private set; }

		protected IDALTransactionMapper DalTransactionMapper { get; private set; }

		private ILogger logger;

		public AbstractTransactionStatuService(
			ILogger logger,
			IMediator mediator,
			ITransactionStatuRepository transactionStatuRepository,
			IApiTransactionStatuServerRequestModelValidator transactionStatuModelValidator,
			IDALTransactionStatuMapper dalTransactionStatuMapper,
			IDALTransactionMapper dalTransactionMapper)
			: base()
		{
			this.TransactionStatuRepository = transactionStatuRepository;
			this.TransactionStatuModelValidator = transactionStatuModelValidator;
			this.DalTransactionStatuMapper = dalTransactionStatuMapper;
			this.DalTransactionMapper = dalTransactionMapper;
			this.logger = logger;

			this.mediator = mediator;
		}

		public virtual async Task<List<ApiTransactionStatuServerResponseModel>> All(int limit = 0, int offset = int.MaxValue, string query = "")
		{
			List<TransactionStatu> records = await this.TransactionStatuRepository.All(limit, offset, query);

			return this.DalTransactionStatuMapper.MapEntityToModel(records);
		}

		public virtual async Task<ApiTransactionStatuServerResponseModel> Get(int id)
		{
			TransactionStatu record = await this.TransactionStatuRepository.Get(id);

			if (record == null)
			{
				return null;
			}
			else
			{
				return this.DalTransactionStatuMapper.MapEntityToModel(record);
			}
		}

		public virtual async Task<CreateResponse<ApiTransactionStatuServerResponseModel>> Create(
			ApiTransactionStatuServerRequestModel model)
		{
			CreateResponse<ApiTransactionStatuServerResponseModel> response = ValidationResponseFactory<ApiTransactionStatuServerResponseModel>.CreateResponse(await this.TransactionStatuModelValidator.ValidateCreateAsync(model));

			if (response.Success)
			{
				TransactionStatu record = this.DalTransactionStatuMapper.MapModelToEntity(default(int), model);
				record = await this.TransactionStatuRepository.Create(record);

				response.SetRecord(this.DalTransactionStatuMapper.MapEntityToModel(record));
				await this.mediator.Publish(new TransactionStatuCreatedNotification(response.Record));
			}

			return response;
		}

		public virtual async Task<UpdateResponse<ApiTransactionStatuServerResponseModel>> Update(
			int id,
			ApiTransactionStatuServerRequestModel model)
		{
			var validationResult = await this.TransactionStatuModelValidator.ValidateUpdateAsync(id, model);

			if (validationResult.IsValid)
			{
				TransactionStatu record = this.DalTransactionStatuMapper.MapModelToEntity(id, model);
				await this.TransactionStatuRepository.Update(record);

				record = await this.TransactionStatuRepository.Get(id);

				ApiTransactionStatuServerResponseModel apiModel = this.DalTransactionStatuMapper.MapEntityToModel(record);
				await this.mediator.Publish(new TransactionStatuUpdatedNotification(apiModel));

				return ValidationResponseFactory<ApiTransactionStatuServerResponseModel>.UpdateResponse(apiModel);
			}
			else
			{
				return ValidationResponseFactory<ApiTransactionStatuServerResponseModel>.UpdateResponse(validationResult);
			}
		}

		public virtual async Task<ActionResponse> Delete(
			int id)
		{
			ActionResponse response = ValidationResponseFactory<object>.ActionResponse(await this.TransactionStatuModelValidator.ValidateDeleteAsync(id));

			if (response.Success)
			{
				await this.TransactionStatuRepository.Delete(id);

				await this.mediator.Publish(new TransactionStatuDeletedNotification(id));
			}

			return response;
		}

		public async virtual Task<List<ApiTransactionServerResponseModel>> TransactionsByTransactionStatusId(int transactionStatusId, int limit = int.MaxValue, int offset = 0)
		{
			List<Transaction> records = await this.TransactionStatuRepository.TransactionsByTransactionStatusId(transactionStatusId, limit, offset);

			return this.DalTransactionMapper.MapEntityToModel(records);
		}
	}
}

/*<Codenesium>
    <Hash>cbd1830bf6a24500c64fa6053426d730</Hash>
</Codenesium>*/