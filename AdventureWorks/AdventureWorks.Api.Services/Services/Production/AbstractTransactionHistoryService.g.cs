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
        public abstract class AbstractTransactionHistoryService : AbstractService
        {
                private ITransactionHistoryRepository transactionHistoryRepository;

                private IApiTransactionHistoryRequestModelValidator transactionHistoryModelValidator;

                private IBOLTransactionHistoryMapper bolTransactionHistoryMapper;

                private IDALTransactionHistoryMapper dalTransactionHistoryMapper;

                private ILogger logger;

                public AbstractTransactionHistoryService(
                        ILogger logger,
                        ITransactionHistoryRepository transactionHistoryRepository,
                        IApiTransactionHistoryRequestModelValidator transactionHistoryModelValidator,
                        IBOLTransactionHistoryMapper bolTransactionHistoryMapper,
                        IDALTransactionHistoryMapper dalTransactionHistoryMapper)
                        : base()
                {
                        this.transactionHistoryRepository = transactionHistoryRepository;
                        this.transactionHistoryModelValidator = transactionHistoryModelValidator;
                        this.bolTransactionHistoryMapper = bolTransactionHistoryMapper;
                        this.dalTransactionHistoryMapper = dalTransactionHistoryMapper;
                        this.logger = logger;
                }

                public virtual async Task<List<ApiTransactionHistoryResponseModel>> All(int limit = 0, int offset = int.MaxValue)
                {
                        var records = await this.transactionHistoryRepository.All(limit, offset);

                        return this.bolTransactionHistoryMapper.MapBOToModel(this.dalTransactionHistoryMapper.MapEFToBO(records));
                }

                public virtual async Task<ApiTransactionHistoryResponseModel> Get(int transactionID)
                {
                        var record = await this.transactionHistoryRepository.Get(transactionID);

                        if (record == null)
                        {
                                return null;
                        }
                        else
                        {
                                return this.bolTransactionHistoryMapper.MapBOToModel(this.dalTransactionHistoryMapper.MapEFToBO(record));
                        }
                }

                public virtual async Task<CreateResponse<ApiTransactionHistoryResponseModel>> Create(
                        ApiTransactionHistoryRequestModel model)
                {
                        CreateResponse<ApiTransactionHistoryResponseModel> response = new CreateResponse<ApiTransactionHistoryResponseModel>(await this.transactionHistoryModelValidator.ValidateCreateAsync(model));
                        if (response.Success)
                        {
                                var bo = this.bolTransactionHistoryMapper.MapModelToBO(default(int), model);
                                var record = await this.transactionHistoryRepository.Create(this.dalTransactionHistoryMapper.MapBOToEF(bo));

                                response.SetRecord(this.bolTransactionHistoryMapper.MapBOToModel(this.dalTransactionHistoryMapper.MapEFToBO(record)));
                        }

                        return response;
                }

                public virtual async Task<UpdateResponse<ApiTransactionHistoryResponseModel>> Update(
                        int transactionID,
                        ApiTransactionHistoryRequestModel model)
                {
                        var validationResult = await this.transactionHistoryModelValidator.ValidateUpdateAsync(transactionID, model);

                        if (validationResult.IsValid)
                        {
                                var bo = this.bolTransactionHistoryMapper.MapModelToBO(transactionID, model);
                                await this.transactionHistoryRepository.Update(this.dalTransactionHistoryMapper.MapBOToEF(bo));

                                var record = await this.transactionHistoryRepository.Get(transactionID);

                                return new UpdateResponse<ApiTransactionHistoryResponseModel>(this.bolTransactionHistoryMapper.MapBOToModel(this.dalTransactionHistoryMapper.MapEFToBO(record)));
                        }
                        else
                        {
                                return new UpdateResponse<ApiTransactionHistoryResponseModel>(validationResult);
                        }
                }

                public virtual async Task<ActionResponse> Delete(
                        int transactionID)
                {
                        ActionResponse response = new ActionResponse(await this.transactionHistoryModelValidator.ValidateDeleteAsync(transactionID));
                        if (response.Success)
                        {
                                await this.transactionHistoryRepository.Delete(transactionID);
                        }

                        return response;
                }

                public async Task<List<ApiTransactionHistoryResponseModel>> ByProductID(int productID)
                {
                        List<TransactionHistory> records = await this.transactionHistoryRepository.ByProductID(productID);

                        return this.bolTransactionHistoryMapper.MapBOToModel(this.dalTransactionHistoryMapper.MapEFToBO(records));
                }

                public async Task<List<ApiTransactionHistoryResponseModel>> ByReferenceOrderIDReferenceOrderLineID(int referenceOrderID, int referenceOrderLineID)
                {
                        List<TransactionHistory> records = await this.transactionHistoryRepository.ByReferenceOrderIDReferenceOrderLineID(referenceOrderID, referenceOrderLineID);

                        return this.bolTransactionHistoryMapper.MapBOToModel(this.dalTransactionHistoryMapper.MapEFToBO(records));
                }
        }
}

/*<Codenesium>
    <Hash>871752e4ed9be085ff7afc47e67f79b2</Hash>
</Codenesium>*/