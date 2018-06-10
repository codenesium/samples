using Codenesium.DataConversionExtensions.AspNetCore;
using System;
using System.Collections.Generic;
using Microsoft.Extensions.Logging;
using Microsoft.EntityFrameworkCore;
using System.Linq;
using System.Linq.Dynamic.Core;
using System.Linq.Expressions;
using System.Threading.Tasks;
using TicketingCRMNS.Api.Contracts;
using TicketingCRMNS.Api.DataAccess;

namespace TicketingCRMNS.Api.Services
{
        public abstract class AbstractCityService: AbstractService
        {
                private ICityRepository cityRepository;

                private IApiCityRequestModelValidator cityModelValidator;

                private IBOLCityMapper bolCityMapper;

                private IDALCityMapper dalCityMapper;

                private ILogger logger;

                public AbstractCityService(
                        ILogger logger,
                        ICityRepository cityRepository,
                        IApiCityRequestModelValidator cityModelValidator,
                        IBOLCityMapper bolcityMapper,
                        IDALCityMapper dalcityMapper)
                        : base()

                {
                        this.cityRepository = cityRepository;
                        this.cityModelValidator = cityModelValidator;
                        this.bolCityMapper = bolcityMapper;
                        this.dalCityMapper = dalcityMapper;
                        this.logger = logger;
                }

                public virtual async Task<List<ApiCityResponseModel>> All(int skip = 0, int take = int.MaxValue, string orderClause = "")
                {
                        var records = await this.cityRepository.All(skip, take, orderClause);

                        return this.bolCityMapper.MapBOToModel(this.dalCityMapper.MapEFToBO(records));
                }

                public virtual async Task<ApiCityResponseModel> Get(int id)
                {
                        var record = await this.cityRepository.Get(id);

                        return this.bolCityMapper.MapBOToModel(this.dalCityMapper.MapEFToBO(record));
                }

                public virtual async Task<CreateResponse<ApiCityResponseModel>> Create(
                        ApiCityRequestModel model)
                {
                        CreateResponse<ApiCityResponseModel> response = new CreateResponse<ApiCityResponseModel>(await this.cityModelValidator.ValidateCreateAsync(model));
                        if (response.Success)
                        {
                                var bo = this.bolCityMapper.MapModelToBO(default (int), model);
                                var record = await this.cityRepository.Create(this.dalCityMapper.MapBOToEF(bo));

                                response.SetRecord(this.bolCityMapper.MapBOToModel(this.dalCityMapper.MapEFToBO(record)));
                        }

                        return response;
                }

                public virtual async Task<ActionResponse> Update(
                        int id,
                        ApiCityRequestModel model)
                {
                        ActionResponse response = new ActionResponse(await this.cityModelValidator.ValidateUpdateAsync(id, model));

                        if (response.Success)
                        {
                                var bo = this.bolCityMapper.MapModelToBO(id, model);
                                await this.cityRepository.Update(this.dalCityMapper.MapBOToEF(bo));
                        }

                        return response;
                }

                public virtual async Task<ActionResponse> Delete(
                        int id)
                {
                        ActionResponse response = new ActionResponse(await this.cityModelValidator.ValidateDeleteAsync(id));

                        if (response.Success)
                        {
                                await this.cityRepository.Delete(id);
                        }

                        return response;
                }

                public async Task<List<ApiCityResponseModel>> GetProvinceId(int provinceId)
                {
                        List<City> records = await this.cityRepository.GetProvinceId(provinceId);

                        return this.bolCityMapper.MapBOToModel(this.dalCityMapper.MapEFToBO(records));
                }
        }
}

/*<Codenesium>
    <Hash>793de3558aa14de7417e757e8738e3e4</Hash>
</Codenesium>*/