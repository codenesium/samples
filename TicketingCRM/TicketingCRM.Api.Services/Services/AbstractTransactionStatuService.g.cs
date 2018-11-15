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
		protected ITransactionStatuRepository TransactionStatuRepository { get; private set; }

		protected IApiTransactionStatuServerRequestModelValidator TransactionStatuModelValidator { get; private set; }

		protected IBOLTransactionStatuMapper BolTransactionStatuMapper { get; private set; }

		protected IDALTransactionStatuMapper DalTransactionStatuMapper { get; private set; }

		protected IBOLTransactionMapper BolTransactionMapper { get; private set; }

		protected IDALTransactionMapper DalTransactionMapper { get; private set; }

		private ILogger logger;

		public AbstractTransactionStatuService(
			ILogger logger,
			ITransactionStatuRepository transactionStatuRepository,
			IApiTransactionStatuServerRequestModelValidator transactionStatuModelValidator,
			IBOLTransactionStatuMapper bolTransactionStatuMapper,
			IDALTransactionStatuMapper dalTransactionStatuMapper,
			IBOLTransactionMapper bolTransactionMapper,
			IDALTransactionMapper dalTransactionMapper)
			: base()
		{
			this.TransactionStatuRepository = transactionStatuRepository;
			this.TransactionStatuModelValidator = transactionStatuModelValidator;
			this.BolTransactionStatuMapper = bolTransactionStatuMapper;
			this.DalTransactionStatuMapper = dalTransactionStatuMapper;
			this.BolTransactionMapper = bolTransactionMapper;
			this.DalTransactionMapper = dalTransactionMapper;
			this.logger = logger;
		}

		public virtual async Task<List<ApiTransactionStatuServerResponseModel>> All(int limit = 0, int offset = int.MaxValue)
		{
			var records = await this.TransactionStatuRepository.All(limit, offset);

			return this.BolTransactionStatuMapper.MapBOToModel(this.DalTransactionStatuMapper.MapEFToBO(records));
		}

		public virtual async Task<ApiTransactionStatuServerResponseModel> Get(int id)
		{
			var record = await this.TransactionStatuRepository.Get(id);

			if (record == null)
			{
				return null;
			}
			else
			{
				return this.BolTransactionStatuMapper.MapBOToModel(this.DalTransactionStatuMapper.MapEFToBO(record));
			}
		}

		public virtual async Task<CreateResponse<ApiTransactionStatuServerResponseModel>> Create(
			ApiTransactionStatuServerRequestModel model)
		{
			CreateResponse<ApiTransactionStatuServerResponseModel> response = ValidationResponseFactory<ApiTransactionStatuServerResponseModel>.CreateResponse(await this.TransactionStatuModelValidator.ValidateCreateAsync(model));

			if (response.Success)
			{
				var bo = this.BolTransactionStatuMapper.MapModelToBO(default(int), model);
				var record = await this.TransactionStatuRepository.Create(this.DalTransactionStatuMapper.MapBOToEF(bo));

				response.SetRecord(this.BolTransactionStatuMapper.MapBOToModel(this.DalTransactionStatuMapper.MapEFToBO(record)));
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
				var bo = this.BolTransactionStatuMapper.MapModelToBO(id, model);
				await this.TransactionStatuRepository.Update(this.DalTransactionStatuMapper.MapBOToEF(bo));

				var record = await this.TransactionStatuRepository.Get(id);

				return ValidationResponseFactory<ApiTransactionStatuServerResponseModel>.UpdateResponse(this.BolTransactionStatuMapper.MapBOToModel(this.DalTransactionStatuMapper.MapEFToBO(record)));
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
			}

			return response;
		}

		public async virtual Task<List<ApiTransactionServerResponseModel>> TransactionsByTransactionStatusId(int transactionStatusId, int limit = int.MaxValue, int offset = 0)
		{
			List<Transaction> records = await this.TransactionStatuRepository.TransactionsByTransactionStatusId(transactionStatusId, limit, offset);

			return this.BolTransactionMapper.MapBOToModel(this.DalTransactionMapper.MapEFToBO(records));
		}
	}
}

/*<Codenesium>
    <Hash>5a036a16e4d3b55701cb616d46793fc6</Hash>
</Codenesium>*/