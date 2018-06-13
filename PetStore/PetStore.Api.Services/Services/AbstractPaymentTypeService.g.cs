using Codenesium.DataConversionExtensions.AspNetCore;
using System;
using System.Collections.Generic;
using Microsoft.Extensions.Logging;
using Microsoft.EntityFrameworkCore;
using System.Linq;
using System.Linq.Dynamic.Core;
using System.Linq.Expressions;
using System.Threading.Tasks;
using PetStoreNS.Api.Contracts;
using PetStoreNS.Api.DataAccess;

namespace PetStoreNS.Api.Services
{
        public abstract class AbstractPaymentTypeService: AbstractService
        {
                private IPaymentTypeRepository paymentTypeRepository;

                private IApiPaymentTypeRequestModelValidator paymentTypeModelValidator;

                private IBOLPaymentTypeMapper bolPaymentTypeMapper;

                private IDALPaymentTypeMapper dalPaymentTypeMapper;

                private IBOLSaleMapper bolSaleMapper;

                private IDALSaleMapper dalSaleMapper;

                private ILogger logger;

                public AbstractPaymentTypeService(
                        ILogger logger,
                        IPaymentTypeRepository paymentTypeRepository,
                        IApiPaymentTypeRequestModelValidator paymentTypeModelValidator,
                        IBOLPaymentTypeMapper bolPaymentTypeMapper,
                        IDALPaymentTypeMapper dalPaymentTypeMapper

                        ,
                        IBOLSaleMapper bolSaleMapper,
                        IDALSaleMapper dalSaleMapper

                        )
                        : base()

                {
                        this.paymentTypeRepository = paymentTypeRepository;
                        this.paymentTypeModelValidator = paymentTypeModelValidator;
                        this.bolPaymentTypeMapper = bolPaymentTypeMapper;
                        this.dalPaymentTypeMapper = dalPaymentTypeMapper;
                        this.bolSaleMapper = bolSaleMapper;
                        this.dalSaleMapper = dalSaleMapper;
                        this.logger = logger;
                }

                public virtual async Task<List<ApiPaymentTypeResponseModel>> All(int limit = 0, int offset = int.MaxValue, string orderClause = "")
                {
                        var records = await this.paymentTypeRepository.All(limit, offset, orderClause);

                        return this.bolPaymentTypeMapper.MapBOToModel(this.dalPaymentTypeMapper.MapEFToBO(records));
                }

                public virtual async Task<ApiPaymentTypeResponseModel> Get(int id)
                {
                        var record = await this.paymentTypeRepository.Get(id);

                        return this.bolPaymentTypeMapper.MapBOToModel(this.dalPaymentTypeMapper.MapEFToBO(record));
                }

                public virtual async Task<CreateResponse<ApiPaymentTypeResponseModel>> Create(
                        ApiPaymentTypeRequestModel model)
                {
                        CreateResponse<ApiPaymentTypeResponseModel> response = new CreateResponse<ApiPaymentTypeResponseModel>(await this.paymentTypeModelValidator.ValidateCreateAsync(model));
                        if (response.Success)
                        {
                                var bo = this.bolPaymentTypeMapper.MapModelToBO(default (int), model);
                                var record = await this.paymentTypeRepository.Create(this.dalPaymentTypeMapper.MapBOToEF(bo));

                                response.SetRecord(this.bolPaymentTypeMapper.MapBOToModel(this.dalPaymentTypeMapper.MapEFToBO(record)));
                        }

                        return response;
                }

                public virtual async Task<ActionResponse> Update(
                        int id,
                        ApiPaymentTypeRequestModel model)
                {
                        ActionResponse response = new ActionResponse(await this.paymentTypeModelValidator.ValidateUpdateAsync(id, model));

                        if (response.Success)
                        {
                                var bo = this.bolPaymentTypeMapper.MapModelToBO(id, model);
                                await this.paymentTypeRepository.Update(this.dalPaymentTypeMapper.MapBOToEF(bo));
                        }

                        return response;
                }

                public virtual async Task<ActionResponse> Delete(
                        int id)
                {
                        ActionResponse response = new ActionResponse(await this.paymentTypeModelValidator.ValidateDeleteAsync(id));

                        if (response.Success)
                        {
                                await this.paymentTypeRepository.Delete(id);
                        }

                        return response;
                }

                public async virtual Task<List<ApiSaleResponseModel>> Sales(int paymentTypeId, int limit = int.MaxValue, int offset = 0)
                {
                        List<Sale> records = await this.paymentTypeRepository.Sales(paymentTypeId, limit, offset);

                        return this.bolSaleMapper.MapBOToModel(this.dalSaleMapper.MapEFToBO(records));
                }
        }
}

/*<Codenesium>
    <Hash>2c0bc266b01a4ff4e8696f5a5209dcb6</Hash>
</Codenesium>*/