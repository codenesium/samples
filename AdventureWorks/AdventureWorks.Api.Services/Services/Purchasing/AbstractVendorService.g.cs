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
        public abstract class AbstractVendorService : AbstractService
        {
                private IVendorRepository vendorRepository;

                private IApiVendorRequestModelValidator vendorModelValidator;

                private IBOLVendorMapper bolVendorMapper;

                private IDALVendorMapper dalVendorMapper;

                private IBOLProductVendorMapper bolProductVendorMapper;

                private IDALProductVendorMapper dalProductVendorMapper;
                private IBOLPurchaseOrderHeaderMapper bolPurchaseOrderHeaderMapper;

                private IDALPurchaseOrderHeaderMapper dalPurchaseOrderHeaderMapper;

                private ILogger logger;

                public AbstractVendorService(
                        ILogger logger,
                        IVendorRepository vendorRepository,
                        IApiVendorRequestModelValidator vendorModelValidator,
                        IBOLVendorMapper bolVendorMapper,
                        IDALVendorMapper dalVendorMapper,
                        IBOLProductVendorMapper bolProductVendorMapper,
                        IDALProductVendorMapper dalProductVendorMapper,
                        IBOLPurchaseOrderHeaderMapper bolPurchaseOrderHeaderMapper,
                        IDALPurchaseOrderHeaderMapper dalPurchaseOrderHeaderMapper)
                        : base()
                {
                        this.vendorRepository = vendorRepository;
                        this.vendorModelValidator = vendorModelValidator;
                        this.bolVendorMapper = bolVendorMapper;
                        this.dalVendorMapper = dalVendorMapper;
                        this.bolProductVendorMapper = bolProductVendorMapper;
                        this.dalProductVendorMapper = dalProductVendorMapper;
                        this.bolPurchaseOrderHeaderMapper = bolPurchaseOrderHeaderMapper;
                        this.dalPurchaseOrderHeaderMapper = dalPurchaseOrderHeaderMapper;
                        this.logger = logger;
                }

                public virtual async Task<List<ApiVendorResponseModel>> All(int limit = 0, int offset = int.MaxValue)
                {
                        var records = await this.vendorRepository.All(limit, offset);

                        return this.bolVendorMapper.MapBOToModel(this.dalVendorMapper.MapEFToBO(records));
                }

                public virtual async Task<ApiVendorResponseModel> Get(int businessEntityID)
                {
                        var record = await this.vendorRepository.Get(businessEntityID);

                        if (record == null)
                        {
                                return null;
                        }
                        else
                        {
                                return this.bolVendorMapper.MapBOToModel(this.dalVendorMapper.MapEFToBO(record));
                        }
                }

                public virtual async Task<CreateResponse<ApiVendorResponseModel>> Create(
                        ApiVendorRequestModel model)
                {
                        CreateResponse<ApiVendorResponseModel> response = new CreateResponse<ApiVendorResponseModel>(await this.vendorModelValidator.ValidateCreateAsync(model));
                        if (response.Success)
                        {
                                var bo = this.bolVendorMapper.MapModelToBO(default(int), model);
                                var record = await this.vendorRepository.Create(this.dalVendorMapper.MapBOToEF(bo));

                                response.SetRecord(this.bolVendorMapper.MapBOToModel(this.dalVendorMapper.MapEFToBO(record)));
                        }

                        return response;
                }

                public virtual async Task<UpdateResponse<ApiVendorResponseModel>> Update(
                        int businessEntityID,
                        ApiVendorRequestModel model)
                {
                        var validationResult = await this.vendorModelValidator.ValidateUpdateAsync(businessEntityID, model);

                        if (validationResult.IsValid)
                        {
                                var bo = this.bolVendorMapper.MapModelToBO(businessEntityID, model);
                                await this.vendorRepository.Update(this.dalVendorMapper.MapBOToEF(bo));

                                var record = await this.vendorRepository.Get(businessEntityID);

                                return new UpdateResponse<ApiVendorResponseModel>(this.bolVendorMapper.MapBOToModel(this.dalVendorMapper.MapEFToBO(record)));
                        }
                        else
                        {
                                return new UpdateResponse<ApiVendorResponseModel>(validationResult);
                        }
                }

                public virtual async Task<ActionResponse> Delete(
                        int businessEntityID)
                {
                        ActionResponse response = new ActionResponse(await this.vendorModelValidator.ValidateDeleteAsync(businessEntityID));
                        if (response.Success)
                        {
                                await this.vendorRepository.Delete(businessEntityID);
                        }

                        return response;
                }

                public async Task<ApiVendorResponseModel> ByAccountNumber(string accountNumber)
                {
                        Vendor record = await this.vendorRepository.ByAccountNumber(accountNumber);

                        if (record == null)
                        {
                                return null;
                        }
                        else
                        {
                                return this.bolVendorMapper.MapBOToModel(this.dalVendorMapper.MapEFToBO(record));
                        }
                }

                public async virtual Task<List<ApiProductVendorResponseModel>> ProductVendors(int businessEntityID, int limit = int.MaxValue, int offset = 0)
                {
                        List<ProductVendor> records = await this.vendorRepository.ProductVendors(businessEntityID, limit, offset);

                        return this.bolProductVendorMapper.MapBOToModel(this.dalProductVendorMapper.MapEFToBO(records));
                }

                public async virtual Task<List<ApiPurchaseOrderHeaderResponseModel>> PurchaseOrderHeaders(int vendorID, int limit = int.MaxValue, int offset = 0)
                {
                        List<PurchaseOrderHeader> records = await this.vendorRepository.PurchaseOrderHeaders(vendorID, limit, offset);

                        return this.bolPurchaseOrderHeaderMapper.MapBOToModel(this.dalPurchaseOrderHeaderMapper.MapEFToBO(records));
                }
        }
}

/*<Codenesium>
    <Hash>3f84e08231c08ad361ee0a1bbcb9be62</Hash>
</Codenesium>*/