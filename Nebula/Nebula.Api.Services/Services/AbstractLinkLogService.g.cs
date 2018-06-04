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

namespace NebulaNS.Api.Services
{
	public abstract class AbstractLinkLogService: AbstractService
	{
		private ILinkLogRepository linkLogRepository;
		private IApiLinkLogRequestModelValidator linkLogModelValidator;
		private IBOLLinkLogMapper BOLLinkLogMapper;
		private IDALLinkLogMapper DALLinkLogMapper;
		private ILogger logger;

		public AbstractLinkLogService(
			ILogger logger,
			ILinkLogRepository linkLogRepository,
			IApiLinkLogRequestModelValidator linkLogModelValidator,
			IBOLLinkLogMapper bollinkLogMapper,
			IDALLinkLogMapper dallinkLogMapper)
			: base()

		{
			this.linkLogRepository = linkLogRepository;
			this.linkLogModelValidator = linkLogModelValidator;
			this.BOLLinkLogMapper = bollinkLogMapper;
			this.DALLinkLogMapper = dallinkLogMapper;
			this.logger = logger;
		}

		public virtual async Task<List<ApiLinkLogResponseModel>> All(int skip = 0, int take = int.MaxValue, string orderClause = "")
		{
			var records = await this.linkLogRepository.All(skip, take, orderClause);

			return this.BOLLinkLogMapper.MapBOToModel(this.DALLinkLogMapper.MapEFToBO(records));
		}

		public virtual async Task<ApiLinkLogResponseModel> Get(int id)
		{
			var record = await linkLogRepository.Get(id);

			return this.BOLLinkLogMapper.MapBOToModel(this.DALLinkLogMapper.MapEFToBO(record));
		}

		public virtual async Task<CreateResponse<ApiLinkLogResponseModel>> Create(
			ApiLinkLogRequestModel model)
		{
			CreateResponse<ApiLinkLogResponseModel> response = new CreateResponse<ApiLinkLogResponseModel>(await this.linkLogModelValidator.ValidateCreateAsync(model));
			if (response.Success)
			{
				var bo = this.BOLLinkLogMapper.MapModelToBO(default (int), model);
				var record = await this.linkLogRepository.Create(this.DALLinkLogMapper.MapBOToEF(bo));

				response.SetRecord(this.BOLLinkLogMapper.MapBOToModel(this.DALLinkLogMapper.MapEFToBO(record)));
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
				var bo = this.BOLLinkLogMapper.MapModelToBO(id, model);
				await this.linkLogRepository.Update(this.DALLinkLogMapper.MapBOToEF(bo));
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
    <Hash>f540c05ae1f26cd0399fd451f2b9a291</Hash>
</Codenesium>*/