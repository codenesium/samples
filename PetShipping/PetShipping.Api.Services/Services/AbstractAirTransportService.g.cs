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
                        IBOLAirTransportMapper bolAirTransportMapper,
                        IDALAirTransportMapper dalAirTransportMapper

                        )
                        : base()

                {
                        this.airTransportRepository = airTransportRepository;
                        this.airTransportModelValidator = airTransportModelValidator;
                        this.bolAirTransportMapper = bolAirTransportMapper;
                        this.dalAirTransportMapper = dalAirTransportMapper;
                        this.logger = logger;
                }

                public virtual async Task<List<ApiAirTransportResponseModel>> All(int limit = 0, int offset = int.MaxValue)
                {
                        var records = await this.airTransportRepository.All(limit, offset);

                        return this.bolAirTransportMapper.MapBOToModel(this.dalAirTransportMapper.MapEFToBO(records));
                }

                public virtual async Task<ApiAirTransportResponseModel> Get(int airlineId)
                {
                        var record = await this.airTransportRepository.Get(airlineId);

                        if (record == null)
                        {
                                return null;
                        }
                        else
                        {
                                return this.bolAirTransportMapper.MapBOToModel(this.dalAirTransportMapper.MapEFToBO(record));
                        }
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
    <Hash>dfd4f18f8bcbd6d3c722d5022b8cf149</Hash>
</Codenesium>*/