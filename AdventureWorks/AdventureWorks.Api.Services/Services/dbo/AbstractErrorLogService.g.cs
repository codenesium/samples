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
	public abstract class AbstractErrorLogService : AbstractService
	{
		protected IErrorLogRepository ErrorLogRepository { get; private set; }

		protected IApiErrorLogRequestModelValidator ErrorLogModelValidator { get; private set; }

		protected IBOLErrorLogMapper BolErrorLogMapper { get; private set; }

		protected IDALErrorLogMapper DalErrorLogMapper { get; private set; }

		private ILogger logger;

		public AbstractErrorLogService(
			ILogger logger,
			IErrorLogRepository errorLogRepository,
			IApiErrorLogRequestModelValidator errorLogModelValidator,
			IBOLErrorLogMapper bolErrorLogMapper,
			IDALErrorLogMapper dalErrorLogMapper)
			: base()
		{
			this.ErrorLogRepository = errorLogRepository;
			this.ErrorLogModelValidator = errorLogModelValidator;
			this.BolErrorLogMapper = bolErrorLogMapper;
			this.DalErrorLogMapper = dalErrorLogMapper;
			this.logger = logger;
		}

		public virtual async Task<List<ApiErrorLogResponseModel>> All(int limit = 0, int offset = int.MaxValue)
		{
			var records = await this.ErrorLogRepository.All(limit, offset);

			return this.BolErrorLogMapper.MapBOToModel(this.DalErrorLogMapper.MapEFToBO(records));
		}

		public virtual async Task<ApiErrorLogResponseModel> Get(int errorLogID)
		{
			var record = await this.ErrorLogRepository.Get(errorLogID);

			if (record == null)
			{
				return null;
			}
			else
			{
				return this.BolErrorLogMapper.MapBOToModel(this.DalErrorLogMapper.MapEFToBO(record));
			}
		}

		public virtual async Task<CreateResponse<ApiErrorLogResponseModel>> Create(
			ApiErrorLogRequestModel model)
		{
			CreateResponse<ApiErrorLogResponseModel> response = new CreateResponse<ApiErrorLogResponseModel>(await this.ErrorLogModelValidator.ValidateCreateAsync(model));
			if (response.Success)
			{
				var bo = this.BolErrorLogMapper.MapModelToBO(default(int), model);
				var record = await this.ErrorLogRepository.Create(this.DalErrorLogMapper.MapBOToEF(bo));

				response.SetRecord(this.BolErrorLogMapper.MapBOToModel(this.DalErrorLogMapper.MapEFToBO(record)));
			}

			return response;
		}

		public virtual async Task<UpdateResponse<ApiErrorLogResponseModel>> Update(
			int errorLogID,
			ApiErrorLogRequestModel model)
		{
			var validationResult = await this.ErrorLogModelValidator.ValidateUpdateAsync(errorLogID, model);

			if (validationResult.IsValid)
			{
				var bo = this.BolErrorLogMapper.MapModelToBO(errorLogID, model);
				await this.ErrorLogRepository.Update(this.DalErrorLogMapper.MapBOToEF(bo));

				var record = await this.ErrorLogRepository.Get(errorLogID);

				return new UpdateResponse<ApiErrorLogResponseModel>(this.BolErrorLogMapper.MapBOToModel(this.DalErrorLogMapper.MapEFToBO(record)));
			}
			else
			{
				return new UpdateResponse<ApiErrorLogResponseModel>(validationResult);
			}
		}

		public virtual async Task<ActionResponse> Delete(
			int errorLogID)
		{
			ActionResponse response = new ActionResponse(await this.ErrorLogModelValidator.ValidateDeleteAsync(errorLogID));
			if (response.Success)
			{
				await this.ErrorLogRepository.Delete(errorLogID);
			}

			return response;
		}
	}
}

/*<Codenesium>
    <Hash>bc6992b7bee51dea07e0cc2fa2497d20</Hash>
</Codenesium>*/