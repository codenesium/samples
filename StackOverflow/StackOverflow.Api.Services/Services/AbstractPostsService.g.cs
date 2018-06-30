using Codenesium.DataConversionExtensions;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;
using StackOverflowNS.Api.Contracts;
using StackOverflowNS.Api.DataAccess;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Dynamic.Core;
using System.Linq.Expressions;
using System.Threading.Tasks;

namespace StackOverflowNS.Api.Services
{
        public abstract class AbstractPostsService : AbstractService
        {
                private IPostsRepository postsRepository;

                private IApiPostsRequestModelValidator postsModelValidator;

                private IBOLPostsMapper bolPostsMapper;

                private IDALPostsMapper dalPostsMapper;

                private ILogger logger;

                public AbstractPostsService(
                        ILogger logger,
                        IPostsRepository postsRepository,
                        IApiPostsRequestModelValidator postsModelValidator,
                        IBOLPostsMapper bolPostsMapper,
                        IDALPostsMapper dalPostsMapper)
                        : base()
                {
                        this.postsRepository = postsRepository;
                        this.postsModelValidator = postsModelValidator;
                        this.bolPostsMapper = bolPostsMapper;
                        this.dalPostsMapper = dalPostsMapper;
                        this.logger = logger;
                }

                public virtual async Task<List<ApiPostsResponseModel>> All(int limit = 0, int offset = int.MaxValue)
                {
                        var records = await this.postsRepository.All(limit, offset);

                        return this.bolPostsMapper.MapBOToModel(this.dalPostsMapper.MapEFToBO(records));
                }

                public virtual async Task<ApiPostsResponseModel> Get(int id)
                {
                        var record = await this.postsRepository.Get(id);

                        if (record == null)
                        {
                                return null;
                        }
                        else
                        {
                                return this.bolPostsMapper.MapBOToModel(this.dalPostsMapper.MapEFToBO(record));
                        }
                }

                public virtual async Task<CreateResponse<ApiPostsResponseModel>> Create(
                        ApiPostsRequestModel model)
                {
                        CreateResponse<ApiPostsResponseModel> response = new CreateResponse<ApiPostsResponseModel>(await this.postsModelValidator.ValidateCreateAsync(model));
                        if (response.Success)
                        {
                                var bo = this.bolPostsMapper.MapModelToBO(default(int), model);
                                var record = await this.postsRepository.Create(this.dalPostsMapper.MapBOToEF(bo));

                                response.SetRecord(this.bolPostsMapper.MapBOToModel(this.dalPostsMapper.MapEFToBO(record)));
                        }

                        return response;
                }

                public virtual async Task<ActionResponse> Update(
                        int id,
                        ApiPostsRequestModel model)
                {
                        ActionResponse response = new ActionResponse(await this.postsModelValidator.ValidateUpdateAsync(id, model));
                        if (response.Success)
                        {
                                var bo = this.bolPostsMapper.MapModelToBO(id, model);
                                await this.postsRepository.Update(this.dalPostsMapper.MapBOToEF(bo));
                        }

                        return response;
                }

                public virtual async Task<ActionResponse> Delete(
                        int id)
                {
                        ActionResponse response = new ActionResponse(await this.postsModelValidator.ValidateDeleteAsync(id));
                        if (response.Success)
                        {
                                await this.postsRepository.Delete(id);
                        }

                        return response;
                }
        }
}

/*<Codenesium>
    <Hash>ad63260a254e9e49abca0033925e5bfb</Hash>
</Codenesium>*/