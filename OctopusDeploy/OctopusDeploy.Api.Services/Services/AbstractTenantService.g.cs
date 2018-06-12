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
        public abstract class AbstractTenantService: AbstractService
        {
                private ITenantRepository tenantRepository;

                private IApiTenantRequestModelValidator tenantModelValidator;

                private IBOLTenantMapper bolTenantMapper;

                private IDALTenantMapper dalTenantMapper;

                private ILogger logger;

                public AbstractTenantService(
                        ILogger logger,
                        ITenantRepository tenantRepository,
                        IApiTenantRequestModelValidator tenantModelValidator,
                        IBOLTenantMapper boltenantMapper,
                        IDALTenantMapper daltenantMapper)
                        : base()

                {
                        this.tenantRepository = tenantRepository;
                        this.tenantModelValidator = tenantModelValidator;
                        this.bolTenantMapper = boltenantMapper;
                        this.dalTenantMapper = daltenantMapper;
                        this.logger = logger;
                }

                public virtual async Task<List<ApiTenantResponseModel>> All(int skip = 0, int take = int.MaxValue, string orderClause = "")
                {
                        var records = await this.tenantRepository.All(skip, take, orderClause);

                        return this.bolTenantMapper.MapBOToModel(this.dalTenantMapper.MapEFToBO(records));
                }

                public virtual async Task<ApiTenantResponseModel> Get(string id)
                {
                        var record = await this.tenantRepository.Get(id);

                        return this.bolTenantMapper.MapBOToModel(this.dalTenantMapper.MapEFToBO(record));
                }

                public virtual async Task<CreateResponse<ApiTenantResponseModel>> Create(
                        ApiTenantRequestModel model)
                {
                        CreateResponse<ApiTenantResponseModel> response = new CreateResponse<ApiTenantResponseModel>(await this.tenantModelValidator.ValidateCreateAsync(model));
                        if (response.Success)
                        {
                                var bo = this.bolTenantMapper.MapModelToBO(default (string), model);
                                var record = await this.tenantRepository.Create(this.dalTenantMapper.MapBOToEF(bo));

                                response.SetRecord(this.bolTenantMapper.MapBOToModel(this.dalTenantMapper.MapEFToBO(record)));
                        }

                        return response;
                }

                public virtual async Task<ActionResponse> Update(
                        string id,
                        ApiTenantRequestModel model)
                {
                        ActionResponse response = new ActionResponse(await this.tenantModelValidator.ValidateUpdateAsync(id, model));

                        if (response.Success)
                        {
                                var bo = this.bolTenantMapper.MapModelToBO(id, model);
                                await this.tenantRepository.Update(this.dalTenantMapper.MapBOToEF(bo));
                        }

                        return response;
                }

                public virtual async Task<ActionResponse> Delete(
                        string id)
                {
                        ActionResponse response = new ActionResponse(await this.tenantModelValidator.ValidateDeleteAsync(id));

                        if (response.Success)
                        {
                                await this.tenantRepository.Delete(id);
                        }

                        return response;
                }

                public async Task<ApiTenantResponseModel> GetName(string name)
                {
                        Tenant record = await this.tenantRepository.GetName(name);

                        return this.bolTenantMapper.MapBOToModel(this.dalTenantMapper.MapEFToBO(record));
                }
                public async Task<List<ApiTenantResponseModel>> GetDataVersion(byte[] dataVersion)
                {
                        List<Tenant> records = await this.tenantRepository.GetDataVersion(dataVersion);

                        return this.bolTenantMapper.MapBOToModel(this.dalTenantMapper.MapEFToBO(records));
                }
        }
}

/*<Codenesium>
    <Hash>b0a4576a779f549339ea005ab6644f6e</Hash>
</Codenesium>*/