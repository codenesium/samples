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
        public abstract class AbstractApiKeyService: AbstractService
        {
                private IApiKeyRepository apiKeyRepository;

                private IApiApiKeyRequestModelValidator apiKeyModelValidator;

                private IBOLApiKeyMapper bolApiKeyMapper;

                private IDALApiKeyMapper dalApiKeyMapper;

                private ILogger logger;

                public AbstractApiKeyService(
                        ILogger logger,
                        IApiKeyRepository apiKeyRepository,
                        IApiApiKeyRequestModelValidator apiKeyModelValidator,
                        IBOLApiKeyMapper bolApiKeyMapper,
                        IDALApiKeyMapper dalApiKeyMapper

                        )
                        : base()

                {
                        this.apiKeyRepository = apiKeyRepository;
                        this.apiKeyModelValidator = apiKeyModelValidator;
                        this.bolApiKeyMapper = bolApiKeyMapper;
                        this.dalApiKeyMapper = dalApiKeyMapper;
                        this.logger = logger;
                }

                public virtual async Task<List<ApiApiKeyResponseModel>> All(int limit = 0, int offset = int.MaxValue, string orderClause = "")
                {
                        var records = await this.apiKeyRepository.All(limit, offset, orderClause);

                        return this.bolApiKeyMapper.MapBOToModel(this.dalApiKeyMapper.MapEFToBO(records));
                }

                public virtual async Task<ApiApiKeyResponseModel> Get(string id)
                {
                        var record = await this.apiKeyRepository.Get(id);

                        return this.bolApiKeyMapper.MapBOToModel(this.dalApiKeyMapper.MapEFToBO(record));
                }

                public virtual async Task<CreateResponse<ApiApiKeyResponseModel>> Create(
                        ApiApiKeyRequestModel model)
                {
                        CreateResponse<ApiApiKeyResponseModel> response = new CreateResponse<ApiApiKeyResponseModel>(await this.apiKeyModelValidator.ValidateCreateAsync(model));
                        if (response.Success)
                        {
                                var bo = this.bolApiKeyMapper.MapModelToBO(default (string), model);
                                var record = await this.apiKeyRepository.Create(this.dalApiKeyMapper.MapBOToEF(bo));

                                response.SetRecord(this.bolApiKeyMapper.MapBOToModel(this.dalApiKeyMapper.MapEFToBO(record)));
                        }

                        return response;
                }

                public virtual async Task<ActionResponse> Update(
                        string id,
                        ApiApiKeyRequestModel model)
                {
                        ActionResponse response = new ActionResponse(await this.apiKeyModelValidator.ValidateUpdateAsync(id, model));

                        if (response.Success)
                        {
                                var bo = this.bolApiKeyMapper.MapModelToBO(id, model);
                                await this.apiKeyRepository.Update(this.dalApiKeyMapper.MapBOToEF(bo));
                        }

                        return response;
                }

                public virtual async Task<ActionResponse> Delete(
                        string id)
                {
                        ActionResponse response = new ActionResponse(await this.apiKeyModelValidator.ValidateDeleteAsync(id));

                        if (response.Success)
                        {
                                await this.apiKeyRepository.Delete(id);
                        }

                        return response;
                }

                public async Task<ApiApiKeyResponseModel> GetApiKeyHashed(string apiKeyHashed)
                {
                        ApiKey record = await this.apiKeyRepository.GetApiKeyHashed(apiKeyHashed);

                        return this.bolApiKeyMapper.MapBOToModel(this.dalApiKeyMapper.MapEFToBO(record));
                }
        }
}

/*<Codenesium>
    <Hash>e0daa46a608d3edb225a9f874351b7e3</Hash>
</Codenesium>*/