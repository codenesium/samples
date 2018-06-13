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
        public abstract class AbstractSalesTaxRateService: AbstractService
        {
                private ISalesTaxRateRepository salesTaxRateRepository;

                private IApiSalesTaxRateRequestModelValidator salesTaxRateModelValidator;

                private IBOLSalesTaxRateMapper bolSalesTaxRateMapper;

                private IDALSalesTaxRateMapper dalSalesTaxRateMapper;

                private ILogger logger;

                public AbstractSalesTaxRateService(
                        ILogger logger,
                        ISalesTaxRateRepository salesTaxRateRepository,
                        IApiSalesTaxRateRequestModelValidator salesTaxRateModelValidator,
                        IBOLSalesTaxRateMapper bolSalesTaxRateMapper,
                        IDALSalesTaxRateMapper dalSalesTaxRateMapper

                        )
                        : base()

                {
                        this.salesTaxRateRepository = salesTaxRateRepository;
                        this.salesTaxRateModelValidator = salesTaxRateModelValidator;
                        this.bolSalesTaxRateMapper = bolSalesTaxRateMapper;
                        this.dalSalesTaxRateMapper = dalSalesTaxRateMapper;
                        this.logger = logger;
                }

                public virtual async Task<List<ApiSalesTaxRateResponseModel>> All(int limit = 0, int offset = int.MaxValue, string orderClause = "")
                {
                        var records = await this.salesTaxRateRepository.All(limit, offset, orderClause);

                        return this.bolSalesTaxRateMapper.MapBOToModel(this.dalSalesTaxRateMapper.MapEFToBO(records));
                }

                public virtual async Task<ApiSalesTaxRateResponseModel> Get(int salesTaxRateID)
                {
                        var record = await this.salesTaxRateRepository.Get(salesTaxRateID);

                        return this.bolSalesTaxRateMapper.MapBOToModel(this.dalSalesTaxRateMapper.MapEFToBO(record));
                }

                public virtual async Task<CreateResponse<ApiSalesTaxRateResponseModel>> Create(
                        ApiSalesTaxRateRequestModel model)
                {
                        CreateResponse<ApiSalesTaxRateResponseModel> response = new CreateResponse<ApiSalesTaxRateResponseModel>(await this.salesTaxRateModelValidator.ValidateCreateAsync(model));
                        if (response.Success)
                        {
                                var bo = this.bolSalesTaxRateMapper.MapModelToBO(default (int), model);
                                var record = await this.salesTaxRateRepository.Create(this.dalSalesTaxRateMapper.MapBOToEF(bo));

                                response.SetRecord(this.bolSalesTaxRateMapper.MapBOToModel(this.dalSalesTaxRateMapper.MapEFToBO(record)));
                        }

                        return response;
                }

                public virtual async Task<ActionResponse> Update(
                        int salesTaxRateID,
                        ApiSalesTaxRateRequestModel model)
                {
                        ActionResponse response = new ActionResponse(await this.salesTaxRateModelValidator.ValidateUpdateAsync(salesTaxRateID, model));

                        if (response.Success)
                        {
                                var bo = this.bolSalesTaxRateMapper.MapModelToBO(salesTaxRateID, model);
                                await this.salesTaxRateRepository.Update(this.dalSalesTaxRateMapper.MapBOToEF(bo));
                        }

                        return response;
                }

                public virtual async Task<ActionResponse> Delete(
                        int salesTaxRateID)
                {
                        ActionResponse response = new ActionResponse(await this.salesTaxRateModelValidator.ValidateDeleteAsync(salesTaxRateID));

                        if (response.Success)
                        {
                                await this.salesTaxRateRepository.Delete(salesTaxRateID);
                        }

                        return response;
                }

                public async Task<ApiSalesTaxRateResponseModel> GetStateProvinceIDTaxType(int stateProvinceID, int taxType)
                {
                        SalesTaxRate record = await this.salesTaxRateRepository.GetStateProvinceIDTaxType(stateProvinceID, taxType);

                        return this.bolSalesTaxRateMapper.MapBOToModel(this.dalSalesTaxRateMapper.MapEFToBO(record));
                }
        }
}

/*<Codenesium>
    <Hash>3f46dff5159b85b1777b18c0781af095</Hash>
</Codenesium>*/