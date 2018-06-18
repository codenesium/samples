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
        public abstract class AbstractProductVendorService: AbstractService
        {
                private IProductVendorRepository productVendorRepository;

                private IApiProductVendorRequestModelValidator productVendorModelValidator;

                private IBOLProductVendorMapper bolProductVendorMapper;

                private IDALProductVendorMapper dalProductVendorMapper;

                private ILogger logger;

                public AbstractProductVendorService(
                        ILogger logger,
                        IProductVendorRepository productVendorRepository,
                        IApiProductVendorRequestModelValidator productVendorModelValidator,
                        IBOLProductVendorMapper bolProductVendorMapper,
                        IDALProductVendorMapper dalProductVendorMapper

                        )
                        : base()

                {
                        this.productVendorRepository = productVendorRepository;
                        this.productVendorModelValidator = productVendorModelValidator;
                        this.bolProductVendorMapper = bolProductVendorMapper;
                        this.dalProductVendorMapper = dalProductVendorMapper;
                        this.logger = logger;
                }

                public virtual async Task<List<ApiProductVendorResponseModel>> All(int limit = 0, int offset = int.MaxValue)
                {
                        var records = await this.productVendorRepository.All(limit, offset);

                        return this.bolProductVendorMapper.MapBOToModel(this.dalProductVendorMapper.MapEFToBO(records));
                }

                public virtual async Task<ApiProductVendorResponseModel> Get(int productID)
                {
                        var record = await this.productVendorRepository.Get(productID);

                        if (record == null)
                        {
                                return null;
                        }
                        else
                        {
                                return this.bolProductVendorMapper.MapBOToModel(this.dalProductVendorMapper.MapEFToBO(record));
                        }
                }

                public virtual async Task<CreateResponse<ApiProductVendorResponseModel>> Create(
                        ApiProductVendorRequestModel model)
                {
                        CreateResponse<ApiProductVendorResponseModel> response = new CreateResponse<ApiProductVendorResponseModel>(await this.productVendorModelValidator.ValidateCreateAsync(model));
                        if (response.Success)
                        {
                                var bo = this.bolProductVendorMapper.MapModelToBO(default (int), model);
                                var record = await this.productVendorRepository.Create(this.dalProductVendorMapper.MapBOToEF(bo));

                                response.SetRecord(this.bolProductVendorMapper.MapBOToModel(this.dalProductVendorMapper.MapEFToBO(record)));
                        }

                        return response;
                }

                public virtual async Task<ActionResponse> Update(
                        int productID,
                        ApiProductVendorRequestModel model)
                {
                        ActionResponse response = new ActionResponse(await this.productVendorModelValidator.ValidateUpdateAsync(productID, model));

                        if (response.Success)
                        {
                                var bo = this.bolProductVendorMapper.MapModelToBO(productID, model);
                                await this.productVendorRepository.Update(this.dalProductVendorMapper.MapBOToEF(bo));
                        }

                        return response;
                }

                public virtual async Task<ActionResponse> Delete(
                        int productID)
                {
                        ActionResponse response = new ActionResponse(await this.productVendorModelValidator.ValidateDeleteAsync(productID));

                        if (response.Success)
                        {
                                await this.productVendorRepository.Delete(productID);
                        }

                        return response;
                }

                public async Task<List<ApiProductVendorResponseModel>> ByBusinessEntityID(int businessEntityID)
                {
                        List<ProductVendor> records = await this.productVendorRepository.ByBusinessEntityID(businessEntityID);

                        return this.bolProductVendorMapper.MapBOToModel(this.dalProductVendorMapper.MapEFToBO(records));
                }
                public async Task<List<ApiProductVendorResponseModel>> ByUnitMeasureCode(string unitMeasureCode)
                {
                        List<ProductVendor> records = await this.productVendorRepository.ByUnitMeasureCode(unitMeasureCode);

                        return this.bolProductVendorMapper.MapBOToModel(this.dalProductVendorMapper.MapEFToBO(records));
                }
        }
}

/*<Codenesium>
    <Hash>950af9be2e1d00f9b78f44cf54047c31</Hash>
</Codenesium>*/