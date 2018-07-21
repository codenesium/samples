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
        public abstract class AbstractProxyService : AbstractService
        {
                private IProxyRepository proxyRepository;

                private IApiProxyRequestModelValidator proxyModelValidator;

                private IBOLProxyMapper bolProxyMapper;

                private IDALProxyMapper dalProxyMapper;

                private ILogger logger;

                public AbstractProxyService(
                        ILogger logger,
                        IProxyRepository proxyRepository,
                        IApiProxyRequestModelValidator proxyModelValidator,
                        IBOLProxyMapper bolProxyMapper,
                        IDALProxyMapper dalProxyMapper)
                        : base()
                {
                        this.proxyRepository = proxyRepository;
                        this.proxyModelValidator = proxyModelValidator;
                        this.bolProxyMapper = bolProxyMapper;
                        this.dalProxyMapper = dalProxyMapper;
                        this.logger = logger;
                }

                public virtual async Task<List<ApiProxyResponseModel>> All(int limit = 0, int offset = int.MaxValue)
                {
                        var records = await this.proxyRepository.All(limit, offset);

                        return this.bolProxyMapper.MapBOToModel(this.dalProxyMapper.MapEFToBO(records));
                }

                public virtual async Task<ApiProxyResponseModel> Get(string id)
                {
                        var record = await this.proxyRepository.Get(id);

                        if (record == null)
                        {
                                return null;
                        }
                        else
                        {
                                return this.bolProxyMapper.MapBOToModel(this.dalProxyMapper.MapEFToBO(record));
                        }
                }

                public virtual async Task<CreateResponse<ApiProxyResponseModel>> Create(
                        ApiProxyRequestModel model)
                {
                        CreateResponse<ApiProxyResponseModel> response = new CreateResponse<ApiProxyResponseModel>(await this.proxyModelValidator.ValidateCreateAsync(model));
                        if (response.Success)
                        {
                                var bo = this.bolProxyMapper.MapModelToBO(default(string), model);
                                var record = await this.proxyRepository.Create(this.dalProxyMapper.MapBOToEF(bo));

                                response.SetRecord(this.bolProxyMapper.MapBOToModel(this.dalProxyMapper.MapEFToBO(record)));
                        }

                        return response;
                }

                public virtual async Task<UpdateResponse<ApiProxyResponseModel>> Update(
                        string id,
                        ApiProxyRequestModel model)
                {
                        var validationResult = await this.proxyModelValidator.ValidateUpdateAsync(id, model);

                        if (validationResult.IsValid)
                        {
                                var bo = this.bolProxyMapper.MapModelToBO(id, model);
                                await this.proxyRepository.Update(this.dalProxyMapper.MapBOToEF(bo));

                                var record = await this.proxyRepository.Get(id);

                                return new UpdateResponse<ApiProxyResponseModel>(this.bolProxyMapper.MapBOToModel(this.dalProxyMapper.MapEFToBO(record)));
                        }
                        else
                        {
                                return new UpdateResponse<ApiProxyResponseModel>(validationResult);
                        }
                }

                public virtual async Task<ActionResponse> Delete(
                        string id)
                {
                        ActionResponse response = new ActionResponse(await this.proxyModelValidator.ValidateDeleteAsync(id));
                        if (response.Success)
                        {
                                await this.proxyRepository.Delete(id);
                        }

                        return response;
                }

                public async Task<ApiProxyResponseModel> ByName(string name)
                {
                        Proxy record = await this.proxyRepository.ByName(name);

                        if (record == null)
                        {
                                return null;
                        }
                        else
                        {
                                return this.bolProxyMapper.MapBOToModel(this.dalProxyMapper.MapEFToBO(record));
                        }
                }
        }
}

/*<Codenesium>
    <Hash>28349711b29a80c8aabb1f9adbc76607</Hash>
</Codenesium>*/