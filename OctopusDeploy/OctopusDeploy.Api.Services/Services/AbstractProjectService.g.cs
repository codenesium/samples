using Codenesium.DataConversionExtensions.AspNetCore;
using System;
using System.Collections.Generic;
using Microsoft.Extensions.Logging;
using Microsoft.EntityFrameworkCore;
using System.Linq;
using System.Linq.Dynamic.Core;
using System.Linq.Expressions;
using System.Threading.Tasks;
using OctopusDeployNS.Api.Contracts;
using OctopusDeployNS.Api.DataAccess;

namespace OctopusDeployNS.Api.Services
{
        public abstract class AbstractProjectService: AbstractService
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
                        IDALProjectMapper dalProjectMapper

                        )
                        : base()

                {
                        this.projectRepository = projectRepository;
                        this.projectModelValidator = projectModelValidator;
                        this.bolProjectMapper = bolProjectMapper;
                        this.dalProjectMapper = dalProjectMapper;
                        this.logger = logger;
                }

                public virtual async Task<List<ApiProjectResponseModel>> All(int limit = 0, int offset = int.MaxValue, string orderClause = "")
                {
                        var records = await this.projectRepository.All(limit, offset, orderClause);

                        return this.bolProjectMapper.MapBOToModel(this.dalProjectMapper.MapEFToBO(records));
                }

                public virtual async Task<ApiProjectResponseModel> Get(string id)
                {
                        var record = await this.projectRepository.Get(id);

                        return this.bolProjectMapper.MapBOToModel(this.dalProjectMapper.MapEFToBO(record));
                }

                public virtual async Task<CreateResponse<ApiProjectResponseModel>> Create(
                        ApiProjectRequestModel model)
                {
                        CreateResponse<ApiProjectResponseModel> response = new CreateResponse<ApiProjectResponseModel>(await this.projectModelValidator.ValidateCreateAsync(model));
                        if (response.Success)
                        {
                                var bo = this.bolProjectMapper.MapModelToBO(default (string), model);
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

                public async Task<ApiProjectResponseModel> GetName(string name)
                {
                        Project record = await this.projectRepository.GetName(name);

                        return this.bolProjectMapper.MapBOToModel(this.dalProjectMapper.MapEFToBO(record));
                }
                public async Task<ApiProjectResponseModel> GetSlug(string slug)
                {
                        Project record = await this.projectRepository.GetSlug(slug);

                        return this.bolProjectMapper.MapBOToModel(this.dalProjectMapper.MapEFToBO(record));
                }
                public async Task<List<ApiProjectResponseModel>> GetDataVersion(byte[] dataVersion)
                {
                        List<Project> records = await this.projectRepository.GetDataVersion(dataVersion);

                        return this.bolProjectMapper.MapBOToModel(this.dalProjectMapper.MapEFToBO(records));
                }
                public async Task<List<ApiProjectResponseModel>> GetDiscreteChannelReleaseId(bool discreteChannelRelease, string id)
                {
                        List<Project> records = await this.projectRepository.GetDiscreteChannelReleaseId(discreteChannelRelease, id);

                        return this.bolProjectMapper.MapBOToModel(this.dalProjectMapper.MapEFToBO(records));
                }
        }
}

/*<Codenesium>
    <Hash>c9d295ba51370e1684bcbbbce2a543a3</Hash>
</Codenesium>*/