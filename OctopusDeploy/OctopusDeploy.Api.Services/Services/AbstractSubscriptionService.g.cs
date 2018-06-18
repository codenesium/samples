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
        public abstract class AbstractSubscriptionService: AbstractService
        {
                private ISubscriptionRepository subscriptionRepository;

                private IApiSubscriptionRequestModelValidator subscriptionModelValidator;

                private IBOLSubscriptionMapper bolSubscriptionMapper;

                private IDALSubscriptionMapper dalSubscriptionMapper;

                private ILogger logger;

                public AbstractSubscriptionService(
                        ILogger logger,
                        ISubscriptionRepository subscriptionRepository,
                        IApiSubscriptionRequestModelValidator subscriptionModelValidator,
                        IBOLSubscriptionMapper bolSubscriptionMapper,
                        IDALSubscriptionMapper dalSubscriptionMapper

                        )
                        : base()

                {
                        this.subscriptionRepository = subscriptionRepository;
                        this.subscriptionModelValidator = subscriptionModelValidator;
                        this.bolSubscriptionMapper = bolSubscriptionMapper;
                        this.dalSubscriptionMapper = dalSubscriptionMapper;
                        this.logger = logger;
                }

                public virtual async Task<List<ApiSubscriptionResponseModel>> All(int limit = 0, int offset = int.MaxValue)
                {
                        var records = await this.subscriptionRepository.All(limit, offset);

                        return this.bolSubscriptionMapper.MapBOToModel(this.dalSubscriptionMapper.MapEFToBO(records));
                }

                public virtual async Task<ApiSubscriptionResponseModel> Get(string id)
                {
                        var record = await this.subscriptionRepository.Get(id);

                        if (record == null)
                        {
                                return null;
                        }
                        else
                        {
                                return this.bolSubscriptionMapper.MapBOToModel(this.dalSubscriptionMapper.MapEFToBO(record));
                        }
                }

                public virtual async Task<CreateResponse<ApiSubscriptionResponseModel>> Create(
                        ApiSubscriptionRequestModel model)
                {
                        CreateResponse<ApiSubscriptionResponseModel> response = new CreateResponse<ApiSubscriptionResponseModel>(await this.subscriptionModelValidator.ValidateCreateAsync(model));
                        if (response.Success)
                        {
                                var bo = this.bolSubscriptionMapper.MapModelToBO(default (string), model);
                                var record = await this.subscriptionRepository.Create(this.dalSubscriptionMapper.MapBOToEF(bo));

                                response.SetRecord(this.bolSubscriptionMapper.MapBOToModel(this.dalSubscriptionMapper.MapEFToBO(record)));
                        }

                        return response;
                }

                public virtual async Task<ActionResponse> Update(
                        string id,
                        ApiSubscriptionRequestModel model)
                {
                        ActionResponse response = new ActionResponse(await this.subscriptionModelValidator.ValidateUpdateAsync(id, model));

                        if (response.Success)
                        {
                                var bo = this.bolSubscriptionMapper.MapModelToBO(id, model);
                                await this.subscriptionRepository.Update(this.dalSubscriptionMapper.MapBOToEF(bo));
                        }

                        return response;
                }

                public virtual async Task<ActionResponse> Delete(
                        string id)
                {
                        ActionResponse response = new ActionResponse(await this.subscriptionModelValidator.ValidateDeleteAsync(id));

                        if (response.Success)
                        {
                                await this.subscriptionRepository.Delete(id);
                        }

                        return response;
                }

                public async Task<ApiSubscriptionResponseModel> GetName(string name)
                {
                        Subscription record = await this.subscriptionRepository.GetName(name);

                        if (record == null)
                        {
                                return null;
                        }
                        else
                        {
                                return this.bolSubscriptionMapper.MapBOToModel(this.dalSubscriptionMapper.MapEFToBO(record));
                        }
                }
        }
}

/*<Codenesium>
    <Hash>2ed896b1f2823b27bafcb64cc5b27c28</Hash>
</Codenesium>*/