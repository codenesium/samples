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
        public abstract class AbstractProjectGroupService: AbstractService
        {
                private IProjectGroupRepository projectGroupRepository;

                private IApiProjectGroupRequestModelValidator projectGroupModelValidator;

                private IBOLProjectGroupMapper bolProjectGroupMapper;

                private IDALProjectGroupMapper dalProjectGroupMapper;

                private ILogger logger;

                public AbstractProjectGroupService(
                        ILogger logger,
                        IProjectGroupRepository projectGroupRepository,
                        IApiProjectGroupRequestModelValidator projectGroupModelValidator,
                        IBOLProjectGroupMapper bolprojectGroupMapper,
                        IDALProjectGroupMapper dalprojectGroupMapper)
                        : base()

                {
                        this.projectGroupRepository = projectGroupRepository;
                        this.projectGroupModelValidator = projectGroupModelValidator;
                        this.bolProjectGroupMapper = bolprojectGroupMapper;
                        this.dalProjectGroupMapper = dalprojectGroupMapper;
                        this.logger = logger;
                }

                public virtual async Task<List<ApiProjectGroupResponseModel>> All(int skip = 0, int take = int.MaxValue, string orderClause = "")
                {
                        var records = await this.projectGroupRepository.All(skip, take, orderClause);

                        return this.bolProjectGroupMapper.MapBOToModel(this.dalProjectGroupMapper.MapEFToBO(records));
                }

                public virtual async Task<ApiProjectGroupResponseModel> Get(string id)
                {
                        var record = await this.projectGroupRepository.Get(id);

                        return this.bolProjectGroupMapper.MapBOToModel(this.dalProjectGroupMapper.MapEFToBO(record));
                }

                public virtual async Task<CreateResponse<ApiProjectGroupResponseModel>> Create(
                        ApiProjectGroupRequestModel model)
                {
                        CreateResponse<ApiProjectGroupResponseModel> response = new CreateResponse<ApiProjectGroupResponseModel>(await this.projectGroupModelValidator.ValidateCreateAsync(model));
                        if (response.Success)
                        {
                                var bo = this.bolProjectGroupMapper.MapModelToBO(default (string), model);
                                var record = await this.projectGroupRepository.Create(this.dalProjectGroupMapper.MapBOToEF(bo));

                                response.SetRecord(this.bolProjectGroupMapper.MapBOToModel(this.dalProjectGroupMapper.MapEFToBO(record)));
                        }

                        return response;
                }

                public virtual async Task<ActionResponse> Update(
                        string id,
                        ApiProjectGroupRequestModel model)
                {
                        ActionResponse response = new ActionResponse(await this.projectGroupModelValidator.ValidateUpdateAsync(id, model));

                        if (response.Success)
                        {
                                var bo = this.bolProjectGroupMapper.MapModelToBO(id, model);
                                await this.projectGroupRepository.Update(this.dalProjectGroupMapper.MapBOToEF(bo));
                        }

                        return response;
                }

                public virtual async Task<ActionResponse> Delete(
                        string id)
                {
                        ActionResponse response = new ActionResponse(await this.projectGroupModelValidator.ValidateDeleteAsync(id));

                        if (response.Success)
                        {
                                await this.projectGroupRepository.Delete(id);
                        }

                        return response;
                }

                public async Task<ApiProjectGroupResponseModel> GetName(string name)
                {
                        ProjectGroup record = await this.projectGroupRepository.GetName(name);

                        return this.bolProjectGroupMapper.MapBOToModel(this.dalProjectGroupMapper.MapEFToBO(record));
                }
                public async Task<List<ApiProjectGroupResponseModel>> GetDataVersion(byte[] dataVersion)
                {
                        List<ProjectGroup> records = await this.projectGroupRepository.GetDataVersion(dataVersion);

                        return this.bolProjectGroupMapper.MapBOToModel(this.dalProjectGroupMapper.MapEFToBO(records));
                }
        }
}

/*<Codenesium>
    <Hash>7aed96df7ee0e774f5731c6cc0acb19f</Hash>
</Codenesium>*/