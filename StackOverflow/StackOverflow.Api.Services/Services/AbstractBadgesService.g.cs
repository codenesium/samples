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
        public abstract class AbstractBadgesService : AbstractService
        {
                private IBadgesRepository badgesRepository;

                private IApiBadgesRequestModelValidator badgesModelValidator;

                private IBOLBadgesMapper bolBadgesMapper;

                private IDALBadgesMapper dalBadgesMapper;

                private ILogger logger;

                public AbstractBadgesService(
                        ILogger logger,
                        IBadgesRepository badgesRepository,
                        IApiBadgesRequestModelValidator badgesModelValidator,
                        IBOLBadgesMapper bolBadgesMapper,
                        IDALBadgesMapper dalBadgesMapper)
                        : base()
                {
                        this.badgesRepository = badgesRepository;
                        this.badgesModelValidator = badgesModelValidator;
                        this.bolBadgesMapper = bolBadgesMapper;
                        this.dalBadgesMapper = dalBadgesMapper;
                        this.logger = logger;
                }

                public virtual async Task<List<ApiBadgesResponseModel>> All(int limit = 0, int offset = int.MaxValue)
                {
                        var records = await this.badgesRepository.All(limit, offset);

                        return this.bolBadgesMapper.MapBOToModel(this.dalBadgesMapper.MapEFToBO(records));
                }

                public virtual async Task<ApiBadgesResponseModel> Get(int id)
                {
                        var record = await this.badgesRepository.Get(id);

                        if (record == null)
                        {
                                return null;
                        }
                        else
                        {
                                return this.bolBadgesMapper.MapBOToModel(this.dalBadgesMapper.MapEFToBO(record));
                        }
                }

                public virtual async Task<CreateResponse<ApiBadgesResponseModel>> Create(
                        ApiBadgesRequestModel model)
                {
                        CreateResponse<ApiBadgesResponseModel> response = new CreateResponse<ApiBadgesResponseModel>(await this.badgesModelValidator.ValidateCreateAsync(model));
                        if (response.Success)
                        {
                                var bo = this.bolBadgesMapper.MapModelToBO(default(int), model);
                                var record = await this.badgesRepository.Create(this.dalBadgesMapper.MapBOToEF(bo));

                                response.SetRecord(this.bolBadgesMapper.MapBOToModel(this.dalBadgesMapper.MapEFToBO(record)));
                        }

                        return response;
                }

                public virtual async Task<UpdateResponse<ApiBadgesResponseModel>> Update(
                        int id,
                        ApiBadgesRequestModel model)
                {
                        var validationResult = await this.badgesModelValidator.ValidateUpdateAsync(id, model);

                        if (validationResult.IsValid)
                        {
                                var bo = this.bolBadgesMapper.MapModelToBO(id, model);
                                await this.badgesRepository.Update(this.dalBadgesMapper.MapBOToEF(bo));

                                var record = await this.badgesRepository.Get(id);

                                return new UpdateResponse<ApiBadgesResponseModel>(this.bolBadgesMapper.MapBOToModel(this.dalBadgesMapper.MapEFToBO(record)));
                        }
                        else
                        {
                                return new UpdateResponse<ApiBadgesResponseModel>(validationResult);
                        }
                }

                public virtual async Task<ActionResponse> Delete(
                        int id)
                {
                        ActionResponse response = new ActionResponse(await this.badgesModelValidator.ValidateDeleteAsync(id));
                        if (response.Success)
                        {
                                await this.badgesRepository.Delete(id);
                        }

                        return response;
                }
        }
}

/*<Codenesium>
    <Hash>a623aa2955ffb381663db60f901841eb</Hash>
</Codenesium>*/