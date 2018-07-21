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
        public abstract class AbstractSalesReasonService : AbstractService
        {
                private ISalesReasonRepository salesReasonRepository;

                private IApiSalesReasonRequestModelValidator salesReasonModelValidator;

                private IBOLSalesReasonMapper bolSalesReasonMapper;

                private IDALSalesReasonMapper dalSalesReasonMapper;

                private IBOLSalesOrderHeaderSalesReasonMapper bolSalesOrderHeaderSalesReasonMapper;

                private IDALSalesOrderHeaderSalesReasonMapper dalSalesOrderHeaderSalesReasonMapper;

                private ILogger logger;

                public AbstractSalesReasonService(
                        ILogger logger,
                        ISalesReasonRepository salesReasonRepository,
                        IApiSalesReasonRequestModelValidator salesReasonModelValidator,
                        IBOLSalesReasonMapper bolSalesReasonMapper,
                        IDALSalesReasonMapper dalSalesReasonMapper,
                        IBOLSalesOrderHeaderSalesReasonMapper bolSalesOrderHeaderSalesReasonMapper,
                        IDALSalesOrderHeaderSalesReasonMapper dalSalesOrderHeaderSalesReasonMapper)
                        : base()
                {
                        this.salesReasonRepository = salesReasonRepository;
                        this.salesReasonModelValidator = salesReasonModelValidator;
                        this.bolSalesReasonMapper = bolSalesReasonMapper;
                        this.dalSalesReasonMapper = dalSalesReasonMapper;
                        this.bolSalesOrderHeaderSalesReasonMapper = bolSalesOrderHeaderSalesReasonMapper;
                        this.dalSalesOrderHeaderSalesReasonMapper = dalSalesOrderHeaderSalesReasonMapper;
                        this.logger = logger;
                }

                public virtual async Task<List<ApiSalesReasonResponseModel>> All(int limit = 0, int offset = int.MaxValue)
                {
                        var records = await this.salesReasonRepository.All(limit, offset);

                        return this.bolSalesReasonMapper.MapBOToModel(this.dalSalesReasonMapper.MapEFToBO(records));
                }

                public virtual async Task<ApiSalesReasonResponseModel> Get(int salesReasonID)
                {
                        var record = await this.salesReasonRepository.Get(salesReasonID);

                        if (record == null)
                        {
                                return null;
                        }
                        else
                        {
                                return this.bolSalesReasonMapper.MapBOToModel(this.dalSalesReasonMapper.MapEFToBO(record));
                        }
                }

                public virtual async Task<CreateResponse<ApiSalesReasonResponseModel>> Create(
                        ApiSalesReasonRequestModel model)
                {
                        CreateResponse<ApiSalesReasonResponseModel> response = new CreateResponse<ApiSalesReasonResponseModel>(await this.salesReasonModelValidator.ValidateCreateAsync(model));
                        if (response.Success)
                        {
                                var bo = this.bolSalesReasonMapper.MapModelToBO(default(int), model);
                                var record = await this.salesReasonRepository.Create(this.dalSalesReasonMapper.MapBOToEF(bo));

                                response.SetRecord(this.bolSalesReasonMapper.MapBOToModel(this.dalSalesReasonMapper.MapEFToBO(record)));
                        }

                        return response;
                }

                public virtual async Task<UpdateResponse<ApiSalesReasonResponseModel>> Update(
                        int salesReasonID,
                        ApiSalesReasonRequestModel model)
                {
                        var validationResult = await this.salesReasonModelValidator.ValidateUpdateAsync(salesReasonID, model);

                        if (validationResult.IsValid)
                        {
                                var bo = this.bolSalesReasonMapper.MapModelToBO(salesReasonID, model);
                                await this.salesReasonRepository.Update(this.dalSalesReasonMapper.MapBOToEF(bo));

                                var record = await this.salesReasonRepository.Get(salesReasonID);

                                return new UpdateResponse<ApiSalesReasonResponseModel>(this.bolSalesReasonMapper.MapBOToModel(this.dalSalesReasonMapper.MapEFToBO(record)));
                        }
                        else
                        {
                                return new UpdateResponse<ApiSalesReasonResponseModel>(validationResult);
                        }
                }

                public virtual async Task<ActionResponse> Delete(
                        int salesReasonID)
                {
                        ActionResponse response = new ActionResponse(await this.salesReasonModelValidator.ValidateDeleteAsync(salesReasonID));
                        if (response.Success)
                        {
                                await this.salesReasonRepository.Delete(salesReasonID);
                        }

                        return response;
                }

                public async virtual Task<List<ApiSalesOrderHeaderSalesReasonResponseModel>> SalesOrderHeaderSalesReasons(int salesReasonID, int limit = int.MaxValue, int offset = 0)
                {
                        List<SalesOrderHeaderSalesReason> records = await this.salesReasonRepository.SalesOrderHeaderSalesReasons(salesReasonID, limit, offset);

                        return this.bolSalesOrderHeaderSalesReasonMapper.MapBOToModel(this.dalSalesOrderHeaderSalesReasonMapper.MapEFToBO(records));
                }
        }
}

/*<Codenesium>
    <Hash>9641f4483a56c2300a3a6104a7091500</Hash>
</Codenesium>*/