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
        public abstract class AbstractProxyService: AbstractService
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
                        IBOLProxyMapper bolproxyMapper,
                        IDALProxyMapper dalproxyMapper)
                        : base()

                {
                        this.proxyRepository = proxyRepository;
                        this.proxyModelValidator = proxyModelValidator;
                        this.bolProxyMapper = bolproxyMapper;
                        this.dalProxyMapper = dalproxyMapper;
                        this.logger = logger;
                }

                public virtual async Task<List<ApiProxyResponseModel>> All(int skip = 0, int take = int.MaxValue, string orderClause = "")
                {
                        var records = await this.proxyRepository.All(skip, take, orderClause);

                        return this.bolProxyMapper.MapBOToModel(this.dalProxyMapper.MapEFToBO(records));
                }

                public virtual async Task<ApiProxyResponseModel> Get(string id)
                {
                        var record = await this.proxyRepository.Get(id);

                        return this.bolProxyMapper.MapBOToModel(this.dalProxyMapper.MapEFToBO(record));
                }

                public virtual async Task<CreateResponse<ApiProxyResponseModel>> Create(
                        ApiProxyRequestModel model)
                {
                        CreateResponse<ApiProxyResponseModel> response = new CreateResponse<ApiProxyResponseModel>(await this.proxyModelValidator.ValidateCreateAsync(model));
                        if (response.Success)
                        {
                                var bo = this.bolProxyMapper.MapModelToBO(default (string), model);
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

                        return this.bolProxyMapper.MapBOToModel(this.dalProxyMapper.MapEFToBO(record));
                }
        }
}

/*<Codenesium>
    <Hash>cd02b685c5f0a2cfa56dd0cdf6d6962f</Hash>
</Codenesium>*/