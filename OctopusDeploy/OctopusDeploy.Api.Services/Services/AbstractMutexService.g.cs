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
        public abstract class AbstractMutexService : AbstractService
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
                        IBOLMutexMapper bolMutexMapper,
                        IDALMutexMapper dalMutexMapper)
                        : base()
                {
                        this.mutexRepository = mutexRepository;
                        this.mutexModelValidator = mutexModelValidator;
                        this.bolMutexMapper = bolMutexMapper;
                        this.dalMutexMapper = dalMutexMapper;
                        this.logger = logger;
                }

                public virtual async Task<List<ApiMutexResponseModel>> All(int limit = 0, int offset = int.MaxValue)
                {
                        var records = await this.mutexRepository.All(limit, offset);

                        return this.bolMutexMapper.MapBOToModel(this.dalMutexMapper.MapEFToBO(records));
                }

                public virtual async Task<ApiMutexResponseModel> Get(string id)
                {
                        var record = await this.mutexRepository.Get(id);

                        if (record == null)
                        {
                                return null;
                        }
                        else
                        {
                                return this.bolMutexMapper.MapBOToModel(this.dalMutexMapper.MapEFToBO(record));
                        }
                }

                public virtual async Task<CreateResponse<ApiMutexResponseModel>> Create(
                        ApiMutexRequestModel model)
                {
                        CreateResponse<ApiMutexResponseModel> response = new CreateResponse<ApiMutexResponseModel>(await this.mutexModelValidator.ValidateCreateAsync(model));
                        if (response.Success)
                        {
                                var bo = this.bolMutexMapper.MapModelToBO(default(string), model);
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
    <Hash>a44773bbdd7aff2d4c8036d9e1d83ba2</Hash>
</Codenesium>*/