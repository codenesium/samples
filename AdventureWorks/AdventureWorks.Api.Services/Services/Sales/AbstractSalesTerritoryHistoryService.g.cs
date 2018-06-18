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
        public abstract class AbstractSalesTerritoryHistoryService: AbstractService
        {
                private ISalesTerritoryHistoryRepository salesTerritoryHistoryRepository;

                private IApiSalesTerritoryHistoryRequestModelValidator salesTerritoryHistoryModelValidator;

                private IBOLSalesTerritoryHistoryMapper bolSalesTerritoryHistoryMapper;

                private IDALSalesTerritoryHistoryMapper dalSalesTerritoryHistoryMapper;

                private ILogger logger;

                public AbstractSalesTerritoryHistoryService(
                        ILogger logger,
                        ISalesTerritoryHistoryRepository salesTerritoryHistoryRepository,
                        IApiSalesTerritoryHistoryRequestModelValidator salesTerritoryHistoryModelValidator,
                        IBOLSalesTerritoryHistoryMapper bolSalesTerritoryHistoryMapper,
                        IDALSalesTerritoryHistoryMapper dalSalesTerritoryHistoryMapper

                        )
                        : base()

                {
                        this.salesTerritoryHistoryRepository = salesTerritoryHistoryRepository;
                        this.salesTerritoryHistoryModelValidator = salesTerritoryHistoryModelValidator;
                        this.bolSalesTerritoryHistoryMapper = bolSalesTerritoryHistoryMapper;
                        this.dalSalesTerritoryHistoryMapper = dalSalesTerritoryHistoryMapper;
                        this.logger = logger;
                }

                public virtual async Task<List<ApiSalesTerritoryHistoryResponseModel>> All(int limit = 0, int offset = int.MaxValue)
                {
                        var records = await this.salesTerritoryHistoryRepository.All(limit, offset);

                        return this.bolSalesTerritoryHistoryMapper.MapBOToModel(this.dalSalesTerritoryHistoryMapper.MapEFToBO(records));
                }

                public virtual async Task<ApiSalesTerritoryHistoryResponseModel> Get(int businessEntityID)
                {
                        var record = await this.salesTerritoryHistoryRepository.Get(businessEntityID);

                        if (record == null)
                        {
                                return null;
                        }
                        else
                        {
                                return this.bolSalesTerritoryHistoryMapper.MapBOToModel(this.dalSalesTerritoryHistoryMapper.MapEFToBO(record));
                        }
                }

                public virtual async Task<CreateResponse<ApiSalesTerritoryHistoryResponseModel>> Create(
                        ApiSalesTerritoryHistoryRequestModel model)
                {
                        CreateResponse<ApiSalesTerritoryHistoryResponseModel> response = new CreateResponse<ApiSalesTerritoryHistoryResponseModel>(await this.salesTerritoryHistoryModelValidator.ValidateCreateAsync(model));
                        if (response.Success)
                        {
                                var bo = this.bolSalesTerritoryHistoryMapper.MapModelToBO(default (int), model);
                                var record = await this.salesTerritoryHistoryRepository.Create(this.dalSalesTerritoryHistoryMapper.MapBOToEF(bo));

                                response.SetRecord(this.bolSalesTerritoryHistoryMapper.MapBOToModel(this.dalSalesTerritoryHistoryMapper.MapEFToBO(record)));
                        }

                        return response;
                }

                public virtual async Task<ActionResponse> Update(
                        int businessEntityID,
                        ApiSalesTerritoryHistoryRequestModel model)
                {
                        ActionResponse response = new ActionResponse(await this.salesTerritoryHistoryModelValidator.ValidateUpdateAsync(businessEntityID, model));

                        if (response.Success)
                        {
                                var bo = this.bolSalesTerritoryHistoryMapper.MapModelToBO(businessEntityID, model);
                                await this.salesTerritoryHistoryRepository.Update(this.dalSalesTerritoryHistoryMapper.MapBOToEF(bo));
                        }

                        return response;
                }

                public virtual async Task<ActionResponse> Delete(
                        int businessEntityID)
                {
                        ActionResponse response = new ActionResponse(await this.salesTerritoryHistoryModelValidator.ValidateDeleteAsync(businessEntityID));

                        if (response.Success)
                        {
                                await this.salesTerritoryHistoryRepository.Delete(businessEntityID);
                        }

                        return response;
                }
        }
}

/*<Codenesium>
    <Hash>5e9ad92e42dec3919ad2b536d65db74b</Hash>
</Codenesium>*/