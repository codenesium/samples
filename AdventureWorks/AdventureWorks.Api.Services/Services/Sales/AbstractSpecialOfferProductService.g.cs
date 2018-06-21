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
        public abstract class AbstractSpecialOfferProductService : AbstractService
        {
                private ISpecialOfferProductRepository specialOfferProductRepository;

                private IApiSpecialOfferProductRequestModelValidator specialOfferProductModelValidator;

                private IBOLSpecialOfferProductMapper bolSpecialOfferProductMapper;

                private IDALSpecialOfferProductMapper dalSpecialOfferProductMapper;

                private IBOLSalesOrderDetailMapper bolSalesOrderDetailMapper;

                private IDALSalesOrderDetailMapper dalSalesOrderDetailMapper;

                private ILogger logger;

                public AbstractSpecialOfferProductService(
                        ILogger logger,
                        ISpecialOfferProductRepository specialOfferProductRepository,
                        IApiSpecialOfferProductRequestModelValidator specialOfferProductModelValidator,
                        IBOLSpecialOfferProductMapper bolSpecialOfferProductMapper,
                        IDALSpecialOfferProductMapper dalSpecialOfferProductMapper,
                        IBOLSalesOrderDetailMapper bolSalesOrderDetailMapper,
                        IDALSalesOrderDetailMapper dalSalesOrderDetailMapper)
                        : base()
                {
                        this.specialOfferProductRepository = specialOfferProductRepository;
                        this.specialOfferProductModelValidator = specialOfferProductModelValidator;
                        this.bolSpecialOfferProductMapper = bolSpecialOfferProductMapper;
                        this.dalSpecialOfferProductMapper = dalSpecialOfferProductMapper;
                        this.bolSalesOrderDetailMapper = bolSalesOrderDetailMapper;
                        this.dalSalesOrderDetailMapper = dalSalesOrderDetailMapper;
                        this.logger = logger;
                }

                public virtual async Task<List<ApiSpecialOfferProductResponseModel>> All(int limit = 0, int offset = int.MaxValue)
                {
                        var records = await this.specialOfferProductRepository.All(limit, offset);

                        return this.bolSpecialOfferProductMapper.MapBOToModel(this.dalSpecialOfferProductMapper.MapEFToBO(records));
                }

                public virtual async Task<ApiSpecialOfferProductResponseModel> Get(int specialOfferID)
                {
                        var record = await this.specialOfferProductRepository.Get(specialOfferID);

                        if (record == null)
                        {
                                return null;
                        }
                        else
                        {
                                return this.bolSpecialOfferProductMapper.MapBOToModel(this.dalSpecialOfferProductMapper.MapEFToBO(record));
                        }
                }

                public virtual async Task<CreateResponse<ApiSpecialOfferProductResponseModel>> Create(
                        ApiSpecialOfferProductRequestModel model)
                {
                        CreateResponse<ApiSpecialOfferProductResponseModel> response = new CreateResponse<ApiSpecialOfferProductResponseModel>(await this.specialOfferProductModelValidator.ValidateCreateAsync(model));
                        if (response.Success)
                        {
                                var bo = this.bolSpecialOfferProductMapper.MapModelToBO(default(int), model);
                                var record = await this.specialOfferProductRepository.Create(this.dalSpecialOfferProductMapper.MapBOToEF(bo));

                                response.SetRecord(this.bolSpecialOfferProductMapper.MapBOToModel(this.dalSpecialOfferProductMapper.MapEFToBO(record)));
                        }

                        return response;
                }

                public virtual async Task<ActionResponse> Update(
                        int specialOfferID,
                        ApiSpecialOfferProductRequestModel model)
                {
                        ActionResponse response = new ActionResponse(await this.specialOfferProductModelValidator.ValidateUpdateAsync(specialOfferID, model));
                        if (response.Success)
                        {
                                var bo = this.bolSpecialOfferProductMapper.MapModelToBO(specialOfferID, model);
                                await this.specialOfferProductRepository.Update(this.dalSpecialOfferProductMapper.MapBOToEF(bo));
                        }

                        return response;
                }

                public virtual async Task<ActionResponse> Delete(
                        int specialOfferID)
                {
                        ActionResponse response = new ActionResponse(await this.specialOfferProductModelValidator.ValidateDeleteAsync(specialOfferID));
                        if (response.Success)
                        {
                                await this.specialOfferProductRepository.Delete(specialOfferID);
                        }

                        return response;
                }

                public async Task<List<ApiSpecialOfferProductResponseModel>> ByProductID(int productID)
                {
                        List<SpecialOfferProduct> records = await this.specialOfferProductRepository.ByProductID(productID);

                        return this.bolSpecialOfferProductMapper.MapBOToModel(this.dalSpecialOfferProductMapper.MapEFToBO(records));
                }

                public async virtual Task<List<ApiSalesOrderDetailResponseModel>> SalesOrderDetails(int specialOfferID, int limit = int.MaxValue, int offset = 0)
                {
                        List<SalesOrderDetail> records = await this.specialOfferProductRepository.SalesOrderDetails(specialOfferID, limit, offset);

                        return this.bolSalesOrderDetailMapper.MapBOToModel(this.dalSalesOrderDetailMapper.MapEFToBO(records));
                }
        }
}

/*<Codenesium>
    <Hash>fc2033035e6f9b6475a67821923c5249</Hash>
</Codenesium>*/