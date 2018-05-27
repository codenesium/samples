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

namespace AdventureWorksNS.Api.BusinessObjects
{
	public abstract class AbstractBOErrorLog: AbstractBOManager
	{
		private IErrorLogRepository errorLogRepository;
		private IApiErrorLogRequestModelValidator errorLogModelValidator;
		private IBOLErrorLogMapper errorLogMapper;
		private ILogger logger;

		public AbstractBOErrorLog(
			ILogger logger,
			IErrorLogRepository errorLogRepository,
			IApiErrorLogRequestModelValidator errorLogModelValidator,
			IBOLErrorLogMapper errorLogMapper)
			: base()

		{
			this.errorLogRepository = errorLogRepository;
			this.errorLogModelValidator = errorLogModelValidator;
			this.errorLogMapper = errorLogMapper;
			this.logger = logger;
		}

		public virtual async Task<List<ApiErrorLogResponseModel>> All(int skip = 0, int take = int.MaxValue, string orderClause = "")
		{
			var records = await this.errorLogRepository.All(skip, take, orderClause);

			return this.errorLogMapper.MapDTOToModel(records);
		}

		public virtual async Task<ApiErrorLogResponseModel> Get(int errorLogID)
		{
			var record = await errorLogRepository.Get(errorLogID);

			return this.errorLogMapper.MapDTOToModel(record);
		}

		public virtual async Task<CreateResponse<ApiErrorLogResponseModel>> Create(
			ApiErrorLogRequestModel model)
		{
			CreateResponse<ApiErrorLogResponseModel> response = new CreateResponse<ApiErrorLogResponseModel>(await this.errorLogModelValidator.ValidateCreateAsync(model));
			if (response.Success)
			{
				var dto = this.errorLogMapper.MapModelToDTO(default (int), model);
				var record = await this.errorLogRepository.Create(dto);

				response.SetRecord(this.errorLogMapper.MapDTOToModel(record));
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
				var dto = this.errorLogMapper.MapModelToDTO(errorLogID, model);
				await this.errorLogRepository.Update(errorLogID, dto);
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
    <Hash>bc8f891955f340cfb55062790d66d63f</Hash>
</Codenesium>*/