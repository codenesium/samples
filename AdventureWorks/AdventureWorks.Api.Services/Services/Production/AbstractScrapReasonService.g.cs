using AdventureWorksNS.Api.Contracts;
using AdventureWorksNS.Api.DataAccess;
using Codenesium.DataConversionExtensions.AspNetCore;
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
        public abstract class AbstractScrapReasonService : AbstractService
        {
                private IScrapReasonRepository scrapReasonRepository;

                private IApiScrapReasonRequestModelValidator scrapReasonModelValidator;

                private IBOLScrapReasonMapper bolScrapReasonMapper;

                private IDALScrapReasonMapper dalScrapReasonMapper;

                private IBOLWorkOrderMapper bolWorkOrderMapper;

                private IDALWorkOrderMapper dalWorkOrderMapper;

                private ILogger logger;

                public AbstractScrapReasonService(
                        ILogger logger,
                        IScrapReasonRepository scrapReasonRepository,
                        IApiScrapReasonRequestModelValidator scrapReasonModelValidator,
                        IBOLScrapReasonMapper bolScrapReasonMapper,
                        IDALScrapReasonMapper dalScrapReasonMapper,
                        IBOLWorkOrderMapper bolWorkOrderMapper,
                        IDALWorkOrderMapper dalWorkOrderMapper)
                        : base()
                {
                        this.scrapReasonRepository = scrapReasonRepository;
                        this.scrapReasonModelValidator = scrapReasonModelValidator;
                        this.bolScrapReasonMapper = bolScrapReasonMapper;
                        this.dalScrapReasonMapper = dalScrapReasonMapper;
                        this.bolWorkOrderMapper = bolWorkOrderMapper;
                        this.dalWorkOrderMapper = dalWorkOrderMapper;
                        this.logger = logger;
                }

                public virtual async Task<List<ApiScrapReasonResponseModel>> All(int limit = 0, int offset = int.MaxValue)
                {
                        var records = await this.scrapReasonRepository.All(limit, offset);

                        return this.bolScrapReasonMapper.MapBOToModel(this.dalScrapReasonMapper.MapEFToBO(records));
                }

                public virtual async Task<ApiScrapReasonResponseModel> Get(short scrapReasonID)
                {
                        var record = await this.scrapReasonRepository.Get(scrapReasonID);

                        if (record == null)
                        {
                                return null;
                        }
                        else
                        {
                                return this.bolScrapReasonMapper.MapBOToModel(this.dalScrapReasonMapper.MapEFToBO(record));
                        }
                }

                public virtual async Task<CreateResponse<ApiScrapReasonResponseModel>> Create(
                        ApiScrapReasonRequestModel model)
                {
                        CreateResponse<ApiScrapReasonResponseModel> response = new CreateResponse<ApiScrapReasonResponseModel>(await this.scrapReasonModelValidator.ValidateCreateAsync(model));
                        if (response.Success)
                        {
                                var bo = this.bolScrapReasonMapper.MapModelToBO(default(short), model);
                                var record = await this.scrapReasonRepository.Create(this.dalScrapReasonMapper.MapBOToEF(bo));

                                response.SetRecord(this.bolScrapReasonMapper.MapBOToModel(this.dalScrapReasonMapper.MapEFToBO(record)));
                        }

                        return response;
                }

                public virtual async Task<ActionResponse> Update(
                        short scrapReasonID,
                        ApiScrapReasonRequestModel model)
                {
                        ActionResponse response = new ActionResponse(await this.scrapReasonModelValidator.ValidateUpdateAsync(scrapReasonID, model));
                        if (response.Success)
                        {
                                var bo = this.bolScrapReasonMapper.MapModelToBO(scrapReasonID, model);
                                await this.scrapReasonRepository.Update(this.dalScrapReasonMapper.MapBOToEF(bo));
                        }

                        return response;
                }

                public virtual async Task<ActionResponse> Delete(
                        short scrapReasonID)
                {
                        ActionResponse response = new ActionResponse(await this.scrapReasonModelValidator.ValidateDeleteAsync(scrapReasonID));
                        if (response.Success)
                        {
                                await this.scrapReasonRepository.Delete(scrapReasonID);
                        }

                        return response;
                }

                public async Task<ApiScrapReasonResponseModel> ByName(string name)
                {
                        ScrapReason record = await this.scrapReasonRepository.ByName(name);

                        if (record == null)
                        {
                                return null;
                        }
                        else
                        {
                                return this.bolScrapReasonMapper.MapBOToModel(this.dalScrapReasonMapper.MapEFToBO(record));
                        }
                }

                public async virtual Task<List<ApiWorkOrderResponseModel>> WorkOrders(short scrapReasonID, int limit = int.MaxValue, int offset = 0)
                {
                        List<WorkOrder> records = await this.scrapReasonRepository.WorkOrders(scrapReasonID, limit, offset);

                        return this.bolWorkOrderMapper.MapBOToModel(this.dalWorkOrderMapper.MapEFToBO(records));
                }
        }
}

/*<Codenesium>
    <Hash>2837be7c81efbaa14960d6f761a92ed2</Hash>
</Codenesium>*/