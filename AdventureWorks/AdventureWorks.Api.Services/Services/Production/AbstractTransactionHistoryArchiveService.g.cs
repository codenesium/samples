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
	public abstract class AbstractTransactionHistoryArchiveService : AbstractService
	{
		protected ITransactionHistoryArchiveRepository TransactionHistoryArchiveRepository { get; private set; }

		protected IApiTransactionHistoryArchiveRequestModelValidator TransactionHistoryArchiveModelValidator { get; private set; }

		protected IBOLTransactionHistoryArchiveMapper BolTransactionHistoryArchiveMapper { get; private set; }

		protected IDALTransactionHistoryArchiveMapper DalTransactionHistoryArchiveMapper { get; private set; }

		private ILogger logger;

		public AbstractTransactionHistoryArchiveService(
			ILogger logger,
			ITransactionHistoryArchiveRepository transactionHistoryArchiveRepository,
			IApiTransactionHistoryArchiveRequestModelValidator transactionHistoryArchiveModelValidator,
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

		public virtual async Task<List<ApiTransactionHistoryArchiveResponseModel>> All(int limit = 0, int offset = int.MaxValue)
		{
			var records = await this.TransactionHistoryArchiveRepository.All(limit, offset);

			return this.BolTransactionHistoryArchiveMapper.MapBOToModel(this.DalTransactionHistoryArchiveMapper.MapEFToBO(records));
		}

		public virtual async Task<ApiTransactionHistoryArchiveResponseModel> Get(int transactionID)
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

		public virtual async Task<CreateResponse<ApiTransactionHistoryArchiveResponseModel>> Create(
			ApiTransactionHistoryArchiveRequestModel model)
		{
			CreateResponse<ApiTransactionHistoryArchiveResponseModel> response = new CreateResponse<ApiTransactionHistoryArchiveResponseModel>(await this.TransactionHistoryArchiveModelValidator.ValidateCreateAsync(model));
			if (response.Success)
			{
				var bo = this.BolTransactionHistoryArchiveMapper.MapModelToBO(default(int), model);
				var record = await this.TransactionHistoryArchiveRepository.Create(this.DalTransactionHistoryArchiveMapper.MapBOToEF(bo));

				response.SetRecord(this.BolTransactionHistoryArchiveMapper.MapBOToModel(this.DalTransactionHistoryArchiveMapper.MapEFToBO(record)));
			}

			return response;
		}

		public virtual async Task<UpdateResponse<ApiTransactionHistoryArchiveResponseModel>> Update(
			int transactionID,
			ApiTransactionHistoryArchiveRequestModel model)
		{
			var validationResult = await this.TransactionHistoryArchiveModelValidator.ValidateUpdateAsync(transactionID, model);

			if (validationResult.IsValid)
			{
				var bo = this.BolTransactionHistoryArchiveMapper.MapModelToBO(transactionID, model);
				await this.TransactionHistoryArchiveRepository.Update(this.DalTransactionHistoryArchiveMapper.MapBOToEF(bo));

				var record = await this.TransactionHistoryArchiveRepository.Get(transactionID);

				return new UpdateResponse<ApiTransactionHistoryArchiveResponseModel>(this.BolTransactionHistoryArchiveMapper.MapBOToModel(this.DalTransactionHistoryArchiveMapper.MapEFToBO(record)));
			}
			else
			{
				return new UpdateResponse<ApiTransactionHistoryArchiveResponseModel>(validationResult);
			}
		}

		public virtual async Task<ActionResponse> Delete(
			int transactionID)
		{
			ActionResponse response = new ActionResponse(await this.TransactionHistoryArchiveModelValidator.ValidateDeleteAsync(transactionID));
			if (response.Success)
			{
				await this.TransactionHistoryArchiveRepository.Delete(transactionID);
			}

			return response;
		}

		public async Task<List<ApiTransactionHistoryArchiveResponseModel>> ByProductID(int productID, int limit = 0, int offset = int.MaxValue)
		{
			List<TransactionHistoryArchive> records = await this.TransactionHistoryArchiveRepository.ByProductID(productID, limit, offset);

			return this.BolTransactionHistoryArchiveMapper.MapBOToModel(this.DalTransactionHistoryArchiveMapper.MapEFToBO(records));
		}

		public async Task<List<ApiTransactionHistoryArchiveResponseModel>> ByReferenceOrderIDReferenceOrderLineID(int referenceOrderID, int referenceOrderLineID, int limit = 0, int offset = int.MaxValue)
		{
			List<TransactionHistoryArchive> records = await this.TransactionHistoryArchiveRepository.ByReferenceOrderIDReferenceOrderLineID(referenceOrderID, referenceOrderLineID, limit, offset);

			return this.BolTransactionHistoryArchiveMapper.MapBOToModel(this.DalTransactionHistoryArchiveMapper.MapEFToBO(records));
		}
	}
}

/*<Codenesium>
    <Hash>1f9ed7322b1cf790bd4571ae7d2baf2b</Hash>
</Codenesium>*/