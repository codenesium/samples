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
                        IBOLSalesTerritoryHistoryMapper bolsalesTerritoryHistoryMapper,
                        IDALSalesTerritoryHistoryMapper dalsalesTerritoryHistoryMapper)
                        : base()

                {
                        this.salesTerritoryHistoryRepository = salesTerritoryHistoryRepository;
                        this.salesTerritoryHistoryModelValidator = salesTerritoryHistoryModelValidator;
                        this.bolSalesTerritoryHistoryMapper = bolsalesTerritoryHistoryMapper;
                        this.dalSalesTerritoryHistoryMapper = dalsalesTerritoryHistoryMapper;
                        this.logger = logger;
                }

                public virtual async Task<List<ApiSalesTerritoryHistoryResponseModel>> All(int skip = 0, int take = int.MaxValue, string orderClause = "")
                {
                        var records = await this.salesTerritoryHistoryRepository.All(skip, take, orderClause);

                        return this.bolSalesTerritoryHistoryMapper.MapBOToModel(this.dalSalesTerritoryHistoryMapper.MapEFToBO(records));
                }

                public virtual async Task<ApiSalesTerritoryHistoryResponseModel> Get(int businessEntityID)
                {
                        var record = await this.salesTerritoryHistoryRepository.Get(businessEntityID);

                        return this.bolSalesTerritoryHistoryMapper.MapBOToModel(this.dalSalesTerritoryHistoryMapper.MapEFToBO(record));
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
    <Hash>c53c696ce23a63b241b8e833a6b747c2</Hash>
</Codenesium>*/