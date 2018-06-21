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
                private IArtifactRepository artifactRepository;

                private IApiArtifactRequestModelValidator artifactModelValidator;

                private IBOLArtifactMapper bolArtifactMapper;

                private IDALArtifactMapper dalArtifactMapper;

                private ILogger logger;

                public AbstractArtifactService(
                        ILogger logger,
                        IArtifactRepository artifactRepository,
                        IApiArtifactRequestModelValidator artifactModelValidator,
                        IBOLArtifactMapper bolArtifactMapper,
                        IDALArtifactMapper dalArtifactMapper)
                        : base()
                {
                        this.artifactRepository = artifactRepository;
                        this.artifactModelValidator = artifactModelValidator;
                        this.bolArtifactMapper = bolArtifactMapper;
                        this.dalArtifactMapper = dalArtifactMapper;
                        this.logger = logger;
                }

                public virtual async Task<List<ApiArtifactResponseModel>> All(int limit = 0, int offset = int.MaxValue)
                {
                        var records = await this.artifactRepository.All(limit, offset);

                        return this.bolArtifactMapper.MapBOToModel(this.dalArtifactMapper.MapEFToBO(records));
                }

                public virtual async Task<ApiArtifactResponseModel> Get(string id)
                {
                        var record = await this.artifactRepository.Get(id);

                        if (record == null)
                        {
                                return null;
                        }
                        else
                        {
                                return this.bolArtifactMapper.MapBOToModel(this.dalArtifactMapper.MapEFToBO(record));
                        }
                }

                public virtual async Task<CreateResponse<ApiArtifactResponseModel>> Create(
                        ApiArtifactRequestModel model)
                {
                        CreateResponse<ApiArtifactResponseModel> response = new CreateResponse<ApiArtifactResponseModel>(await this.artifactModelValidator.ValidateCreateAsync(model));
                        if (response.Success)
                        {
                                var bo = this.bolArtifactMapper.MapModelToBO(default(string), model);
                                var record = await this.artifactRepository.Create(this.dalArtifactMapper.MapBOToEF(bo));

                                response.SetRecord(this.bolArtifactMapper.MapBOToModel(this.dalArtifactMapper.MapEFToBO(record)));
                        }

                        return response;
                }

                public virtual async Task<ActionResponse> Update(
                        string id,
                        ApiArtifactRequestModel model)
                {
                        ActionResponse response = new ActionResponse(await this.artifactModelValidator.ValidateUpdateAsync(id, model));
                        if (response.Success)
                        {
                                var bo = this.bolArtifactMapper.MapModelToBO(id, model);
                                await this.artifactRepository.Update(this.dalArtifactMapper.MapBOToEF(bo));
                        }

                        return response;
                }

                public virtual async Task<ActionResponse> Delete(
                        string id)
                {
                        ActionResponse response = new ActionResponse(await this.artifactModelValidator.ValidateDeleteAsync(id));
                        if (response.Success)
                        {
                                await this.artifactRepository.Delete(id);
                        }

                        return response;
                }

                public async Task<List<ApiArtifactResponseModel>> GetTenantId(string tenantId)
                {
                        List<Artifact> records = await this.artifactRepository.GetTenantId(tenantId);

                        return this.bolArtifactMapper.MapBOToModel(this.dalArtifactMapper.MapEFToBO(records));
                }
        }
}

/*<Codenesium>
    <Hash>3000080530d350fa66b63a0975e2497c</Hash>
</Codenesium>*/