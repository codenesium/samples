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
        public abstract class AbstractActionTemplateService: AbstractService
        {
                private IActionTemplateRepository actionTemplateRepository;

                private IApiActionTemplateRequestModelValidator actionTemplateModelValidator;

                private IBOLActionTemplateMapper bolActionTemplateMapper;

                private IDALActionTemplateMapper dalActionTemplateMapper;

                private ILogger logger;

                public AbstractActionTemplateService(
                        ILogger logger,
                        IActionTemplateRepository actionTemplateRepository,
                        IApiActionTemplateRequestModelValidator actionTemplateModelValidator,
                        IBOLActionTemplateMapper bolactionTemplateMapper,
                        IDALActionTemplateMapper dalactionTemplateMapper)
                        : base()

                {
                        this.actionTemplateRepository = actionTemplateRepository;
                        this.actionTemplateModelValidator = actionTemplateModelValidator;
                        this.bolActionTemplateMapper = bolactionTemplateMapper;
                        this.dalActionTemplateMapper = dalactionTemplateMapper;
                        this.logger = logger;
                }

                public virtual async Task<List<ApiActionTemplateResponseModel>> All(int skip = 0, int take = int.MaxValue, string orderClause = "")
                {
                        var records = await this.actionTemplateRepository.All(skip, take, orderClause);

                        return this.bolActionTemplateMapper.MapBOToModel(this.dalActionTemplateMapper.MapEFToBO(records));
                }

                public virtual async Task<ApiActionTemplateResponseModel> Get(string id)
                {
                        var record = await this.actionTemplateRepository.Get(id);

                        return this.bolActionTemplateMapper.MapBOToModel(this.dalActionTemplateMapper.MapEFToBO(record));
                }

                public virtual async Task<CreateResponse<ApiActionTemplateResponseModel>> Create(
                        ApiActionTemplateRequestModel model)
                {
                        CreateResponse<ApiActionTemplateResponseModel> response = new CreateResponse<ApiActionTemplateResponseModel>(await this.actionTemplateModelValidator.ValidateCreateAsync(model));
                        if (response.Success)
                        {
                                var bo = this.bolActionTemplateMapper.MapModelToBO(default (string), model);
                                var record = await this.actionTemplateRepository.Create(this.dalActionTemplateMapper.MapBOToEF(bo));

                                response.SetRecord(this.bolActionTemplateMapper.MapBOToModel(this.dalActionTemplateMapper.MapEFToBO(record)));
                        }

                        return response;
                }

                public virtual async Task<ActionResponse> Update(
                        string id,
                        ApiActionTemplateRequestModel model)
                {
                        ActionResponse response = new ActionResponse(await this.actionTemplateModelValidator.ValidateUpdateAsync(id, model));

                        if (response.Success)
                        {
                                var bo = this.bolActionTemplateMapper.MapModelToBO(id, model);
                                await this.actionTemplateRepository.Update(this.dalActionTemplateMapper.MapBOToEF(bo));
                        }

                        return response;
                }

                public virtual async Task<ActionResponse> Delete(
                        string id)
                {
                        ActionResponse response = new ActionResponse(await this.actionTemplateModelValidator.ValidateDeleteAsync(id));

                        if (response.Success)
                        {
                                await this.actionTemplateRepository.Delete(id);
                        }

                        return response;
                }

                public async Task<ApiActionTemplateResponseModel> GetName(string name)
                {
                        ActionTemplate record = await this.actionTemplateRepository.GetName(name);

                        return this.bolActionTemplateMapper.MapBOToModel(this.dalActionTemplateMapper.MapEFToBO(record));
                }
        }
}

/*<Codenesium>
    <Hash>da0e3a12ec0520f31c504bd1ef3da19c</Hash>
</Codenesium>*/