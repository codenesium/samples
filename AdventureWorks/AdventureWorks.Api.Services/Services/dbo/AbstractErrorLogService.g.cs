using Codenesium.DataConversionExtensions.AspNetCore;
using System;
using System.Collections.Generic;
using Microsoft.Extensions.Logging;
using Microsoft.EntityFrameworkCore;
using System.Linq;
using System.Linq.Dynamic.Core;
using System.Linq.Expressions;
using System.Threading.Tasks;
using AdventureWorksNS.Api.Contracts;
using AdventureWorksNS.Api.DataAccess;

namespace AdventureWorksNS.Api.Services
{
	public abstract class AbstractErrorLogService: AbstractService
	{
		private IErrorLogRepository errorLogRepository;
		private IApiErrorLogRequestModelValidator errorLogModelValidator;
		private IBOLErrorLogMapper BOLErrorLogMapper;
		private IDALErrorLogMapper DALErrorLogMapper;
		private ILogger logger;

		public AbstractErrorLogService(
			ILogger logger,
			IErrorLogRepository errorLogRepository,
			IApiErrorLogRequestModelValidator errorLogModelValidator,
			IBOLErrorLogMapper bolerrorLogMapper,
			IDALErrorLogMapper dalerrorLogMapper)
			: base()

		{
			this.errorLogRepository = errorLogRepository;
			this.errorLogModelValidator = errorLogModelValidator;
			this.BOLErrorLogMapper = bolerrorLogMapper;
			this.DALErrorLogMapper = dalerrorLogMapper;
			this.logger = logger;
		}

		public virtual async Task<List<ApiErrorLogResponseModel>> All(int skip = 0, int take = int.MaxValue, string orderClause = "")
		{
			var records = await this.errorLogRepository.All(skip, take, orderClause);

			return this.BOLErrorLogMapper.MapBOToModel(this.DALErrorLogMapper.MapEFToBO(records));
		}

		public virtual async Task<ApiErrorLogResponseModel> Get(int errorLogID)
		{
			var record = await errorLogRepository.Get(errorLogID);

			return this.BOLErrorLogMapper.MapBOToModel(this.DALErrorLogMapper.MapEFToBO(record));
		}

		public virtual async Task<CreateResponse<ApiErrorLogResponseModel>> Create(
			ApiErrorLogRequestModel model)
		{
			CreateResponse<ApiErrorLogResponseModel> response = new CreateResponse<ApiErrorLogResponseModel>(await this.errorLogModelValidator.ValidateCreateAsync(model));
			if (response.Success)
			{
				var bo = this.BOLErrorLogMapper.MapModelToBO(default (int), model);
				var record = await this.errorLogRepository.Create(this.DALErrorLogMapper.MapBOToEF(bo));

				response.SetRecord(this.BOLErrorLogMapper.MapBOToModel(this.DALErrorLogMapper.MapEFToBO(record)));
			}
			return response;
		}

		public virtual async Task<ActionResponse> Update(
			int errorLogID,
			ApiErrorLogRequestModel model)
		{
			ActionResponse response = new ActionResponse(await this.errorLogModelValidator.ValidateUpdateAsync(errorLogID, model));

			if (response.Success)
			{
				var bo = this.BOLErrorLogMapper.MapModelToBO(errorLogID, model);
				await this.errorLogRepository.Update(this.DALErrorLogMapper.MapBOToEF(bo));
			}

			return response;
		}

		public virtual async Task<ActionResponse> Delete(
			int errorLogID)
		{
			ActionResponse response = new ActionResponse(await this.errorLogModelValidator.ValidateDeleteAsync(errorLogID));

			if (response.Success)
			{
				await this.errorLogRepository.Delete(errorLogID);
			}
			return response;
		}
	}
}

/*<Codenesium>
    <Hash>dfc80cd63a4a800852196e239d98f834</Hash>
</Codenesium>*/