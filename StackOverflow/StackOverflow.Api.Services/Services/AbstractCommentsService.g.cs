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
        public abstract class AbstractCommentsService : AbstractService
        {
                private ICommentsRepository commentsRepository;

                private IApiCommentsRequestModelValidator commentsModelValidator;

                private IBOLCommentsMapper bolCommentsMapper;

                private IDALCommentsMapper dalCommentsMapper;

                private ILogger logger;

                public AbstractCommentsService(
                        ILogger logger,
                        ICommentsRepository commentsRepository,
                        IApiCommentsRequestModelValidator commentsModelValidator,
                        IBOLCommentsMapper bolCommentsMapper,
                        IDALCommentsMapper dalCommentsMapper)
                        : base()
                {
                        this.commentsRepository = commentsRepository;
                        this.commentsModelValidator = commentsModelValidator;
                        this.bolCommentsMapper = bolCommentsMapper;
                        this.dalCommentsMapper = dalCommentsMapper;
                        this.logger = logger;
                }

                public virtual async Task<List<ApiCommentsResponseModel>> All(int limit = 0, int offset = int.MaxValue)
                {
                        var records = await this.commentsRepository.All(limit, offset);

                        return this.bolCommentsMapper.MapBOToModel(this.dalCommentsMapper.MapEFToBO(records));
                }

                public virtual async Task<ApiCommentsResponseModel> Get(int id)
                {
                        var record = await this.commentsRepository.Get(id);

                        if (record == null)
                        {
                                return null;
                        }
                        else
                        {
                                return this.bolCommentsMapper.MapBOToModel(this.dalCommentsMapper.MapEFToBO(record));
                        }
                }

                public virtual async Task<CreateResponse<ApiCommentsResponseModel>> Create(
                        ApiCommentsRequestModel model)
                {
                        CreateResponse<ApiCommentsResponseModel> response = new CreateResponse<ApiCommentsResponseModel>(await this.commentsModelValidator.ValidateCreateAsync(model));
                        if (response.Success)
                        {
                                var bo = this.bolCommentsMapper.MapModelToBO(default(int), model);
                                var record = await this.commentsRepository.Create(this.dalCommentsMapper.MapBOToEF(bo));

                                response.SetRecord(this.bolCommentsMapper.MapBOToModel(this.dalCommentsMapper.MapEFToBO(record)));
                        }

                        return response;
                }

                public virtual async Task<UpdateResponse<ApiCommentsResponseModel>> Update(
                        int id,
                        ApiCommentsRequestModel model)
                {
                        var validationResult = await this.commentsModelValidator.ValidateUpdateAsync(id, model);

                        if (validationResult.IsValid)
                        {
                                var bo = this.bolCommentsMapper.MapModelToBO(id, model);
                                await this.commentsRepository.Update(this.dalCommentsMapper.MapBOToEF(bo));

                                var record = await this.commentsRepository.Get(id);

                                return new UpdateResponse<ApiCommentsResponseModel>(this.bolCommentsMapper.MapBOToModel(this.dalCommentsMapper.MapEFToBO(record)));
                        }
                        else
                        {
                                return new UpdateResponse<ApiCommentsResponseModel>(validationResult);
                        }
                }

                public virtual async Task<ActionResponse> Delete(
                        int id)
                {
                        ActionResponse response = new ActionResponse(await this.commentsModelValidator.ValidateDeleteAsync(id));
                        if (response.Success)
                        {
                                await this.commentsRepository.Delete(id);
                        }

                        return response;
                }
        }
}

/*<Codenesium>
    <Hash>db7b0136275361ed148c5aac4c47e2f2</Hash>
</Codenesium>*/