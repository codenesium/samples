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
        public abstract class AbstractAirlineService: AbstractService
        {
                private IAirlineRepository airlineRepository;

                private IApiAirlineRequestModelValidator airlineModelValidator;

                private IBOLAirlineMapper bolAirlineMapper;

                private IDALAirlineMapper dalAirlineMapper;

                private ILogger logger;

                public AbstractAirlineService(
                        ILogger logger,
                        IAirlineRepository airlineRepository,
                        IApiAirlineRequestModelValidator airlineModelValidator,
                        IBOLAirlineMapper bolAirlineMapper,
                        IDALAirlineMapper dalAirlineMapper

                        )
                        : base()

                {
                        this.airlineRepository = airlineRepository;
                        this.airlineModelValidator = airlineModelValidator;
                        this.bolAirlineMapper = bolAirlineMapper;
                        this.dalAirlineMapper = dalAirlineMapper;
                        this.logger = logger;
                }

                public virtual async Task<List<ApiAirlineResponseModel>> All(int limit = 0, int offset = int.MaxValue)
                {
                        var records = await this.airlineRepository.All(limit, offset);

                        return this.bolAirlineMapper.MapBOToModel(this.dalAirlineMapper.MapEFToBO(records));
                }

                public virtual async Task<ApiAirlineResponseModel> Get(int id)
                {
                        var record = await this.airlineRepository.Get(id);

                        if (record == null)
                        {
                                return null;
                        }
                        else
                        {
                                return this.bolAirlineMapper.MapBOToModel(this.dalAirlineMapper.MapEFToBO(record));
                        }
                }

                public virtual async Task<CreateResponse<ApiAirlineResponseModel>> Create(
                        ApiAirlineRequestModel model)
                {
                        CreateResponse<ApiAirlineResponseModel> response = new CreateResponse<ApiAirlineResponseModel>(await this.airlineModelValidator.ValidateCreateAsync(model));
                        if (response.Success)
                        {
                                var bo = this.bolAirlineMapper.MapModelToBO(default (int), model);
                                var record = await this.airlineRepository.Create(this.dalAirlineMapper.MapBOToEF(bo));

                                response.SetRecord(this.bolAirlineMapper.MapBOToModel(this.dalAirlineMapper.MapEFToBO(record)));
                        }

                        return response;
                }

                public virtual async Task<ActionResponse> Update(
                        int id,
                        ApiAirlineRequestModel model)
                {
                        ActionResponse response = new ActionResponse(await this.airlineModelValidator.ValidateUpdateAsync(id, model));

                        if (response.Success)
                        {
                                var bo = this.bolAirlineMapper.MapModelToBO(id, model);
                                await this.airlineRepository.Update(this.dalAirlineMapper.MapBOToEF(bo));
                        }

                        return response;
                }

                public virtual async Task<ActionResponse> Delete(
                        int id)
                {
                        ActionResponse response = new ActionResponse(await this.airlineModelValidator.ValidateDeleteAsync(id));

                        if (response.Success)
                        {
                                await this.airlineRepository.Delete(id);
                        }

                        return response;
                }
        }
}

/*<Codenesium>
    <Hash>99bc21d5352c0901fa733209bc17cf4e</Hash>
</Codenesium>*/