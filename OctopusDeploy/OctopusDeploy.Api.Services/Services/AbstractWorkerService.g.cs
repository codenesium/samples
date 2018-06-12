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
        public abstract class AbstractWorkerService: AbstractService
        {
                private IWorkerRepository workerRepository;

                private IApiWorkerRequestModelValidator workerModelValidator;

                private IBOLWorkerMapper bolWorkerMapper;

                private IDALWorkerMapper dalWorkerMapper;

                private ILogger logger;

                public AbstractWorkerService(
                        ILogger logger,
                        IWorkerRepository workerRepository,
                        IApiWorkerRequestModelValidator workerModelValidator,
                        IBOLWorkerMapper bolworkerMapper,
                        IDALWorkerMapper dalworkerMapper)
                        : base()

                {
                        this.workerRepository = workerRepository;
                        this.workerModelValidator = workerModelValidator;
                        this.bolWorkerMapper = bolworkerMapper;
                        this.dalWorkerMapper = dalworkerMapper;
                        this.logger = logger;
                }

                public virtual async Task<List<ApiWorkerResponseModel>> All(int skip = 0, int take = int.MaxValue, string orderClause = "")
                {
                        var records = await this.workerRepository.All(skip, take, orderClause);

                        return this.bolWorkerMapper.MapBOToModel(this.dalWorkerMapper.MapEFToBO(records));
                }

                public virtual async Task<ApiWorkerResponseModel> Get(string id)
                {
                        var record = await this.workerRepository.Get(id);

                        return this.bolWorkerMapper.MapBOToModel(this.dalWorkerMapper.MapEFToBO(record));
                }

                public virtual async Task<CreateResponse<ApiWorkerResponseModel>> Create(
                        ApiWorkerRequestModel model)
                {
                        CreateResponse<ApiWorkerResponseModel> response = new CreateResponse<ApiWorkerResponseModel>(await this.workerModelValidator.ValidateCreateAsync(model));
                        if (response.Success)
                        {
                                var bo = this.bolWorkerMapper.MapModelToBO(default (string), model);
                                var record = await this.workerRepository.Create(this.dalWorkerMapper.MapBOToEF(bo));

                                response.SetRecord(this.bolWorkerMapper.MapBOToModel(this.dalWorkerMapper.MapEFToBO(record)));
                        }

                        return response;
                }

                public virtual async Task<ActionResponse> Update(
                        string id,
                        ApiWorkerRequestModel model)
                {
                        ActionResponse response = new ActionResponse(await this.workerModelValidator.ValidateUpdateAsync(id, model));

                        if (response.Success)
                        {
                                var bo = this.bolWorkerMapper.MapModelToBO(id, model);
                                await this.workerRepository.Update(this.dalWorkerMapper.MapBOToEF(bo));
                        }

                        return response;
                }

                public virtual async Task<ActionResponse> Delete(
                        string id)
                {
                        ActionResponse response = new ActionResponse(await this.workerModelValidator.ValidateDeleteAsync(id));

                        if (response.Success)
                        {
                                await this.workerRepository.Delete(id);
                        }

                        return response;
                }

                public async Task<ApiWorkerResponseModel> GetName(string name)
                {
                        Worker record = await this.workerRepository.GetName(name);

                        return this.bolWorkerMapper.MapBOToModel(this.dalWorkerMapper.MapEFToBO(record));
                }
                public async Task<List<ApiWorkerResponseModel>> GetMachinePolicyId(string machinePolicyId)
                {
                        List<Worker> records = await this.workerRepository.GetMachinePolicyId(machinePolicyId);

                        return this.bolWorkerMapper.MapBOToModel(this.dalWorkerMapper.MapEFToBO(records));
                }
        }
}

/*<Codenesium>
    <Hash>b3d8faf8f98ef982929be327e358478a</Hash>
</Codenesium>*/