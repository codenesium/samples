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
        public abstract class AbstractActionTemplateVersionService: AbstractService
        {
                private IActionTemplateVersionRepository actionTemplateVersionRepository;

                private IApiActionTemplateVersionRequestModelValidator actionTemplateVersionModelValidator;

                private IBOLActionTemplateVersionMapper bolActionTemplateVersionMapper;

                private IDALActionTemplateVersionMapper dalActionTemplateVersionMapper;

                private ILogger logger;

                public AbstractActionTemplateVersionService(
                        ILogger logger,
                        IActionTemplateVersionRepository actionTemplateVersionRepository,
                        IApiActionTemplateVersionRequestModelValidator actionTemplateVersionModelValidator,
                        IBOLActionTemplateVersionMapper bolactionTemplateVersionMapper,
                        IDALActionTemplateVersionMapper dalactionTemplateVersionMapper)
                        : base()

                {
                        this.actionTemplateVersionRepository = actionTemplateVersionRepository;
                        this.actionTemplateVersionModelValidator = actionTemplateVersionModelValidator;
                        this.bolActionTemplateVersionMapper = bolactionTemplateVersionMapper;
                        this.dalActionTemplateVersionMapper = dalactionTemplateVersionMapper;
                        this.logger = logger;
                }

                public virtual async Task<List<ApiActionTemplateVersionResponseModel>> All(int skip = 0, int take = int.MaxValue, string orderClause = "")
                {
                        var records = await this.actionTemplateVersionRepository.All(skip, take, orderClause);

                        return this.bolActionTemplateVersionMapper.MapBOToModel(this.dalActionTemplateVersionMapper.MapEFToBO(records));
                }

                public virtual async Task<ApiActionTemplateVersionResponseModel> Get(string id)
                {
                        var record = await this.actionTemplateVersionRepository.Get(id);

                        return this.bolActionTemplateVersionMapper.MapBOToModel(this.dalActionTemplateVersionMapper.MapEFToBO(record));
                }

                public virtual async Task<CreateResponse<ApiActionTemplateVersionResponseModel>> Create(
                        ApiActionTemplateVersionRequestModel model)
                {
                        CreateResponse<ApiActionTemplateVersionResponseModel> response = new CreateResponse<ApiActionTemplateVersionResponseModel>(await this.actionTemplateVersionModelValidator.ValidateCreateAsync(model));
                        if (response.Success)
                        {
                                var bo = this.bolActionTemplateVersionMapper.MapModelToBO(default (string), model);
                                var record = await this.actionTemplateVersionRepository.Create(this.dalActionTemplateVersionMapper.MapBOToEF(bo));

                                response.SetRecord(this.bolActionTemplateVersionMapper.MapBOToModel(this.dalActionTemplateVersionMapper.MapEFToBO(record)));
                        }

                        return response;
                }

                public virtual async Task<ActionResponse> Update(
                        string id,
                        ApiActionTemplateVersionRequestModel model)
                {
                        ActionResponse response = new ActionResponse(await this.actionTemplateVersionModelValidator.ValidateUpdateAsync(id, model));

                        if (response.Success)
                        {
                                var bo = this.bolActionTemplateVersionMapper.MapModelToBO(id, model);
                                await this.actionTemplateVersionRepository.Update(this.dalActionTemplateVersionMapper.MapBOToEF(bo));
                        }

                        return response;
                }

                public virtual async Task<ActionResponse> Delete(
                        string id)
                {
                        ActionResponse response = new ActionResponse(await this.actionTemplateVersionModelValidator.ValidateDeleteAsync(id));

                        if (response.Success)
                        {
                                await this.actionTemplateVersionRepository.Delete(id);
                        }

                        return response;
                }

                public async Task<ApiActionTemplateVersionResponseModel> GetNameVersion(string name, int version)
                {
                        ActionTemplateVersion record = await this.actionTemplateVersionRepository.GetNameVersion(name, version);

                        return this.bolActionTemplateVersionMapper.MapBOToModel(this.dalActionTemplateVersionMapper.MapEFToBO(record));
                }
                public async Task<List<ApiActionTemplateVersionResponseModel>> GetLatestActionTemplateId(string latestActionTemplateId)
                {
                        List<ActionTemplateVersion> records = await this.actionTemplateVersionRepository.GetLatestActionTemplateId(latestActionTemplateId);

                        return this.bolActionTemplateVersionMapper.MapBOToModel(this.dalActionTemplateVersionMapper.MapEFToBO(records));
                }
        }
}

/*<Codenesium>
    <Hash>43a746639cfaccc19c73f6bba2e8c88e</Hash>
</Codenesium>*/