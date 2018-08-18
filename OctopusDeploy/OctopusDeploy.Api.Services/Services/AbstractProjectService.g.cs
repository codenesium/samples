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
	public abstract class AbstractProjectService : AbstractService
	{
		protected IProjectRepository ProjectRepository { get; private set; }

		protected IApiProjectRequestModelValidator ProjectModelValidator { get; private set; }

		protected IBOLProjectMapper BolProjectMapper { get; private set; }

		protected IDALProjectMapper DalProjectMapper { get; private set; }

		private ILogger logger;

		public AbstractProjectService(
			ILogger logger,
			IProjectRepository projectRepository,
			IApiProjectRequestModelValidator projectModelValidator,
			IBOLProjectMapper bolProjectMapper,
			IDALProjectMapper dalProjectMapper)
			: base()
		{
			this.ProjectRepository = projectRepository;
			this.ProjectModelValidator = projectModelValidator;
			this.BolProjectMapper = bolProjectMapper;
			this.DalProjectMapper = dalProjectMapper;
			this.logger = logger;
		}

		public virtual async Task<List<ApiProjectResponseModel>> All(int limit = 0, int offset = int.MaxValue)
		{
			var records = await this.ProjectRepository.All(limit, offset);

			return this.BolProjectMapper.MapBOToModel(this.DalProjectMapper.MapEFToBO(records));
		}

		public virtual async Task<ApiProjectResponseModel> Get(string id)
		{
			var record = await this.ProjectRepository.Get(id);

			if (record == null)
			{
				return null;
			}
			else
			{
				return this.BolProjectMapper.MapBOToModel(this.DalProjectMapper.MapEFToBO(record));
			}
		}

		public virtual async Task<CreateResponse<ApiProjectResponseModel>> Create(
			ApiProjectRequestModel model)
		{
			CreateResponse<ApiProjectResponseModel> response = new CreateResponse<ApiProjectResponseModel>(await this.ProjectModelValidator.ValidateCreateAsync(model));
			if (response.Success)
			{
				var bo = this.BolProjectMapper.MapModelToBO(default(string), model);
				var record = await this.ProjectRepository.Create(this.DalProjectMapper.MapBOToEF(bo));

				response.SetRecord(this.BolProjectMapper.MapBOToModel(this.DalProjectMapper.MapEFToBO(record)));
			}

			return response;
		}

		public virtual async Task<UpdateResponse<ApiProjectResponseModel>> Update(
			string id,
			ApiProjectRequestModel model)
		{
			var validationResult = await this.ProjectModelValidator.ValidateUpdateAsync(id, model);

			if (validationResult.IsValid)
			{
				var bo = this.BolProjectMapper.MapModelToBO(id, model);
				await this.ProjectRepository.Update(this.DalProjectMapper.MapBOToEF(bo));

				var record = await this.ProjectRepository.Get(id);

				return new UpdateResponse<ApiProjectResponseModel>(this.BolProjectMapper.MapBOToModel(this.DalProjectMapper.MapEFToBO(record)));
			}
			else
			{
				return new UpdateResponse<ApiProjectResponseModel>(validationResult);
			}
		}

		public virtual async Task<ActionResponse> Delete(
			string id)
		{
			ActionResponse response = new ActionResponse(await this.ProjectModelValidator.ValidateDeleteAsync(id));
			if (response.Success)
			{
				await this.ProjectRepository.Delete(id);
			}

			return response;
		}

		public async Task<ApiProjectResponseModel> ByName(string name)
		{
			Project record = await this.ProjectRepository.ByName(name);

			if (record == null)
			{
				return null;
			}
			else
			{
				return this.BolProjectMapper.MapBOToModel(this.DalProjectMapper.MapEFToBO(record));
			}
		}

		public async Task<ApiProjectResponseModel> BySlug(string slug)
		{
			Project record = await this.ProjectRepository.BySlug(slug);

			if (record == null)
			{
				return null;
			}
			else
			{
				return this.BolProjectMapper.MapBOToModel(this.DalProjectMapper.MapEFToBO(record));
			}
		}

		public async Task<List<ApiProjectResponseModel>> ByDataVersion(byte[] dataVersion, int limit = 0, int offset = int.MaxValue)
		{
			List<Project> records = await this.ProjectRepository.ByDataVersion(dataVersion, limit, offset);

			return this.BolProjectMapper.MapBOToModel(this.DalProjectMapper.MapEFToBO(records));
		}

		public async Task<List<ApiProjectResponseModel>> ByDiscreteChannelReleaseId(bool discreteChannelRelease, string id, int limit = 0, int offset = int.MaxValue)
		{
			List<Project> records = await this.ProjectRepository.ByDiscreteChannelReleaseId(discreteChannelRelease, id, limit, offset);

			return this.BolProjectMapper.MapBOToModel(this.DalProjectMapper.MapEFToBO(records));
		}
	}
}

/*<Codenesium>
    <Hash>8a2aaaa8411d954c7570998577dec47a</Hash>
</Codenesium>*/