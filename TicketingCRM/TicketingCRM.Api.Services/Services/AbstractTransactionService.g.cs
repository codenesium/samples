using Codenesium.DataConversionExtensions;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Dynamic.Core;
using System.Linq.Expressions;
using System.Threading.Tasks;
using TicketingCRMNS.Api.Contracts;
using TicketingCRMNS.Api.DataAccess;

namespace TicketingCRMNS.Api.Services
{
	public abstract class AbstractTransactionService : AbstractService
	{
		protected ITransactionRepository TransactionRepository { get; private set; }

		protected IApiTransactionRequestModelValidator TransactionModelValidator { get; private set; }

		protected IBOLTransactionMapper BolTransactionMapper { get; private set; }

		protected IDALTransactionMapper DalTransactionMapper { get; private set; }

		protected IBOLSaleMapper BolSaleMapper { get; private set; }

		protected IDALSaleMapper DalSaleMapper { get; private set; }

		private ILogger logger;

		public AbstractTransactionService(
			ILogger logger,
			ITransactionRepository transactionRepository,
			IApiTransactionRequestModelValidator transactionModelValidator,
			IBOLTransactionMapper bolTransactionMapper,
			IDALTransactionMapper dalTransactionMapper,
			IBOLSaleMapper bolSaleMapper,
			IDALSaleMapper dalSaleMapper)
			: base()
		{
			this.TransactionRepository = transactionRepository;
			this.TransactionModelValidator = transactionModelValidator;
			this.BolTransactionMapper = bolTransactionMapper;
			this.DalTransactionMapper = dalTransactionMapper;
			this.BolSaleMapper = bolSaleMapper;
			this.DalSaleMapper = dalSaleMapper;
			this.logger = logger;
		}

		public virtual async Task<List<ApiTransactionResponseModel>> All(int limit = 0, int offset = int.MaxValue)
		{
			var records = await this.TransactionRepository.All(limit, offset);

			return this.BolTransactionMapper.MapBOToModel(this.DalTransactionMapper.MapEFToBO(records));
		}

		public virtual async Task<ApiTransactionResponseModel> Get(int id)
		{
			var record = await this.TransactionRepository.Get(id);

			if (record == null)
			{
				return null;
			}
			else
			{
				return this.BolTransactionMapper.MapBOToModel(this.DalTransactionMapper.MapEFToBO(record));
			}
		}

		public virtual async Task<CreateResponse<ApiTransactionResponseModel>> Create(
			ApiTransactionRequestModel model)
		{
			CreateResponse<ApiTransactionResponseModel> response = new CreateResponse<ApiTransactionResponseModel>(await this.TransactionModelValidator.ValidateCreateAsync(model));
			if (response.Success)
			{
				var bo = this.BolTransactionMapper.MapModelToBO(default(int), model);
				var record = await this.TransactionRepository.Create(this.DalTransactionMapper.MapBOToEF(bo));

				response.SetRecord(this.BolTransactionMapper.MapBOToModel(this.DalTransactionMapper.MapEFToBO(record)));
			}

			return response;
		}

		public virtual async Task<UpdateResponse<ApiTransactionResponseModel>> Update(
			int id,
			ApiTransactionRequestModel model)
		{
			var validationResult = await this.TransactionModelValidator.ValidateUpdateAsync(id, model);

			if (validationResult.IsValid)
			{
				var bo = this.BolTransactionMapper.MapModelToBO(id, model);
				await this.TransactionRepository.Update(this.DalTransactionMapper.MapBOToEF(bo));

				var record = await this.TransactionRepository.Get(id);

				return new UpdateResponse<ApiTransactionResponseModel>(this.BolTransactionMapper.MapBOToModel(this.DalTransactionMapper.MapEFToBO(record)));
			}
			else
			{
				return new UpdateResponse<ApiTransactionResponseModel>(validationResult);
			}
		}

		public virtual async Task<ActionResponse> Delete(
			int id)
		{
			ActionResponse response = new ActionResponse(await this.TransactionModelValidator.ValidateDeleteAsync(id));
			if (response.Success)
			{
				await this.TransactionRepository.Delete(id);
			}

			return response;
		}

		public async Task<List<ApiTransactionResponseModel>> ByTransactionStatusId(int transactionStatusId, int limit = 0, int offset = int.MaxValue)
		{
			List<Transaction> records = await this.TransactionRepository.ByTransactionStatusId(transactionStatusId, limit, offset);

			return this.BolTransactionMapper.MapBOToModel(this.DalTransactionMapper.MapEFToBO(records));
		}

		public async virtual Task<List<ApiSaleResponseModel>> SalesByTransactionId(int transactionId, int limit = int.MaxValue, int offset = 0)
		{
			List<Sale> records = await this.TransactionRepository.SalesByTransactionId(transactionId, limit, offset);

			return this.BolSaleMapper.MapBOToModel(this.DalSaleMapper.MapEFToBO(records));
		}
	}
}

/*<Codenesium>
    <Hash>f726b019e81ecd0b74c9ee40765c3fed</Hash>
</Codenesium>*/