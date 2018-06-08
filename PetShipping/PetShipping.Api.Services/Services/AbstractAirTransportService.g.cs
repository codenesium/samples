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
        public abstract class AbstractAirTransportService: AbstractService
        {
                private IAirTransportRepository airTransportRepository;

                private IApiAirTransportRequestModelValidator airTransportModelValidator;

                private IBOLAirTransportMapper bolAirTransportMapper;

                private IDALAirTransportMapper dalAirTransportMapper;

                private ILogger logger;

                public AbstractAirTransportService(
                        ILogger logger,
                        IAirTransportRepository airTransportRepository,
                        IApiAirTransportRequestModelValidator airTransportModelValidator,
                        IBOLAirTransportMapper bolairTransportMapper,
                        IDALAirTransportMapper dalairTransportMapper)
                        : base()

                {
                        this.airTransportRepository = airTransportRepository;
                        this.airTransportModelValidator = airTransportModelValidator;
                        this.bolAirTransportMapper = bolairTransportMapper;
                        this.dalAirTransportMapper = dalairTransportMapper;
                        this.logger = logger;
                }

                public virtual async Task<List<ApiAirTransportResponseModel>> All(int skip = 0, int take = int.MaxValue, string orderClause = "")
                {
                        var records = await this.airTransportRepository.All(skip, take, orderClause);

                        return this.bolAirTransportMapper.MapBOToModel(this.dalAirTransportMapper.MapEFToBO(records));
                }

                public virtual async Task<ApiAirTransportResponseModel> Get(int airlineId)
                {
                        var record = await this.airTransportRepository.Get(airlineId);

                        return this.bolAirTransportMapper.MapBOToModel(this.dalAirTransportMapper.MapEFToBO(record));
                }

                public virtual async Task<CreateResponse<ApiAirTransportResponseModel>> Create(
                        ApiAirTransportRequestModel model)
                {
                        CreateResponse<ApiAirTransportResponseModel> response = new CreateResponse<ApiAirTransportResponseModel>(await this.airTransportModelValidator.ValidateCreateAsync(model));
                        if (response.Success)
                        {
                                var bo = this.bolAirTransportMapper.MapModelToBO(default (int), model);
                                var record = await this.airTransportRepository.Create(this.dalAirTransportMapper.MapBOToEF(bo));

                                response.SetRecord(this.bolAirTransportMapper.MapBOToModel(this.dalAirTransportMapper.MapEFToBO(record)));
                        }

                        return response;
                }

                public virtual async Task<ActionResponse> Update(
                        int airlineId,
                        ApiAirTransportRequestModel model)
                {
                        ActionResponse response = new ActionResponse(await this.airTransportModelValidator.ValidateUpdateAsync(airlineId, model));

                        if (response.Success)
                        {
                                var bo = this.bolAirTransportMapper.MapModelToBO(airlineId, model);
                                await this.airTransportRepository.Update(this.dalAirTransportMapper.MapBOToEF(bo));
                        }

                        return response;
                }

                public virtual async Task<ActionResponse> Delete(
                        int airlineId)
                {
                        ActionResponse response = new ActionResponse(await this.airTransportModelValidator.ValidateDeleteAsync(airlineId));

                        if (response.Success)
                        {
                                await this.airTransportRepository.Delete(airlineId);
                        }

                        return response;
                }
        }
}

/*<Codenesium>
    <Hash>4a3f6afd57c887ac8376d621f62ca360</Hash>
</Codenesium>*/