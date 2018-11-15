using AdventureWorksNS.Api.Contracts;
using AdventureWorksNS.Api.DataAccess;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace AdventureWorksNS.Api.Services
{
	public abstract class AbstractTransactionHistoryArchiveService : AbstractService
	{
		protected ITransactionHistoryArchiveRepository TransactionHistoryArchiveRepository { get; private set; }

		protected IApiTransactionHistoryArchiveServerRequestModelValidator TransactionHistoryArchiveModelValidator { get; private set; }

		protected IBOLTransactionHistoryArchiveMapper BolTransactionHistoryArchiveMapper { get; private set; }

		protected IDALTransactionHistoryArchiveMapper DalTransactionHistoryArchiveMapper { get; private set; }

		private ILogger logger;

		public AbstractTransactionHistoryArchiveService(
			ILogger logger,
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

				response.SetRecord(this.BolTransactionHistoryArchiveMapper.MapBOToModel(this.DalTransactionHistoryArchiveMapper.MapEFToBO(record)));
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

				return ValidationResponseFactory<ApiTransactionHistoryArchiveServerResponseModel>.UpdateResponse(this.BolTransactionHistoryArchiveMapper.MapBOToModel(this.DalTransactionHistoryArchiveMapper.MapEFToBO(record)));
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
    <Hash>4fe294fb62ea3b2a1e5218d13739f74a</Hash>
</Codenesium>*/