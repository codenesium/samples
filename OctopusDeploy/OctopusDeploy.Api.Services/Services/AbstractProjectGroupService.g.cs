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
	public abstract class AbstractProjectGroupService : AbstractService
	{
		protected IProjectGroupRepository ProjectGroupRepository { get; private set; }

		protected IApiProjectGroupRequestModelValidator ProjectGroupModelValidator { get; private set; }

		protected IBOLProjectGroupMapper BolProjectGroupMapper { get; private set; }

		protected IDALProjectGroupMapper DalProjectGroupMapper { get; private set; }

		private ILogger logger;

		public AbstractProjectGroupService(
			ILogger logger,
			IProjectGroupRepository projectGroupRepository,
			IApiProjectGroupRequestModelValidator projectGroupModelValidator,
			IBOLProjectGroupMapper bolProjectGroupMapper,
			IDALProjectGroupMapper dalProjectGroupMapper)
			: base()
		{
			this.ProjectGroupRepository = projectGroupRepository;
			this.ProjectGroupModelValidator = projectGroupModelValidator;
			this.BolProjectGroupMapper = bolProjectGroupMapper;
			this.DalProjectGroupMapper = dalProjectGroupMapper;
			this.logger = logger;
		}

		public virtual async Task<List<ApiProjectGroupResponseModel>> All(int limit = 0, int offset = int.MaxValue)
		{
			var records = await this.ProjectGroupRepository.All(limit, offset);

			return this.BolProjectGroupMapper.MapBOToModel(this.DalProjectGroupMapper.MapEFToBO(records));
		}

		public virtual async Task<ApiProjectGroupResponseModel> Get(string id)
		{
			var record = await this.ProjectGroupRepository.Get(id);

			if (record == null)
			{
				return null;
			}
			else
			{
				return this.BolProjectGroupMapper.MapBOToModel(this.DalProjectGroupMapper.MapEFToBO(record));
			}
		}

		public virtual async Task<CreateResponse<ApiProjectGroupResponseModel>> Create(
			ApiProjectGroupRequestModel model)
		{
			CreateResponse<ApiProjectGroupResponseModel> response = new CreateResponse<ApiProjectGroupResponseModel>(await this.ProjectGroupModelValidator.ValidateCreateAsync(model));
			if (response.Success)
			{
				var bo = this.BolProjectGroupMapper.MapModelToBO(default(string), model);
				var record = await this.ProjectGroupRepository.Create(this.DalProjectGroupMapper.MapBOToEF(bo));

				response.SetRecord(this.BolProjectGroupMapper.MapBOToModel(this.DalProjectGroupMapper.MapEFToBO(record)));
			}

			return response;
		}

		public virtual async Task<UpdateResponse<ApiProjectGroupResponseModel>> Update(
			string id,
			ApiProjectGroupRequestModel model)
		{
			var validationResult = await this.ProjectGroupModelValidator.ValidateUpdateAsync(id, model);

			if (validationResult.IsValid)
			{
				var bo = this.BolProjectGroupMapper.MapModelToBO(id, model);
				await this.ProjectGroupRepository.Update(this.DalProjectGroupMapper.MapBOToEF(bo));

				var record = await this.ProjectGroupRepository.Get(id);

				return new UpdateResponse<ApiProjectGroupResponseModel>(this.BolProjectGroupMapper.MapBOToModel(this.DalProjectGroupMapper.MapEFToBO(record)));
			}
			else
			{
				return new UpdateResponse<ApiProjectGroupResponseModel>(validationResult);
			}
		}

		public virtual async Task<ActionResponse> Delete(
			string id)
		{
			ActionResponse response = new ActionResponse(await this.ProjectGroupModelValidator.ValidateDeleteAsync(id));
			if (response.Success)
			{
				await this.ProjectGroupRepository.Delete(id);
			}

			return response;
		}

		public async Task<ApiProjectGroupResponseModel> ByName(string name)
		{
			ProjectGroup record = await this.ProjectGroupRepository.ByName(name);

			if (record == null)
			{
				return null;
			}
			else
			{
				return this.BolProjectGroupMapper.MapBOToModel(this.DalProjectGroupMapper.MapEFToBO(record));
			}
		}

		public async Task<List<ApiProjectGroupResponseModel>> ByDataVersion(byte[] dataVersion, int limit = 0, int offset = int.MaxValue)
		{
			List<ProjectGroup> records = await this.ProjectGroupRepository.ByDataVersion(dataVersion, limit, offset);

			return this.BolProjectGroupMapper.MapBOToModel(this.DalProjectGroupMapper.MapEFToBO(records));
		}
	}
}

/*<Codenesium>
    <Hash>03b15c2d820cf9105906c669aa724402</Hash>
</Codenesium>*/