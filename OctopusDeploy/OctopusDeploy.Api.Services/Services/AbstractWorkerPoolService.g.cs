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
        public abstract class AbstractWorkerPoolService: AbstractService
        {
                private IWorkerPoolRepository workerPoolRepository;

                private IApiWorkerPoolRequestModelValidator workerPoolModelValidator;

                private IBOLWorkerPoolMapper bolWorkerPoolMapper;

                private IDALWorkerPoolMapper dalWorkerPoolMapper;

                private ILogger logger;

                public AbstractWorkerPoolService(
                        ILogger logger,
                        IWorkerPoolRepository workerPoolRepository,
                        IApiWorkerPoolRequestModelValidator workerPoolModelValidator,
                        IBOLWorkerPoolMapper bolWorkerPoolMapper,
                        IDALWorkerPoolMapper dalWorkerPoolMapper

                        )
                        : base()

                {
                        this.workerPoolRepository = workerPoolRepository;
                        this.workerPoolModelValidator = workerPoolModelValidator;
                        this.bolWorkerPoolMapper = bolWorkerPoolMapper;
                        this.dalWorkerPoolMapper = dalWorkerPoolMapper;
                        this.logger = logger;
                }

                public virtual async Task<List<ApiWorkerPoolResponseModel>> All(int limit = 0, int offset = int.MaxValue)
                {
                        var records = await this.workerPoolRepository.All(limit, offset);

                        return this.bolWorkerPoolMapper.MapBOToModel(this.dalWorkerPoolMapper.MapEFToBO(records));
                }

                public virtual async Task<ApiWorkerPoolResponseModel> Get(string id)
                {
                        var record = await this.workerPoolRepository.Get(id);

                        if (record == null)
                        {
                                return null;
                        }
                        else
                        {
                                return this.bolWorkerPoolMapper.MapBOToModel(this.dalWorkerPoolMapper.MapEFToBO(record));
                        }
                }

                public virtual async Task<CreateResponse<ApiWorkerPoolResponseModel>> Create(
                        ApiWorkerPoolRequestModel model)
                {
                        CreateResponse<ApiWorkerPoolResponseModel> response = new CreateResponse<ApiWorkerPoolResponseModel>(await this.workerPoolModelValidator.ValidateCreateAsync(model));
                        if (response.Success)
                        {
                                var bo = this.bolWorkerPoolMapper.MapModelToBO(default (string), model);
                                var record = await this.workerPoolRepository.Create(this.dalWorkerPoolMapper.MapBOToEF(bo));

                                response.SetRecord(this.bolWorkerPoolMapper.MapBOToModel(this.dalWorkerPoolMapper.MapEFToBO(record)));
                        }

                        return response;
                }

                public virtual async Task<ActionResponse> Update(
                        string id,
                        ApiWorkerPoolRequestModel model)
                {
                        ActionResponse response = new ActionResponse(await this.workerPoolModelValidator.ValidateUpdateAsync(id, model));

                        if (response.Success)
                        {
                                var bo = this.bolWorkerPoolMapper.MapModelToBO(id, model);
                                await this.workerPoolRepository.Update(this.dalWorkerPoolMapper.MapBOToEF(bo));
                        }

                        return response;
                }

                public virtual async Task<ActionResponse> Delete(
                        string id)
                {
                        ActionResponse response = new ActionResponse(await this.workerPoolModelValidator.ValidateDeleteAsync(id));

                        if (response.Success)
                        {
                                await this.workerPoolRepository.Delete(id);
                        }

                        return response;
                }

                public async Task<ApiWorkerPoolResponseModel> GetName(string name)
                {
                        WorkerPool record = await this.workerPoolRepository.GetName(name);

                        if (record == null)
                        {
                                return null;
                        }
                        else
                        {
                                return this.bolWorkerPoolMapper.MapBOToModel(this.dalWorkerPoolMapper.MapEFToBO(record));
                        }
                }
        }
}

/*<Codenesium>
    <Hash>aeb9958e51f4bc170a5bb53488e24c0f</Hash>
</Codenesium>*/