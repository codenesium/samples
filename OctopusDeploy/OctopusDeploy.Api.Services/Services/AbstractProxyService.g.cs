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

                public virtual async Task<ActionResponse> Update(
                        string id,
                        ApiProxyRequestModel model)
                {
                        ActionResponse response = new ActionResponse(await this.proxyModelValidator.ValidateUpdateAsync(id, model));
                        if (response.Success)
                        {
                                var bo = this.bolProxyMapper.MapModelToBO(id, model);
                                await this.proxyRepository.Update(this.dalProxyMapper.MapBOToEF(bo));
                        }

                        return response;
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

                public async Task<ApiProxyResponseModel> GetName(string name)
                {
                        Proxy record = await this.proxyRepository.GetName(name);

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
    <Hash>12073f72932631a30493bc7466e00c6e</Hash>
</Codenesium>*/