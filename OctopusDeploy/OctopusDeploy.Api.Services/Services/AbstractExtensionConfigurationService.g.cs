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
        public abstract class AbstractExtensionConfigurationService : AbstractService
        {
                private IExtensionConfigurationRepository extensionConfigurationRepository;

                private IApiExtensionConfigurationRequestModelValidator extensionConfigurationModelValidator;

                private IBOLExtensionConfigurationMapper bolExtensionConfigurationMapper;

                private IDALExtensionConfigurationMapper dalExtensionConfigurationMapper;

                private ILogger logger;

                public AbstractExtensionConfigurationService(
                        ILogger logger,
                        IExtensionConfigurationRepository extensionConfigurationRepository,
                        IApiExtensionConfigurationRequestModelValidator extensionConfigurationModelValidator,
                        IBOLExtensionConfigurationMapper bolExtensionConfigurationMapper,
                        IDALExtensionConfigurationMapper dalExtensionConfigurationMapper)
                        : base()
                {
                        this.extensionConfigurationRepository = extensionConfigurationRepository;
                        this.extensionConfigurationModelValidator = extensionConfigurationModelValidator;
                        this.bolExtensionConfigurationMapper = bolExtensionConfigurationMapper;
                        this.dalExtensionConfigurationMapper = dalExtensionConfigurationMapper;
                        this.logger = logger;
                }

                public virtual async Task<List<ApiExtensionConfigurationResponseModel>> All(int limit = 0, int offset = int.MaxValue)
                {
                        var records = await this.extensionConfigurationRepository.All(limit, offset);

                        return this.bolExtensionConfigurationMapper.MapBOToModel(this.dalExtensionConfigurationMapper.MapEFToBO(records));
                }

                public virtual async Task<ApiExtensionConfigurationResponseModel> Get(string id)
                {
                        var record = await this.extensionConfigurationRepository.Get(id);

                        if (record == null)
                        {
                                return null;
                        }
                        else
                        {
                                return this.bolExtensionConfigurationMapper.MapBOToModel(this.dalExtensionConfigurationMapper.MapEFToBO(record));
                        }
                }

                public virtual async Task<CreateResponse<ApiExtensionConfigurationResponseModel>> Create(
                        ApiExtensionConfigurationRequestModel model)
                {
                        CreateResponse<ApiExtensionConfigurationResponseModel> response = new CreateResponse<ApiExtensionConfigurationResponseModel>(await this.extensionConfigurationModelValidator.ValidateCreateAsync(model));
                        if (response.Success)
                        {
                                var bo = this.bolExtensionConfigurationMapper.MapModelToBO(default(string), model);
                                var record = await this.extensionConfigurationRepository.Create(this.dalExtensionConfigurationMapper.MapBOToEF(bo));

                                response.SetRecord(this.bolExtensionConfigurationMapper.MapBOToModel(this.dalExtensionConfigurationMapper.MapEFToBO(record)));
                        }

                        return response;
                }

                public virtual async Task<ActionResponse> Update(
                        string id,
                        ApiExtensionConfigurationRequestModel model)
                {
                        ActionResponse response = new ActionResponse(await this.extensionConfigurationModelValidator.ValidateUpdateAsync(id, model));
                        if (response.Success)
                        {
                                var bo = this.bolExtensionConfigurationMapper.MapModelToBO(id, model);
                                await this.extensionConfigurationRepository.Update(this.dalExtensionConfigurationMapper.MapBOToEF(bo));
                        }

                        return response;
                }

                public virtual async Task<ActionResponse> Delete(
                        string id)
                {
                        ActionResponse response = new ActionResponse(await this.extensionConfigurationModelValidator.ValidateDeleteAsync(id));
                        if (response.Success)
                        {
                                await this.extensionConfigurationRepository.Delete(id);
                        }

                        return response;
                }
        }
}

/*<Codenesium>
    <Hash>f6701436faf663535840afbaef73ad3e</Hash>
</Codenesium>*/