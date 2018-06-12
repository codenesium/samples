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
        public abstract class AbstractDeploymentHistoryService: AbstractService
        {
                private IDeploymentHistoryRepository deploymentHistoryRepository;

                private IApiDeploymentHistoryRequestModelValidator deploymentHistoryModelValidator;

                private IBOLDeploymentHistoryMapper bolDeploymentHistoryMapper;

                private IDALDeploymentHistoryMapper dalDeploymentHistoryMapper;

                private ILogger logger;

                public AbstractDeploymentHistoryService(
                        ILogger logger,
                        IDeploymentHistoryRepository deploymentHistoryRepository,
                        IApiDeploymentHistoryRequestModelValidator deploymentHistoryModelValidator,
                        IBOLDeploymentHistoryMapper boldeploymentHistoryMapper,
                        IDALDeploymentHistoryMapper daldeploymentHistoryMapper)
                        : base()

                {
                        this.deploymentHistoryRepository = deploymentHistoryRepository;
                        this.deploymentHistoryModelValidator = deploymentHistoryModelValidator;
                        this.bolDeploymentHistoryMapper = boldeploymentHistoryMapper;
                        this.dalDeploymentHistoryMapper = daldeploymentHistoryMapper;
                        this.logger = logger;
                }

                public virtual async Task<List<ApiDeploymentHistoryResponseModel>> All(int skip = 0, int take = int.MaxValue, string orderClause = "")
                {
                        var records = await this.deploymentHistoryRepository.All(skip, take, orderClause);

                        return this.bolDeploymentHistoryMapper.MapBOToModel(this.dalDeploymentHistoryMapper.MapEFToBO(records));
                }

                public virtual async Task<ApiDeploymentHistoryResponseModel> Get(string deploymentId)
                {
                        var record = await this.deploymentHistoryRepository.Get(deploymentId);

                        return this.bolDeploymentHistoryMapper.MapBOToModel(this.dalDeploymentHistoryMapper.MapEFToBO(record));
                }

                public virtual async Task<CreateResponse<ApiDeploymentHistoryResponseModel>> Create(
                        ApiDeploymentHistoryRequestModel model)
                {
                        CreateResponse<ApiDeploymentHistoryResponseModel> response = new CreateResponse<ApiDeploymentHistoryResponseModel>(await this.deploymentHistoryModelValidator.ValidateCreateAsync(model));
                        if (response.Success)
                        {
                                var bo = this.bolDeploymentHistoryMapper.MapModelToBO(default (string), model);
                                var record = await this.deploymentHistoryRepository.Create(this.dalDeploymentHistoryMapper.MapBOToEF(bo));

                                response.SetRecord(this.bolDeploymentHistoryMapper.MapBOToModel(this.dalDeploymentHistoryMapper.MapEFToBO(record)));
                        }

                        return response;
                }

                public virtual async Task<ActionResponse> Update(
                        string deploymentId,
                        ApiDeploymentHistoryRequestModel model)
                {
                        ActionResponse response = new ActionResponse(await this.deploymentHistoryModelValidator.ValidateUpdateAsync(deploymentId, model));

                        if (response.Success)
                        {
                                var bo = this.bolDeploymentHistoryMapper.MapModelToBO(deploymentId, model);
                                await this.deploymentHistoryRepository.Update(this.dalDeploymentHistoryMapper.MapBOToEF(bo));
                        }

                        return response;
                }

                public virtual async Task<ActionResponse> Delete(
                        string deploymentId)
                {
                        ActionResponse response = new ActionResponse(await this.deploymentHistoryModelValidator.ValidateDeleteAsync(deploymentId));

                        if (response.Success)
                        {
                                await this.deploymentHistoryRepository.Delete(deploymentId);
                        }

                        return response;
                }

                public async Task<List<ApiDeploymentHistoryResponseModel>> GetCreated(DateTime created)
                {
                        List<DeploymentHistory> records = await this.deploymentHistoryRepository.GetCreated(created);

                        return this.bolDeploymentHistoryMapper.MapBOToModel(this.dalDeploymentHistoryMapper.MapEFToBO(records));
                }
        }
}

/*<Codenesium>
    <Hash>c8e47d9745b9c4810312446302af7049</Hash>
</Codenesium>*/