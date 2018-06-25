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
        public abstract class AbstractWorkOrderService : AbstractService
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
                        IDALWorkOrderMapper dalWorkOrderMapper,
                        IBOLWorkOrderRoutingMapper bolWorkOrderRoutingMapper,
                        IDALWorkOrderRoutingMapper dalWorkOrderRoutingMapper)
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

                public virtual async Task<List<ApiWorkOrderResponseModel>> All(int limit = 0, int offset = int.MaxValue)
                {
                        var records = await this.workOrderRepository.All(limit, offset);

                        return this.bolWorkOrderMapper.MapBOToModel(this.dalWorkOrderMapper.MapEFToBO(records));
                }

                public virtual async Task<ApiWorkOrderResponseModel> Get(int workOrderID)
                {
                        var record = await this.workOrderRepository.Get(workOrderID);

                        if (record == null)
                        {
                                return null;
                        }
                        else
                        {
                                return this.bolWorkOrderMapper.MapBOToModel(this.dalWorkOrderMapper.MapEFToBO(record));
                        }
                }

                public virtual async Task<CreateResponse<ApiWorkOrderResponseModel>> Create(
                        ApiWorkOrderRequestModel model)
                {
                        CreateResponse<ApiWorkOrderResponseModel> response = new CreateResponse<ApiWorkOrderResponseModel>(await this.workOrderModelValidator.ValidateCreateAsync(model));
                        if (response.Success)
                        {
                                var bo = this.bolWorkOrderMapper.MapModelToBO(default(int), model);
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

                public async Task<List<ApiWorkOrderResponseModel>> ByProductID(int productID)
                {
                        List<WorkOrder> records = await this.workOrderRepository.ByProductID(productID);

                        return this.bolWorkOrderMapper.MapBOToModel(this.dalWorkOrderMapper.MapEFToBO(records));
                }

                public async Task<List<ApiWorkOrderResponseModel>> ByScrapReasonID(short? scrapReasonID)
                {
                        List<WorkOrder> records = await this.workOrderRepository.ByScrapReasonID(scrapReasonID);

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
    <Hash>dd9e7e5cb2ff8209bea5f19b977b1ded</Hash>
</Codenesium>*/