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
        public abstract class AbstractDashboardConfigurationService: AbstractService
        {
                private IDashboardConfigurationRepository dashboardConfigurationRepository;

                private IApiDashboardConfigurationRequestModelValidator dashboardConfigurationModelValidator;

                private IBOLDashboardConfigurationMapper bolDashboardConfigurationMapper;

                private IDALDashboardConfigurationMapper dalDashboardConfigurationMapper;

                private ILogger logger;

                public AbstractDashboardConfigurationService(
                        ILogger logger,
                        IDashboardConfigurationRepository dashboardConfigurationRepository,
                        IApiDashboardConfigurationRequestModelValidator dashboardConfigurationModelValidator,
                        IBOLDashboardConfigurationMapper boldashboardConfigurationMapper,
                        IDALDashboardConfigurationMapper daldashboardConfigurationMapper)
                        : base()

                {
                        this.dashboardConfigurationRepository = dashboardConfigurationRepository;
                        this.dashboardConfigurationModelValidator = dashboardConfigurationModelValidator;
                        this.bolDashboardConfigurationMapper = boldashboardConfigurationMapper;
                        this.dalDashboardConfigurationMapper = daldashboardConfigurationMapper;
                        this.logger = logger;
                }

                public virtual async Task<List<ApiDashboardConfigurationResponseModel>> All(int skip = 0, int take = int.MaxValue, string orderClause = "")
                {
                        var records = await this.dashboardConfigurationRepository.All(skip, take, orderClause);

                        return this.bolDashboardConfigurationMapper.MapBOToModel(this.dalDashboardConfigurationMapper.MapEFToBO(records));
                }

                public virtual async Task<ApiDashboardConfigurationResponseModel> Get(string id)
                {
                        var record = await this.dashboardConfigurationRepository.Get(id);

                        return this.bolDashboardConfigurationMapper.MapBOToModel(this.dalDashboardConfigurationMapper.MapEFToBO(record));
                }

                public virtual async Task<CreateResponse<ApiDashboardConfigurationResponseModel>> Create(
                        ApiDashboardConfigurationRequestModel model)
                {
                        CreateResponse<ApiDashboardConfigurationResponseModel> response = new CreateResponse<ApiDashboardConfigurationResponseModel>(await this.dashboardConfigurationModelValidator.ValidateCreateAsync(model));
                        if (response.Success)
                        {
                                var bo = this.bolDashboardConfigurationMapper.MapModelToBO(default (string), model);
                                var record = await this.dashboardConfigurationRepository.Create(this.dalDashboardConfigurationMapper.MapBOToEF(bo));

                                response.SetRecord(this.bolDashboardConfigurationMapper.MapBOToModel(this.dalDashboardConfigurationMapper.MapEFToBO(record)));
                        }

                        return response;
                }

                public virtual async Task<ActionResponse> Update(
                        string id,
                        ApiDashboardConfigurationRequestModel model)
                {
                        ActionResponse response = new ActionResponse(await this.dashboardConfigurationModelValidator.ValidateUpdateAsync(id, model));

                        if (response.Success)
                        {
                                var bo = this.bolDashboardConfigurationMapper.MapModelToBO(id, model);
                                await this.dashboardConfigurationRepository.Update(this.dalDashboardConfigurationMapper.MapBOToEF(bo));
                        }

                        return response;
                }

                public virtual async Task<ActionResponse> Delete(
                        string id)
                {
                        ActionResponse response = new ActionResponse(await this.dashboardConfigurationModelValidator.ValidateDeleteAsync(id));

                        if (response.Success)
                        {
                                await this.dashboardConfigurationRepository.Delete(id);
                        }

                        return response;
                }
        }
}

/*<Codenesium>
    <Hash>8ef5b3aaba1603b0bbdd5f04372b6baf</Hash>
</Codenesium>*/