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
        public abstract class AbstractFeedService: AbstractService
        {
                private IFeedRepository feedRepository;

                private IApiFeedRequestModelValidator feedModelValidator;

                private IBOLFeedMapper bolFeedMapper;

                private IDALFeedMapper dalFeedMapper;

                private ILogger logger;

                public AbstractFeedService(
                        ILogger logger,
                        IFeedRepository feedRepository,
                        IApiFeedRequestModelValidator feedModelValidator,
                        IBOLFeedMapper bolfeedMapper,
                        IDALFeedMapper dalfeedMapper)
                        : base()

                {
                        this.feedRepository = feedRepository;
                        this.feedModelValidator = feedModelValidator;
                        this.bolFeedMapper = bolfeedMapper;
                        this.dalFeedMapper = dalfeedMapper;
                        this.logger = logger;
                }

                public virtual async Task<List<ApiFeedResponseModel>> All(int skip = 0, int take = int.MaxValue, string orderClause = "")
                {
                        var records = await this.feedRepository.All(skip, take, orderClause);

                        return this.bolFeedMapper.MapBOToModel(this.dalFeedMapper.MapEFToBO(records));
                }

                public virtual async Task<ApiFeedResponseModel> Get(string id)
                {
                        var record = await this.feedRepository.Get(id);

                        return this.bolFeedMapper.MapBOToModel(this.dalFeedMapper.MapEFToBO(record));
                }

                public virtual async Task<CreateResponse<ApiFeedResponseModel>> Create(
                        ApiFeedRequestModel model)
                {
                        CreateResponse<ApiFeedResponseModel> response = new CreateResponse<ApiFeedResponseModel>(await this.feedModelValidator.ValidateCreateAsync(model));
                        if (response.Success)
                        {
                                var bo = this.bolFeedMapper.MapModelToBO(default (string), model);
                                var record = await this.feedRepository.Create(this.dalFeedMapper.MapBOToEF(bo));

                                response.SetRecord(this.bolFeedMapper.MapBOToModel(this.dalFeedMapper.MapEFToBO(record)));
                        }

                        return response;
                }

                public virtual async Task<ActionResponse> Update(
                        string id,
                        ApiFeedRequestModel model)
                {
                        ActionResponse response = new ActionResponse(await this.feedModelValidator.ValidateUpdateAsync(id, model));

                        if (response.Success)
                        {
                                var bo = this.bolFeedMapper.MapModelToBO(id, model);
                                await this.feedRepository.Update(this.dalFeedMapper.MapBOToEF(bo));
                        }

                        return response;
                }

                public virtual async Task<ActionResponse> Delete(
                        string id)
                {
                        ActionResponse response = new ActionResponse(await this.feedModelValidator.ValidateDeleteAsync(id));

                        if (response.Success)
                        {
                                await this.feedRepository.Delete(id);
                        }

                        return response;
                }

                public async Task<ApiFeedResponseModel> GetName(string name)
                {
                        Feed record = await this.feedRepository.GetName(name);

                        return this.bolFeedMapper.MapBOToModel(this.dalFeedMapper.MapEFToBO(record));
                }
        }
}

/*<Codenesium>
    <Hash>cc90b8f6ac2c65f92067822cb00fcf9e</Hash>
</Codenesium>*/