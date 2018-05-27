using Codenesium.DataConversionExtensions.AspNetCore;
using System;
using System.Collections.Generic;
using Microsoft.Extensions.Logging;
using Microsoft.EntityFrameworkCore;
using System.Linq;
using System.Linq.Dynamic.Core;
using System.Linq.Expressions;
using System.Threading.Tasks;
using NebulaNS.Api.Contracts;
using NebulaNS.Api.DataAccess;

namespace NebulaNS.Api.BusinessObjects
{
	public abstract class AbstractBOLinkLog: AbstractBOManager
	{
		private ILinkLogRepository linkLogRepository;
		private IApiLinkLogRequestModelValidator linkLogModelValidator;
		private IBOLLinkLogMapper linkLogMapper;
		private ILogger logger;

		public AbstractBOLinkLog(
			ILogger logger,
			ILinkLogRepository linkLogRepository,
			IApiLinkLogRequestModelValidator linkLogModelValidator,
			IBOLLinkLogMapper linkLogMapper)
			: base()

		{
			this.linkLogRepository = linkLogRepository;
			this.linkLogModelValidator = linkLogModelValidator;
			this.linkLogMapper = linkLogMapper;
			this.logger = logger;
		}

		public virtual async Task<List<ApiLinkLogResponseModel>> All(int skip = 0, int take = int.MaxValue, string orderClause = "")
		{
			var records = await this.linkLogRepository.All(skip, take, orderClause);

			return this.linkLogMapper.MapDTOToModel(records);
		}

		public virtual async Task<ApiLinkLogResponseModel> Get(int id)
		{
			var record = await linkLogRepository.Get(id);

			return this.linkLogMapper.MapDTOToModel(record);
		}

		public virtual async Task<CreateResponse<ApiLinkLogResponseModel>> Create(
			ApiLinkLogRequestModel model)
		{
			CreateResponse<ApiLinkLogResponseModel> response = new CreateResponse<ApiLinkLogResponseModel>(await this.linkLogModelValidator.ValidateCreateAsync(model));
			if (response.Success)
			{
				var dto = this.linkLogMapper.MapModelToDTO(default (int), model);
				var record = await this.linkLogRepository.Create(dto);

				response.SetRecord(this.linkLogMapper.MapDTOToModel(record));
			}
			return response;
		}

		public virtual async Task<ActionResponse> Update(
			int id,
			ApiLinkLogRequestModel model)
		{
			ActionResponse response = new ActionResponse(await this.linkLogModelValidator.ValidateUpdateAsync(id, model));

			if (response.Success)
			{
				var dto = this.linkLogMapper.MapModelToDTO(id, model);
				await this.linkLogRepository.Update(id, dto);
			}

			return response;
		}

		public virtual async Task<ActionResponse> Delete(
			int id)
		{
			ActionResponse response = new ActionResponse(await this.linkLogModelValidator.ValidateDeleteAsync(id));

			if (response.Success)
			{
				await this.linkLogRepository.Delete(id);
			}
			return response;
		}
	}
}

/*<Codenesium>
    <Hash>29d63936650e3f56688d24db31834c57</Hash>
</Codenesium>*/