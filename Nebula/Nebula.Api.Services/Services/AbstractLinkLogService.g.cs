using Codenesium.DataConversionExtensions;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;
using NebulaNS.Api.Contracts;
using NebulaNS.Api.DataAccess;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Dynamic.Core;
using System.Linq.Expressions;
using System.Threading.Tasks;

namespace NebulaNS.Api.Services
{
	public abstract class AbstractLinkLogService : AbstractService
	{
		protected ILinkLogRepository LinkLogRepository { get; private set; }

		protected IApiLinkLogRequestModelValidator LinkLogModelValidator { get; private set; }

		protected IBOLLinkLogMapper BolLinkLogMapper { get; private set; }

		protected IDALLinkLogMapper DalLinkLogMapper { get; private set; }

		private ILogger logger;

		public AbstractLinkLogService(
			ILogger logger,
			ILinkLogRepository linkLogRepository,
			IApiLinkLogRequestModelValidator linkLogModelValidator,
			IBOLLinkLogMapper bolLinkLogMapper,
			IDALLinkLogMapper dalLinkLogMapper)
			: base()
		{
			this.LinkLogRepository = linkLogRepository;
			this.LinkLogModelValidator = linkLogModelValidator;
			this.BolLinkLogMapper = bolLinkLogMapper;
			this.DalLinkLogMapper = dalLinkLogMapper;
			this.logger = logger;
		}

		public virtual async Task<List<ApiLinkLogResponseModel>> All(int limit = 0, int offset = int.MaxValue)
		{
			var records = await this.LinkLogRepository.All(limit, offset);

			return this.BolLinkLogMapper.MapBOToModel(this.DalLinkLogMapper.MapEFToBO(records));
		}

		public virtual async Task<ApiLinkLogResponseModel> Get(int id)
		{
			var record = await this.LinkLogRepository.Get(id);

			if (record == null)
			{
				return null;
			}
			else
			{
				return this.BolLinkLogMapper.MapBOToModel(this.DalLinkLogMapper.MapEFToBO(record));
			}
		}

		public virtual async Task<CreateResponse<ApiLinkLogResponseModel>> Create(
			ApiLinkLogRequestModel model)
		{
			CreateResponse<ApiLinkLogResponseModel> response = new CreateResponse<ApiLinkLogResponseModel>(await this.LinkLogModelValidator.ValidateCreateAsync(model));
			if (response.Success)
			{
				var bo = this.BolLinkLogMapper.MapModelToBO(default(int), model);
				var record = await this.LinkLogRepository.Create(this.DalLinkLogMapper.MapBOToEF(bo));

				response.SetRecord(this.BolLinkLogMapper.MapBOToModel(this.DalLinkLogMapper.MapEFToBO(record)));
			}

			return response;
		}

		public virtual async Task<UpdateResponse<ApiLinkLogResponseModel>> Update(
			int id,
			ApiLinkLogRequestModel model)
		{
			var validationResult = await this.LinkLogModelValidator.ValidateUpdateAsync(id, model);

			if (validationResult.IsValid)
			{
				var bo = this.BolLinkLogMapper.MapModelToBO(id, model);
				await this.LinkLogRepository.Update(this.DalLinkLogMapper.MapBOToEF(bo));

				var record = await this.LinkLogRepository.Get(id);

				return new UpdateResponse<ApiLinkLogResponseModel>(this.BolLinkLogMapper.MapBOToModel(this.DalLinkLogMapper.MapEFToBO(record)));
			}
			else
			{
				return new UpdateResponse<ApiLinkLogResponseModel>(validationResult);
			}
		}

		public virtual async Task<ActionResponse> Delete(
			int id)
		{
			ActionResponse response = new ActionResponse(await this.LinkLogModelValidator.ValidateDeleteAsync(id));
			if (response.Success)
			{
				await this.LinkLogRepository.Delete(id);
			}

			return response;
		}
	}
}

/*<Codenesium>
    <Hash>6a0e916fb952e13ad0fe622cb8d9471f</Hash>
</Codenesium>*/