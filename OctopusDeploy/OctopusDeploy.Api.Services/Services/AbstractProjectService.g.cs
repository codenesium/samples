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
                private IProjectRepository projectRepository;

                private IApiProjectRequestModelValidator projectModelValidator;

                private IBOLProjectMapper bolProjectMapper;

                private IDALProjectMapper dalProjectMapper;

                private ILogger logger;

                public AbstractProjectService(
                        ILogger logger,
                        IProjectRepository projectRepository,
                        IApiProjectRequestModelValidator projectModelValidator,
                        IBOLProjectMapper bolProjectMapper,
                        IDALProjectMapper dalProjectMapper)
                        : base()
                {
                        this.projectRepository = projectRepository;
                        this.projectModelValidator = projectModelValidator;
                        this.bolProjectMapper = bolProjectMapper;
                        this.dalProjectMapper = dalProjectMapper;
                        this.logger = logger;
                }

                public virtual async Task<List<ApiProjectResponseModel>> All(int limit = 0, int offset = int.MaxValue)
                {
                        var records = await this.projectRepository.All(limit, offset);

                        return this.bolProjectMapper.MapBOToModel(this.dalProjectMapper.MapEFToBO(records));
                }

                public virtual async Task<ApiProjectResponseModel> Get(string id)
                {
                        var record = await this.projectRepository.Get(id);

                        if (record == null)
                        {
                                return null;
                        }
                        else
                        {
                                return this.bolProjectMapper.MapBOToModel(this.dalProjectMapper.MapEFToBO(record));
                        }
                }

                public virtual async Task<CreateResponse<ApiProjectResponseModel>> Create(
                        ApiProjectRequestModel model)
                {
                        CreateResponse<ApiProjectResponseModel> response = new CreateResponse<ApiProjectResponseModel>(await this.projectModelValidator.ValidateCreateAsync(model));
                        if (response.Success)
                        {
                                var bo = this.bolProjectMapper.MapModelToBO(default(string), model);
                                var record = await this.projectRepository.Create(this.dalProjectMapper.MapBOToEF(bo));

                                response.SetRecord(this.bolProjectMapper.MapBOToModel(this.dalProjectMapper.MapEFToBO(record)));
                        }

                        return response;
                }

                public virtual async Task<ActionResponse> Update(
                        string id,
                        ApiProjectRequestModel model)
                {
                        ActionResponse response = new ActionResponse(await this.projectModelValidator.ValidateUpdateAsync(id, model));
                        if (response.Success)
                        {
                                var bo = this.bolProjectMapper.MapModelToBO(id, model);
                                await this.projectRepository.Update(this.dalProjectMapper.MapBOToEF(bo));
                        }

                        return response;
                }

                public virtual async Task<ActionResponse> Delete(
                        string id)
                {
                        ActionResponse response = new ActionResponse(await this.projectModelValidator.ValidateDeleteAsync(id));
                        if (response.Success)
                        {
                                await this.projectRepository.Delete(id);
                        }

                        return response;
                }

                public async Task<ApiProjectResponseModel> ByName(string name)
                {
                        Project record = await this.projectRepository.ByName(name);

                        if (record == null)
                        {
                                return null;
                        }
                        else
                        {
                                return this.bolProjectMapper.MapBOToModel(this.dalProjectMapper.MapEFToBO(record));
                        }
                }

                public async Task<ApiProjectResponseModel> BySlug(string slug)
                {
                        Project record = await this.projectRepository.BySlug(slug);

                        if (record == null)
                        {
                                return null;
                        }
                        else
                        {
                                return this.bolProjectMapper.MapBOToModel(this.dalProjectMapper.MapEFToBO(record));
                        }
                }

                public async Task<List<ApiProjectResponseModel>> ByDataVersion(byte[] dataVersion)
                {
                        List<Project> records = await this.projectRepository.ByDataVersion(dataVersion);

                        return this.bolProjectMapper.MapBOToModel(this.dalProjectMapper.MapEFToBO(records));
                }

                public async Task<List<ApiProjectResponseModel>> ByDiscreteChannelReleaseId(bool discreteChannelRelease, string id)
                {
                        List<Project> records = await this.projectRepository.ByDiscreteChannelReleaseId(discreteChannelRelease, id);

                        return this.bolProjectMapper.MapBOToModel(this.dalProjectMapper.MapEFToBO(records));
                }
        }
}

/*<Codenesium>
    <Hash>d8beae93396e11c748ccf315c9b06ec4</Hash>
</Codenesium>*/