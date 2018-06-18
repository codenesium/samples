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
        public abstract class AbstractLifecycleService: AbstractService
        {
                private ILifecycleRepository lifecycleRepository;

                private IApiLifecycleRequestModelValidator lifecycleModelValidator;

                private IBOLLifecycleMapper bolLifecycleMapper;

                private IDALLifecycleMapper dalLifecycleMapper;

                private ILogger logger;

                public AbstractLifecycleService(
                        ILogger logger,
                        ILifecycleRepository lifecycleRepository,
                        IApiLifecycleRequestModelValidator lifecycleModelValidator,
                        IBOLLifecycleMapper bolLifecycleMapper,
                        IDALLifecycleMapper dalLifecycleMapper

                        )
                        : base()

                {
                        this.lifecycleRepository = lifecycleRepository;
                        this.lifecycleModelValidator = lifecycleModelValidator;
                        this.bolLifecycleMapper = bolLifecycleMapper;
                        this.dalLifecycleMapper = dalLifecycleMapper;
                        this.logger = logger;
                }

                public virtual async Task<List<ApiLifecycleResponseModel>> All(int limit = 0, int offset = int.MaxValue)
                {
                        var records = await this.lifecycleRepository.All(limit, offset);

                        return this.bolLifecycleMapper.MapBOToModel(this.dalLifecycleMapper.MapEFToBO(records));
                }

                public virtual async Task<ApiLifecycleResponseModel> Get(string id)
                {
                        var record = await this.lifecycleRepository.Get(id);

                        if (record == null)
                        {
                                return null;
                        }
                        else
                        {
                                return this.bolLifecycleMapper.MapBOToModel(this.dalLifecycleMapper.MapEFToBO(record));
                        }
                }

                public virtual async Task<CreateResponse<ApiLifecycleResponseModel>> Create(
                        ApiLifecycleRequestModel model)
                {
                        CreateResponse<ApiLifecycleResponseModel> response = new CreateResponse<ApiLifecycleResponseModel>(await this.lifecycleModelValidator.ValidateCreateAsync(model));
                        if (response.Success)
                        {
                                var bo = this.bolLifecycleMapper.MapModelToBO(default (string), model);
                                var record = await this.lifecycleRepository.Create(this.dalLifecycleMapper.MapBOToEF(bo));

                                response.SetRecord(this.bolLifecycleMapper.MapBOToModel(this.dalLifecycleMapper.MapEFToBO(record)));
                        }

                        return response;
                }

                public virtual async Task<ActionResponse> Update(
                        string id,
                        ApiLifecycleRequestModel model)
                {
                        ActionResponse response = new ActionResponse(await this.lifecycleModelValidator.ValidateUpdateAsync(id, model));

                        if (response.Success)
                        {
                                var bo = this.bolLifecycleMapper.MapModelToBO(id, model);
                                await this.lifecycleRepository.Update(this.dalLifecycleMapper.MapBOToEF(bo));
                        }

                        return response;
                }

                public virtual async Task<ActionResponse> Delete(
                        string id)
                {
                        ActionResponse response = new ActionResponse(await this.lifecycleModelValidator.ValidateDeleteAsync(id));

                        if (response.Success)
                        {
                                await this.lifecycleRepository.Delete(id);
                        }

                        return response;
                }

                public async Task<ApiLifecycleResponseModel> GetName(string name)
                {
                        Lifecycle record = await this.lifecycleRepository.GetName(name);

                        if (record == null)
                        {
                                return null;
                        }
                        else
                        {
                                return this.bolLifecycleMapper.MapBOToModel(this.dalLifecycleMapper.MapEFToBO(record));
                        }
                }
                public async Task<List<ApiLifecycleResponseModel>> GetDataVersion(byte[] dataVersion)
                {
                        List<Lifecycle> records = await this.lifecycleRepository.GetDataVersion(dataVersion);

                        return this.bolLifecycleMapper.MapBOToModel(this.dalLifecycleMapper.MapEFToBO(records));
                }
        }
}

/*<Codenesium>
    <Hash>11d168d591f152c4305099cf70e3ff82</Hash>
</Codenesium>*/