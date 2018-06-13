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
        public abstract class AbstractProvinceService: AbstractService
        {
                private IProvinceRepository provinceRepository;

                private IApiProvinceRequestModelValidator provinceModelValidator;

                private IBOLProvinceMapper bolProvinceMapper;

                private IDALProvinceMapper dalProvinceMapper;

                private IBOLCityMapper bolCityMapper;

                private IDALCityMapper dalCityMapper;
                private IBOLVenueMapper bolVenueMapper;

                private IDALVenueMapper dalVenueMapper;

                private ILogger logger;

                public AbstractProvinceService(
                        ILogger logger,
                        IProvinceRepository provinceRepository,
                        IApiProvinceRequestModelValidator provinceModelValidator,
                        IBOLProvinceMapper bolProvinceMapper,
                        IDALProvinceMapper dalProvinceMapper

                        ,
                        IBOLCityMapper bolCityMapper,
                        IDALCityMapper dalCityMapper
                        ,
                        IBOLVenueMapper bolVenueMapper,
                        IDALVenueMapper dalVenueMapper

                        )
                        : base()

                {
                        this.provinceRepository = provinceRepository;
                        this.provinceModelValidator = provinceModelValidator;
                        this.bolProvinceMapper = bolProvinceMapper;
                        this.dalProvinceMapper = dalProvinceMapper;
                        this.bolCityMapper = bolCityMapper;
                        this.dalCityMapper = dalCityMapper;
                        this.bolVenueMapper = bolVenueMapper;
                        this.dalVenueMapper = dalVenueMapper;
                        this.logger = logger;
                }

                public virtual async Task<List<ApiProvinceResponseModel>> All(int limit = 0, int offset = int.MaxValue, string orderClause = "")
                {
                        var records = await this.provinceRepository.All(limit, offset, orderClause);

                        return this.bolProvinceMapper.MapBOToModel(this.dalProvinceMapper.MapEFToBO(records));
                }

                public virtual async Task<ApiProvinceResponseModel> Get(int id)
                {
                        var record = await this.provinceRepository.Get(id);

                        return this.bolProvinceMapper.MapBOToModel(this.dalProvinceMapper.MapEFToBO(record));
                }

                public virtual async Task<CreateResponse<ApiProvinceResponseModel>> Create(
                        ApiProvinceRequestModel model)
                {
                        CreateResponse<ApiProvinceResponseModel> response = new CreateResponse<ApiProvinceResponseModel>(await this.provinceModelValidator.ValidateCreateAsync(model));
                        if (response.Success)
                        {
                                var bo = this.bolProvinceMapper.MapModelToBO(default (int), model);
                                var record = await this.provinceRepository.Create(this.dalProvinceMapper.MapBOToEF(bo));

                                response.SetRecord(this.bolProvinceMapper.MapBOToModel(this.dalProvinceMapper.MapEFToBO(record)));
                        }

                        return response;
                }

                public virtual async Task<ActionResponse> Update(
                        int id,
                        ApiProvinceRequestModel model)
                {
                        ActionResponse response = new ActionResponse(await this.provinceModelValidator.ValidateUpdateAsync(id, model));

                        if (response.Success)
                        {
                                var bo = this.bolProvinceMapper.MapModelToBO(id, model);
                                await this.provinceRepository.Update(this.dalProvinceMapper.MapBOToEF(bo));
                        }

                        return response;
                }

                public virtual async Task<ActionResponse> Delete(
                        int id)
                {
                        ActionResponse response = new ActionResponse(await this.provinceModelValidator.ValidateDeleteAsync(id));

                        if (response.Success)
                        {
                                await this.provinceRepository.Delete(id);
                        }

                        return response;
                }

                public async Task<List<ApiProvinceResponseModel>> GetCountryId(int countryId)
                {
                        List<Province> records = await this.provinceRepository.GetCountryId(countryId);

                        return this.bolProvinceMapper.MapBOToModel(this.dalProvinceMapper.MapEFToBO(records));
                }

                public async virtual Task<List<ApiCityResponseModel>> Cities(int provinceId, int limit = int.MaxValue, int offset = 0)
                {
                        List<City> records = await this.provinceRepository.Cities(provinceId, limit, offset);

                        return this.bolCityMapper.MapBOToModel(this.dalCityMapper.MapEFToBO(records));
                }
                public async virtual Task<List<ApiVenueResponseModel>> Venues(int provinceId, int limit = int.MaxValue, int offset = 0)
                {
                        List<Venue> records = await this.provinceRepository.Venues(provinceId, limit, offset);

                        return this.bolVenueMapper.MapBOToModel(this.dalVenueMapper.MapEFToBO(records));
                }
        }
}

/*<Codenesium>
    <Hash>c09f25a50d31cfda028c6212e8fbb9b6</Hash>
</Codenesium>*/