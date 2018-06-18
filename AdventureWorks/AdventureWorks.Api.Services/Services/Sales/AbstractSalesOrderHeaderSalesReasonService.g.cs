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
        public abstract class AbstractSalesOrderHeaderSalesReasonService: AbstractService
        {
                private ISalesOrderHeaderSalesReasonRepository salesOrderHeaderSalesReasonRepository;

                private IApiSalesOrderHeaderSalesReasonRequestModelValidator salesOrderHeaderSalesReasonModelValidator;

                private IBOLSalesOrderHeaderSalesReasonMapper bolSalesOrderHeaderSalesReasonMapper;

                private IDALSalesOrderHeaderSalesReasonMapper dalSalesOrderHeaderSalesReasonMapper;

                private ILogger logger;

                public AbstractSalesOrderHeaderSalesReasonService(
                        ILogger logger,
                        ISalesOrderHeaderSalesReasonRepository salesOrderHeaderSalesReasonRepository,
                        IApiSalesOrderHeaderSalesReasonRequestModelValidator salesOrderHeaderSalesReasonModelValidator,
                        IBOLSalesOrderHeaderSalesReasonMapper bolSalesOrderHeaderSalesReasonMapper,
                        IDALSalesOrderHeaderSalesReasonMapper dalSalesOrderHeaderSalesReasonMapper

                        )
                        : base()

                {
                        this.salesOrderHeaderSalesReasonRepository = salesOrderHeaderSalesReasonRepository;
                        this.salesOrderHeaderSalesReasonModelValidator = salesOrderHeaderSalesReasonModelValidator;
                        this.bolSalesOrderHeaderSalesReasonMapper = bolSalesOrderHeaderSalesReasonMapper;
                        this.dalSalesOrderHeaderSalesReasonMapper = dalSalesOrderHeaderSalesReasonMapper;
                        this.logger = logger;
                }

                public virtual async Task<List<ApiSalesOrderHeaderSalesReasonResponseModel>> All(int limit = 0, int offset = int.MaxValue)
                {
                        var records = await this.salesOrderHeaderSalesReasonRepository.All(limit, offset);

                        return this.bolSalesOrderHeaderSalesReasonMapper.MapBOToModel(this.dalSalesOrderHeaderSalesReasonMapper.MapEFToBO(records));
                }

                public virtual async Task<ApiSalesOrderHeaderSalesReasonResponseModel> Get(int salesOrderID)
                {
                        var record = await this.salesOrderHeaderSalesReasonRepository.Get(salesOrderID);

                        if (record == null)
                        {
                                return null;
                        }
                        else
                        {
                                return this.bolSalesOrderHeaderSalesReasonMapper.MapBOToModel(this.dalSalesOrderHeaderSalesReasonMapper.MapEFToBO(record));
                        }
                }

                public virtual async Task<CreateResponse<ApiSalesOrderHeaderSalesReasonResponseModel>> Create(
                        ApiSalesOrderHeaderSalesReasonRequestModel model)
                {
                        CreateResponse<ApiSalesOrderHeaderSalesReasonResponseModel> response = new CreateResponse<ApiSalesOrderHeaderSalesReasonResponseModel>(await this.salesOrderHeaderSalesReasonModelValidator.ValidateCreateAsync(model));
                        if (response.Success)
                        {
                                var bo = this.bolSalesOrderHeaderSalesReasonMapper.MapModelToBO(default (int), model);
                                var record = await this.salesOrderHeaderSalesReasonRepository.Create(this.dalSalesOrderHeaderSalesReasonMapper.MapBOToEF(bo));

                                response.SetRecord(this.bolSalesOrderHeaderSalesReasonMapper.MapBOToModel(this.dalSalesOrderHeaderSalesReasonMapper.MapEFToBO(record)));
                        }

                        return response;
                }

                public virtual async Task<ActionResponse> Update(
                        int salesOrderID,
                        ApiSalesOrderHeaderSalesReasonRequestModel model)
                {
                        ActionResponse response = new ActionResponse(await this.salesOrderHeaderSalesReasonModelValidator.ValidateUpdateAsync(salesOrderID, model));

                        if (response.Success)
                        {
                                var bo = this.bolSalesOrderHeaderSalesReasonMapper.MapModelToBO(salesOrderID, model);
                                await this.salesOrderHeaderSalesReasonRepository.Update(this.dalSalesOrderHeaderSalesReasonMapper.MapBOToEF(bo));
                        }

                        return response;
                }

                public virtual async Task<ActionResponse> Delete(
                        int salesOrderID)
                {
                        ActionResponse response = new ActionResponse(await this.salesOrderHeaderSalesReasonModelValidator.ValidateDeleteAsync(salesOrderID));

                        if (response.Success)
                        {
                                await this.salesOrderHeaderSalesReasonRepository.Delete(salesOrderID);
                        }

                        return response;
                }
        }
}

/*<Codenesium>
    <Hash>8f67398bee9485f5e2cb9f0120bbfe00</Hash>
</Codenesium>*/