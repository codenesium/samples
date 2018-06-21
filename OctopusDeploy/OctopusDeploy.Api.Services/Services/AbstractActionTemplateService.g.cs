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
        public abstract class AbstractActionTemplateService : AbstractService
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
                        IBOLActionTemplateMapper bolActionTemplateMapper,
                        IDALActionTemplateMapper dalActionTemplateMapper)
                        : base()
                {
                        this.actionTemplateRepository = actionTemplateRepository;
                        this.actionTemplateModelValidator = actionTemplateModelValidator;
                        this.bolActionTemplateMapper = bolActionTemplateMapper;
                        this.dalActionTemplateMapper = dalActionTemplateMapper;
                        this.logger = logger;
                }

                public virtual async Task<List<ApiActionTemplateResponseModel>> All(int limit = 0, int offset = int.MaxValue)
                {
                        var records = await this.actionTemplateRepository.All(limit, offset);

                        return this.bolActionTemplateMapper.MapBOToModel(this.dalActionTemplateMapper.MapEFToBO(records));
                }

                public virtual async Task<ApiActionTemplateResponseModel> Get(string id)
                {
                        var record = await this.actionTemplateRepository.Get(id);

                        if (record == null)
                        {
                                return null;
                        }
                        else
                        {
                                return this.bolActionTemplateMapper.MapBOToModel(this.dalActionTemplateMapper.MapEFToBO(record));
                        }
                }

                public virtual async Task<CreateResponse<ApiActionTemplateResponseModel>> Create(
                        ApiActionTemplateRequestModel model)
                {
                        CreateResponse<ApiActionTemplateResponseModel> response = new CreateResponse<ApiActionTemplateResponseModel>(await this.actionTemplateModelValidator.ValidateCreateAsync(model));
                        if (response.Success)
                        {
                                var bo = this.bolActionTemplateMapper.MapModelToBO(default(string), model);
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

                        if (record == null)
                        {
                                return null;
                        }
                        else
                        {
                                return this.bolActionTemplateMapper.MapBOToModel(this.dalActionTemplateMapper.MapEFToBO(record));
                        }
                }
        }
}

/*<Codenesium>
    <Hash>040af830c37d73e16fb3de6c3bded464</Hash>
</Codenesium>*/