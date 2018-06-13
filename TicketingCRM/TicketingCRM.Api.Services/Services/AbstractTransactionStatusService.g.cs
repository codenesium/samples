using Codenesium.DataConversionExtensions.AspNetCore;
using System;
using System.Collections.Generic;
using Microsoft.Extensions.Logging;
using Microsoft.EntityFrameworkCore;
using System.Linq;
using System.Linq.Dynamic.Core;
using System.Linq.Expressions;
using System.Threading.Tasks;
using TicketingCRMNS.Api.Contracts;
using TicketingCRMNS.Api.DataAccess;

namespace TicketingCRMNS.Api.Services
{
        public abstract class AbstractTransactionStatusService: AbstractService
        {
                private ITransactionStatusRepository transactionStatusRepository;

                private IApiTransactionStatusRequestModelValidator transactionStatusModelValidator;

                private IBOLTransactionStatusMapper bolTransactionStatusMapper;

                private IDALTransactionStatusMapper dalTransactionStatusMapper;

                private IBOLTransactionMapper bolTransactionMapper;

                private IDALTransactionMapper dalTransactionMapper;

                private ILogger logger;

                public AbstractTransactionStatusService(
                        ILogger logger,
                        ITransactionStatusRepository transactionStatusRepository,
                        IApiTransactionStatusRequestModelValidator transactionStatusModelValidator,
                        IBOLTransactionStatusMapper bolTransactionStatusMapper,
                        IDALTransactionStatusMapper dalTransactionStatusMapper

                        ,
                        IBOLTransactionMapper bolTransactionMapper,
                        IDALTransactionMapper dalTransactionMapper

                        )
                        : base()

                {
                        this.transactionStatusRepository = transactionStatusRepository;
                        this.transactionStatusModelValidator = transactionStatusModelValidator;
                        this.bolTransactionStatusMapper = bolTransactionStatusMapper;
                        this.dalTransactionStatusMapper = dalTransactionStatusMapper;
                        this.bolTransactionMapper = bolTransactionMapper;
                        this.dalTransactionMapper = dalTransactionMapper;
                        this.logger = logger;
                }

                public virtual async Task<List<ApiTransactionStatusResponseModel>> All(int limit = 0, int offset = int.MaxValue, string orderClause = "")
                {
                        var records = await this.transactionStatusRepository.All(limit, offset, orderClause);

                        return this.bolTransactionStatusMapper.MapBOToModel(this.dalTransactionStatusMapper.MapEFToBO(records));
                }

                public virtual async Task<ApiTransactionStatusResponseModel> Get(int id)
                {
                        var record = await this.transactionStatusRepository.Get(id);

                        return this.bolTransactionStatusMapper.MapBOToModel(this.dalTransactionStatusMapper.MapEFToBO(record));
                }

                public virtual async Task<CreateResponse<ApiTransactionStatusResponseModel>> Create(
                        ApiTransactionStatusRequestModel model)
                {
                        CreateResponse<ApiTransactionStatusResponseModel> response = new CreateResponse<ApiTransactionStatusResponseModel>(await this.transactionStatusModelValidator.ValidateCreateAsync(model));
                        if (response.Success)
                        {
                                var bo = this.bolTransactionStatusMapper.MapModelToBO(default (int), model);
                                var record = await this.transactionStatusRepository.Create(this.dalTransactionStatusMapper.MapBOToEF(bo));

                                response.SetRecord(this.bolTransactionStatusMapper.MapBOToModel(this.dalTransactionStatusMapper.MapEFToBO(record)));
                        }

                        return response;
                }

                public virtual async Task<ActionResponse> Update(
                        int id,
                        ApiTransactionStatusRequestModel model)
                {
                        ActionResponse response = new ActionResponse(await this.transactionStatusModelValidator.ValidateUpdateAsync(id, model));

                        if (response.Success)
                        {
                                var bo = this.bolTransactionStatusMapper.MapModelToBO(id, model);
                                await this.transactionStatusRepository.Update(this.dalTransactionStatusMapper.MapBOToEF(bo));
                        }

                        return response;
                }

                public virtual async Task<ActionResponse> Delete(
                        int id)
                {
                        ActionResponse response = new ActionResponse(await this.transactionStatusModelValidator.ValidateDeleteAsync(id));

                        if (response.Success)
                        {
                                await this.transactionStatusRepository.Delete(id);
                        }

                        return response;
                }

                public async virtual Task<List<ApiTransactionResponseModel>> Transactions(int transactionStatusId, int limit = int.MaxValue, int offset = 0)
                {
                        List<Transaction> records = await this.transactionStatusRepository.Transactions(transactionStatusId, limit, offset);

                        return this.bolTransactionMapper.MapBOToModel(this.dalTransactionMapper.MapEFToBO(records));
                }
        }
}

/*<Codenesium>
    <Hash>1c8796b5e0999ce19dc8d10e86711009</Hash>
</Codenesium>*/