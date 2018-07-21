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
                private IProjectGroupRepository projectGroupRepository;

                private IApiProjectGroupRequestModelValidator projectGroupModelValidator;

                private IBOLProjectGroupMapper bolProjectGroupMapper;

                private IDALProjectGroupMapper dalProjectGroupMapper;

                private ILogger logger;

                public AbstractProjectGroupService(
                        ILogger logger,
                        IProjectGroupRepository projectGroupRepository,
                        IApiProjectGroupRequestModelValidator projectGroupModelValidator,
                        IBOLProjectGroupMapper bolProjectGroupMapper,
                        IDALProjectGroupMapper dalProjectGroupMapper)
                        : base()
                {
                        this.projectGroupRepository = projectGroupRepository;
                        this.projectGroupModelValidator = projectGroupModelValidator;
                        this.bolProjectGroupMapper = bolProjectGroupMapper;
                        this.dalProjectGroupMapper = dalProjectGroupMapper;
                        this.logger = logger;
                }

                public virtual async Task<List<ApiProjectGroupResponseModel>> All(int limit = 0, int offset = int.MaxValue)
                {
                        var records = await this.projectGroupRepository.All(limit, offset);

                        return this.bolProjectGroupMapper.MapBOToModel(this.dalProjectGroupMapper.MapEFToBO(records));
                }

                public virtual async Task<ApiProjectGroupResponseModel> Get(string id)
                {
                        var record = await this.projectGroupRepository.Get(id);

                        if (record == null)
                        {
                                return null;
                        }
                        else
                        {
                                return this.bolProjectGroupMapper.MapBOToModel(this.dalProjectGroupMapper.MapEFToBO(record));
                        }
                }

                public virtual async Task<CreateResponse<ApiProjectGroupResponseModel>> Create(
                        ApiProjectGroupRequestModel model)
                {
                        CreateResponse<ApiProjectGroupResponseModel> response = new CreateResponse<ApiProjectGroupResponseModel>(await this.projectGroupModelValidator.ValidateCreateAsync(model));
                        if (response.Success)
                        {
                                var bo = this.bolProjectGroupMapper.MapModelToBO(default(string), model);
                                var record = await this.projectGroupRepository.Create(this.dalProjectGroupMapper.MapBOToEF(bo));

                                response.SetRecord(this.bolProjectGroupMapper.MapBOToModel(this.dalProjectGroupMapper.MapEFToBO(record)));
                        }

                        return response;
                }

                public virtual async Task<UpdateResponse<ApiProjectGroupResponseModel>> Update(
                        string id,
                        ApiProjectGroupRequestModel model)
                {
                        var validationResult = await this.projectGroupModelValidator.ValidateUpdateAsync(id, model);

                        if (validationResult.IsValid)
                        {
                                var bo = this.bolProjectGroupMapper.MapModelToBO(id, model);
                                await this.projectGroupRepository.Update(this.dalProjectGroupMapper.MapBOToEF(bo));

                                var record = await this.projectGroupRepository.Get(id);

                                return new UpdateResponse<ApiProjectGroupResponseModel>(this.bolProjectGroupMapper.MapBOToModel(this.dalProjectGroupMapper.MapEFToBO(record)));
                        }
                        else
                        {
                                return new UpdateResponse<ApiProjectGroupResponseModel>(validationResult);
                        }
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

                public async Task<ApiProjectGroupResponseModel> ByName(string name)
                {
                        ProjectGroup record = await this.projectGroupRepository.ByName(name);

                        if (record == null)
                        {
                                return null;
                        }
                        else
                        {
                                return this.bolProjectGroupMapper.MapBOToModel(this.dalProjectGroupMapper.MapEFToBO(record));
                        }
                }

                public async Task<List<ApiProjectGroupResponseModel>> ByDataVersion(byte[] dataVersion)
                {
                        List<ProjectGroup> records = await this.projectGroupRepository.ByDataVersion(dataVersion);

                        return this.bolProjectGroupMapper.MapBOToModel(this.dalProjectGroupMapper.MapEFToBO(records));
                }
        }
}

/*<Codenesium>
    <Hash>2af48211f07cc262b140f476388e1091</Hash>
</Codenesium>*/