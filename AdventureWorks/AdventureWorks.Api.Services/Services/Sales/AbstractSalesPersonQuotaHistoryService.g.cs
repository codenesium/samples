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
        public abstract class AbstractSalesPersonQuotaHistoryService: AbstractService
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
                        IDALSalesPersonQuotaHistoryMapper dalSalesPersonQuotaHistoryMapper

                        )
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
                                var bo = this.bolSalesPersonQuotaHistoryMapper.MapModelToBO(default (int), model);
                                var record = await this.salesPersonQuotaHistoryRepository.Create(this.dalSalesPersonQuotaHistoryMapper.MapBOToEF(bo));

                                response.SetRecord(this.bolSalesPersonQuotaHistoryMapper.MapBOToModel(this.dalSalesPersonQuotaHistoryMapper.MapEFToBO(record)));
                        }

                        return response;
                }

                public virtual async Task<ActionResponse> Update(
                        int businessEntityID,
                        ApiSalesPersonQuotaHistoryRequestModel model)
                {
                        ActionResponse response = new ActionResponse(await this.salesPersonQuotaHistoryModelValidator.ValidateUpdateAsync(businessEntityID, model));

                        if (response.Success)
                        {
                                var bo = this.bolSalesPersonQuotaHistoryMapper.MapModelToBO(businessEntityID, model);
                                await this.salesPersonQuotaHistoryRepository.Update(this.dalSalesPersonQuotaHistoryMapper.MapBOToEF(bo));
                        }

                        return response;
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
    <Hash>8b351adb2f39b03988386e0d083d3ffc</Hash>
</Codenesium>*/