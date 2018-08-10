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
	public abstract class AbstractArtifactService : AbstractService
	{
		protected IArtifactRepository ArtifactRepository { get; private set; }

		protected IApiArtifactRequestModelValidator ArtifactModelValidator { get; private set; }

		protected IBOLArtifactMapper BolArtifactMapper { get; private set; }

		protected IDALArtifactMapper DalArtifactMapper { get; private set; }

		private ILogger logger;

		public AbstractArtifactService(
			ILogger logger,
			IArtifactRepository artifactRepository,
			IApiArtifactRequestModelValidator artifactModelValidator,
			IBOLArtifactMapper bolArtifactMapper,
			IDALArtifactMapper dalArtifactMapper)
			: base()
		{
			this.ArtifactRepository = artifactRepository;
			this.ArtifactModelValidator = artifactModelValidator;
			this.BolArtifactMapper = bolArtifactMapper;
			this.DalArtifactMapper = dalArtifactMapper;
			this.logger = logger;
		}

		public virtual async Task<List<ApiArtifactResponseModel>> All(int limit = 0, int offset = int.MaxValue)
		{
			var records = await this.ArtifactRepository.All(limit, offset);

			return this.BolArtifactMapper.MapBOToModel(this.DalArtifactMapper.MapEFToBO(records));
		}

		public virtual async Task<ApiArtifactResponseModel> Get(string id)
		{
			var record = await this.ArtifactRepository.Get(id);

			if (record == null)
			{
				return null;
			}
			else
			{
				return this.BolArtifactMapper.MapBOToModel(this.DalArtifactMapper.MapEFToBO(record));
			}
		}

		public virtual async Task<CreateResponse<ApiArtifactResponseModel>> Create(
			ApiArtifactRequestModel model)
		{
			CreateResponse<ApiArtifactResponseModel> response = new CreateResponse<ApiArtifactResponseModel>(await this.ArtifactModelValidator.ValidateCreateAsync(model));
			if (response.Success)
			{
				var bo = this.BolArtifactMapper.MapModelToBO(default(string), model);
				var record = await this.ArtifactRepository.Create(this.DalArtifactMapper.MapBOToEF(bo));

				response.SetRecord(this.BolArtifactMapper.MapBOToModel(this.DalArtifactMapper.MapEFToBO(record)));
			}

			return response;
		}

		public virtual async Task<UpdateResponse<ApiArtifactResponseModel>> Update(
			string id,
			ApiArtifactRequestModel model)
		{
			var validationResult = await this.ArtifactModelValidator.ValidateUpdateAsync(id, model);

			if (validationResult.IsValid)
			{
				var bo = this.BolArtifactMapper.MapModelToBO(id, model);
				await this.ArtifactRepository.Update(this.DalArtifactMapper.MapBOToEF(bo));

				var record = await this.ArtifactRepository.Get(id);

				return new UpdateResponse<ApiArtifactResponseModel>(this.BolArtifactMapper.MapBOToModel(this.DalArtifactMapper.MapEFToBO(record)));
			}
			else
			{
				return new UpdateResponse<ApiArtifactResponseModel>(validationResult);
			}
		}

		public virtual async Task<ActionResponse> Delete(
			string id)
		{
			ActionResponse response = new ActionResponse(await this.ArtifactModelValidator.ValidateDeleteAsync(id));
			if (response.Success)
			{
				await this.ArtifactRepository.Delete(id);
			}

			return response;
		}

		public async Task<List<ApiArtifactResponseModel>> ByTenantId(string tenantId)
		{
			List<Artifact> records = await this.ArtifactRepository.ByTenantId(tenantId);

			return this.BolArtifactMapper.MapBOToModel(this.DalArtifactMapper.MapEFToBO(records));
		}
	}
}

/*<Codenesium>
    <Hash>55735926e6b88d21ba488e7fe604f920</Hash>
</Codenesium>*/