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
        public abstract class AbstractTagsService : AbstractService
        {
                private ITagsRepository tagsRepository;

                private IApiTagsRequestModelValidator tagsModelValidator;

                private IBOLTagsMapper bolTagsMapper;

                private IDALTagsMapper dalTagsMapper;

                private ILogger logger;

                public AbstractTagsService(
                        ILogger logger,
                        ITagsRepository tagsRepository,
                        IApiTagsRequestModelValidator tagsModelValidator,
                        IBOLTagsMapper bolTagsMapper,
                        IDALTagsMapper dalTagsMapper)
                        : base()
                {
                        this.tagsRepository = tagsRepository;
                        this.tagsModelValidator = tagsModelValidator;
                        this.bolTagsMapper = bolTagsMapper;
                        this.dalTagsMapper = dalTagsMapper;
                        this.logger = logger;
                }

                public virtual async Task<List<ApiTagsResponseModel>> All(int limit = 0, int offset = int.MaxValue)
                {
                        var records = await this.tagsRepository.All(limit, offset);

                        return this.bolTagsMapper.MapBOToModel(this.dalTagsMapper.MapEFToBO(records));
                }

                public virtual async Task<ApiTagsResponseModel> Get(int id)
                {
                        var record = await this.tagsRepository.Get(id);

                        if (record == null)
                        {
                                return null;
                        }
                        else
                        {
                                return this.bolTagsMapper.MapBOToModel(this.dalTagsMapper.MapEFToBO(record));
                        }
                }

                public virtual async Task<CreateResponse<ApiTagsResponseModel>> Create(
                        ApiTagsRequestModel model)
                {
                        CreateResponse<ApiTagsResponseModel> response = new CreateResponse<ApiTagsResponseModel>(await this.tagsModelValidator.ValidateCreateAsync(model));
                        if (response.Success)
                        {
                                var bo = this.bolTagsMapper.MapModelToBO(default(int), model);
                                var record = await this.tagsRepository.Create(this.dalTagsMapper.MapBOToEF(bo));

                                response.SetRecord(this.bolTagsMapper.MapBOToModel(this.dalTagsMapper.MapEFToBO(record)));
                        }

                        return response;
                }

                public virtual async Task<ActionResponse> Update(
                        int id,
                        ApiTagsRequestModel model)
                {
                        ActionResponse response = new ActionResponse(await this.tagsModelValidator.ValidateUpdateAsync(id, model));
                        if (response.Success)
                        {
                                var bo = this.bolTagsMapper.MapModelToBO(id, model);
                                await this.tagsRepository.Update(this.dalTagsMapper.MapBOToEF(bo));
                        }

                        return response;
                }

                public virtual async Task<ActionResponse> Delete(
                        int id)
                {
                        ActionResponse response = new ActionResponse(await this.tagsModelValidator.ValidateDeleteAsync(id));
                        if (response.Success)
                        {
                                await this.tagsRepository.Delete(id);
                        }

                        return response;
                }
        }
}

/*<Codenesium>
    <Hash>ebdd9bcbcab5aa87611036f78b744150</Hash>
</Codenesium>*/