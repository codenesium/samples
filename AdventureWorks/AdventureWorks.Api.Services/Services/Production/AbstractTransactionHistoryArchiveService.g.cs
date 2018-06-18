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
        public abstract class AbstractTransactionHistoryArchiveService: AbstractService
        {
                private ITransactionHistoryArchiveRepository transactionHistoryArchiveRepository;

                private IApiTransactionHistoryArchiveRequestModelValidator transactionHistoryArchiveModelValidator;

                private IBOLTransactionHistoryArchiveMapper bolTransactionHistoryArchiveMapper;

                private IDALTransactionHistoryArchiveMapper dalTransactionHistoryArchiveMapper;

                private ILogger logger;

                public AbstractTransactionHistoryArchiveService(
                        ILogger logger,
                        ITransactionHistoryArchiveRepository transactionHistoryArchiveRepository,
                        IApiTransactionHistoryArchiveRequestModelValidator transactionHistoryArchiveModelValidator,
                        IBOLTransactionHistoryArchiveMapper bolTransactionHistoryArchiveMapper,
                        IDALTransactionHistoryArchiveMapper dalTransactionHistoryArchiveMapper

                        )
                        : base()

                {
                        this.transactionHistoryArchiveRepository = transactionHistoryArchiveRepository;
                        this.transactionHistoryArchiveModelValidator = transactionHistoryArchiveModelValidator;
                        this.bolTransactionHistoryArchiveMapper = bolTransactionHistoryArchiveMapper;
                        this.dalTransactionHistoryArchiveMapper = dalTransactionHistoryArchiveMapper;
                        this.logger = logger;
                }

                public virtual async Task<List<ApiTransactionHistoryArchiveResponseModel>> All(int limit = 0, int offset = int.MaxValue)
                {
                        var records = await this.transactionHistoryArchiveRepository.All(limit, offset);

                        return this.bolTransactionHistoryArchiveMapper.MapBOToModel(this.dalTransactionHistoryArchiveMapper.MapEFToBO(records));
                }

                public virtual async Task<ApiTransactionHistoryArchiveResponseModel> Get(int transactionID)
                {
                        var record = await this.transactionHistoryArchiveRepository.Get(transactionID);

                        if (record == null)
                        {
                                return null;
                        }
                        else
                        {
                                return this.bolTransactionHistoryArchiveMapper.MapBOToModel(this.dalTransactionHistoryArchiveMapper.MapEFToBO(record));
                        }
                }

                public virtual async Task<CreateResponse<ApiTransactionHistoryArchiveResponseModel>> Create(
                        ApiTransactionHistoryArchiveRequestModel model)
                {
                        CreateResponse<ApiTransactionHistoryArchiveResponseModel> response = new CreateResponse<ApiTransactionHistoryArchiveResponseModel>(await this.transactionHistoryArchiveModelValidator.ValidateCreateAsync(model));
                        if (response.Success)
                        {
                                var bo = this.bolTransactionHistoryArchiveMapper.MapModelToBO(default (int), model);
                                var record = await this.transactionHistoryArchiveRepository.Create(this.dalTransactionHistoryArchiveMapper.MapBOToEF(bo));

                                response.SetRecord(this.bolTransactionHistoryArchiveMapper.MapBOToModel(this.dalTransactionHistoryArchiveMapper.MapEFToBO(record)));
                        }

                        return response;
                }

                public virtual async Task<ActionResponse> Update(
                        int transactionID,
                        ApiTransactionHistoryArchiveRequestModel model)
                {
                        ActionResponse response = new ActionResponse(await this.transactionHistoryArchiveModelValidator.ValidateUpdateAsync(transactionID, model));

                        if (response.Success)
                        {
                                var bo = this.bolTransactionHistoryArchiveMapper.MapModelToBO(transactionID, model);
                                await this.transactionHistoryArchiveRepository.Update(this.dalTransactionHistoryArchiveMapper.MapBOToEF(bo));
                        }

                        return response;
                }

                public virtual async Task<ActionResponse> Delete(
                        int transactionID)
                {
                        ActionResponse response = new ActionResponse(await this.transactionHistoryArchiveModelValidator.ValidateDeleteAsync(transactionID));

                        if (response.Success)
                        {
                                await this.transactionHistoryArchiveRepository.Delete(transactionID);
                        }

                        return response;
                }

                public async Task<List<ApiTransactionHistoryArchiveResponseModel>> ByProductID(int productID)
                {
                        List<TransactionHistoryArchive> records = await this.transactionHistoryArchiveRepository.ByProductID(productID);

                        return this.bolTransactionHistoryArchiveMapper.MapBOToModel(this.dalTransactionHistoryArchiveMapper.MapEFToBO(records));
                }
                public async Task<List<ApiTransactionHistoryArchiveResponseModel>> ByReferenceOrderIDReferenceOrderLineID(int referenceOrderID, int referenceOrderLineID)
                {
                        List<TransactionHistoryArchive> records = await this.transactionHistoryArchiveRepository.ByReferenceOrderIDReferenceOrderLineID(referenceOrderID, referenceOrderLineID);

                        return this.bolTransactionHistoryArchiveMapper.MapBOToModel(this.dalTransactionHistoryArchiveMapper.MapEFToBO(records));
                }
        }
}

/*<Codenesium>
    <Hash>a4bcfb9378bca4d61efc9bb6d85cd86a</Hash>
</Codenesium>*/