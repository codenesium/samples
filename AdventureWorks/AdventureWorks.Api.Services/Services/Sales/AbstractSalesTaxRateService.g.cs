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
        public abstract class AbstractSalesTaxRateService : AbstractService
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
                        IDALSalesTaxRateMapper dalSalesTaxRateMapper)
                        : base()
                {
                        this.salesTaxRateRepository = salesTaxRateRepository;
                        this.salesTaxRateModelValidator = salesTaxRateModelValidator;
                        this.bolSalesTaxRateMapper = bolSalesTaxRateMapper;
                        this.dalSalesTaxRateMapper = dalSalesTaxRateMapper;
                        this.logger = logger;
                }

                public virtual async Task<List<ApiSalesTaxRateResponseModel>> All(int limit = 0, int offset = int.MaxValue)
                {
                        var records = await this.salesTaxRateRepository.All(limit, offset);

                        return this.bolSalesTaxRateMapper.MapBOToModel(this.dalSalesTaxRateMapper.MapEFToBO(records));
                }

                public virtual async Task<ApiSalesTaxRateResponseModel> Get(int salesTaxRateID)
                {
                        var record = await this.salesTaxRateRepository.Get(salesTaxRateID);

                        if (record == null)
                        {
                                return null;
                        }
                        else
                        {
                                return this.bolSalesTaxRateMapper.MapBOToModel(this.dalSalesTaxRateMapper.MapEFToBO(record));
                        }
                }

                public virtual async Task<CreateResponse<ApiSalesTaxRateResponseModel>> Create(
                        ApiSalesTaxRateRequestModel model)
                {
                        CreateResponse<ApiSalesTaxRateResponseModel> response = new CreateResponse<ApiSalesTaxRateResponseModel>(await this.salesTaxRateModelValidator.ValidateCreateAsync(model));
                        if (response.Success)
                        {
                                var bo = this.bolSalesTaxRateMapper.MapModelToBO(default(int), model);
                                var record = await this.salesTaxRateRepository.Create(this.dalSalesTaxRateMapper.MapBOToEF(bo));

                                response.SetRecord(this.bolSalesTaxRateMapper.MapBOToModel(this.dalSalesTaxRateMapper.MapEFToBO(record)));
                        }

                        return response;
                }

                public virtual async Task<UpdateResponse<ApiSalesTaxRateResponseModel>> Update(
                        int salesTaxRateID,
                        ApiSalesTaxRateRequestModel model)
                {
                        var validationResult = await this.salesTaxRateModelValidator.ValidateUpdateAsync(salesTaxRateID, model);

                        if (validationResult.IsValid)
                        {
                                var bo = this.bolSalesTaxRateMapper.MapModelToBO(salesTaxRateID, model);
                                await this.salesTaxRateRepository.Update(this.dalSalesTaxRateMapper.MapBOToEF(bo));

                                var record = await this.salesTaxRateRepository.Get(salesTaxRateID);

                                return new UpdateResponse<ApiSalesTaxRateResponseModel>(this.bolSalesTaxRateMapper.MapBOToModel(this.dalSalesTaxRateMapper.MapEFToBO(record)));
                        }
                        else
                        {
                                return new UpdateResponse<ApiSalesTaxRateResponseModel>(validationResult);
                        }
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

                public async Task<ApiSalesTaxRateResponseModel> ByStateProvinceIDTaxType(int stateProvinceID, int taxType)
                {
                        SalesTaxRate record = await this.salesTaxRateRepository.ByStateProvinceIDTaxType(stateProvinceID, taxType);

                        if (record == null)
                        {
                                return null;
                        }
                        else
                        {
                                return this.bolSalesTaxRateMapper.MapBOToModel(this.dalSalesTaxRateMapper.MapEFToBO(record));
                        }
                }
        }
}

/*<Codenesium>
    <Hash>9d5d6b88cea2a3fc3b6197b873b4b71d</Hash>
</Codenesium>*/