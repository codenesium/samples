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
        public abstract class AbstractErrorLogService : AbstractService
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
                        IBOLErrorLogMapper bolErrorLogMapper,
                        IDALErrorLogMapper dalErrorLogMapper)
                        : base()
                {
                        this.errorLogRepository = errorLogRepository;
                        this.errorLogModelValidator = errorLogModelValidator;
                        this.bolErrorLogMapper = bolErrorLogMapper;
                        this.dalErrorLogMapper = dalErrorLogMapper;
                        this.logger = logger;
                }

                public virtual async Task<List<ApiErrorLogResponseModel>> All(int limit = 0, int offset = int.MaxValue)
                {
                        var records = await this.errorLogRepository.All(limit, offset);

                        return this.bolErrorLogMapper.MapBOToModel(this.dalErrorLogMapper.MapEFToBO(records));
                }

                public virtual async Task<ApiErrorLogResponseModel> Get(int errorLogID)
                {
                        var record = await this.errorLogRepository.Get(errorLogID);

                        if (record == null)
                        {
                                return null;
                        }
                        else
                        {
                                return this.bolErrorLogMapper.MapBOToModel(this.dalErrorLogMapper.MapEFToBO(record));
                        }
                }

                public virtual async Task<CreateResponse<ApiErrorLogResponseModel>> Create(
                        ApiErrorLogRequestModel model)
                {
                        CreateResponse<ApiErrorLogResponseModel> response = new CreateResponse<ApiErrorLogResponseModel>(await this.errorLogModelValidator.ValidateCreateAsync(model));
                        if (response.Success)
                        {
                                var bo = this.bolErrorLogMapper.MapModelToBO(default(int), model);
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
    <Hash>120cca4ce82f67c12d70d9db78a93f83</Hash>
</Codenesium>*/