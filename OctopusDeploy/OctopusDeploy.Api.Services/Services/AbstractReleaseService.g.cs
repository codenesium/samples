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
	public abstract class AbstractReleaseService : AbstractService
	{
		protected IReleaseRepository ReleaseRepository { get; private set; }

		protected IApiReleaseRequestModelValidator ReleaseModelValidator { get; private set; }

		protected IBOLReleaseMapper BolReleaseMapper { get; private set; }

		protected IDALReleaseMapper DalReleaseMapper { get; private set; }

		private ILogger logger;

		public AbstractReleaseService(
			ILogger logger,
			IReleaseRepository releaseRepository,
			IApiReleaseRequestModelValidator releaseModelValidator,
			IBOLReleaseMapper bolReleaseMapper,
			IDALReleaseMapper dalReleaseMapper)
			: base()
		{
			this.ReleaseRepository = releaseRepository;
			this.ReleaseModelValidator = releaseModelValidator;
			this.BolReleaseMapper = bolReleaseMapper;
			this.DalReleaseMapper = dalReleaseMapper;
			this.logger = logger;
		}

		public virtual async Task<List<ApiReleaseResponseModel>> All(int limit = 0, int offset = int.MaxValue)
		{
			var records = await this.ReleaseRepository.All(limit, offset);

			return this.BolReleaseMapper.MapBOToModel(this.DalReleaseMapper.MapEFToBO(records));
		}

		public virtual async Task<ApiReleaseResponseModel> Get(string id)
		{
			var record = await this.ReleaseRepository.Get(id);

			if (record == null)
			{
				return null;
			}
			else
			{
				return this.BolReleaseMapper.MapBOToModel(this.DalReleaseMapper.MapEFToBO(record));
			}
		}

		public virtual async Task<CreateResponse<ApiReleaseResponseModel>> Create(
			ApiReleaseRequestModel model)
		{
			CreateResponse<ApiReleaseResponseModel> response = new CreateResponse<ApiReleaseResponseModel>(await this.ReleaseModelValidator.ValidateCreateAsync(model));
			if (response.Success)
			{
				var bo = this.BolReleaseMapper.MapModelToBO(default(string), model);
				var record = await this.ReleaseRepository.Create(this.DalReleaseMapper.MapBOToEF(bo));

				response.SetRecord(this.BolReleaseMapper.MapBOToModel(this.DalReleaseMapper.MapEFToBO(record)));
			}

			return response;
		}

		public virtual async Task<UpdateResponse<ApiReleaseResponseModel>> Update(
			string id,
			ApiReleaseRequestModel model)
		{
			var validationResult = await this.ReleaseModelValidator.ValidateUpdateAsync(id, model);

			if (validationResult.IsValid)
			{
				var bo = this.BolReleaseMapper.MapModelToBO(id, model);
				await this.ReleaseRepository.Update(this.DalReleaseMapper.MapBOToEF(bo));

				var record = await this.ReleaseRepository.Get(id);

				return new UpdateResponse<ApiReleaseResponseModel>(this.BolReleaseMapper.MapBOToModel(this.DalReleaseMapper.MapEFToBO(record)));
			}
			else
			{
				return new UpdateResponse<ApiReleaseResponseModel>(validationResult);
			}
		}

		public virtual async Task<ActionResponse> Delete(
			string id)
		{
			ActionResponse response = new ActionResponse(await this.ReleaseModelValidator.ValidateDeleteAsync(id));
			if (response.Success)
			{
				await this.ReleaseRepository.Delete(id);
			}

			return response;
		}

		public async Task<ApiReleaseResponseModel> ByVersionProjectId(string version, string projectId)
		{
			Release record = await this.ReleaseRepository.ByVersionProjectId(version, projectId);

			if (record == null)
			{
				return null;
			}
			else
			{
				return this.BolReleaseMapper.MapBOToModel(this.DalReleaseMapper.MapEFToBO(record));
			}
		}

		public async Task<List<ApiReleaseResponseModel>> ByIdAssembled(string id, DateTimeOffset assembled)
		{
			List<Release> records = await this.ReleaseRepository.ByIdAssembled(id, assembled);

			return this.BolReleaseMapper.MapBOToModel(this.DalReleaseMapper.MapEFToBO(records));
		}

		public async Task<List<ApiReleaseResponseModel>> ByProjectDeploymentProcessSnapshotId(string projectDeploymentProcessSnapshotId)
		{
			List<Release> records = await this.ReleaseRepository.ByProjectDeploymentProcessSnapshotId(projectDeploymentProcessSnapshotId);

			return this.BolReleaseMapper.MapBOToModel(this.DalReleaseMapper.MapEFToBO(records));
		}

		public async Task<List<ApiReleaseResponseModel>> ByIdVersionProjectVariableSetSnapshotIdProjectDeploymentProcessSnapshotIdJSONProjectIdChannelIdAssembled(string id, string version, string projectVariableSetSnapshotId, string projectDeploymentProcessSnapshotId, string jSON, string projectId, string channelId, DateTimeOffset assembled)
		{
			List<Release> records = await this.ReleaseRepository.ByIdVersionProjectVariableSetSnapshotIdProjectDeploymentProcessSnapshotIdJSONProjectIdChannelIdAssembled(id, version, projectVariableSetSnapshotId, projectDeploymentProcessSnapshotId, jSON, projectId, channelId, assembled);

			return this.BolReleaseMapper.MapBOToModel(this.DalReleaseMapper.MapEFToBO(records));
		}

		public async Task<List<ApiReleaseResponseModel>> ByIdChannelIdProjectVariableSetSnapshotIdProjectDeploymentProcessSnapshotIdJSONProjectIdVersionAssembled(string id, string channelId, string projectVariableSetSnapshotId, string projectDeploymentProcessSnapshotId, string jSON, string projectId, string version, DateTimeOffset assembled)
		{
			List<Release> records = await this.ReleaseRepository.ByIdChannelIdProjectVariableSetSnapshotIdProjectDeploymentProcessSnapshotIdJSONProjectIdVersionAssembled(id, channelId, projectVariableSetSnapshotId, projectDeploymentProcessSnapshotId, jSON, projectId, version, assembled);

			return this.BolReleaseMapper.MapBOToModel(this.DalReleaseMapper.MapEFToBO(records));
		}
	}
}

/*<Codenesium>
    <Hash>c677532cead618757cce0d39a9681109</Hash>
</Codenesium>*/