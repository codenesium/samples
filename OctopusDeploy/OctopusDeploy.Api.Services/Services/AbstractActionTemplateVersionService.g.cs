using Codenesium.DataConversionExtensions;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;
using OctopusDeployNS.Api.Contracts;
using OctopusDeployNS.Api.DataAccess;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Dynamic.Core;
using System.Linq.Expressions;
using System.Threading.Tasks;

namespace OctopusDeployNS.Api.Services
{
	public abstract class AbstractActionTemplateVersionService : AbstractService
	{
		private IActionTemplateVersionRepository actionTemplateVersionRepository;

		private IApiActionTemplateVersionRequestModelValidator actionTemplateVersionModelValidator;

		private IBOLActionTemplateVersionMapper bolActionTemplateVersionMapper;

		private IDALActionTemplateVersionMapper dalActionTemplateVersionMapper;

		private ILogger logger;

		public AbstractActionTemplateVersionService(
			ILogger logger,
			IActionTemplateVersionRepository actionTemplateVersionRepository,
			IApiActionTemplateVersionRequestModelValidator actionTemplateVersionModelValidator,
			IBOLActionTemplateVersionMapper bolActionTemplateVersionMapper,
			IDALActionTemplateVersionMapper dalActionTemplateVersionMapper)
			: base()
		{
			this.actionTemplateVersionRepository = actionTemplateVersionRepository;
			this.actionTemplateVersionModelValidator = actionTemplateVersionModelValidator;
			this.bolActionTemplateVersionMapper = bolActionTemplateVersionMapper;
			this.dalActionTemplateVersionMapper = dalActionTemplateVersionMapper;
			this.logger = logger;
		}

		public virtual async Task<List<ApiActionTemplateVersionResponseModel>> All(int limit = 0, int offset = int.MaxValue)
		{
			var records = await this.actionTemplateVersionRepository.All(limit, offset);

			return this.bolActionTemplateVersionMapper.MapBOToModel(this.dalActionTemplateVersionMapper.MapEFToBO(records));
		}

		public virtual async Task<ApiActionTemplateVersionResponseModel> Get(string id)
		{
			var record = await this.actionTemplateVersionRepository.Get(id);

			if (record == null)
			{
				return null;
			}
			else
			{
				return this.bolActionTemplateVersionMapper.MapBOToModel(this.dalActionTemplateVersionMapper.MapEFToBO(record));
			}
		}

		public virtual async Task<CreateResponse<ApiActionTemplateVersionResponseModel>> Create(
			ApiActionTemplateVersionRequestModel model)
		{
			CreateResponse<ApiActionTemplateVersionResponseModel> response = new CreateResponse<ApiActionTemplateVersionResponseModel>(await this.actionTemplateVersionModelValidator.ValidateCreateAsync(model));
			if (response.Success)
			{
				var bo = this.bolActionTemplateVersionMapper.MapModelToBO(default(string), model);
				var record = await this.actionTemplateVersionRepository.Create(this.dalActionTemplateVersionMapper.MapBOToEF(bo));

				response.SetRecord(this.bolActionTemplateVersionMapper.MapBOToModel(this.dalActionTemplateVersionMapper.MapEFToBO(record)));
			}

			return response;
		}

		public virtual async Task<UpdateResponse<ApiActionTemplateVersionResponseModel>> Update(
			string id,
			ApiActionTemplateVersionRequestModel model)
		{
			var validationResult = await this.actionTemplateVersionModelValidator.ValidateUpdateAsync(id, model);

			if (validationResult.IsValid)
			{
				var bo = this.bolActionTemplateVersionMapper.MapModelToBO(id, model);
				await this.actionTemplateVersionRepository.Update(this.dalActionTemplateVersionMapper.MapBOToEF(bo));

				var record = await this.actionTemplateVersionRepository.Get(id);

				return new UpdateResponse<ApiActionTemplateVersionResponseModel>(this.bolActionTemplateVersionMapper.MapBOToModel(this.dalActionTemplateVersionMapper.MapEFToBO(record)));
			}
			else
			{
				return new UpdateResponse<ApiActionTemplateVersionResponseModel>(validationResult);
			}
		}

		public virtual async Task<ActionResponse> Delete(
			string id)
		{
			ActionResponse response = new ActionResponse(await this.actionTemplateVersionModelValidator.ValidateDeleteAsync(id));
			if (response.Success)
			{
				await this.actionTemplateVersionRepository.Delete(id);
			}

			return response;
		}

		public async Task<ApiActionTemplateVersionResponseModel> ByNameVersion(string name, int version)
		{
			ActionTemplateVersion record = await this.actionTemplateVersionRepository.ByNameVersion(name, version);

			if (record == null)
			{
				return null;
			}
			else
			{
				return this.bolActionTemplateVersionMapper.MapBOToModel(this.dalActionTemplateVersionMapper.MapEFToBO(record));
			}
		}

		public async Task<List<ApiActionTemplateVersionResponseModel>> ByLatestActionTemplateId(string latestActionTemplateId)
		{
			List<ActionTemplateVersion> records = await this.actionTemplateVersionRepository.ByLatestActionTemplateId(latestActionTemplateId);

			return this.bolActionTemplateVersionMapper.MapBOToModel(this.dalActionTemplateVersionMapper.MapEFToBO(records));
		}
	}
}

/*<Codenesium>
    <Hash>f39c7b80b6a4835217537bd44418a03a</Hash>
</Codenesium>*/