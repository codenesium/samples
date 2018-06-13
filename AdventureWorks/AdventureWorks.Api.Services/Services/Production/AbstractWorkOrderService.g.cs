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
        public abstract class AbstractWorkOrderService: AbstractService
        {
                private IWorkOrderRepository workOrderRepository;

                private IApiWorkOrderRequestModelValidator workOrderModelValidator;

                private IBOLWorkOrderMapper bolWorkOrderMapper;

                private IDALWorkOrderMapper dalWorkOrderMapper;

                private IBOLWorkOrderRoutingMapper bolWorkOrderRoutingMapper;

                private IDALWorkOrderRoutingMapper dalWorkOrderRoutingMapper;

                private ILogger logger;

                public AbstractWorkOrderService(
                        ILogger logger,
                        IWorkOrderRepository workOrderRepository,
                        IApiWorkOrderRequestModelValidator workOrderModelValidator,
                        IBOLWorkOrderMapper bolWorkOrderMapper,
                        IDALWorkOrderMapper dalWorkOrderMapper

                        ,
                        IBOLWorkOrderRoutingMapper bolWorkOrderRoutingMapper,
                        IDALWorkOrderRoutingMapper dalWorkOrderRoutingMapper

                        )
                        : base()

                {
                        this.workOrderRepository = workOrderRepository;
                        this.workOrderModelValidator = workOrderModelValidator;
                        this.bolWorkOrderMapper = bolWorkOrderMapper;
                        this.dalWorkOrderMapper = dalWorkOrderMapper;
                        this.bolWorkOrderRoutingMapper = bolWorkOrderRoutingMapper;
                        this.dalWorkOrderRoutingMapper = dalWorkOrderRoutingMapper;
                        this.logger = logger;
                }

                public virtual async Task<List<ApiWorkOrderResponseModel>> All(int limit = 0, int offset = int.MaxValue, string orderClause = "")
                {
                        var records = await this.workOrderRepository.All(limit, offset, orderClause);

                        return this.bolWorkOrderMapper.MapBOToModel(this.dalWorkOrderMapper.MapEFToBO(records));
                }

                public virtual async Task<ApiWorkOrderResponseModel> Get(int workOrderID)
                {
                        var record = await this.workOrderRepository.Get(workOrderID);

                        return this.bolWorkOrderMapper.MapBOToModel(this.dalWorkOrderMapper.MapEFToBO(record));
                }

                public virtual async Task<CreateResponse<ApiWorkOrderResponseModel>> Create(
                        ApiWorkOrderRequestModel model)
                {
                        CreateResponse<ApiWorkOrderResponseModel> response = new CreateResponse<ApiWorkOrderResponseModel>(await this.workOrderModelValidator.ValidateCreateAsync(model));
                        if (response.Success)
                        {
                                var bo = this.bolWorkOrderMapper.MapModelToBO(default (int), model);
                                var record = await this.workOrderRepository.Create(this.dalWorkOrderMapper.MapBOToEF(bo));

                                response.SetRecord(this.bolWorkOrderMapper.MapBOToModel(this.dalWorkOrderMapper.MapEFToBO(record)));
                        }

                        return response;
                }

                public virtual async Task<ActionResponse> Update(
                        int workOrderID,
                        ApiWorkOrderRequestModel model)
                {
                        ActionResponse response = new ActionResponse(await this.workOrderModelValidator.ValidateUpdateAsync(workOrderID, model));

                        if (response.Success)
                        {
                                var bo = this.bolWorkOrderMapper.MapModelToBO(workOrderID, model);
                                await this.workOrderRepository.Update(this.dalWorkOrderMapper.MapBOToEF(bo));
                        }

                        return response;
                }

                public virtual async Task<ActionResponse> Delete(
                        int workOrderID)
                {
                        ActionResponse response = new ActionResponse(await this.workOrderModelValidator.ValidateDeleteAsync(workOrderID));

                        if (response.Success)
                        {
                                await this.workOrderRepository.Delete(workOrderID);
                        }

                        return response;
                }

                public async Task<List<ApiWorkOrderResponseModel>> GetProductID(int productID)
                {
                        List<WorkOrder> records = await this.workOrderRepository.GetProductID(productID);

                        return this.bolWorkOrderMapper.MapBOToModel(this.dalWorkOrderMapper.MapEFToBO(records));
                }
                public async Task<List<ApiWorkOrderResponseModel>> GetScrapReasonID(Nullable<short> scrapReasonID)
                {
                        List<WorkOrder> records = await this.workOrderRepository.GetScrapReasonID(scrapReasonID);

                        return this.bolWorkOrderMapper.MapBOToModel(this.dalWorkOrderMapper.MapEFToBO(records));
                }

                public async virtual Task<List<ApiWorkOrderRoutingResponseModel>> WorkOrderRoutings(int workOrderID, int limit = int.MaxValue, int offset = 0)
                {
                        List<WorkOrderRouting> records = await this.workOrderRepository.WorkOrderRoutings(workOrderID, limit, offset);

                        return this.bolWorkOrderRoutingMapper.MapBOToModel(this.dalWorkOrderRoutingMapper.MapEFToBO(records));
                }
        }
}

/*<Codenesium>
    <Hash>3f88e2a615d334c9311899096b39ac12</Hash>
</Codenesium>*/