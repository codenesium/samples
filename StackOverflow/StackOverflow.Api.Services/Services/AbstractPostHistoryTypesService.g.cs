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
        public abstract class AbstractPostHistoryTypesService : AbstractService
        {
                private IPostHistoryTypesRepository postHistoryTypesRepository;

                private IApiPostHistoryTypesRequestModelValidator postHistoryTypesModelValidator;

                private IBOLPostHistoryTypesMapper bolPostHistoryTypesMapper;

                private IDALPostHistoryTypesMapper dalPostHistoryTypesMapper;

                private ILogger logger;

                public AbstractPostHistoryTypesService(
                        ILogger logger,
                        IPostHistoryTypesRepository postHistoryTypesRepository,
                        IApiPostHistoryTypesRequestModelValidator postHistoryTypesModelValidator,
                        IBOLPostHistoryTypesMapper bolPostHistoryTypesMapper,
                        IDALPostHistoryTypesMapper dalPostHistoryTypesMapper)
                        : base()
                {
                        this.postHistoryTypesRepository = postHistoryTypesRepository;
                        this.postHistoryTypesModelValidator = postHistoryTypesModelValidator;
                        this.bolPostHistoryTypesMapper = bolPostHistoryTypesMapper;
                        this.dalPostHistoryTypesMapper = dalPostHistoryTypesMapper;
                        this.logger = logger;
                }

                public virtual async Task<List<ApiPostHistoryTypesResponseModel>> All(int limit = 0, int offset = int.MaxValue)
                {
                        var records = await this.postHistoryTypesRepository.All(limit, offset);

                        return this.bolPostHistoryTypesMapper.MapBOToModel(this.dalPostHistoryTypesMapper.MapEFToBO(records));
                }

                public virtual async Task<ApiPostHistoryTypesResponseModel> Get(int id)
                {
                        var record = await this.postHistoryTypesRepository.Get(id);

                        if (record == null)
                        {
                                return null;
                        }
                        else
                        {
                                return this.bolPostHistoryTypesMapper.MapBOToModel(this.dalPostHistoryTypesMapper.MapEFToBO(record));
                        }
                }

                public virtual async Task<CreateResponse<ApiPostHistoryTypesResponseModel>> Create(
                        ApiPostHistoryTypesRequestModel model)
                {
                        CreateResponse<ApiPostHistoryTypesResponseModel> response = new CreateResponse<ApiPostHistoryTypesResponseModel>(await this.postHistoryTypesModelValidator.ValidateCreateAsync(model));
                        if (response.Success)
                        {
                                var bo = this.bolPostHistoryTypesMapper.MapModelToBO(default(int), model);
                                var record = await this.postHistoryTypesRepository.Create(this.dalPostHistoryTypesMapper.MapBOToEF(bo));

                                response.SetRecord(this.bolPostHistoryTypesMapper.MapBOToModel(this.dalPostHistoryTypesMapper.MapEFToBO(record)));
                        }

                        return response;
                }

                public virtual async Task<UpdateResponse<ApiPostHistoryTypesResponseModel>> Update(
                        int id,
                        ApiPostHistoryTypesRequestModel model)
                {
                        var validationResult = await this.postHistoryTypesModelValidator.ValidateUpdateAsync(id, model);

                        if (validationResult.IsValid)
                        {
                                var bo = this.bolPostHistoryTypesMapper.MapModelToBO(id, model);
                                await this.postHistoryTypesRepository.Update(this.dalPostHistoryTypesMapper.MapBOToEF(bo));

                                var record = await this.postHistoryTypesRepository.Get(id);

                                return new UpdateResponse<ApiPostHistoryTypesResponseModel>(this.bolPostHistoryTypesMapper.MapBOToModel(this.dalPostHistoryTypesMapper.MapEFToBO(record)));
                        }
                        else
                        {
                                return new UpdateResponse<ApiPostHistoryTypesResponseModel>(validationResult);
                        }
                }

                public virtual async Task<ActionResponse> Delete(
                        int id)
                {
                        ActionResponse response = new ActionResponse(await this.postHistoryTypesModelValidator.ValidateDeleteAsync(id));
                        if (response.Success)
                        {
                                await this.postHistoryTypesRepository.Delete(id);
                        }

                        return response;
                }
        }
}

/*<Codenesium>
    <Hash>7fc4c90c035d16d7ff7e1942a67bc664</Hash>
</Codenesium>*/