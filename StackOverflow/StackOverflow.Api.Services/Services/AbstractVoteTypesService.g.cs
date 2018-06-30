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
        public abstract class AbstractVoteTypesService : AbstractService
        {
                private IVoteTypesRepository voteTypesRepository;

                private IApiVoteTypesRequestModelValidator voteTypesModelValidator;

                private IBOLVoteTypesMapper bolVoteTypesMapper;

                private IDALVoteTypesMapper dalVoteTypesMapper;

                private ILogger logger;

                public AbstractVoteTypesService(
                        ILogger logger,
                        IVoteTypesRepository voteTypesRepository,
                        IApiVoteTypesRequestModelValidator voteTypesModelValidator,
                        IBOLVoteTypesMapper bolVoteTypesMapper,
                        IDALVoteTypesMapper dalVoteTypesMapper)
                        : base()
                {
                        this.voteTypesRepository = voteTypesRepository;
                        this.voteTypesModelValidator = voteTypesModelValidator;
                        this.bolVoteTypesMapper = bolVoteTypesMapper;
                        this.dalVoteTypesMapper = dalVoteTypesMapper;
                        this.logger = logger;
                }

                public virtual async Task<List<ApiVoteTypesResponseModel>> All(int limit = 0, int offset = int.MaxValue)
                {
                        var records = await this.voteTypesRepository.All(limit, offset);

                        return this.bolVoteTypesMapper.MapBOToModel(this.dalVoteTypesMapper.MapEFToBO(records));
                }

                public virtual async Task<ApiVoteTypesResponseModel> Get(int id)
                {
                        var record = await this.voteTypesRepository.Get(id);

                        if (record == null)
                        {
                                return null;
                        }
                        else
                        {
                                return this.bolVoteTypesMapper.MapBOToModel(this.dalVoteTypesMapper.MapEFToBO(record));
                        }
                }

                public virtual async Task<CreateResponse<ApiVoteTypesResponseModel>> Create(
                        ApiVoteTypesRequestModel model)
                {
                        CreateResponse<ApiVoteTypesResponseModel> response = new CreateResponse<ApiVoteTypesResponseModel>(await this.voteTypesModelValidator.ValidateCreateAsync(model));
                        if (response.Success)
                        {
                                var bo = this.bolVoteTypesMapper.MapModelToBO(default(int), model);
                                var record = await this.voteTypesRepository.Create(this.dalVoteTypesMapper.MapBOToEF(bo));

                                response.SetRecord(this.bolVoteTypesMapper.MapBOToModel(this.dalVoteTypesMapper.MapEFToBO(record)));
                        }

                        return response;
                }

                public virtual async Task<ActionResponse> Update(
                        int id,
                        ApiVoteTypesRequestModel model)
                {
                        ActionResponse response = new ActionResponse(await this.voteTypesModelValidator.ValidateUpdateAsync(id, model));
                        if (response.Success)
                        {
                                var bo = this.bolVoteTypesMapper.MapModelToBO(id, model);
                                await this.voteTypesRepository.Update(this.dalVoteTypesMapper.MapBOToEF(bo));
                        }

                        return response;
                }

                public virtual async Task<ActionResponse> Delete(
                        int id)
                {
                        ActionResponse response = new ActionResponse(await this.voteTypesModelValidator.ValidateDeleteAsync(id));
                        if (response.Success)
                        {
                                await this.voteTypesRepository.Delete(id);
                        }

                        return response;
                }
        }
}

/*<Codenesium>
    <Hash>03af13519667ac4d64ca8fddde94227e</Hash>
</Codenesium>*/