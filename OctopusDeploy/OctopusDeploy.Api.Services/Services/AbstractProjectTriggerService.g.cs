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
        public abstract class AbstractProjectTriggerService: AbstractService
        {
                private IProjectTriggerRepository projectTriggerRepository;

                private IApiProjectTriggerRequestModelValidator projectTriggerModelValidator;

                private IBOLProjectTriggerMapper bolProjectTriggerMapper;

                private IDALProjectTriggerMapper dalProjectTriggerMapper;

                private ILogger logger;

                public AbstractProjectTriggerService(
                        ILogger logger,
                        IProjectTriggerRepository projectTriggerRepository,
                        IApiProjectTriggerRequestModelValidator projectTriggerModelValidator,
                        IBOLProjectTriggerMapper bolProjectTriggerMapper,
                        IDALProjectTriggerMapper dalProjectTriggerMapper

                        )
                        : base()

                {
                        this.projectTriggerRepository = projectTriggerRepository;
                        this.projectTriggerModelValidator = projectTriggerModelValidator;
                        this.bolProjectTriggerMapper = bolProjectTriggerMapper;
                        this.dalProjectTriggerMapper = dalProjectTriggerMapper;
                        this.logger = logger;
                }

                public virtual async Task<List<ApiProjectTriggerResponseModel>> All(int limit = 0, int offset = int.MaxValue, string orderClause = "")
                {
                        var records = await this.projectTriggerRepository.All(limit, offset, orderClause);

                        return this.bolProjectTriggerMapper.MapBOToModel(this.dalProjectTriggerMapper.MapEFToBO(records));
                }

                public virtual async Task<ApiProjectTriggerResponseModel> Get(string id)
                {
                        var record = await this.projectTriggerRepository.Get(id);

                        return this.bolProjectTriggerMapper.MapBOToModel(this.dalProjectTriggerMapper.MapEFToBO(record));
                }

                public virtual async Task<CreateResponse<ApiProjectTriggerResponseModel>> Create(
                        ApiProjectTriggerRequestModel model)
                {
                        CreateResponse<ApiProjectTriggerResponseModel> response = new CreateResponse<ApiProjectTriggerResponseModel>(await this.projectTriggerModelValidator.ValidateCreateAsync(model));
                        if (response.Success)
                        {
                                var bo = this.bolProjectTriggerMapper.MapModelToBO(default (string), model);
                                var record = await this.projectTriggerRepository.Create(this.dalProjectTriggerMapper.MapBOToEF(bo));

                                response.SetRecord(this.bolProjectTriggerMapper.MapBOToModel(this.dalProjectTriggerMapper.MapEFToBO(record)));
                        }

                        return response;
                }

                public virtual async Task<ActionResponse> Update(
                        string id,
                        ApiProjectTriggerRequestModel model)
                {
                        ActionResponse response = new ActionResponse(await this.projectTriggerModelValidator.ValidateUpdateAsync(id, model));

                        if (response.Success)
                        {
                                var bo = this.bolProjectTriggerMapper.MapModelToBO(id, model);
                                await this.projectTriggerRepository.Update(this.dalProjectTriggerMapper.MapBOToEF(bo));
                        }

                        return response;
                }

                public virtual async Task<ActionResponse> Delete(
                        string id)
                {
                        ActionResponse response = new ActionResponse(await this.projectTriggerModelValidator.ValidateDeleteAsync(id));

                        if (response.Success)
                        {
                                await this.projectTriggerRepository.Delete(id);
                        }

                        return response;
                }

                public async Task<ApiProjectTriggerResponseModel> GetProjectIdName(string projectId, string name)
                {
                        ProjectTrigger record = await this.projectTriggerRepository.GetProjectIdName(projectId, name);

                        return this.bolProjectTriggerMapper.MapBOToModel(this.dalProjectTriggerMapper.MapEFToBO(record));
                }
                public async Task<List<ApiProjectTriggerResponseModel>> GetProjectId(string projectId)
                {
                        List<ProjectTrigger> records = await this.projectTriggerRepository.GetProjectId(projectId);

                        return this.bolProjectTriggerMapper.MapBOToModel(this.dalProjectTriggerMapper.MapEFToBO(records));
                }
        }
}

/*<Codenesium>
    <Hash>56fe13629a9342d01d1fdaf3352a674a</Hash>
</Codenesium>*/