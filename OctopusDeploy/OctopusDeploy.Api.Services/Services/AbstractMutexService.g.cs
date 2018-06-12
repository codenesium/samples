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
        public abstract class AbstractMutexService: AbstractService
        {
                private IMutexRepository mutexRepository;

                private IApiMutexRequestModelValidator mutexModelValidator;

                private IBOLMutexMapper bolMutexMapper;

                private IDALMutexMapper dalMutexMapper;

                private ILogger logger;

                public AbstractMutexService(
                        ILogger logger,
                        IMutexRepository mutexRepository,
                        IApiMutexRequestModelValidator mutexModelValidator,
                        IBOLMutexMapper bolmutexMapper,
                        IDALMutexMapper dalmutexMapper)
                        : base()

                {
                        this.mutexRepository = mutexRepository;
                        this.mutexModelValidator = mutexModelValidator;
                        this.bolMutexMapper = bolmutexMapper;
                        this.dalMutexMapper = dalmutexMapper;
                        this.logger = logger;
                }

                public virtual async Task<List<ApiMutexResponseModel>> All(int skip = 0, int take = int.MaxValue, string orderClause = "")
                {
                        var records = await this.mutexRepository.All(skip, take, orderClause);

                        return this.bolMutexMapper.MapBOToModel(this.dalMutexMapper.MapEFToBO(records));
                }

                public virtual async Task<ApiMutexResponseModel> Get(string id)
                {
                        var record = await this.mutexRepository.Get(id);

                        return this.bolMutexMapper.MapBOToModel(this.dalMutexMapper.MapEFToBO(record));
                }

                public virtual async Task<CreateResponse<ApiMutexResponseModel>> Create(
                        ApiMutexRequestModel model)
                {
                        CreateResponse<ApiMutexResponseModel> response = new CreateResponse<ApiMutexResponseModel>(await this.mutexModelValidator.ValidateCreateAsync(model));
                        if (response.Success)
                        {
                                var bo = this.bolMutexMapper.MapModelToBO(default (string), model);
                                var record = await this.mutexRepository.Create(this.dalMutexMapper.MapBOToEF(bo));

                                response.SetRecord(this.bolMutexMapper.MapBOToModel(this.dalMutexMapper.MapEFToBO(record)));
                        }

                        return response;
                }

                public virtual async Task<ActionResponse> Update(
                        string id,
                        ApiMutexRequestModel model)
                {
                        ActionResponse response = new ActionResponse(await this.mutexModelValidator.ValidateUpdateAsync(id, model));

                        if (response.Success)
                        {
                                var bo = this.bolMutexMapper.MapModelToBO(id, model);
                                await this.mutexRepository.Update(this.dalMutexMapper.MapBOToEF(bo));
                        }

                        return response;
                }

                public virtual async Task<ActionResponse> Delete(
                        string id)
                {
                        ActionResponse response = new ActionResponse(await this.mutexModelValidator.ValidateDeleteAsync(id));

                        if (response.Success)
                        {
                                await this.mutexRepository.Delete(id);
                        }

                        return response;
                }
        }
}

/*<Codenesium>
    <Hash>b7f186ed797d886b96d3e9150397e5d4</Hash>
</Codenesium>*/