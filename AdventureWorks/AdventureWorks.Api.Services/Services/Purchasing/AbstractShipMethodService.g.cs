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
        public abstract class AbstractShipMethodService: AbstractService
        {
                private IShipMethodRepository shipMethodRepository;

                private IApiShipMethodRequestModelValidator shipMethodModelValidator;

                private IBOLShipMethodMapper bolShipMethodMapper;

                private IDALShipMethodMapper dalShipMethodMapper;

                private ILogger logger;

                public AbstractShipMethodService(
                        ILogger logger,
                        IShipMethodRepository shipMethodRepository,
                        IApiShipMethodRequestModelValidator shipMethodModelValidator,
                        IBOLShipMethodMapper bolshipMethodMapper,
                        IDALShipMethodMapper dalshipMethodMapper)
                        : base()

                {
                        this.shipMethodRepository = shipMethodRepository;
                        this.shipMethodModelValidator = shipMethodModelValidator;
                        this.bolShipMethodMapper = bolshipMethodMapper;
                        this.dalShipMethodMapper = dalshipMethodMapper;
                        this.logger = logger;
                }

                public virtual async Task<List<ApiShipMethodResponseModel>> All(int skip = 0, int take = int.MaxValue, string orderClause = "")
                {
                        var records = await this.shipMethodRepository.All(skip, take, orderClause);

                        return this.bolShipMethodMapper.MapBOToModel(this.dalShipMethodMapper.MapEFToBO(records));
                }

                public virtual async Task<ApiShipMethodResponseModel> Get(int shipMethodID)
                {
                        var record = await this.shipMethodRepository.Get(shipMethodID);

                        return this.bolShipMethodMapper.MapBOToModel(this.dalShipMethodMapper.MapEFToBO(record));
                }

                public virtual async Task<CreateResponse<ApiShipMethodResponseModel>> Create(
                        ApiShipMethodRequestModel model)
                {
                        CreateResponse<ApiShipMethodResponseModel> response = new CreateResponse<ApiShipMethodResponseModel>(await this.shipMethodModelValidator.ValidateCreateAsync(model));
                        if (response.Success)
                        {
                                var bo = this.bolShipMethodMapper.MapModelToBO(default (int), model);
                                var record = await this.shipMethodRepository.Create(this.dalShipMethodMapper.MapBOToEF(bo));

                                response.SetRecord(this.bolShipMethodMapper.MapBOToModel(this.dalShipMethodMapper.MapEFToBO(record)));
                        }

                        return response;
                }

                public virtual async Task<ActionResponse> Update(
                        int shipMethodID,
                        ApiShipMethodRequestModel model)
                {
                        ActionResponse response = new ActionResponse(await this.shipMethodModelValidator.ValidateUpdateAsync(shipMethodID, model));

                        if (response.Success)
                        {
                                var bo = this.bolShipMethodMapper.MapModelToBO(shipMethodID, model);
                                await this.shipMethodRepository.Update(this.dalShipMethodMapper.MapBOToEF(bo));
                        }

                        return response;
                }

                public virtual async Task<ActionResponse> Delete(
                        int shipMethodID)
                {
                        ActionResponse response = new ActionResponse(await this.shipMethodModelValidator.ValidateDeleteAsync(shipMethodID));

                        if (response.Success)
                        {
                                await this.shipMethodRepository.Delete(shipMethodID);
                        }

                        return response;
                }

                public async Task<ApiShipMethodResponseModel> GetName(string name)
                {
                        ShipMethod record = await this.shipMethodRepository.GetName(name);

                        return this.bolShipMethodMapper.MapBOToModel(this.dalShipMethodMapper.MapEFToBO(record));
                }
        }
}

/*<Codenesium>
    <Hash>436a158593b1525914f78c0fc95a9ec5</Hash>
</Codenesium>*/