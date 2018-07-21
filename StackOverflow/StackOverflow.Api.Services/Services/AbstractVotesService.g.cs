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
        public abstract class AbstractVotesService : AbstractService
        {
                private IVotesRepository votesRepository;

                private IApiVotesRequestModelValidator votesModelValidator;

                private IBOLVotesMapper bolVotesMapper;

                private IDALVotesMapper dalVotesMapper;

                private ILogger logger;

                public AbstractVotesService(
                        ILogger logger,
                        IVotesRepository votesRepository,
                        IApiVotesRequestModelValidator votesModelValidator,
                        IBOLVotesMapper bolVotesMapper,
                        IDALVotesMapper dalVotesMapper)
                        : base()
                {
                        this.votesRepository = votesRepository;
                        this.votesModelValidator = votesModelValidator;
                        this.bolVotesMapper = bolVotesMapper;
                        this.dalVotesMapper = dalVotesMapper;
                        this.logger = logger;
                }

                public virtual async Task<List<ApiVotesResponseModel>> All(int limit = 0, int offset = int.MaxValue)
                {
                        var records = await this.votesRepository.All(limit, offset);

                        return this.bolVotesMapper.MapBOToModel(this.dalVotesMapper.MapEFToBO(records));
                }

                public virtual async Task<ApiVotesResponseModel> Get(int id)
                {
                        var record = await this.votesRepository.Get(id);

                        if (record == null)
                        {
                                return null;
                        }
                        else
                        {
                                return this.bolVotesMapper.MapBOToModel(this.dalVotesMapper.MapEFToBO(record));
                        }
                }

                public virtual async Task<CreateResponse<ApiVotesResponseModel>> Create(
                        ApiVotesRequestModel model)
                {
                        CreateResponse<ApiVotesResponseModel> response = new CreateResponse<ApiVotesResponseModel>(await this.votesModelValidator.ValidateCreateAsync(model));
                        if (response.Success)
                        {
                                var bo = this.bolVotesMapper.MapModelToBO(default(int), model);
                                var record = await this.votesRepository.Create(this.dalVotesMapper.MapBOToEF(bo));

                                response.SetRecord(this.bolVotesMapper.MapBOToModel(this.dalVotesMapper.MapEFToBO(record)));
                        }

                        return response;
                }

                public virtual async Task<UpdateResponse<ApiVotesResponseModel>> Update(
                        int id,
                        ApiVotesRequestModel model)
                {
                        var validationResult = await this.votesModelValidator.ValidateUpdateAsync(id, model);

                        if (validationResult.IsValid)
                        {
                                var bo = this.bolVotesMapper.MapModelToBO(id, model);
                                await this.votesRepository.Update(this.dalVotesMapper.MapBOToEF(bo));

                                var record = await this.votesRepository.Get(id);

                                return new UpdateResponse<ApiVotesResponseModel>(this.bolVotesMapper.MapBOToModel(this.dalVotesMapper.MapEFToBO(record)));
                        }
                        else
                        {
                                return new UpdateResponse<ApiVotesResponseModel>(validationResult);
                        }
                }

                public virtual async Task<ActionResponse> Delete(
                        int id)
                {
                        ActionResponse response = new ActionResponse(await this.votesModelValidator.ValidateDeleteAsync(id));
                        if (response.Success)
                        {
                                await this.votesRepository.Delete(id);
                        }

                        return response;
                }
        }
}

/*<Codenesium>
    <Hash>6ca8ff52e533de8566040c3085c32416</Hash>
</Codenesium>*/