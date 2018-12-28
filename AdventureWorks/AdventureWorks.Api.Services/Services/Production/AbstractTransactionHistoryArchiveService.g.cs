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

		protected IBOLTransactionHistoryArchiveMapper BolTransactionHistoryArchiveMapper { get; private set; }

		protected IDALTransactionHistoryArchiveMapper DalTransactionHistoryArchiveMapper { get; private set; }

		private ILogger logger;

		public AbstractTransactionHistoryArchiveService(
			ILogger logger,
			IMediator mediator,
			ITransactionHistoryArchiveRepository transactionHistoryArchiveRepository,
			IApiTransactionHistoryArchiveServerRequestModelValidator transactionHistoryArchiveModelValidator,
			IBOLTransactionHistoryArchiveMapper bolTransactionHistoryArchiveMapper,
			IDALTransactionHistoryArchiveMapper dalTransactionHistoryArchiveMapper)
			: base()
		{
			this.TransactionHistoryArchiveRepository = transactionHistoryArchiveRepository;
			this.TransactionHistoryArchiveModelValidator = transactionHistoryArchiveModelValidator;
			this.BolTransactionHistoryArchiveMapper = bolTransactionHistoryArchiveMapper;
			this.DalTransactionHistoryArchiveMapper = dalTransactionHistoryArchiveMapper;
			this.logger = logger;

			this.mediator = mediator;
		}

		public virtual async Task<List<ApiTransactionHistoryArchiveServerResponseModel>> All(int limit = 0, int offset = int.MaxValue)
		{
			var records = await this.TransactionHistoryArchiveRepository.All(limit, offset);

			return this.BolTransactionHistoryArchiveMapper.MapBOToModel(this.DalTransactionHistoryArchiveMapper.MapEFToBO(records));
		}

		public virtual async Task<ApiTransactionHistoryArchiveServerResponseModel> Get(int transactionID)
		{
			var record = await this.TransactionHistoryArchiveRepository.Get(transactionID);

			if (record == null)
			{
				return null;
			}
			else
			{
				return this.BolTransactionHistoryArchiveMapper.MapBOToModel(this.DalTransactionHistoryArchiveMapper.MapEFToBO(record));
			}
		}

		public virtual async Task<CreateResponse<ApiTransactionHistoryArchiveServerResponseModel>> Create(
			ApiTransactionHistoryArchiveServerRequestModel model)
		{
			CreateResponse<ApiTransactionHistoryArchiveServerResponseModel> response = ValidationResponseFactory<ApiTransactionHistoryArchiveServerResponseModel>.CreateResponse(await this.TransactionHistoryArchiveModelValidator.ValidateCreateAsync(model));

			if (response.Success)
			{
				var bo = this.BolTransactionHistoryArchiveMapper.MapModelToBO(default(int), model);
				var record = await this.TransactionHistoryArchiveRepository.Create(this.DalTransactionHistoryArchiveMapper.MapBOToEF(bo));

				var businessObject = this.DalTransactionHistoryArchiveMapper.MapEFToBO(record);
				response.SetRecord(this.BolTransactionHistoryArchiveMapper.MapBOToModel(businessObject));
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
				var bo = this.BolTransactionHistoryArchiveMapper.MapModelToBO(transactionID, model);
				await this.TransactionHistoryArchiveRepository.Update(this.DalTransactionHistoryArchiveMapper.MapBOToEF(bo));

				var record = await this.TransactionHistoryArchiveRepository.Get(transactionID);

				var businessObject = this.DalTransactionHistoryArchiveMapper.MapEFToBO(record);
				var apiModel = this.BolTransactionHistoryArchiveMapper.MapBOToModel(businessObject);
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

			return this.BolTransactionHistoryArchiveMapper.MapBOToModel(this.DalTransactionHistoryArchiveMapper.MapEFToBO(records));
		}

		public async virtual Task<List<ApiTransactionHistoryArchiveServerResponseModel>> ByReferenceOrderIDReferenceOrderLineID(int referenceOrderID, int referenceOrderLineID, int limit = 0, int offset = int.MaxValue)
		{
			List<TransactionHistoryArchive> records = await this.TransactionHistoryArchiveRepository.ByReferenceOrderIDReferenceOrderLineID(referenceOrderID, referenceOrderLineID, limit, offset);

			return this.BolTransactionHistoryArchiveMapper.MapBOToModel(this.DalTransactionHistoryArchiveMapper.MapEFToBO(records));
		}
	}
}

/*<Codenesium>
    <Hash>db8f5aa342d4d15015d7bf542036b8a3</Hash>
</Codenesium>*/