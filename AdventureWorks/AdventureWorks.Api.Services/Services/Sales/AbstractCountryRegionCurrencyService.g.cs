using AdventureWorksNS.Api.Contracts;
using AdventureWorksNS.Api.DataAccess;
using Codenesium.DataConversionExtensions;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Dynamic.Core;
using System.Linq.Expressions;
using System.Threading.Tasks;

namespace AdventureWorksNS.Api.Services
{
        public abstract class AbstractCountryRegionCurrencyService : AbstractService
        {
                private ICountryRegionCurrencyRepository countryRegionCurrencyRepository;

                private IApiCountryRegionCurrencyRequestModelValidator countryRegionCurrencyModelValidator;

                private IBOLCountryRegionCurrencyMapper bolCountryRegionCurrencyMapper;

                private IDALCountryRegionCurrencyMapper dalCountryRegionCurrencyMapper;

                private ILogger logger;

                public AbstractCountryRegionCurrencyService(
                        ILogger logger,
                        ICountryRegionCurrencyRepository countryRegionCurrencyRepository,
                        IApiCountryRegionCurrencyRequestModelValidator countryRegionCurrencyModelValidator,
                        IBOLCountryRegionCurrencyMapper bolCountryRegionCurrencyMapper,
                        IDALCountryRegionCurrencyMapper dalCountryRegionCurrencyMapper)
                        : base()
                {
                        this.countryRegionCurrencyRepository = countryRegionCurrencyRepository;
                        this.countryRegionCurrencyModelValidator = countryRegionCurrencyModelValidator;
                        this.bolCountryRegionCurrencyMapper = bolCountryRegionCurrencyMapper;
                        this.dalCountryRegionCurrencyMapper = dalCountryRegionCurrencyMapper;
                        this.logger = logger;
                }

                public virtual async Task<List<ApiCountryRegionCurrencyResponseModel>> All(int limit = 0, int offset = int.MaxValue)
                {
                        var records = await this.countryRegionCurrencyRepository.All(limit, offset);

                        return this.bolCountryRegionCurrencyMapper.MapBOToModel(this.dalCountryRegionCurrencyMapper.MapEFToBO(records));
                }

                public virtual async Task<ApiCountryRegionCurrencyResponseModel> Get(string countryRegionCode)
                {
                        var record = await this.countryRegionCurrencyRepository.Get(countryRegionCode);

                        if (record == null)
                        {
                                return null;
                        }
                        else
                        {
                                return this.bolCountryRegionCurrencyMapper.MapBOToModel(this.dalCountryRegionCurrencyMapper.MapEFToBO(record));
                        }
                }

                public virtual async Task<CreateResponse<ApiCountryRegionCurrencyResponseModel>> Create(
                        ApiCountryRegionCurrencyRequestModel model)
                {
                        CreateResponse<ApiCountryRegionCurrencyResponseModel> response = new CreateResponse<ApiCountryRegionCurrencyResponseModel>(await this.countryRegionCurrencyModelValidator.ValidateCreateAsync(model));
                        if (response.Success)
                        {
                                var bo = this.bolCountryRegionCurrencyMapper.MapModelToBO(default(string), model);
                                var record = await this.countryRegionCurrencyRepository.Create(this.dalCountryRegionCurrencyMapper.MapBOToEF(bo));

                                response.SetRecord(this.bolCountryRegionCurrencyMapper.MapBOToModel(this.dalCountryRegionCurrencyMapper.MapEFToBO(record)));
                        }

                        return response;
                }

                public virtual async Task<ActionResponse> Update(
                        string countryRegionCode,
                        ApiCountryRegionCurrencyRequestModel model)
                {
                        ActionResponse response = new ActionResponse(await this.countryRegionCurrencyModelValidator.ValidateUpdateAsync(countryRegionCode, model));
                        if (response.Success)
                        {
                                var bo = this.bolCountryRegionCurrencyMapper.MapModelToBO(countryRegionCode, model);
                                await this.countryRegionCurrencyRepository.Update(this.dalCountryRegionCurrencyMapper.MapBOToEF(bo));
                        }

                        return response;
                }

                public virtual async Task<ActionResponse> Delete(
                        string countryRegionCode)
                {
                        ActionResponse response = new ActionResponse(await this.countryRegionCurrencyModelValidator.ValidateDeleteAsync(countryRegionCode));
                        if (response.Success)
                        {
                                await this.countryRegionCurrencyRepository.Delete(countryRegionCode);
                        }

                        return response;
                }

                public async Task<List<ApiCountryRegionCurrencyResponseModel>> ByCurrencyCode(string currencyCode)
                {
                        List<CountryRegionCurrency> records = await this.countryRegionCurrencyRepository.ByCurrencyCode(currencyCode);

                        return this.bolCountryRegionCurrencyMapper.MapBOToModel(this.dalCountryRegionCurrencyMapper.MapEFToBO(records));
                }
        }
}

/*<Codenesium>
    <Hash>cc1cce78cd0ffe742f1e8eb46ab09319</Hash>
</Codenesium>*/