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
        public abstract class AbstractSalesPersonQuotaHistoryService : AbstractService
        {
                private ISalesPersonQuotaHistoryRepository salesPersonQuotaHistoryRepository;

                private IApiSalesPersonQuotaHistoryRequestModelValidator salesPersonQuotaHistoryModelValidator;

                private IBOLSalesPersonQuotaHistoryMapper bolSalesPersonQuotaHistoryMapper;

                private IDALSalesPersonQuotaHistoryMapper dalSalesPersonQuotaHistoryMapper;

                private ILogger logger;

                public AbstractSalesPersonQuotaHistoryService(
                        ILogger logger,
                        ISalesPersonQuotaHistoryRepository salesPersonQuotaHistoryRepository,
                        IApiSalesPersonQuotaHistoryRequestModelValidator salesPersonQuotaHistoryModelValidator,
                        IBOLSalesPersonQuotaHistoryMapper bolSalesPersonQuotaHistoryMapper,
                        IDALSalesPersonQuotaHistoryMapper dalSalesPersonQuotaHistoryMapper)
                        : base()
                {
                        this.salesPersonQuotaHistoryRepository = salesPersonQuotaHistoryRepository;
                        this.salesPersonQuotaHistoryModelValidator = salesPersonQuotaHistoryModelValidator;
                        this.bolSalesPersonQuotaHistoryMapper = bolSalesPersonQuotaHistoryMapper;
                        this.dalSalesPersonQuotaHistoryMapper = dalSalesPersonQuotaHistoryMapper;
                        this.logger = logger;
                }

                public virtual async Task<List<ApiSalesPersonQuotaHistoryResponseModel>> All(int limit = 0, int offset = int.MaxValue)
                {
                        var records = await this.salesPersonQuotaHistoryRepository.All(limit, offset);

                        return this.bolSalesPersonQuotaHistoryMapper.MapBOToModel(this.dalSalesPersonQuotaHistoryMapper.MapEFToBO(records));
                }

                public virtual async Task<ApiSalesPersonQuotaHistoryResponseModel> Get(int businessEntityID)
                {
                        var record = await this.salesPersonQuotaHistoryRepository.Get(businessEntityID);

                        if (record == null)
                        {
                                return null;
                        }
                        else
                        {
                                return this.bolSalesPersonQuotaHistoryMapper.MapBOToModel(this.dalSalesPersonQuotaHistoryMapper.MapEFToBO(record));
                        }
                }

                public virtual async Task<CreateResponse<ApiSalesPersonQuotaHistoryResponseModel>> Create(
                        ApiSalesPersonQuotaHistoryRequestModel model)
                {
                        CreateResponse<ApiSalesPersonQuotaHistoryResponseModel> response = new CreateResponse<ApiSalesPersonQuotaHistoryResponseModel>(await this.salesPersonQuotaHistoryModelValidator.ValidateCreateAsync(model));
                        if (response.Success)
                        {
                                var bo = this.bolSalesPersonQuotaHistoryMapper.MapModelToBO(default(int), model);
                                var record = await this.salesPersonQuotaHistoryRepository.Create(this.dalSalesPersonQuotaHistoryMapper.MapBOToEF(bo));

                                response.SetRecord(this.bolSalesPersonQuotaHistoryMapper.MapBOToModel(this.dalSalesPersonQuotaHistoryMapper.MapEFToBO(record)));
                        }

                        return response;
                }

                public virtual async Task<UpdateResponse<ApiSalesPersonQuotaHistoryResponseModel>> Update(
                        int businessEntityID,
                        ApiSalesPersonQuotaHistoryRequestModel model)
                {
                        var validationResult = await this.salesPersonQuotaHistoryModelValidator.ValidateUpdateAsync(businessEntityID, model);

                        if (validationResult.IsValid)
                        {
                                var bo = this.bolSalesPersonQuotaHistoryMapper.MapModelToBO(businessEntityID, model);
                                await this.salesPersonQuotaHistoryRepository.Update(this.dalSalesPersonQuotaHistoryMapper.MapBOToEF(bo));

                                var record = await this.salesPersonQuotaHistoryRepository.Get(businessEntityID);

                                return new UpdateResponse<ApiSalesPersonQuotaHistoryResponseModel>(this.bolSalesPersonQuotaHistoryMapper.MapBOToModel(this.dalSalesPersonQuotaHistoryMapper.MapEFToBO(record)));
                        }
                        else
                        {
                                return new UpdateResponse<ApiSalesPersonQuotaHistoryResponseModel>(validationResult);
                        }
                }

                public virtual async Task<ActionResponse> Delete(
                        int businessEntityID)
                {
                        ActionResponse response = new ActionResponse(await this.salesPersonQuotaHistoryModelValidator.ValidateDeleteAsync(businessEntityID));
                        if (response.Success)
                        {
                                await this.salesPersonQuotaHistoryRepository.Delete(businessEntityID);
                        }

                        return response;
                }
        }
}

/*<Codenesium>
    <Hash>66721cc9b882c61bab6a0ae7ab6434ff</Hash>
</Codenesium>*/