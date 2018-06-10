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

                private ILogger logger;

                public AbstractTransactionStatusService(
                        ILogger logger,
                        ITransactionStatusRepository transactionStatusRepository,
                        IApiTransactionStatusRequestModelValidator transactionStatusModelValidator,
                        IBOLTransactionStatusMapper boltransactionStatusMapper,
                        IDALTransactionStatusMapper daltransactionStatusMapper)
                        : base()

                {
                        this.transactionStatusRepository = transactionStatusRepository;
                        this.transactionStatusModelValidator = transactionStatusModelValidator;
                        this.bolTransactionStatusMapper = boltransactionStatusMapper;
                        this.dalTransactionStatusMapper = daltransactionStatusMapper;
                        this.logger = logger;
                }

                public virtual async Task<List<ApiTransactionStatusResponseModel>> All(int skip = 0, int take = int.MaxValue, string orderClause = "")
                {
                        var records = await this.transactionStatusRepository.All(skip, take, orderClause);

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
        }
}

/*<Codenesium>
    <Hash>f19c3f72715f5a5502a72164b7ba6b9e</Hash>
</Codenesium>*/