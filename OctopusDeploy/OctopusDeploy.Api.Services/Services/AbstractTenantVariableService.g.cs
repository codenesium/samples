using Codenesium.DataConversionExtensions.AspNetCore;
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
        public abstract class AbstractTenantVariableService : AbstractService
        {
                private ITenantVariableRepository tenantVariableRepository;

                private IApiTenantVariableRequestModelValidator tenantVariableModelValidator;

                private IBOLTenantVariableMapper bolTenantVariableMapper;

                private IDALTenantVariableMapper dalTenantVariableMapper;

                private ILogger logger;

                public AbstractTenantVariableService(
                        ILogger logger,
                        ITenantVariableRepository tenantVariableRepository,
                        IApiTenantVariableRequestModelValidator tenantVariableModelValidator,
                        IBOLTenantVariableMapper bolTenantVariableMapper,
                        IDALTenantVariableMapper dalTenantVariableMapper)
                        : base()
                {
                        this.tenantVariableRepository = tenantVariableRepository;
                        this.tenantVariableModelValidator = tenantVariableModelValidator;
                        this.bolTenantVariableMapper = bolTenantVariableMapper;
                        this.dalTenantVariableMapper = dalTenantVariableMapper;
                        this.logger = logger;
                }

                public virtual async Task<List<ApiTenantVariableResponseModel>> All(int limit = 0, int offset = int.MaxValue)
                {
                        var records = await this.tenantVariableRepository.All(limit, offset);

                        return this.bolTenantVariableMapper.MapBOToModel(this.dalTenantVariableMapper.MapEFToBO(records));
                }

                public virtual async Task<ApiTenantVariableResponseModel> Get(string id)
                {
                        var record = await this.tenantVariableRepository.Get(id);

                        if (record == null)
                        {
                                return null;
                        }
                        else
                        {
                                return this.bolTenantVariableMapper.MapBOToModel(this.dalTenantVariableMapper.MapEFToBO(record));
                        }
                }

                public virtual async Task<CreateResponse<ApiTenantVariableResponseModel>> Create(
                        ApiTenantVariableRequestModel model)
                {
                        CreateResponse<ApiTenantVariableResponseModel> response = new CreateResponse<ApiTenantVariableResponseModel>(await this.tenantVariableModelValidator.ValidateCreateAsync(model));
                        if (response.Success)
                        {
                                var bo = this.bolTenantVariableMapper.MapModelToBO(default(string), model);
                                var record = await this.tenantVariableRepository.Create(this.dalTenantVariableMapper.MapBOToEF(bo));

                                response.SetRecord(this.bolTenantVariableMapper.MapBOToModel(this.dalTenantVariableMapper.MapEFToBO(record)));
                        }

                        return response;
                }

                public virtual async Task<ActionResponse> Update(
                        string id,
                        ApiTenantVariableRequestModel model)
                {
                        ActionResponse response = new ActionResponse(await this.tenantVariableModelValidator.ValidateUpdateAsync(id, model));
                        if (response.Success)
                        {
                                var bo = this.bolTenantVariableMapper.MapModelToBO(id, model);
                                await this.tenantVariableRepository.Update(this.dalTenantVariableMapper.MapBOToEF(bo));
                        }

                        return response;
                }

                public virtual async Task<ActionResponse> Delete(
                        string id)
                {
                        ActionResponse response = new ActionResponse(await this.tenantVariableModelValidator.ValidateDeleteAsync(id));
                        if (response.Success)
                        {
                                await this.tenantVariableRepository.Delete(id);
                        }

                        return response;
                }

                public async Task<ApiTenantVariableResponseModel> GetTenantIdOwnerIdEnvironmentIdVariableTemplateId(string tenantId, string ownerId, string environmentId, string variableTemplateId)
                {
                        TenantVariable record = await this.tenantVariableRepository.GetTenantIdOwnerIdEnvironmentIdVariableTemplateId(tenantId, ownerId, environmentId, variableTemplateId);

                        if (record == null)
                        {
                                return null;
                        }
                        else
                        {
                                return this.bolTenantVariableMapper.MapBOToModel(this.dalTenantVariableMapper.MapEFToBO(record));
                        }
                }

                public async Task<List<ApiTenantVariableResponseModel>> GetTenantId(string tenantId)
                {
                        List<TenantVariable> records = await this.tenantVariableRepository.GetTenantId(tenantId);

                        return this.bolTenantVariableMapper.MapBOToModel(this.dalTenantVariableMapper.MapEFToBO(records));
                }
        }
}

/*<Codenesium>
    <Hash>e97e1edacdc853e974e0ef8eb1b1cb3c</Hash>
</Codenesium>*/