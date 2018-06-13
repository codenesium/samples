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
        public abstract class AbstractWorkerTaskLeaseService: AbstractService
        {
                private IWorkerTaskLeaseRepository workerTaskLeaseRepository;

                private IApiWorkerTaskLeaseRequestModelValidator workerTaskLeaseModelValidator;

                private IBOLWorkerTaskLeaseMapper bolWorkerTaskLeaseMapper;

                private IDALWorkerTaskLeaseMapper dalWorkerTaskLeaseMapper;

                private ILogger logger;

                public AbstractWorkerTaskLeaseService(
                        ILogger logger,
                        IWorkerTaskLeaseRepository workerTaskLeaseRepository,
                        IApiWorkerTaskLeaseRequestModelValidator workerTaskLeaseModelValidator,
                        IBOLWorkerTaskLeaseMapper bolWorkerTaskLeaseMapper,
                        IDALWorkerTaskLeaseMapper dalWorkerTaskLeaseMapper

                        )
                        : base()

                {
                        this.workerTaskLeaseRepository = workerTaskLeaseRepository;
                        this.workerTaskLeaseModelValidator = workerTaskLeaseModelValidator;
                        this.bolWorkerTaskLeaseMapper = bolWorkerTaskLeaseMapper;
                        this.dalWorkerTaskLeaseMapper = dalWorkerTaskLeaseMapper;
                        this.logger = logger;
                }

                public virtual async Task<List<ApiWorkerTaskLeaseResponseModel>> All(int limit = 0, int offset = int.MaxValue, string orderClause = "")
                {
                        var records = await this.workerTaskLeaseRepository.All(limit, offset, orderClause);

                        return this.bolWorkerTaskLeaseMapper.MapBOToModel(this.dalWorkerTaskLeaseMapper.MapEFToBO(records));
                }

                public virtual async Task<ApiWorkerTaskLeaseResponseModel> Get(string id)
                {
                        var record = await this.workerTaskLeaseRepository.Get(id);

                        return this.bolWorkerTaskLeaseMapper.MapBOToModel(this.dalWorkerTaskLeaseMapper.MapEFToBO(record));
                }

                public virtual async Task<CreateResponse<ApiWorkerTaskLeaseResponseModel>> Create(
                        ApiWorkerTaskLeaseRequestModel model)
                {
                        CreateResponse<ApiWorkerTaskLeaseResponseModel> response = new CreateResponse<ApiWorkerTaskLeaseResponseModel>(await this.workerTaskLeaseModelValidator.ValidateCreateAsync(model));
                        if (response.Success)
                        {
                                var bo = this.bolWorkerTaskLeaseMapper.MapModelToBO(default (string), model);
                                var record = await this.workerTaskLeaseRepository.Create(this.dalWorkerTaskLeaseMapper.MapBOToEF(bo));

                                response.SetRecord(this.bolWorkerTaskLeaseMapper.MapBOToModel(this.dalWorkerTaskLeaseMapper.MapEFToBO(record)));
                        }

                        return response;
                }

                public virtual async Task<ActionResponse> Update(
                        string id,
                        ApiWorkerTaskLeaseRequestModel model)
                {
                        ActionResponse response = new ActionResponse(await this.workerTaskLeaseModelValidator.ValidateUpdateAsync(id, model));

                        if (response.Success)
                        {
                                var bo = this.bolWorkerTaskLeaseMapper.MapModelToBO(id, model);
                                await this.workerTaskLeaseRepository.Update(this.dalWorkerTaskLeaseMapper.MapBOToEF(bo));
                        }

                        return response;
                }

                public virtual async Task<ActionResponse> Delete(
                        string id)
                {
                        ActionResponse response = new ActionResponse(await this.workerTaskLeaseModelValidator.ValidateDeleteAsync(id));

                        if (response.Success)
                        {
                                await this.workerTaskLeaseRepository.Delete(id);
                        }

                        return response;
                }
        }
}

/*<Codenesium>
    <Hash>ab01b6a36709f0950edc00a6fc2793a5</Hash>
</Codenesium>*/