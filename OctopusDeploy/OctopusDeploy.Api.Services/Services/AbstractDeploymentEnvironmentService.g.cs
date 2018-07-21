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
        public abstract class AbstractDeploymentEnvironmentService : AbstractService
        {
                private IDeploymentEnvironmentRepository deploymentEnvironmentRepository;

                private IApiDeploymentEnvironmentRequestModelValidator deploymentEnvironmentModelValidator;

                private IBOLDeploymentEnvironmentMapper bolDeploymentEnvironmentMapper;

                private IDALDeploymentEnvironmentMapper dalDeploymentEnvironmentMapper;

                private ILogger logger;

                public AbstractDeploymentEnvironmentService(
                        ILogger logger,
                        IDeploymentEnvironmentRepository deploymentEnvironmentRepository,
                        IApiDeploymentEnvironmentRequestModelValidator deploymentEnvironmentModelValidator,
                        IBOLDeploymentEnvironmentMapper bolDeploymentEnvironmentMapper,
                        IDALDeploymentEnvironmentMapper dalDeploymentEnvironmentMapper)
                        : base()
                {
                        this.deploymentEnvironmentRepository = deploymentEnvironmentRepository;
                        this.deploymentEnvironmentModelValidator = deploymentEnvironmentModelValidator;
                        this.bolDeploymentEnvironmentMapper = bolDeploymentEnvironmentMapper;
                        this.dalDeploymentEnvironmentMapper = dalDeploymentEnvironmentMapper;
                        this.logger = logger;
                }

                public virtual async Task<List<ApiDeploymentEnvironmentResponseModel>> All(int limit = 0, int offset = int.MaxValue)
                {
                        var records = await this.deploymentEnvironmentRepository.All(limit, offset);

                        return this.bolDeploymentEnvironmentMapper.MapBOToModel(this.dalDeploymentEnvironmentMapper.MapEFToBO(records));
                }

                public virtual async Task<ApiDeploymentEnvironmentResponseModel> Get(string id)
                {
                        var record = await this.deploymentEnvironmentRepository.Get(id);

                        if (record == null)
                        {
                                return null;
                        }
                        else
                        {
                                return this.bolDeploymentEnvironmentMapper.MapBOToModel(this.dalDeploymentEnvironmentMapper.MapEFToBO(record));
                        }
                }

                public virtual async Task<CreateResponse<ApiDeploymentEnvironmentResponseModel>> Create(
                        ApiDeploymentEnvironmentRequestModel model)
                {
                        CreateResponse<ApiDeploymentEnvironmentResponseModel> response = new CreateResponse<ApiDeploymentEnvironmentResponseModel>(await this.deploymentEnvironmentModelValidator.ValidateCreateAsync(model));
                        if (response.Success)
                        {
                                var bo = this.bolDeploymentEnvironmentMapper.MapModelToBO(default(string), model);
                                var record = await this.deploymentEnvironmentRepository.Create(this.dalDeploymentEnvironmentMapper.MapBOToEF(bo));

                                response.SetRecord(this.bolDeploymentEnvironmentMapper.MapBOToModel(this.dalDeploymentEnvironmentMapper.MapEFToBO(record)));
                        }

                        return response;
                }

                public virtual async Task<UpdateResponse<ApiDeploymentEnvironmentResponseModel>> Update(
                        string id,
                        ApiDeploymentEnvironmentRequestModel model)
                {
                        var validationResult = await this.deploymentEnvironmentModelValidator.ValidateUpdateAsync(id, model);

                        if (validationResult.IsValid)
                        {
                                var bo = this.bolDeploymentEnvironmentMapper.MapModelToBO(id, model);
                                await this.deploymentEnvironmentRepository.Update(this.dalDeploymentEnvironmentMapper.MapBOToEF(bo));

                                var record = await this.deploymentEnvironmentRepository.Get(id);

                                return new UpdateResponse<ApiDeploymentEnvironmentResponseModel>(this.bolDeploymentEnvironmentMapper.MapBOToModel(this.dalDeploymentEnvironmentMapper.MapEFToBO(record)));
                        }
                        else
                        {
                                return new UpdateResponse<ApiDeploymentEnvironmentResponseModel>(validationResult);
                        }
                }

                public virtual async Task<ActionResponse> Delete(
                        string id)
                {
                        ActionResponse response = new ActionResponse(await this.deploymentEnvironmentModelValidator.ValidateDeleteAsync(id));
                        if (response.Success)
                        {
                                await this.deploymentEnvironmentRepository.Delete(id);
                        }

                        return response;
                }

                public async Task<ApiDeploymentEnvironmentResponseModel> ByName(string name)
                {
                        DeploymentEnvironment record = await this.deploymentEnvironmentRepository.ByName(name);

                        if (record == null)
                        {
                                return null;
                        }
                        else
                        {
                                return this.bolDeploymentEnvironmentMapper.MapBOToModel(this.dalDeploymentEnvironmentMapper.MapEFToBO(record));
                        }
                }

                public async Task<List<ApiDeploymentEnvironmentResponseModel>> ByDataVersion(byte[] dataVersion)
                {
                        List<DeploymentEnvironment> records = await this.deploymentEnvironmentRepository.ByDataVersion(dataVersion);

                        return this.bolDeploymentEnvironmentMapper.MapBOToModel(this.dalDeploymentEnvironmentMapper.MapEFToBO(records));
                }
        }
}

/*<Codenesium>
    <Hash>512feb1df8a5635a0c7e6244104fd5c4</Hash>
</Codenesium>*/