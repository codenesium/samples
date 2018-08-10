using AdventureWorksNS.Api.Contracts;
using AdventureWorksNS.Api.DataAccess;
using Codenesium.DataConversionExtensions;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Dynamic.Core;
using System.Linq.Expressions;
using System.Threading.Tasks;

namespace AdventureWorksNS.Api.Services
{
	public abstract class AbstractTransactionHistoryService : AbstractService
	{
		protected ITransactionHistoryRepository TransactionHistoryRepository { get; private set; }

		protected IApiTransactionHistoryRequestModelValidator TransactionHistoryModelValidator { get; private set; }

		protected IBOLTransactionHistoryMapper BolTransactionHistoryMapper { get; private set; }

		protected IDALTransactionHistoryMapper DalTransactionHistoryMapper { get; private set; }

		private ILogger logger;

		public AbstractTransactionHistoryService(
			ILogger logger,
			ITransactionHistoryRepository transactionHistoryRepository,
			IApiTransactionHistoryRequestModelValidator transactionHistoryModelValidator,
			IBOLTransactionHistoryMapper bolTransactionHistoryMapper,
			IDALTransactionHistoryMapper dalTransactionHistoryMapper)
			: base()
		{
			this.TransactionHistoryRepository = transactionHistoryRepository;
			this.TransactionHistoryModelValidator = transactionHistoryModelValidator;
			this.BolTransactionHistoryMapper = bolTransactionHistoryMapper;
			this.DalTransactionHistoryMapper = dalTransactionHistoryMapper;
			this.logger = logger;
		}

		public virtual async Task<List<ApiTransactionHistoryResponseModel>> All(int limit = 0, int offset = int.MaxValue)
		{
			var records = await this.TransactionHistoryRepository.All(limit, offset);

			return this.BolTransactionHistoryMapper.MapBOToModel(this.DalTransactionHistoryMapper.MapEFToBO(records));
		}

		public virtual async Task<ApiTransactionHistoryResponseModel> Get(int transactionID)
		{
			var record = await this.TransactionHistoryRepository.Get(transactionID);

			if (record == null)
			{
				return null;
			}
			else
			{
				return this.BolTransactionHistoryMapper.MapBOToModel(this.DalTransactionHistoryMapper.MapEFToBO(record));
			}
		}

		public virtual async Task<CreateResponse<ApiTransactionHistoryResponseModel>> Create(
			ApiTransactionHistoryRequestModel model)
		{
			CreateResponse<ApiTransactionHistoryResponseModel> response = new CreateResponse<ApiTransactionHistoryResponseModel>(await this.TransactionHistoryModelValidator.ValidateCreateAsync(model));
			if (response.Success)
			{
				var bo = this.BolTransactionHistoryMapper.MapModelToBO(default(int), model);
				var record = await this.TransactionHistoryRepository.Create(this.DalTransactionHistoryMapper.MapBOToEF(bo));

				response.SetRecord(this.BolTransactionHistoryMapper.MapBOToModel(this.DalTransactionHistoryMapper.MapEFToBO(record)));
			}

			return response;
		}

		public virtual async Task<UpdateResponse<ApiTransactionHistoryResponseModel>> Update(
			int transactionID,
			ApiTransactionHistoryRequestModel model)
		{
			var validationResult = await this.TransactionHistoryModelValidator.ValidateUpdateAsync(transactionID, model);

			if (validationResult.IsValid)
			{
				var bo = this.BolTransactionHistoryMapper.MapModelToBO(transactionID, model);
				await this.TransactionHistoryRepository.Update(this.DalTransactionHistoryMapper.MapBOToEF(bo));

				var record = await this.TransactionHistoryRepository.Get(transactionID);

				return new UpdateResponse<ApiTransactionHistoryResponseModel>(this.BolTransactionHistoryMapper.MapBOToModel(this.DalTransactionHistoryMapper.MapEFToBO(record)));
			}
			else
			{
				return new UpdateResponse<ApiTransactionHistoryResponseModel>(validationResult);
			}
		}

		public virtual async Task<ActionResponse> Delete(
			int transactionID)
		{
			ActionResponse response = new ActionResponse(await this.TransactionHistoryModelValidator.ValidateDeleteAsync(transactionID));
			if (response.Success)
			{
				await this.TransactionHistoryRepository.Delete(transactionID);
			}

			return response;
		}

		public async Task<List<ApiTransactionHistoryResponseModel>> ByProductID(int productID)
		{
			List<TransactionHistory> records = await this.TransactionHistoryRepository.ByProductID(productID);

			return this.BolTransactionHistoryMapper.MapBOToModel(this.DalTransactionHistoryMapper.MapEFToBO(records));
		}

		public async Task<List<ApiTransactionHistoryResponseModel>> ByReferenceOrderIDReferenceOrderLineID(int referenceOrderID, int referenceOrderLineID)
		{
			List<TransactionHistory> records = await this.TransactionHistoryRepository.ByReferenceOrderIDReferenceOrderLineID(referenceOrderID, referenceOrderLineID);

			return this.BolTransactionHistoryMapper.MapBOToModel(this.DalTransactionHistoryMapper.MapEFToBO(records));
		}
	}
}

/*<Codenesium>
    <Hash>cedcff33dfe8c054c94e5831dcc7a4a5</Hash>
</Codenesium>*/