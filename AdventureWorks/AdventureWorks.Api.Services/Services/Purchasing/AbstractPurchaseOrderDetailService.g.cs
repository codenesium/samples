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
        public abstract class AbstractPurchaseOrderDetailService : AbstractService
        {
                private IPurchaseOrderDetailRepository purchaseOrderDetailRepository;

                private IApiPurchaseOrderDetailRequestModelValidator purchaseOrderDetailModelValidator;

                private IBOLPurchaseOrderDetailMapper bolPurchaseOrderDetailMapper;

                private IDALPurchaseOrderDetailMapper dalPurchaseOrderDetailMapper;

                private ILogger logger;

                public AbstractPurchaseOrderDetailService(
                        ILogger logger,
                        IPurchaseOrderDetailRepository purchaseOrderDetailRepository,
                        IApiPurchaseOrderDetailRequestModelValidator purchaseOrderDetailModelValidator,
                        IBOLPurchaseOrderDetailMapper bolPurchaseOrderDetailMapper,
                        IDALPurchaseOrderDetailMapper dalPurchaseOrderDetailMapper)
                        : base()
                {
                        this.purchaseOrderDetailRepository = purchaseOrderDetailRepository;
                        this.purchaseOrderDetailModelValidator = purchaseOrderDetailModelValidator;
                        this.bolPurchaseOrderDetailMapper = bolPurchaseOrderDetailMapper;
                        this.dalPurchaseOrderDetailMapper = dalPurchaseOrderDetailMapper;
                        this.logger = logger;
                }

                public virtual async Task<List<ApiPurchaseOrderDetailResponseModel>> All(int limit = 0, int offset = int.MaxValue)
                {
                        var records = await this.purchaseOrderDetailRepository.All(limit, offset);

                        return this.bolPurchaseOrderDetailMapper.MapBOToModel(this.dalPurchaseOrderDetailMapper.MapEFToBO(records));
                }

                public virtual async Task<ApiPurchaseOrderDetailResponseModel> Get(int purchaseOrderID)
                {
                        var record = await this.purchaseOrderDetailRepository.Get(purchaseOrderID);

                        if (record == null)
                        {
                                return null;
                        }
                        else
                        {
                                return this.bolPurchaseOrderDetailMapper.MapBOToModel(this.dalPurchaseOrderDetailMapper.MapEFToBO(record));
                        }
                }

                public virtual async Task<CreateResponse<ApiPurchaseOrderDetailResponseModel>> Create(
                        ApiPurchaseOrderDetailRequestModel model)
                {
                        CreateResponse<ApiPurchaseOrderDetailResponseModel> response = new CreateResponse<ApiPurchaseOrderDetailResponseModel>(await this.purchaseOrderDetailModelValidator.ValidateCreateAsync(model));
                        if (response.Success)
                        {
                                var bo = this.bolPurchaseOrderDetailMapper.MapModelToBO(default(int), model);
                                var record = await this.purchaseOrderDetailRepository.Create(this.dalPurchaseOrderDetailMapper.MapBOToEF(bo));

                                response.SetRecord(this.bolPurchaseOrderDetailMapper.MapBOToModel(this.dalPurchaseOrderDetailMapper.MapEFToBO(record)));
                        }

                        return response;
                }

                public virtual async Task<ActionResponse> Update(
                        int purchaseOrderID,
                        ApiPurchaseOrderDetailRequestModel model)
                {
                        ActionResponse response = new ActionResponse(await this.purchaseOrderDetailModelValidator.ValidateUpdateAsync(purchaseOrderID, model));
                        if (response.Success)
                        {
                                var bo = this.bolPurchaseOrderDetailMapper.MapModelToBO(purchaseOrderID, model);
                                await this.purchaseOrderDetailRepository.Update(this.dalPurchaseOrderDetailMapper.MapBOToEF(bo));
                        }

                        return response;
                }

                public virtual async Task<ActionResponse> Delete(
                        int purchaseOrderID)
                {
                        ActionResponse response = new ActionResponse(await this.purchaseOrderDetailModelValidator.ValidateDeleteAsync(purchaseOrderID));
                        if (response.Success)
                        {
                                await this.purchaseOrderDetailRepository.Delete(purchaseOrderID);
                        }

                        return response;
                }

                public async Task<List<ApiPurchaseOrderDetailResponseModel>> ByProductID(int productID)
                {
                        List<PurchaseOrderDetail> records = await this.purchaseOrderDetailRepository.ByProductID(productID);

                        return this.bolPurchaseOrderDetailMapper.MapBOToModel(this.dalPurchaseOrderDetailMapper.MapEFToBO(records));
                }
        }
}

/*<Codenesium>
    <Hash>6d1ecc52258a93b82dcaa4be21fa3fc3</Hash>
</Codenesium>*/