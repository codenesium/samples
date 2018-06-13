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
        public abstract class AbstractLocationService: AbstractService
        {
                private ILocationRepository locationRepository;

                private IApiLocationRequestModelValidator locationModelValidator;

                private IBOLLocationMapper bolLocationMapper;

                private IDALLocationMapper dalLocationMapper;

                private IBOLProductInventoryMapper bolProductInventoryMapper;

                private IDALProductInventoryMapper dalProductInventoryMapper;
                private IBOLWorkOrderRoutingMapper bolWorkOrderRoutingMapper;

                private IDALWorkOrderRoutingMapper dalWorkOrderRoutingMapper;

                private ILogger logger;

                public AbstractLocationService(
                        ILogger logger,
                        ILocationRepository locationRepository,
                        IApiLocationRequestModelValidator locationModelValidator,
                        IBOLLocationMapper bolLocationMapper,
                        IDALLocationMapper dalLocationMapper

                        ,
                        IBOLProductInventoryMapper bolProductInventoryMapper,
                        IDALProductInventoryMapper dalProductInventoryMapper
                        ,
                        IBOLWorkOrderRoutingMapper bolWorkOrderRoutingMapper,
                        IDALWorkOrderRoutingMapper dalWorkOrderRoutingMapper

                        )
                        : base()

                {
                        this.locationRepository = locationRepository;
                        this.locationModelValidator = locationModelValidator;
                        this.bolLocationMapper = bolLocationMapper;
                        this.dalLocationMapper = dalLocationMapper;
                        this.bolProductInventoryMapper = bolProductInventoryMapper;
                        this.dalProductInventoryMapper = dalProductInventoryMapper;
                        this.bolWorkOrderRoutingMapper = bolWorkOrderRoutingMapper;
                        this.dalWorkOrderRoutingMapper = dalWorkOrderRoutingMapper;
                        this.logger = logger;
                }

                public virtual async Task<List<ApiLocationResponseModel>> All(int limit = 0, int offset = int.MaxValue, string orderClause = "")
                {
                        var records = await this.locationRepository.All(limit, offset, orderClause);

                        return this.bolLocationMapper.MapBOToModel(this.dalLocationMapper.MapEFToBO(records));
                }

                public virtual async Task<ApiLocationResponseModel> Get(short locationID)
                {
                        var record = await this.locationRepository.Get(locationID);

                        return this.bolLocationMapper.MapBOToModel(this.dalLocationMapper.MapEFToBO(record));
                }

                public virtual async Task<CreateResponse<ApiLocationResponseModel>> Create(
                        ApiLocationRequestModel model)
                {
                        CreateResponse<ApiLocationResponseModel> response = new CreateResponse<ApiLocationResponseModel>(await this.locationModelValidator.ValidateCreateAsync(model));
                        if (response.Success)
                        {
                                var bo = this.bolLocationMapper.MapModelToBO(default (short), model);
                                var record = await this.locationRepository.Create(this.dalLocationMapper.MapBOToEF(bo));

                                response.SetRecord(this.bolLocationMapper.MapBOToModel(this.dalLocationMapper.MapEFToBO(record)));
                        }

                        return response;
                }

                public virtual async Task<ActionResponse> Update(
                        short locationID,
                        ApiLocationRequestModel model)
                {
                        ActionResponse response = new ActionResponse(await this.locationModelValidator.ValidateUpdateAsync(locationID, model));

                        if (response.Success)
                        {
                                var bo = this.bolLocationMapper.MapModelToBO(locationID, model);
                                await this.locationRepository.Update(this.dalLocationMapper.MapBOToEF(bo));
                        }

                        return response;
                }

                public virtual async Task<ActionResponse> Delete(
                        short locationID)
                {
                        ActionResponse response = new ActionResponse(await this.locationModelValidator.ValidateDeleteAsync(locationID));

                        if (response.Success)
                        {
                                await this.locationRepository.Delete(locationID);
                        }

                        return response;
                }

                public async Task<ApiLocationResponseModel> GetName(string name)
                {
                        Location record = await this.locationRepository.GetName(name);

                        return this.bolLocationMapper.MapBOToModel(this.dalLocationMapper.MapEFToBO(record));
                }

                public async virtual Task<List<ApiProductInventoryResponseModel>> ProductInventories(short locationID, int limit = int.MaxValue, int offset = 0)
                {
                        List<ProductInventory> records = await this.locationRepository.ProductInventories(locationID, limit, offset);

                        return this.bolProductInventoryMapper.MapBOToModel(this.dalProductInventoryMapper.MapEFToBO(records));
                }
                public async virtual Task<List<ApiWorkOrderRoutingResponseModel>> WorkOrderRoutings(short locationID, int limit = int.MaxValue, int offset = 0)
                {
                        List<WorkOrderRouting> records = await this.locationRepository.WorkOrderRoutings(locationID, limit, offset);

                        return this.bolWorkOrderRoutingMapper.MapBOToModel(this.dalWorkOrderRoutingMapper.MapEFToBO(records));
                }
        }
}

/*<Codenesium>
    <Hash>0ccf4945c18d1614e7a0024c08758030</Hash>
</Codenesium>*/