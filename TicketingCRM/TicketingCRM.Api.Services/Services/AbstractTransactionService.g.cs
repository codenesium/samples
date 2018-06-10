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
        public abstract class AbstractTransactionService: AbstractService
        {
                private ITransactionRepository transactionRepository;

                private IApiTransactionRequestModelValidator transactionModelValidator;

                private IBOLTransactionMapper bolTransactionMapper;

                private IDALTransactionMapper dalTransactionMapper;

                private ILogger logger;

                public AbstractTransactionService(
                        ILogger logger,
                        ITransactionRepository transactionRepository,
                        IApiTransactionRequestModelValidator transactionModelValidator,
                        IBOLTransactionMapper boltransactionMapper,
                        IDALTransactionMapper daltransactionMapper)
                        : base()

                {
                        this.transactionRepository = transactionRepository;
                        this.transactionModelValidator = transactionModelValidator;
                        this.bolTransactionMapper = boltransactionMapper;
                        this.dalTransactionMapper = daltransactionMapper;
                        this.logger = logger;
                }

                public virtual async Task<List<ApiTransactionResponseModel>> All(int skip = 0, int take = int.MaxValue, string orderClause = "")
                {
                        var records = await this.transactionRepository.All(skip, take, orderClause);

                        return this.bolTransactionMapper.MapBOToModel(this.dalTransactionMapper.MapEFToBO(records));
                }

                public virtual async Task<ApiTransactionResponseModel> Get(int id)
                {
                        var record = await this.transactionRepository.Get(id);

                        return this.bolTransactionMapper.MapBOToModel(this.dalTransactionMapper.MapEFToBO(record));
                }

                public virtual async Task<CreateResponse<ApiTransactionResponseModel>> Create(
                        ApiTransactionRequestModel model)
                {
                        CreateResponse<ApiTransactionResponseModel> response = new CreateResponse<ApiTransactionResponseModel>(await this.transactionModelValidator.ValidateCreateAsync(model));
                        if (response.Success)
                        {
                                var bo = this.bolTransactionMapper.MapModelToBO(default (int), model);
                                var record = await this.transactionRepository.Create(this.dalTransactionMapper.MapBOToEF(bo));

                                response.SetRecord(this.bolTransactionMapper.MapBOToModel(this.dalTransactionMapper.MapEFToBO(record)));
                        }

                        return response;
                }

                public virtual async Task<ActionResponse> Update(
                        int id,
                        ApiTransactionRequestModel model)
                {
                        ActionResponse response = new ActionResponse(await this.transactionModelValidator.ValidateUpdateAsync(id, model));

                        if (response.Success)
                        {
                                var bo = this.bolTransactionMapper.MapModelToBO(id, model);
                                await this.transactionRepository.Update(this.dalTransactionMapper.MapBOToEF(bo));
                        }

                        return response;
                }

                public virtual async Task<ActionResponse> Delete(
                        int id)
                {
                        ActionResponse response = new ActionResponse(await this.transactionModelValidator.ValidateDeleteAsync(id));

                        if (response.Success)
                        {
                                await this.transactionRepository.Delete(id);
                        }

                        return response;
                }

                public async Task<List<ApiTransactionResponseModel>> GetTransactionStatusId(int transactionStatusId)
                {
                        List<Transaction> records = await this.transactionRepository.GetTransactionStatusId(transactionStatusId);

                        return this.bolTransactionMapper.MapBOToModel(this.dalTransactionMapper.MapEFToBO(records));
                }
        }
}

/*<Codenesium>
    <Hash>d59aa5d34b3266128084900868c7b21e</Hash>
</Codenesium>*/