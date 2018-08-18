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
	public abstract class AbstractTransactionStatusService : AbstractService
	{
		protected ITransactionStatusRepository TransactionStatusRepository { get; private set; }

		protected IApiTransactionStatusRequestModelValidator TransactionStatusModelValidator { get; private set; }

		protected IBOLTransactionStatusMapper BolTransactionStatusMapper { get; private set; }

		protected IDALTransactionStatusMapper DalTransactionStatusMapper { get; private set; }

		protected IBOLTransactionMapper BolTransactionMapper { get; private set; }

		protected IDALTransactionMapper DalTransactionMapper { get; private set; }

		private ILogger logger;

		public AbstractTransactionStatusService(
			ILogger logger,
			ITransactionStatusRepository transactionStatusRepository,
			IApiTransactionStatusRequestModelValidator transactionStatusModelValidator,
			IBOLTransactionStatusMapper bolTransactionStatusMapper,
			IDALTransactionStatusMapper dalTransactionStatusMapper,
			IBOLTransactionMapper bolTransactionMapper,
			IDALTransactionMapper dalTransactionMapper)
			: base()
		{
			this.TransactionStatusRepository = transactionStatusRepository;
			this.TransactionStatusModelValidator = transactionStatusModelValidator;
			this.BolTransactionStatusMapper = bolTransactionStatusMapper;
			this.DalTransactionStatusMapper = dalTransactionStatusMapper;
			this.BolTransactionMapper = bolTransactionMapper;
			this.DalTransactionMapper = dalTransactionMapper;
			this.logger = logger;
		}

		public virtual async Task<List<ApiTransactionStatusResponseModel>> All(int limit = 0, int offset = int.MaxValue)
		{
			var records = await this.TransactionStatusRepository.All(limit, offset);

			return this.BolTransactionStatusMapper.MapBOToModel(this.DalTransactionStatusMapper.MapEFToBO(records));
		}

		public virtual async Task<ApiTransactionStatusResponseModel> Get(int id)
		{
			var record = await this.TransactionStatusRepository.Get(id);

			if (record == null)
			{
				return null;
			}
			else
			{
				return this.BolTransactionStatusMapper.MapBOToModel(this.DalTransactionStatusMapper.MapEFToBO(record));
			}
		}

		public virtual async Task<CreateResponse<ApiTransactionStatusResponseModel>> Create(
			ApiTransactionStatusRequestModel model)
		{
			CreateResponse<ApiTransactionStatusResponseModel> response = new CreateResponse<ApiTransactionStatusResponseModel>(await this.TransactionStatusModelValidator.ValidateCreateAsync(model));
			if (response.Success)
			{
				var bo = this.BolTransactionStatusMapper.MapModelToBO(default(int), model);
				var record = await this.TransactionStatusRepository.Create(this.DalTransactionStatusMapper.MapBOToEF(bo));

				response.SetRecord(this.BolTransactionStatusMapper.MapBOToModel(this.DalTransactionStatusMapper.MapEFToBO(record)));
			}

			return response;
		}

		public virtual async Task<UpdateResponse<ApiTransactionStatusResponseModel>> Update(
			int id,
			ApiTransactionStatusRequestModel model)
		{
			var validationResult = await this.TransactionStatusModelValidator.ValidateUpdateAsync(id, model);

			if (validationResult.IsValid)
			{
				var bo = this.BolTransactionStatusMapper.MapModelToBO(id, model);
				await this.TransactionStatusRepository.Update(this.DalTransactionStatusMapper.MapBOToEF(bo));

				var record = await this.TransactionStatusRepository.Get(id);

				return new UpdateResponse<ApiTransactionStatusResponseModel>(this.BolTransactionStatusMapper.MapBOToModel(this.DalTransactionStatusMapper.MapEFToBO(record)));
			}
			else
			{
				return new UpdateResponse<ApiTransactionStatusResponseModel>(validationResult);
			}
		}

		public virtual async Task<ActionResponse> Delete(
			int id)
		{
			ActionResponse response = new ActionResponse(await this.TransactionStatusModelValidator.ValidateDeleteAsync(id));
			if (response.Success)
			{
				await this.TransactionStatusRepository.Delete(id);
			}

			return response;
		}

		public async virtual Task<List<ApiTransactionResponseModel>> Transactions(int transactionStatusId, int limit = int.MaxValue, int offset = 0)
		{
			List<Transaction> records = await this.TransactionStatusRepository.Transactions(transactionStatusId, limit, offset);

			return this.BolTransactionMapper.MapBOToModel(this.DalTransactionMapper.MapEFToBO(records));
		}
	}
}

/*<Codenesium>
    <Hash>3a8d3785f50eb2a0791fd1fbc9d14668</Hash>
</Codenesium>*/