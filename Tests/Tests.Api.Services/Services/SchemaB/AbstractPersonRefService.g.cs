using Codenesium.DataConversionExtensions;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Dynamic.Core;
using System.Linq.Expressions;
using System.Threading.Tasks;
using TestsNS.Api.Contracts;
using TestsNS.Api.DataAccess;

namespace TestsNS.Api.Services
{
        public abstract class AbstractPersonRefService : AbstractService
        {
                private IPersonRefRepository personRefRepository;

                private IApiPersonRefRequestModelValidator personRefModelValidator;

                private IBOLPersonRefMapper bolPersonRefMapper;

                private IDALPersonRefMapper dalPersonRefMapper;

                private ILogger logger;

                public AbstractPersonRefService(
                        ILogger logger,
                        IPersonRefRepository personRefRepository,
                        IApiPersonRefRequestModelValidator personRefModelValidator,
                        IBOLPersonRefMapper bolPersonRefMapper,
                        IDALPersonRefMapper dalPersonRefMapper)
                        : base()
                {
                        this.personRefRepository = personRefRepository;
                        this.personRefModelValidator = personRefModelValidator;
                        this.bolPersonRefMapper = bolPersonRefMapper;
                        this.dalPersonRefMapper = dalPersonRefMapper;
                        this.logger = logger;
                }

                public virtual async Task<List<ApiPersonRefResponseModel>> All(int limit = 0, int offset = int.MaxValue)
                {
                        var records = await this.personRefRepository.All(limit, offset);

                        return this.bolPersonRefMapper.MapBOToModel(this.dalPersonRefMapper.MapEFToBO(records));
                }

                public virtual async Task<ApiPersonRefResponseModel> Get(int id)
                {
                        var record = await this.personRefRepository.Get(id);

                        if (record == null)
                        {
                                return null;
                        }
                        else
                        {
                                return this.bolPersonRefMapper.MapBOToModel(this.dalPersonRefMapper.MapEFToBO(record));
                        }
                }

                public virtual async Task<CreateResponse<ApiPersonRefResponseModel>> Create(
                        ApiPersonRefRequestModel model)
                {
                        CreateResponse<ApiPersonRefResponseModel> response = new CreateResponse<ApiPersonRefResponseModel>(await this.personRefModelValidator.ValidateCreateAsync(model));
                        if (response.Success)
                        {
                                var bo = this.bolPersonRefMapper.MapModelToBO(default(int), model);
                                var record = await this.personRefRepository.Create(this.dalPersonRefMapper.MapBOToEF(bo));

                                response.SetRecord(this.bolPersonRefMapper.MapBOToModel(this.dalPersonRefMapper.MapEFToBO(record)));
                        }

                        return response;
                }

                public virtual async Task<UpdateResponse<ApiPersonRefResponseModel>> Update(
                        int id,
                        ApiPersonRefRequestModel model)
                {
                        var validationResult = await this.personRefModelValidator.ValidateUpdateAsync(id, model);

                        if (validationResult.IsValid)
                        {
                                var bo = this.bolPersonRefMapper.MapModelToBO(id, model);
                                await this.personRefRepository.Update(this.dalPersonRefMapper.MapBOToEF(bo));

                                var record = await this.personRefRepository.Get(id);

                                return new UpdateResponse<ApiPersonRefResponseModel>(this.bolPersonRefMapper.MapBOToModel(this.dalPersonRefMapper.MapEFToBO(record)));
                        }
                        else
                        {
                                return new UpdateResponse<ApiPersonRefResponseModel>(validationResult);
                        }
                }

                public virtual async Task<ActionResponse> Delete(
                        int id)
                {
                        ActionResponse response = new ActionResponse(await this.personRefModelValidator.ValidateDeleteAsync(id));
                        if (response.Success)
                        {
                                await this.personRefRepository.Delete(id);
                        }

                        return response;
                }
        }
}

/*<Codenesium>
    <Hash>d63df7e24834ecc6cc3cab748e03ded7</Hash>
</Codenesium>*/