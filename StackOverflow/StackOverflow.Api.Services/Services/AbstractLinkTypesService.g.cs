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
        public abstract class AbstractLinkTypesService : AbstractService
        {
                private ILinkTypesRepository linkTypesRepository;

                private IApiLinkTypesRequestModelValidator linkTypesModelValidator;

                private IBOLLinkTypesMapper bolLinkTypesMapper;

                private IDALLinkTypesMapper dalLinkTypesMapper;

                private ILogger logger;

                public AbstractLinkTypesService(
                        ILogger logger,
                        ILinkTypesRepository linkTypesRepository,
                        IApiLinkTypesRequestModelValidator linkTypesModelValidator,
                        IBOLLinkTypesMapper bolLinkTypesMapper,
                        IDALLinkTypesMapper dalLinkTypesMapper)
                        : base()
                {
                        this.linkTypesRepository = linkTypesRepository;
                        this.linkTypesModelValidator = linkTypesModelValidator;
                        this.bolLinkTypesMapper = bolLinkTypesMapper;
                        this.dalLinkTypesMapper = dalLinkTypesMapper;
                        this.logger = logger;
                }

                public virtual async Task<List<ApiLinkTypesResponseModel>> All(int limit = 0, int offset = int.MaxValue)
                {
                        var records = await this.linkTypesRepository.All(limit, offset);

                        return this.bolLinkTypesMapper.MapBOToModel(this.dalLinkTypesMapper.MapEFToBO(records));
                }

                public virtual async Task<ApiLinkTypesResponseModel> Get(int id)
                {
                        var record = await this.linkTypesRepository.Get(id);

                        if (record == null)
                        {
                                return null;
                        }
                        else
                        {
                                return this.bolLinkTypesMapper.MapBOToModel(this.dalLinkTypesMapper.MapEFToBO(record));
                        }
                }

                public virtual async Task<CreateResponse<ApiLinkTypesResponseModel>> Create(
                        ApiLinkTypesRequestModel model)
                {
                        CreateResponse<ApiLinkTypesResponseModel> response = new CreateResponse<ApiLinkTypesResponseModel>(await this.linkTypesModelValidator.ValidateCreateAsync(model));
                        if (response.Success)
                        {
                                var bo = this.bolLinkTypesMapper.MapModelToBO(default(int), model);
                                var record = await this.linkTypesRepository.Create(this.dalLinkTypesMapper.MapBOToEF(bo));

                                response.SetRecord(this.bolLinkTypesMapper.MapBOToModel(this.dalLinkTypesMapper.MapEFToBO(record)));
                        }

                        return response;
                }

                public virtual async Task<ActionResponse> Update(
                        int id,
                        ApiLinkTypesRequestModel model)
                {
                        ActionResponse response = new ActionResponse(await this.linkTypesModelValidator.ValidateUpdateAsync(id, model));
                        if (response.Success)
                        {
                                var bo = this.bolLinkTypesMapper.MapModelToBO(id, model);
                                await this.linkTypesRepository.Update(this.dalLinkTypesMapper.MapBOToEF(bo));
                        }

                        return response;
                }

                public virtual async Task<ActionResponse> Delete(
                        int id)
                {
                        ActionResponse response = new ActionResponse(await this.linkTypesModelValidator.ValidateDeleteAsync(id));
                        if (response.Success)
                        {
                                await this.linkTypesRepository.Delete(id);
                        }

                        return response;
                }
        }
}

/*<Codenesium>
    <Hash>bc96157684532244a9384e89db132411</Hash>
</Codenesium>*/