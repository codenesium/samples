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
        public abstract class AbstractKeyAllocationService: AbstractService
        {
                private IKeyAllocationRepository keyAllocationRepository;

                private IApiKeyAllocationRequestModelValidator keyAllocationModelValidator;

                private IBOLKeyAllocationMapper bolKeyAllocationMapper;

                private IDALKeyAllocationMapper dalKeyAllocationMapper;

                private ILogger logger;

                public AbstractKeyAllocationService(
                        ILogger logger,
                        IKeyAllocationRepository keyAllocationRepository,
                        IApiKeyAllocationRequestModelValidator keyAllocationModelValidator,
                        IBOLKeyAllocationMapper bolkeyAllocationMapper,
                        IDALKeyAllocationMapper dalkeyAllocationMapper)
                        : base()

                {
                        this.keyAllocationRepository = keyAllocationRepository;
                        this.keyAllocationModelValidator = keyAllocationModelValidator;
                        this.bolKeyAllocationMapper = bolkeyAllocationMapper;
                        this.dalKeyAllocationMapper = dalkeyAllocationMapper;
                        this.logger = logger;
                }

                public virtual async Task<List<ApiKeyAllocationResponseModel>> All(int skip = 0, int take = int.MaxValue, string orderClause = "")
                {
                        var records = await this.keyAllocationRepository.All(skip, take, orderClause);

                        return this.bolKeyAllocationMapper.MapBOToModel(this.dalKeyAllocationMapper.MapEFToBO(records));
                }

                public virtual async Task<ApiKeyAllocationResponseModel> Get(string collectionName)
                {
                        var record = await this.keyAllocationRepository.Get(collectionName);

                        return this.bolKeyAllocationMapper.MapBOToModel(this.dalKeyAllocationMapper.MapEFToBO(record));
                }

                public virtual async Task<CreateResponse<ApiKeyAllocationResponseModel>> Create(
                        ApiKeyAllocationRequestModel model)
                {
                        CreateResponse<ApiKeyAllocationResponseModel> response = new CreateResponse<ApiKeyAllocationResponseModel>(await this.keyAllocationModelValidator.ValidateCreateAsync(model));
                        if (response.Success)
                        {
                                var bo = this.bolKeyAllocationMapper.MapModelToBO(default (string), model);
                                var record = await this.keyAllocationRepository.Create(this.dalKeyAllocationMapper.MapBOToEF(bo));

                                response.SetRecord(this.bolKeyAllocationMapper.MapBOToModel(this.dalKeyAllocationMapper.MapEFToBO(record)));
                        }

                        return response;
                }

                public virtual async Task<ActionResponse> Update(
                        string collectionName,
                        ApiKeyAllocationRequestModel model)
                {
                        ActionResponse response = new ActionResponse(await this.keyAllocationModelValidator.ValidateUpdateAsync(collectionName, model));

                        if (response.Success)
                        {
                                var bo = this.bolKeyAllocationMapper.MapModelToBO(collectionName, model);
                                await this.keyAllocationRepository.Update(this.dalKeyAllocationMapper.MapBOToEF(bo));
                        }

                        return response;
                }

                public virtual async Task<ActionResponse> Delete(
                        string collectionName)
                {
                        ActionResponse response = new ActionResponse(await this.keyAllocationModelValidator.ValidateDeleteAsync(collectionName));

                        if (response.Success)
                        {
                                await this.keyAllocationRepository.Delete(collectionName);
                        }

                        return response;
                }
        }
}

/*<Codenesium>
    <Hash>972388c753c9004b5e7308fe7fd5fefb</Hash>
</Codenesium>*/