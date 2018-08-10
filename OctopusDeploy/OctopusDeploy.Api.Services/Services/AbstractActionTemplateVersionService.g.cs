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
		protected IActionTemplateVersionRepository ActionTemplateVersionRepository { get; private set; }

		protected IApiActionTemplateVersionRequestModelValidator ActionTemplateVersionModelValidator { get; private set; }

		protected IBOLActionTemplateVersionMapper BolActionTemplateVersionMapper { get; private set; }

		protected IDALActionTemplateVersionMapper DalActionTemplateVersionMapper { get; private set; }

		private ILogger logger;

		public AbstractActionTemplateVersionService(
			ILogger logger,
			IActionTemplateVersionRepository actionTemplateVersionRepository,
			IApiActionTemplateVersionRequestModelValidator actionTemplateVersionModelValidator,
			IBOLActionTemplateVersionMapper bolActionTemplateVersionMapper,
			IDALActionTemplateVersionMapper dalActionTemplateVersionMapper)
			: base()
		{
			this.ActionTemplateVersionRepository = actionTemplateVersionRepository;
			this.ActionTemplateVersionModelValidator = actionTemplateVersionModelValidator;
			this.BolActionTemplateVersionMapper = bolActionTemplateVersionMapper;
			this.DalActionTemplateVersionMapper = dalActionTemplateVersionMapper;
			this.logger = logger;
		}

		public virtual async Task<List<ApiActionTemplateVersionResponseModel>> All(int limit = 0, int offset = int.MaxValue)
		{
			var records = await this.ActionTemplateVersionRepository.All(limit, offset);

			return this.BolActionTemplateVersionMapper.MapBOToModel(this.DalActionTemplateVersionMapper.MapEFToBO(records));
		}

		public virtual async Task<ApiActionTemplateVersionResponseModel> Get(string id)
		{
			var record = await this.ActionTemplateVersionRepository.Get(id);

			if (record == null)
			{
				return null;
			}
			else
			{
				return this.BolActionTemplateVersionMapper.MapBOToModel(this.DalActionTemplateVersionMapper.MapEFToBO(record));
			}
		}

		public virtual async Task<CreateResponse<ApiActionTemplateVersionResponseModel>> Create(
			ApiActionTemplateVersionRequestModel model)
		{
			CreateResponse<ApiActionTemplateVersionResponseModel> response = new CreateResponse<ApiActionTemplateVersionResponseModel>(await this.ActionTemplateVersionModelValidator.ValidateCreateAsync(model));
			if (response.Success)
			{
				var bo = this.BolActionTemplateVersionMapper.MapModelToBO(default(string), model);
				var record = await this.ActionTemplateVersionRepository.Create(this.DalActionTemplateVersionMapper.MapBOToEF(bo));

				response.SetRecord(this.BolActionTemplateVersionMapper.MapBOToModel(this.DalActionTemplateVersionMapper.MapEFToBO(record)));
			}

			return response;
		}

		public virtual async Task<UpdateResponse<ApiActionTemplateVersionResponseModel>> Update(
			string id,
			ApiActionTemplateVersionRequestModel model)
		{
			var validationResult = await this.ActionTemplateVersionModelValidator.ValidateUpdateAsync(id, model);

			if (validationResult.IsValid)
			{
				var bo = this.BolActionTemplateVersionMapper.MapModelToBO(id, model);
				await this.ActionTemplateVersionRepository.Update(this.DalActionTemplateVersionMapper.MapBOToEF(bo));

				var record = await this.ActionTemplateVersionRepository.Get(id);

				return new UpdateResponse<ApiActionTemplateVersionResponseModel>(this.BolActionTemplateVersionMapper.MapBOToModel(this.DalActionTemplateVersionMapper.MapEFToBO(record)));
			}
			else
			{
				return new UpdateResponse<ApiActionTemplateVersionResponseModel>(validationResult);
			}
		}

		public virtual async Task<ActionResponse> Delete(
			string id)
		{
			ActionResponse response = new ActionResponse(await this.ActionTemplateVersionModelValidator.ValidateDeleteAsync(id));
			if (response.Success)
			{
				await this.ActionTemplateVersionRepository.Delete(id);
			}

			return response;
		}

		public async Task<ApiActionTemplateVersionResponseModel> ByNameVersion(string name, int version)
		{
			ActionTemplateVersion record = await this.ActionTemplateVersionRepository.ByNameVersion(name, version);

			if (record == null)
			{
				return null;
			}
			else
			{
				return this.BolActionTemplateVersionMapper.MapBOToModel(this.DalActionTemplateVersionMapper.MapEFToBO(record));
			}
		}

		public async Task<List<ApiActionTemplateVersionResponseModel>> ByLatestActionTemplateId(string latestActionTemplateId)
		{
			List<ActionTemplateVersion> records = await this.ActionTemplateVersionRepository.ByLatestActionTemplateId(latestActionTemplateId);

			return this.BolActionTemplateVersionMapper.MapBOToModel(this.DalActionTemplateVersionMapper.MapEFToBO(records));
		}
	}
}

/*<Codenesium>
    <Hash>b880dbf108bcd2f01b245ae7ad31c6d3</Hash>
</Codenesium>*/