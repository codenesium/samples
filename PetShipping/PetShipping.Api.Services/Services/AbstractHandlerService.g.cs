using Codenesium.DataConversionExtensions.AspNetCore;
using System;
using System.Collections.Generic;
using Microsoft.Extensions.Logging;
using Microsoft.EntityFrameworkCore;
using System.Linq;
using System.Linq.Dynamic.Core;
using System.Linq.Expressions;
using System.Threading.Tasks;
using PetShippingNS.Api.Contracts;
using PetShippingNS.Api.DataAccess;

namespace PetShippingNS.Api.Services
{
        public abstract class AbstractHandlerService: AbstractService
        {
                private IHandlerRepository handlerRepository;

                private IApiHandlerRequestModelValidator handlerModelValidator;

                private IBOLHandlerMapper bolHandlerMapper;

                private IDALHandlerMapper dalHandlerMapper;

                private ILogger logger;

                public AbstractHandlerService(
                        ILogger logger,
                        IHandlerRepository handlerRepository,
                        IApiHandlerRequestModelValidator handlerModelValidator,
                        IBOLHandlerMapper bolhandlerMapper,
                        IDALHandlerMapper dalhandlerMapper)
                        : base()

                {
                        this.handlerRepository = handlerRepository;
                        this.handlerModelValidator = handlerModelValidator;
                        this.bolHandlerMapper = bolhandlerMapper;
                        this.dalHandlerMapper = dalhandlerMapper;
                        this.logger = logger;
                }

                public virtual async Task<List<ApiHandlerResponseModel>> All(int skip = 0, int take = int.MaxValue, string orderClause = "")
                {
                        var records = await this.handlerRepository.All(skip, take, orderClause);

                        return this.bolHandlerMapper.MapBOToModel(this.dalHandlerMapper.MapEFToBO(records));
                }

                public virtual async Task<ApiHandlerResponseModel> Get(int id)
                {
                        var record = await this.handlerRepository.Get(id);

                        return this.bolHandlerMapper.MapBOToModel(this.dalHandlerMapper.MapEFToBO(record));
                }

                public virtual async Task<CreateResponse<ApiHandlerResponseModel>> Create(
                        ApiHandlerRequestModel model)
                {
                        CreateResponse<ApiHandlerResponseModel> response = new CreateResponse<ApiHandlerResponseModel>(await this.handlerModelValidator.ValidateCreateAsync(model));
                        if (response.Success)
                        {
                                var bo = this.bolHandlerMapper.MapModelToBO(default (int), model);
                                var record = await this.handlerRepository.Create(this.dalHandlerMapper.MapBOToEF(bo));

                                response.SetRecord(this.bolHandlerMapper.MapBOToModel(this.dalHandlerMapper.MapEFToBO(record)));
                        }

                        return response;
                }

                public virtual async Task<ActionResponse> Update(
                        int id,
                        ApiHandlerRequestModel model)
                {
                        ActionResponse response = new ActionResponse(await this.handlerModelValidator.ValidateUpdateAsync(id, model));

                        if (response.Success)
                        {
                                var bo = this.bolHandlerMapper.MapModelToBO(id, model);
                                await this.handlerRepository.Update(this.dalHandlerMapper.MapBOToEF(bo));
                        }

                        return response;
                }

                public virtual async Task<ActionResponse> Delete(
                        int id)
                {
                        ActionResponse response = new ActionResponse(await this.handlerModelValidator.ValidateDeleteAsync(id));

                        if (response.Success)
                        {
                                await this.handlerRepository.Delete(id);
                        }

                        return response;
                }
        }
}

/*<Codenesium>
    <Hash>977331a6701539af914b8a46191031f7</Hash>
</Codenesium>*/