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
        public abstract class AbstractSalesOrderDetailService : AbstractService
        {
                private ISalesOrderDetailRepository salesOrderDetailRepository;

                private IApiSalesOrderDetailRequestModelValidator salesOrderDetailModelValidator;

                private IBOLSalesOrderDetailMapper bolSalesOrderDetailMapper;

                private IDALSalesOrderDetailMapper dalSalesOrderDetailMapper;

                private ILogger logger;

                public AbstractSalesOrderDetailService(
                        ILogger logger,
                        ISalesOrderDetailRepository salesOrderDetailRepository,
                        IApiSalesOrderDetailRequestModelValidator salesOrderDetailModelValidator,
                        IBOLSalesOrderDetailMapper bolSalesOrderDetailMapper,
                        IDALSalesOrderDetailMapper dalSalesOrderDetailMapper)
                        : base()
                {
                        this.salesOrderDetailRepository = salesOrderDetailRepository;
                        this.salesOrderDetailModelValidator = salesOrderDetailModelValidator;
                        this.bolSalesOrderDetailMapper = bolSalesOrderDetailMapper;
                        this.dalSalesOrderDetailMapper = dalSalesOrderDetailMapper;
                        this.logger = logger;
                }

                public virtual async Task<List<ApiSalesOrderDetailResponseModel>> All(int limit = 0, int offset = int.MaxValue)
                {
                        var records = await this.salesOrderDetailRepository.All(limit, offset);

                        return this.bolSalesOrderDetailMapper.MapBOToModel(this.dalSalesOrderDetailMapper.MapEFToBO(records));
                }

                public virtual async Task<ApiSalesOrderDetailResponseModel> Get(int salesOrderID)
                {
                        var record = await this.salesOrderDetailRepository.Get(salesOrderID);

                        if (record == null)
                        {
                                return null;
                        }
                        else
                        {
                                return this.bolSalesOrderDetailMapper.MapBOToModel(this.dalSalesOrderDetailMapper.MapEFToBO(record));
                        }
                }

                public virtual async Task<CreateResponse<ApiSalesOrderDetailResponseModel>> Create(
                        ApiSalesOrderDetailRequestModel model)
                {
                        CreateResponse<ApiSalesOrderDetailResponseModel> response = new CreateResponse<ApiSalesOrderDetailResponseModel>(await this.salesOrderDetailModelValidator.ValidateCreateAsync(model));
                        if (response.Success)
                        {
                                var bo = this.bolSalesOrderDetailMapper.MapModelToBO(default(int), model);
                                var record = await this.salesOrderDetailRepository.Create(this.dalSalesOrderDetailMapper.MapBOToEF(bo));

                                response.SetRecord(this.bolSalesOrderDetailMapper.MapBOToModel(this.dalSalesOrderDetailMapper.MapEFToBO(record)));
                        }

                        return response;
                }

                public virtual async Task<UpdateResponse<ApiSalesOrderDetailResponseModel>> Update(
                        int salesOrderID,
                        ApiSalesOrderDetailRequestModel model)
                {
                        var validationResult = await this.salesOrderDetailModelValidator.ValidateUpdateAsync(salesOrderID, model);

                        if (validationResult.IsValid)
                        {
                                var bo = this.bolSalesOrderDetailMapper.MapModelToBO(salesOrderID, model);
                                await this.salesOrderDetailRepository.Update(this.dalSalesOrderDetailMapper.MapBOToEF(bo));

                                var record = await this.salesOrderDetailRepository.Get(salesOrderID);

                                return new UpdateResponse<ApiSalesOrderDetailResponseModel>(this.bolSalesOrderDetailMapper.MapBOToModel(this.dalSalesOrderDetailMapper.MapEFToBO(record)));
                        }
                        else
                        {
                                return new UpdateResponse<ApiSalesOrderDetailResponseModel>(validationResult);
                        }
                }

                public virtual async Task<ActionResponse> Delete(
                        int salesOrderID)
                {
                        ActionResponse response = new ActionResponse(await this.salesOrderDetailModelValidator.ValidateDeleteAsync(salesOrderID));
                        if (response.Success)
                        {
                                await this.salesOrderDetailRepository.Delete(salesOrderID);
                        }

                        return response;
                }

                public async Task<List<ApiSalesOrderDetailResponseModel>> ByProductID(int productID)
                {
                        List<SalesOrderDetail> records = await this.salesOrderDetailRepository.ByProductID(productID);

                        return this.bolSalesOrderDetailMapper.MapBOToModel(this.dalSalesOrderDetailMapper.MapEFToBO(records));
                }
        }
}

/*<Codenesium>
    <Hash>f6dab445e1fe85d56ca169fe9559e16a</Hash>
</Codenesium>*/