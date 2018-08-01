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
		private ITransactionStatusRepository transactionStatusRepository;

		private IApiTransactionStatusRequestModelValidator transactionStatusModelValidator;

		private IBOLTransactionStatusMapper bolTransactionStatusMapper;

		private IDALTransactionStatusMapper dalTransactionStatusMapper;

		private IBOLTransactionMapper bolTransactionMapper;

		private IDALTransactionMapper dalTransactionMapper;

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
			this.transactionStatusRepository = transactionStatusRepository;
			this.transactionStatusModelValidator = transactionStatusModelValidator;
			this.bolTransactionStatusMapper = bolTransactionStatusMapper;
			this.dalTransactionStatusMapper = dalTransactionStatusMapper;
			this.bolTransactionMapper = bolTransactionMapper;
			this.dalTransactionMapper = dalTransactionMapper;
			this.logger = logger;
		}

		public virtual async Task<List<ApiTransactionStatusResponseModel>> All(int limit = 0, int offset = int.MaxValue)
		{
			var records = await this.transactionStatusRepository.All(limit, offset);

			return this.bolTransactionStatusMapper.MapBOToModel(this.dalTransactionStatusMapper.MapEFToBO(records));
		}

		public virtual async Task<ApiTransactionStatusResponseModel> Get(int id)
		{
			var record = await this.transactionStatusRepository.Get(id);

			if (record == null)
			{
				return null;
			}
			else
			{
				return this.bolTransactionStatusMapper.MapBOToModel(this.dalTransactionStatusMapper.MapEFToBO(record));
			}
		}

		public virtual async Task<CreateResponse<ApiTransactionStatusResponseModel>> Create(
			ApiTransactionStatusRequestModel model)
		{
			CreateResponse<ApiTransactionStatusResponseModel> response = new CreateResponse<ApiTransactionStatusResponseModel>(await this.transactionStatusModelValidator.ValidateCreateAsync(model));
			if (response.Success)
			{
				var bo = this.bolTransactionStatusMapper.MapModelToBO(default(int), model);
				var record = await this.transactionStatusRepository.Create(this.dalTransactionStatusMapper.MapBOToEF(bo));

				response.SetRecord(this.bolTransactionStatusMapper.MapBOToModel(this.dalTransactionStatusMapper.MapEFToBO(record)));
			}

			return response;
		}

		public virtual async Task<UpdateResponse<ApiTransactionStatusResponseModel>> Update(
			int id,
			ApiTransactionStatusRequestModel model)
		{
			var validationResult = await this.transactionStatusModelValidator.ValidateUpdateAsync(id, model);

			if (validationResult.IsValid)
			{
				var bo = this.bolTransactionStatusMapper.MapModelToBO(id, model);
				await this.transactionStatusRepository.Update(this.dalTransactionStatusMapper.MapBOToEF(bo));

				var record = await this.transactionStatusRepository.Get(id);

				return new UpdateResponse<ApiTransactionStatusResponseModel>(this.bolTransactionStatusMapper.MapBOToModel(this.dalTransactionStatusMapper.MapEFToBO(record)));
			}
			else
			{
				return new UpdateResponse<ApiTransactionStatusResponseModel>(validationResult);
			}
		}

		public virtual async Task<ActionResponse> Delete(
			int id)
		{
			ActionResponse response = new ActionResponse(await this.transactionStatusModelValidator.ValidateDeleteAsync(id));
			if (response.Success)
			{
				await this.transactionStatusRepository.Delete(id);
			}

			return response;
		}

		public async virtual Task<List<ApiTransactionResponseModel>> Transactions(int transactionStatusId, int limit = int.MaxValue, int offset = 0)
		{
			List<Transaction> records = await this.transactionStatusRepository.Transactions(transactionStatusId, limit, offset);

			return this.bolTransactionMapper.MapBOToModel(this.dalTransactionMapper.MapEFToBO(records));
		}
	}
}

/*<Codenesium>
    <Hash>56c57fce6dbe0d1c2cffe4b4deb93125</Hash>
</Codenesium>*/