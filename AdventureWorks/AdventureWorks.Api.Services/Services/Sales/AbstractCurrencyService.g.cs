using Codenesium.DataConversionExtensions.AspNetCore;
using System;
using System.Collections.Generic;
using Microsoft.Extensions.Logging;
using Microsoft.EntityFrameworkCore;
using System.Linq;
using System.Linq.Dynamic.Core;
using System.Linq.Expressions;
using System.Threading.Tasks;
using AdventureWorksNS.Api.Contracts;
using AdventureWorksNS.Api.DataAccess;

namespace AdventureWorksNS.Api.Services
{
        public abstract class AbstractCurrencyService: AbstractService
        {
                private ICurrencyRepository currencyRepository;

                private IApiCurrencyRequestModelValidator currencyModelValidator;

                private IBOLCurrencyMapper bolCurrencyMapper;

                private IDALCurrencyMapper dalCurrencyMapper;

                private IBOLCountryRegionCurrencyMapper bolCountryRegionCurrencyMapper;

                private IDALCountryRegionCurrencyMapper dalCountryRegionCurrencyMapper;
                private IBOLCurrencyRateMapper bolCurrencyRateMapper;

                private IDALCurrencyRateMapper dalCurrencyRateMapper;

                private ILogger logger;

                public AbstractCurrencyService(
                        ILogger logger,
                        ICurrencyRepository currencyRepository,
                        IApiCurrencyRequestModelValidator currencyModelValidator,
                        IBOLCurrencyMapper bolCurrencyMapper,
                        IDALCurrencyMapper dalCurrencyMapper

                        ,
                        IBOLCountryRegionCurrencyMapper bolCountryRegionCurrencyMapper,
                        IDALCountryRegionCurrencyMapper dalCountryRegionCurrencyMapper
                        ,
                        IBOLCurrencyRateMapper bolCurrencyRateMapper,
                        IDALCurrencyRateMapper dalCurrencyRateMapper

                        )
                        : base()

                {
                        this.currencyRepository = currencyRepository;
                        this.currencyModelValidator = currencyModelValidator;
                        this.bolCurrencyMapper = bolCurrencyMapper;
                        this.dalCurrencyMapper = dalCurrencyMapper;
                        this.bolCountryRegionCurrencyMapper = bolCountryRegionCurrencyMapper;
                        this.dalCountryRegionCurrencyMapper = dalCountryRegionCurrencyMapper;
                        this.bolCurrencyRateMapper = bolCurrencyRateMapper;
                        this.dalCurrencyRateMapper = dalCurrencyRateMapper;
                        this.logger = logger;
                }

                public virtual async Task<List<ApiCurrencyResponseModel>> All(int limit = 0, int offset = int.MaxValue)
                {
                        var records = await this.currencyRepository.All(limit, offset);

                        return this.bolCurrencyMapper.MapBOToModel(this.dalCurrencyMapper.MapEFToBO(records));
                }

                public virtual async Task<ApiCurrencyResponseModel> Get(string currencyCode)
                {
                        var record = await this.currencyRepository.Get(currencyCode);

                        if (record == null)
                        {
                                return null;
                        }
                        else
                        {
                                return this.bolCurrencyMapper.MapBOToModel(this.dalCurrencyMapper.MapEFToBO(record));
                        }
                }

                public virtual async Task<CreateResponse<ApiCurrencyResponseModel>> Create(
                        ApiCurrencyRequestModel model)
                {
                        CreateResponse<ApiCurrencyResponseModel> response = new CreateResponse<ApiCurrencyResponseModel>(await this.currencyModelValidator.ValidateCreateAsync(model));
                        if (response.Success)
                        {
                                var bo = this.bolCurrencyMapper.MapModelToBO(default (string), model);
                                var record = await this.currencyRepository.Create(this.dalCurrencyMapper.MapBOToEF(bo));

                                response.SetRecord(this.bolCurrencyMapper.MapBOToModel(this.dalCurrencyMapper.MapEFToBO(record)));
                        }

                        return response;
                }

                public virtual async Task<ActionResponse> Update(
                        string currencyCode,
                        ApiCurrencyRequestModel model)
                {
                        ActionResponse response = new ActionResponse(await this.currencyModelValidator.ValidateUpdateAsync(currencyCode, model));

                        if (response.Success)
                        {
                                var bo = this.bolCurrencyMapper.MapModelToBO(currencyCode, model);
                                await this.currencyRepository.Update(this.dalCurrencyMapper.MapBOToEF(bo));
                        }

                        return response;
                }

                public virtual async Task<ActionResponse> Delete(
                        string currencyCode)
                {
                        ActionResponse response = new ActionResponse(await this.currencyModelValidator.ValidateDeleteAsync(currencyCode));

                        if (response.Success)
                        {
                                await this.currencyRepository.Delete(currencyCode);
                        }

                        return response;
                }

                public async Task<ApiCurrencyResponseModel> ByName(string name)
                {
                        Currency record = await this.currencyRepository.ByName(name);

                        if (record == null)
                        {
                                return null;
                        }
                        else
                        {
                                return this.bolCurrencyMapper.MapBOToModel(this.dalCurrencyMapper.MapEFToBO(record));
                        }
                }

                public async virtual Task<List<ApiCountryRegionCurrencyResponseModel>> CountryRegionCurrencies(string currencyCode, int limit = int.MaxValue, int offset = 0)
                {
                        List<CountryRegionCurrency> records = await this.currencyRepository.CountryRegionCurrencies(currencyCode, limit, offset);

                        return this.bolCountryRegionCurrencyMapper.MapBOToModel(this.dalCountryRegionCurrencyMapper.MapEFToBO(records));
                }
                public async virtual Task<List<ApiCurrencyRateResponseModel>> CurrencyRates(string fromCurrencyCode, int limit = int.MaxValue, int offset = 0)
                {
                        List<CurrencyRate> records = await this.currencyRepository.CurrencyRates(fromCurrencyCode, limit, offset);

                        return this.bolCurrencyRateMapper.MapBOToModel(this.dalCurrencyRateMapper.MapEFToBO(records));
                }
        }
}

/*<Codenesium>
    <Hash>16ed112f48ad09eceba5dff77d9fde9e</Hash>
</Codenesium>*/