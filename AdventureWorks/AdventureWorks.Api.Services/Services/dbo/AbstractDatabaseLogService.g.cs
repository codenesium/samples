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
        public abstract class AbstractDatabaseLogService : AbstractService
        {
                private IDatabaseLogRepository databaseLogRepository;

                private IApiDatabaseLogRequestModelValidator databaseLogModelValidator;

                private IBOLDatabaseLogMapper bolDatabaseLogMapper;

                private IDALDatabaseLogMapper dalDatabaseLogMapper;

                private ILogger logger;

                public AbstractDatabaseLogService(
                        ILogger logger,
                        IDatabaseLogRepository databaseLogRepository,
                        IApiDatabaseLogRequestModelValidator databaseLogModelValidator,
                        IBOLDatabaseLogMapper bolDatabaseLogMapper,
                        IDALDatabaseLogMapper dalDatabaseLogMapper)
                        : base()
                {
                        this.databaseLogRepository = databaseLogRepository;
                        this.databaseLogModelValidator = databaseLogModelValidator;
                        this.bolDatabaseLogMapper = bolDatabaseLogMapper;
                        this.dalDatabaseLogMapper = dalDatabaseLogMapper;
                        this.logger = logger;
                }

                public virtual async Task<List<ApiDatabaseLogResponseModel>> All(int limit = 0, int offset = int.MaxValue)
                {
                        var records = await this.databaseLogRepository.All(limit, offset);

                        return this.bolDatabaseLogMapper.MapBOToModel(this.dalDatabaseLogMapper.MapEFToBO(records));
                }

                public virtual async Task<ApiDatabaseLogResponseModel> Get(int databaseLogID)
                {
                        var record = await this.databaseLogRepository.Get(databaseLogID);

                        if (record == null)
                        {
                                return null;
                        }
                        else
                        {
                                return this.bolDatabaseLogMapper.MapBOToModel(this.dalDatabaseLogMapper.MapEFToBO(record));
                        }
                }

                public virtual async Task<CreateResponse<ApiDatabaseLogResponseModel>> Create(
                        ApiDatabaseLogRequestModel model)
                {
                        CreateResponse<ApiDatabaseLogResponseModel> response = new CreateResponse<ApiDatabaseLogResponseModel>(await this.databaseLogModelValidator.ValidateCreateAsync(model));
                        if (response.Success)
                        {
                                var bo = this.bolDatabaseLogMapper.MapModelToBO(default(int), model);
                                var record = await this.databaseLogRepository.Create(this.dalDatabaseLogMapper.MapBOToEF(bo));

                                response.SetRecord(this.bolDatabaseLogMapper.MapBOToModel(this.dalDatabaseLogMapper.MapEFToBO(record)));
                        }

                        return response;
                }

                public virtual async Task<ActionResponse> Update(
                        int databaseLogID,
                        ApiDatabaseLogRequestModel model)
                {
                        ActionResponse response = new ActionResponse(await this.databaseLogModelValidator.ValidateUpdateAsync(databaseLogID, model));
                        if (response.Success)
                        {
                                var bo = this.bolDatabaseLogMapper.MapModelToBO(databaseLogID, model);
                                await this.databaseLogRepository.Update(this.dalDatabaseLogMapper.MapBOToEF(bo));
                        }

                        return response;
                }

                public virtual async Task<ActionResponse> Delete(
                        int databaseLogID)
                {
                        ActionResponse response = new ActionResponse(await this.databaseLogModelValidator.ValidateDeleteAsync(databaseLogID));
                        if (response.Success)
                        {
                                await this.databaseLogRepository.Delete(databaseLogID);
                        }

                        return response;
                }
        }
}

/*<Codenesium>
    <Hash>36b727c3f6efb66aa37cfda950ac2162</Hash>
</Codenesium>*/