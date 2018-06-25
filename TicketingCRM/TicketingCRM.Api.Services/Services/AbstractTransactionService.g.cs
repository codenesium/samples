using Codenesium.DataConversionExtensions;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Dynamic.Core;
using System.Linq.Expressions;
using System.Threading.Tasks;
using TicketingCRMNS.Api.Contracts;
using TicketingCRMNS.Api.DataAccess;

namespace TicketingCRMNS.Api.Services
{
        public abstract class AbstractTransactionService : AbstractService
        {
                private ITransactionRepository transactionRepository;

                private IApiTransactionRequestModelValidator transactionModelValidator;

                private IBOLTransactionMapper bolTransactionMapper;

                private IDALTransactionMapper dalTransactionMapper;

                private IBOLSaleMapper bolSaleMapper;

                private IDALSaleMapper dalSaleMapper;

                private ILogger logger;

                public AbstractTransactionService(
                        ILogger logger,
                        ITransactionRepository transactionRepository,
                        IApiTransactionRequestModelValidator transactionModelValidator,
                        IBOLTransactionMapper bolTransactionMapper,
                        IDALTransactionMapper dalTransactionMapper,
                        IBOLSaleMapper bolSaleMapper,
                        IDALSaleMapper dalSaleMapper)
                        : base()
                {
                        this.transactionRepository = transactionRepository;
                        this.transactionModelValidator = transactionModelValidator;
                        this.bolTransactionMapper = bolTransactionMapper;
                        this.dalTransactionMapper = dalTransactionMapper;
                        this.bolSaleMapper = bolSaleMapper;
                        this.dalSaleMapper = dalSaleMapper;
                        this.logger = logger;
                }

                public virtual async Task<List<ApiTransactionResponseModel>> All(int limit = 0, int offset = int.MaxValue)
                {
                        var records = await this.transactionRepository.All(limit, offset);

                        return this.bolTransactionMapper.MapBOToModel(this.dalTransactionMapper.MapEFToBO(records));
                }

                public virtual async Task<ApiTransactionResponseModel> Get(int id)
                {
                        var record = await this.transactionRepository.Get(id);

                        if (record == null)
                        {
                                return null;
                        }
                        else
                        {
                                return this.bolTransactionMapper.MapBOToModel(this.dalTransactionMapper.MapEFToBO(record));
                        }
                }

                public virtual async Task<CreateResponse<ApiTransactionResponseModel>> Create(
                        ApiTransactionRequestModel model)
                {
                        CreateResponse<ApiTransactionResponseModel> response = new CreateResponse<ApiTransactionResponseModel>(await this.transactionModelValidator.ValidateCreateAsync(model));
                        if (response.Success)
                        {
                                var bo = this.bolTransactionMapper.MapModelToBO(default(int), model);
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

                public async Task<List<ApiTransactionResponseModel>> ByTransactionStatusId(int transactionStatusId)
                {
                        List<Transaction> records = await this.transactionRepository.ByTransactionStatusId(transactionStatusId);

                        return this.bolTransactionMapper.MapBOToModel(this.dalTransactionMapper.MapEFToBO(records));
                }

                public async virtual Task<List<ApiSaleResponseModel>> Sales(int transactionId, int limit = int.MaxValue, int offset = 0)
                {
                        List<Sale> records = await this.transactionRepository.Sales(transactionId, limit, offset);

                        return this.bolSaleMapper.MapBOToModel(this.dalSaleMapper.MapEFToBO(records));
                }
        }
}

/*<Codenesium>
    <Hash>caf1c7a089704e8de72e734462649d39</Hash>
</Codenesium>*/