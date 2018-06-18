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
        public abstract class AbstractDeploymentRelatedMachineService: AbstractService
        {
                private IDeploymentRelatedMachineRepository deploymentRelatedMachineRepository;

                private IApiDeploymentRelatedMachineRequestModelValidator deploymentRelatedMachineModelValidator;

                private IBOLDeploymentRelatedMachineMapper bolDeploymentRelatedMachineMapper;

                private IDALDeploymentRelatedMachineMapper dalDeploymentRelatedMachineMapper;

                private ILogger logger;

                public AbstractDeploymentRelatedMachineService(
                        ILogger logger,
                        IDeploymentRelatedMachineRepository deploymentRelatedMachineRepository,
                        IApiDeploymentRelatedMachineRequestModelValidator deploymentRelatedMachineModelValidator,
                        IBOLDeploymentRelatedMachineMapper bolDeploymentRelatedMachineMapper,
                        IDALDeploymentRelatedMachineMapper dalDeploymentRelatedMachineMapper

                        )
                        : base()

                {
                        this.deploymentRelatedMachineRepository = deploymentRelatedMachineRepository;
                        this.deploymentRelatedMachineModelValidator = deploymentRelatedMachineModelValidator;
                        this.bolDeploymentRelatedMachineMapper = bolDeploymentRelatedMachineMapper;
                        this.dalDeploymentRelatedMachineMapper = dalDeploymentRelatedMachineMapper;
                        this.logger = logger;
                }

                public virtual async Task<List<ApiDeploymentRelatedMachineResponseModel>> All(int limit = 0, int offset = int.MaxValue)
                {
                        var records = await this.deploymentRelatedMachineRepository.All(limit, offset);

                        return this.bolDeploymentRelatedMachineMapper.MapBOToModel(this.dalDeploymentRelatedMachineMapper.MapEFToBO(records));
                }

                public virtual async Task<ApiDeploymentRelatedMachineResponseModel> Get(int id)
                {
                        var record = await this.deploymentRelatedMachineRepository.Get(id);

                        if (record == null)
                        {
                                return null;
                        }
                        else
                        {
                                return this.bolDeploymentRelatedMachineMapper.MapBOToModel(this.dalDeploymentRelatedMachineMapper.MapEFToBO(record));
                        }
                }

                public virtual async Task<CreateResponse<ApiDeploymentRelatedMachineResponseModel>> Create(
                        ApiDeploymentRelatedMachineRequestModel model)
                {
                        CreateResponse<ApiDeploymentRelatedMachineResponseModel> response = new CreateResponse<ApiDeploymentRelatedMachineResponseModel>(await this.deploymentRelatedMachineModelValidator.ValidateCreateAsync(model));
                        if (response.Success)
                        {
                                var bo = this.bolDeploymentRelatedMachineMapper.MapModelToBO(default (int), model);
                                var record = await this.deploymentRelatedMachineRepository.Create(this.dalDeploymentRelatedMachineMapper.MapBOToEF(bo));

                                response.SetRecord(this.bolDeploymentRelatedMachineMapper.MapBOToModel(this.dalDeploymentRelatedMachineMapper.MapEFToBO(record)));
                        }

                        return response;
                }

                public virtual async Task<ActionResponse> Update(
                        int id,
                        ApiDeploymentRelatedMachineRequestModel model)
                {
                        ActionResponse response = new ActionResponse(await this.deploymentRelatedMachineModelValidator.ValidateUpdateAsync(id, model));

                        if (response.Success)
                        {
                                var bo = this.bolDeploymentRelatedMachineMapper.MapModelToBO(id, model);
                                await this.deploymentRelatedMachineRepository.Update(this.dalDeploymentRelatedMachineMapper.MapBOToEF(bo));
                        }

                        return response;
                }

                public virtual async Task<ActionResponse> Delete(
                        int id)
                {
                        ActionResponse response = new ActionResponse(await this.deploymentRelatedMachineModelValidator.ValidateDeleteAsync(id));

                        if (response.Success)
                        {
                                await this.deploymentRelatedMachineRepository.Delete(id);
                        }

                        return response;
                }

                public async Task<List<ApiDeploymentRelatedMachineResponseModel>> GetDeploymentId(string deploymentId)
                {
                        List<DeploymentRelatedMachine> records = await this.deploymentRelatedMachineRepository.GetDeploymentId(deploymentId);

                        return this.bolDeploymentRelatedMachineMapper.MapBOToModel(this.dalDeploymentRelatedMachineMapper.MapEFToBO(records));
                }
                public async Task<List<ApiDeploymentRelatedMachineResponseModel>> GetMachineId(string machineId)
                {
                        List<DeploymentRelatedMachine> records = await this.deploymentRelatedMachineRepository.GetMachineId(machineId);

                        return this.bolDeploymentRelatedMachineMapper.MapBOToModel(this.dalDeploymentRelatedMachineMapper.MapEFToBO(records));
                }
        }
}

/*<Codenesium>
    <Hash>9ccf85872d73036cdd3b076fda938158</Hash>
</Codenesium>*/