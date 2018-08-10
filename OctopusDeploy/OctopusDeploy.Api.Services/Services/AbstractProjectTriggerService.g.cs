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
	public abstract class AbstractProjectTriggerService : AbstractService
	{
		protected IProjectTriggerRepository ProjectTriggerRepository { get; private set; }

		protected IApiProjectTriggerRequestModelValidator ProjectTriggerModelValidator { get; private set; }

		protected IBOLProjectTriggerMapper BolProjectTriggerMapper { get; private set; }

		protected IDALProjectTriggerMapper DalProjectTriggerMapper { get; private set; }

		private ILogger logger;

		public AbstractProjectTriggerService(
			ILogger logger,
			IProjectTriggerRepository projectTriggerRepository,
			IApiProjectTriggerRequestModelValidator projectTriggerModelValidator,
			IBOLProjectTriggerMapper bolProjectTriggerMapper,
			IDALProjectTriggerMapper dalProjectTriggerMapper)
			: base()
		{
			this.ProjectTriggerRepository = projectTriggerRepository;
			this.ProjectTriggerModelValidator = projectTriggerModelValidator;
			this.BolProjectTriggerMapper = bolProjectTriggerMapper;
			this.DalProjectTriggerMapper = dalProjectTriggerMapper;
			this.logger = logger;
		}

		public virtual async Task<List<ApiProjectTriggerResponseModel>> All(int limit = 0, int offset = int.MaxValue)
		{
			var records = await this.ProjectTriggerRepository.All(limit, offset);

			return this.BolProjectTriggerMapper.MapBOToModel(this.DalProjectTriggerMapper.MapEFToBO(records));
		}

		public virtual async Task<ApiProjectTriggerResponseModel> Get(string id)
		{
			var record = await this.ProjectTriggerRepository.Get(id);

			if (record == null)
			{
				return null;
			}
			else
			{
				return this.BolProjectTriggerMapper.MapBOToModel(this.DalProjectTriggerMapper.MapEFToBO(record));
			}
		}

		public virtual async Task<CreateResponse<ApiProjectTriggerResponseModel>> Create(
			ApiProjectTriggerRequestModel model)
		{
			CreateResponse<ApiProjectTriggerResponseModel> response = new CreateResponse<ApiProjectTriggerResponseModel>(await this.ProjectTriggerModelValidator.ValidateCreateAsync(model));
			if (response.Success)
			{
				var bo = this.BolProjectTriggerMapper.MapModelToBO(default(string), model);
				var record = await this.ProjectTriggerRepository.Create(this.DalProjectTriggerMapper.MapBOToEF(bo));

				response.SetRecord(this.BolProjectTriggerMapper.MapBOToModel(this.DalProjectTriggerMapper.MapEFToBO(record)));
			}

			return response;
		}

		public virtual async Task<UpdateResponse<ApiProjectTriggerResponseModel>> Update(
			string id,
			ApiProjectTriggerRequestModel model)
		{
			var validationResult = await this.ProjectTriggerModelValidator.ValidateUpdateAsync(id, model);

			if (validationResult.IsValid)
			{
				var bo = this.BolProjectTriggerMapper.MapModelToBO(id, model);
				await this.ProjectTriggerRepository.Update(this.DalProjectTriggerMapper.MapBOToEF(bo));

				var record = await this.ProjectTriggerRepository.Get(id);

				return new UpdateResponse<ApiProjectTriggerResponseModel>(this.BolProjectTriggerMapper.MapBOToModel(this.DalProjectTriggerMapper.MapEFToBO(record)));
			}
			else
			{
				return new UpdateResponse<ApiProjectTriggerResponseModel>(validationResult);
			}
		}

		public virtual async Task<ActionResponse> Delete(
			string id)
		{
			ActionResponse response = new ActionResponse(await this.ProjectTriggerModelValidator.ValidateDeleteAsync(id));
			if (response.Success)
			{
				await this.ProjectTriggerRepository.Delete(id);
			}

			return response;
		}

		public async Task<ApiProjectTriggerResponseModel> ByProjectIdName(string projectId, string name)
		{
			ProjectTrigger record = await this.ProjectTriggerRepository.ByProjectIdName(projectId, name);

			if (record == null)
			{
				return null;
			}
			else
			{
				return this.BolProjectTriggerMapper.MapBOToModel(this.DalProjectTriggerMapper.MapEFToBO(record));
			}
		}

		public async Task<List<ApiProjectTriggerResponseModel>> ByProjectId(string projectId)
		{
			List<ProjectTrigger> records = await this.ProjectTriggerRepository.ByProjectId(projectId);

			return this.BolProjectTriggerMapper.MapBOToModel(this.DalProjectTriggerMapper.MapEFToBO(records));
		}
	}
}

/*<Codenesium>
    <Hash>968c536efe2b17de23cd9dbf41e32fcf</Hash>
</Codenesium>*/