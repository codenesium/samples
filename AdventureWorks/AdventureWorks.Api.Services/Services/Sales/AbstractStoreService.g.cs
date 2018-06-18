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
        public abstract class AbstractStoreService: AbstractService
        {
                private IStoreRepository storeRepository;

                private IApiStoreRequestModelValidator storeModelValidator;

                private IBOLStoreMapper bolStoreMapper;

                private IDALStoreMapper dalStoreMapper;

                private IBOLCustomerMapper bolCustomerMapper;

                private IDALCustomerMapper dalCustomerMapper;

                private ILogger logger;

                public AbstractStoreService(
                        ILogger logger,
                        IStoreRepository storeRepository,
                        IApiStoreRequestModelValidator storeModelValidator,
                        IBOLStoreMapper bolStoreMapper,
                        IDALStoreMapper dalStoreMapper

                        ,
                        IBOLCustomerMapper bolCustomerMapper,
                        IDALCustomerMapper dalCustomerMapper

                        )
                        : base()

                {
                        this.storeRepository = storeRepository;
                        this.storeModelValidator = storeModelValidator;
                        this.bolStoreMapper = bolStoreMapper;
                        this.dalStoreMapper = dalStoreMapper;
                        this.bolCustomerMapper = bolCustomerMapper;
                        this.dalCustomerMapper = dalCustomerMapper;
                        this.logger = logger;
                }

                public virtual async Task<List<ApiStoreResponseModel>> All(int limit = 0, int offset = int.MaxValue)
                {
                        var records = await this.storeRepository.All(limit, offset);

                        return this.bolStoreMapper.MapBOToModel(this.dalStoreMapper.MapEFToBO(records));
                }

                public virtual async Task<ApiStoreResponseModel> Get(int businessEntityID)
                {
                        var record = await this.storeRepository.Get(businessEntityID);

                        if (record == null)
                        {
                                return null;
                        }
                        else
                        {
                                return this.bolStoreMapper.MapBOToModel(this.dalStoreMapper.MapEFToBO(record));
                        }
                }

                public virtual async Task<CreateResponse<ApiStoreResponseModel>> Create(
                        ApiStoreRequestModel model)
                {
                        CreateResponse<ApiStoreResponseModel> response = new CreateResponse<ApiStoreResponseModel>(await this.storeModelValidator.ValidateCreateAsync(model));
                        if (response.Success)
                        {
                                var bo = this.bolStoreMapper.MapModelToBO(default (int), model);
                                var record = await this.storeRepository.Create(this.dalStoreMapper.MapBOToEF(bo));

                                response.SetRecord(this.bolStoreMapper.MapBOToModel(this.dalStoreMapper.MapEFToBO(record)));
                        }

                        return response;
                }

                public virtual async Task<ActionResponse> Update(
                        int businessEntityID,
                        ApiStoreRequestModel model)
                {
                        ActionResponse response = new ActionResponse(await this.storeModelValidator.ValidateUpdateAsync(businessEntityID, model));

                        if (response.Success)
                        {
                                var bo = this.bolStoreMapper.MapModelToBO(businessEntityID, model);
                                await this.storeRepository.Update(this.dalStoreMapper.MapBOToEF(bo));
                        }

                        return response;
                }

                public virtual async Task<ActionResponse> Delete(
                        int businessEntityID)
                {
                        ActionResponse response = new ActionResponse(await this.storeModelValidator.ValidateDeleteAsync(businessEntityID));

                        if (response.Success)
                        {
                                await this.storeRepository.Delete(businessEntityID);
                        }

                        return response;
                }

                public async Task<List<ApiStoreResponseModel>> BySalesPersonID(Nullable<int> salesPersonID)
                {
                        List<Store> records = await this.storeRepository.BySalesPersonID(salesPersonID);

                        return this.bolStoreMapper.MapBOToModel(this.dalStoreMapper.MapEFToBO(records));
                }
                public async Task<List<ApiStoreResponseModel>> ByDemographics(string demographics)
                {
                        List<Store> records = await this.storeRepository.ByDemographics(demographics);

                        return this.bolStoreMapper.MapBOToModel(this.dalStoreMapper.MapEFToBO(records));
                }

                public async virtual Task<List<ApiCustomerResponseModel>> Customers(int storeID, int limit = int.MaxValue, int offset = 0)
                {
                        List<Customer> records = await this.storeRepository.Customers(storeID, limit, offset);

                        return this.bolCustomerMapper.MapBOToModel(this.dalCustomerMapper.MapEFToBO(records));
                }
        }
}

/*<Codenesium>
    <Hash>bd608d6d8233f3e512ff9b51c1ea9403</Hash>
</Codenesium>*/