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
        public abstract class AbstractPurchaseOrderDetailService: AbstractService
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
                        IBOLPurchaseOrderDetailMapper bolpurchaseOrderDetailMapper,
                        IDALPurchaseOrderDetailMapper dalpurchaseOrderDetailMapper)
                        : base()

                {
                        this.purchaseOrderDetailRepository = purchaseOrderDetailRepository;
                        this.purchaseOrderDetailModelValidator = purchaseOrderDetailModelValidator;
                        this.bolPurchaseOrderDetailMapper = bolpurchaseOrderDetailMapper;
                        this.dalPurchaseOrderDetailMapper = dalpurchaseOrderDetailMapper;
                        this.logger = logger;
                }

                public virtual async Task<List<ApiPurchaseOrderDetailResponseModel>> All(int skip = 0, int take = int.MaxValue, string orderClause = "")
                {
                        var records = await this.purchaseOrderDetailRepository.All(skip, take, orderClause);

                        return this.bolPurchaseOrderDetailMapper.MapBOToModel(this.dalPurchaseOrderDetailMapper.MapEFToBO(records));
                }

                public virtual async Task<ApiPurchaseOrderDetailResponseModel> Get(int purchaseOrderID)
                {
                        var record = await this.purchaseOrderDetailRepository.Get(purchaseOrderID);

                        return this.bolPurchaseOrderDetailMapper.MapBOToModel(this.dalPurchaseOrderDetailMapper.MapEFToBO(record));
                }

                public virtual async Task<CreateResponse<ApiPurchaseOrderDetailResponseModel>> Create(
                        ApiPurchaseOrderDetailRequestModel model)
                {
                        CreateResponse<ApiPurchaseOrderDetailResponseModel> response = new CreateResponse<ApiPurchaseOrderDetailResponseModel>(await this.purchaseOrderDetailModelValidator.ValidateCreateAsync(model));
                        if (response.Success)
                        {
                                var bo = this.bolPurchaseOrderDetailMapper.MapModelToBO(default (int), model);
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

                public async Task<List<ApiPurchaseOrderDetailResponseModel>> GetProductID(int productID)
                {
                        List<PurchaseOrderDetail> records = await this.purchaseOrderDetailRepository.GetProductID(productID);

                        return this.bolPurchaseOrderDetailMapper.MapBOToModel(this.dalPurchaseOrderDetailMapper.MapEFToBO(records));
                }
        }
}

/*<Codenesium>
    <Hash>0db7c44f91664199038ed669f3703d81</Hash>
</Codenesium>*/