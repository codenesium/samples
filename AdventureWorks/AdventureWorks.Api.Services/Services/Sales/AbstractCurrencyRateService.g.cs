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
        public abstract class AbstractCurrencyRateService: AbstractService
        {
                private ICurrencyRateRepository currencyRateRepository;

                private IApiCurrencyRateRequestModelValidator currencyRateModelValidator;

                private IBOLCurrencyRateMapper bolCurrencyRateMapper;

                private IDALCurrencyRateMapper dalCurrencyRateMapper;

                private IBOLSalesOrderHeaderMapper bolSalesOrderHeaderMapper;

                private IDALSalesOrderHeaderMapper dalSalesOrderHeaderMapper;

                private ILogger logger;

                public AbstractCurrencyRateService(
                        ILogger logger,
                        ICurrencyRateRepository currencyRateRepository,
                        IApiCurrencyRateRequestModelValidator currencyRateModelValidator,
                        IBOLCurrencyRateMapper bolCurrencyRateMapper,
                        IDALCurrencyRateMapper dalCurrencyRateMapper

                        ,
                        IBOLSalesOrderHeaderMapper bolSalesOrderHeaderMapper,
                        IDALSalesOrderHeaderMapper dalSalesOrderHeaderMapper

                        )
                        : base()

                {
                        this.currencyRateRepository = currencyRateRepository;
                        this.currencyRateModelValidator = currencyRateModelValidator;
                        this.bolCurrencyRateMapper = bolCurrencyRateMapper;
                        this.dalCurrencyRateMapper = dalCurrencyRateMapper;
                        this.bolSalesOrderHeaderMapper = bolSalesOrderHeaderMapper;
                        this.dalSalesOrderHeaderMapper = dalSalesOrderHeaderMapper;
                        this.logger = logger;
                }

                public virtual async Task<List<ApiCurrencyRateResponseModel>> All(int limit = 0, int offset = int.MaxValue)
                {
                        var records = await this.currencyRateRepository.All(limit, offset);

                        return this.bolCurrencyRateMapper.MapBOToModel(this.dalCurrencyRateMapper.MapEFToBO(records));
                }

                public virtual async Task<ApiCurrencyRateResponseModel> Get(int currencyRateID)
                {
                        var record = await this.currencyRateRepository.Get(currencyRateID);

                        if (record == null)
                        {
                                return null;
                        }
                        else
                        {
                                return this.bolCurrencyRateMapper.MapBOToModel(this.dalCurrencyRateMapper.MapEFToBO(record));
                        }
                }

                public virtual async Task<CreateResponse<ApiCurrencyRateResponseModel>> Create(
                        ApiCurrencyRateRequestModel model)
                {
                        CreateResponse<ApiCurrencyRateResponseModel> response = new CreateResponse<ApiCurrencyRateResponseModel>(await this.currencyRateModelValidator.ValidateCreateAsync(model));
                        if (response.Success)
                        {
                                var bo = this.bolCurrencyRateMapper.MapModelToBO(default (int), model);
                                var record = await this.currencyRateRepository.Create(this.dalCurrencyRateMapper.MapBOToEF(bo));

                                response.SetRecord(this.bolCurrencyRateMapper.MapBOToModel(this.dalCurrencyRateMapper.MapEFToBO(record)));
                        }

                        return response;
                }

                public virtual async Task<ActionResponse> Update(
                        int currencyRateID,
                        ApiCurrencyRateRequestModel model)
                {
                        ActionResponse response = new ActionResponse(await this.currencyRateModelValidator.ValidateUpdateAsync(currencyRateID, model));

                        if (response.Success)
                        {
                                var bo = this.bolCurrencyRateMapper.MapModelToBO(currencyRateID, model);
                                await this.currencyRateRepository.Update(this.dalCurrencyRateMapper.MapBOToEF(bo));
                        }

                        return response;
                }

                public virtual async Task<ActionResponse> Delete(
                        int currencyRateID)
                {
                        ActionResponse response = new ActionResponse(await this.currencyRateModelValidator.ValidateDeleteAsync(currencyRateID));

                        if (response.Success)
                        {
                                await this.currencyRateRepository.Delete(currencyRateID);
                        }

                        return response;
                }

                public async Task<ApiCurrencyRateResponseModel> ByCurrencyRateDateFromCurrencyCodeToCurrencyCode(DateTime currencyRateDate, string fromCurrencyCode, string toCurrencyCode)
                {
                        CurrencyRate record = await this.currencyRateRepository.ByCurrencyRateDateFromCurrencyCodeToCurrencyCode(currencyRateDate, fromCurrencyCode, toCurrencyCode);

                        if (record == null)
                        {
                                return null;
                        }
                        else
                        {
                                return this.bolCurrencyRateMapper.MapBOToModel(this.dalCurrencyRateMapper.MapEFToBO(record));
                        }
                }

                public async virtual Task<List<ApiSalesOrderHeaderResponseModel>> SalesOrderHeaders(int currencyRateID, int limit = int.MaxValue, int offset = 0)
                {
                        List<SalesOrderHeader> records = await this.currencyRateRepository.SalesOrderHeaders(currencyRateID, limit, offset);

                        return this.bolSalesOrderHeaderMapper.MapBOToModel(this.dalSalesOrderHeaderMapper.MapEFToBO(records));
                }
        }
}

/*<Codenesium>
    <Hash>6b7651df20d65f7168b3ee4ebcd09918</Hash>
</Codenesium>*/