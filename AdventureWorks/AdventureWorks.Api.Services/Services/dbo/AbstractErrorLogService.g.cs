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
        public abstract class AbstractErrorLogService: AbstractService
        {
                private IErrorLogRepository errorLogRepository;

                private IApiErrorLogRequestModelValidator errorLogModelValidator;

                private IBOLErrorLogMapper bolErrorLogMapper;

                private IDALErrorLogMapper dalErrorLogMapper;

                private ILogger logger;

                public AbstractErrorLogService(
                        ILogger logger,
                        IErrorLogRepository errorLogRepository,
                        IApiErrorLogRequestModelValidator errorLogModelValidator,
                        IBOLErrorLogMapper bolerrorLogMapper,
                        IDALErrorLogMapper dalerrorLogMapper)
                        : base()

                {
                        this.errorLogRepository = errorLogRepository;
                        this.errorLogModelValidator = errorLogModelValidator;
                        this.bolErrorLogMapper = bolerrorLogMapper;
                        this.dalErrorLogMapper = dalerrorLogMapper;
                        this.logger = logger;
                }

                public virtual async Task<List<ApiErrorLogResponseModel>> All(int skip = 0, int take = int.MaxValue, string orderClause = "")
                {
                        var records = await this.errorLogRepository.All(skip, take, orderClause);

                        return this.bolErrorLogMapper.MapBOToModel(this.dalErrorLogMapper.MapEFToBO(records));
                }

                public virtual async Task<ApiErrorLogResponseModel> Get(int errorLogID)
                {
                        var record = await this.errorLogRepository.Get(errorLogID);

                        return this.bolErrorLogMapper.MapBOToModel(this.dalErrorLogMapper.MapEFToBO(record));
                }

                public virtual async Task<CreateResponse<ApiErrorLogResponseModel>> Create(
                        ApiErrorLogRequestModel model)
                {
                        CreateResponse<ApiErrorLogResponseModel> response = new CreateResponse<ApiErrorLogResponseModel>(await this.errorLogModelValidator.ValidateCreateAsync(model));
                        if (response.Success)
                        {
                                var bo = this.bolErrorLogMapper.MapModelToBO(default (int), model);
                                var record = await this.errorLogRepository.Create(this.dalErrorLogMapper.MapBOToEF(bo));

                                response.SetRecord(this.bolErrorLogMapper.MapBOToModel(this.dalErrorLogMapper.MapEFToBO(record)));
                        }

                        return response;
                }

                public virtual async Task<ActionResponse> Update(
                        int errorLogID,
                        ApiErrorLogRequestModel model)
                {
                        ActionResponse response = new ActionResponse(await this.errorLogModelValidator.ValidateUpdateAsync(errorLogID, model));

                        if (response.Success)
                        {
                                var bo = this.bolErrorLogMapper.MapModelToBO(errorLogID, model);
                                await this.errorLogRepository.Update(this.dalErrorLogMapper.MapBOToEF(bo));
                        }

                        return response;
                }

                public virtual async Task<ActionResponse> Delete(
                        int errorLogID)
                {
                        ActionResponse response = new ActionResponse(await this.errorLogModelValidator.ValidateDeleteAsync(errorLogID));

                        if (response.Success)
                        {
                                await this.errorLogRepository.Delete(errorLogID);
                        }

                        return response;
                }
        }
}

/*<Codenesium>
    <Hash>3901a23200d5178e39a5e86c305543aa</Hash>
</Codenesium>*/