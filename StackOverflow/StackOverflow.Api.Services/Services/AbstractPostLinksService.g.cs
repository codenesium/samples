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
        public abstract class AbstractPostLinksService : AbstractService
        {
                private IPostLinksRepository postLinksRepository;

                private IApiPostLinksRequestModelValidator postLinksModelValidator;

                private IBOLPostLinksMapper bolPostLinksMapper;

                private IDALPostLinksMapper dalPostLinksMapper;

                private ILogger logger;

                public AbstractPostLinksService(
                        ILogger logger,
                        IPostLinksRepository postLinksRepository,
                        IApiPostLinksRequestModelValidator postLinksModelValidator,
                        IBOLPostLinksMapper bolPostLinksMapper,
                        IDALPostLinksMapper dalPostLinksMapper)
                        : base()
                {
                        this.postLinksRepository = postLinksRepository;
                        this.postLinksModelValidator = postLinksModelValidator;
                        this.bolPostLinksMapper = bolPostLinksMapper;
                        this.dalPostLinksMapper = dalPostLinksMapper;
                        this.logger = logger;
                }

                public virtual async Task<List<ApiPostLinksResponseModel>> All(int limit = 0, int offset = int.MaxValue)
                {
                        var records = await this.postLinksRepository.All(limit, offset);

                        return this.bolPostLinksMapper.MapBOToModel(this.dalPostLinksMapper.MapEFToBO(records));
                }

                public virtual async Task<ApiPostLinksResponseModel> Get(int id)
                {
                        var record = await this.postLinksRepository.Get(id);

                        if (record == null)
                        {
                                return null;
                        }
                        else
                        {
                                return this.bolPostLinksMapper.MapBOToModel(this.dalPostLinksMapper.MapEFToBO(record));
                        }
                }

                public virtual async Task<CreateResponse<ApiPostLinksResponseModel>> Create(
                        ApiPostLinksRequestModel model)
                {
                        CreateResponse<ApiPostLinksResponseModel> response = new CreateResponse<ApiPostLinksResponseModel>(await this.postLinksModelValidator.ValidateCreateAsync(model));
                        if (response.Success)
                        {
                                var bo = this.bolPostLinksMapper.MapModelToBO(default(int), model);
                                var record = await this.postLinksRepository.Create(this.dalPostLinksMapper.MapBOToEF(bo));

                                response.SetRecord(this.bolPostLinksMapper.MapBOToModel(this.dalPostLinksMapper.MapEFToBO(record)));
                        }

                        return response;
                }

                public virtual async Task<UpdateResponse<ApiPostLinksResponseModel>> Update(
                        int id,
                        ApiPostLinksRequestModel model)
                {
                        var validationResult = await this.postLinksModelValidator.ValidateUpdateAsync(id, model);

                        if (validationResult.IsValid)
                        {
                                var bo = this.bolPostLinksMapper.MapModelToBO(id, model);
                                await this.postLinksRepository.Update(this.dalPostLinksMapper.MapBOToEF(bo));

                                var record = await this.postLinksRepository.Get(id);

                                return new UpdateResponse<ApiPostLinksResponseModel>(this.bolPostLinksMapper.MapBOToModel(this.dalPostLinksMapper.MapEFToBO(record)));
                        }
                        else
                        {
                                return new UpdateResponse<ApiPostLinksResponseModel>(validationResult);
                        }
                }

                public virtual async Task<ActionResponse> Delete(
                        int id)
                {
                        ActionResponse response = new ActionResponse(await this.postLinksModelValidator.ValidateDeleteAsync(id));
                        if (response.Success)
                        {
                                await this.postLinksRepository.Delete(id);
                        }

                        return response;
                }
        }
}

/*<Codenesium>
    <Hash>2a567e92f3fa4e6040a4bf84c44be9fc</Hash>
</Codenesium>*/