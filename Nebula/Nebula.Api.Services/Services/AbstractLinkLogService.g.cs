using Codenesium.DataConversionExtensions.AspNetCore;
using System;
using System.Collections.Generic;
using Microsoft.Extensions.Logging;
using Microsoft.EntityFrameworkCore;
using System.Linq;
using System.Linq.Dynamic.Core;
using System.Linq.Expressions;
using System.Threading.Tasks;
using NebulaNS.Api.Contracts;
using NebulaNS.Api.DataAccess;

namespace NebulaNS.Api.Services
{
        public abstract class AbstractLinkLogService: AbstractService
        {
                private ILinkLogRepository linkLogRepository;

                private IApiLinkLogRequestModelValidator linkLogModelValidator;

                private IBOLLinkLogMapper bolLinkLogMapper;

                private IDALLinkLogMapper dalLinkLogMapper;

                private ILogger logger;

                public AbstractLinkLogService(
                        ILogger logger,
                        ILinkLogRepository linkLogRepository,
                        IApiLinkLogRequestModelValidator linkLogModelValidator,
                        IBOLLinkLogMapper bollinkLogMapper,
                        IDALLinkLogMapper dallinkLogMapper)
                        : base()

                {
                        this.linkLogRepository = linkLogRepository;
                        this.linkLogModelValidator = linkLogModelValidator;
                        this.bolLinkLogMapper = bollinkLogMapper;
                        this.dalLinkLogMapper = dallinkLogMapper;
                        this.logger = logger;
                }

                public virtual async Task<List<ApiLinkLogResponseModel>> All(int skip = 0, int take = int.MaxValue, string orderClause = "")
                {
                        var records = await this.linkLogRepository.All(skip, take, orderClause);

                        return this.bolLinkLogMapper.MapBOToModel(this.dalLinkLogMapper.MapEFToBO(records));
                }

                public virtual async Task<ApiLinkLogResponseModel> Get(int id)
                {
                        var record = await this.linkLogRepository.Get(id);

                        return this.bolLinkLogMapper.MapBOToModel(this.dalLinkLogMapper.MapEFToBO(record));
                }

                public virtual async Task<CreateResponse<ApiLinkLogResponseModel>> Create(
                        ApiLinkLogRequestModel model)
                {
                        CreateResponse<ApiLinkLogResponseModel> response = new CreateResponse<ApiLinkLogResponseModel>(await this.linkLogModelValidator.ValidateCreateAsync(model));
                        if (response.Success)
                        {
                                var bo = this.bolLinkLogMapper.MapModelToBO(default (int), model);
                                var record = await this.linkLogRepository.Create(this.dalLinkLogMapper.MapBOToEF(bo));

                                response.SetRecord(this.bolLinkLogMapper.MapBOToModel(this.dalLinkLogMapper.MapEFToBO(record)));
                        }

                        return response;
                }

                public virtual async Task<ActionResponse> Update(
                        int id,
                        ApiLinkLogRequestModel model)
                {
                        ActionResponse response = new ActionResponse(await this.linkLogModelValidator.ValidateUpdateAsync(id, model));

                        if (response.Success)
                        {
                                var bo = this.bolLinkLogMapper.MapModelToBO(id, model);
                                await this.linkLogRepository.Update(this.dalLinkLogMapper.MapBOToEF(bo));
                        }

                        return response;
                }

                public virtual async Task<ActionResponse> Delete(
                        int id)
                {
                        ActionResponse response = new ActionResponse(await this.linkLogModelValidator.ValidateDeleteAsync(id));

                        if (response.Success)
                        {
                                await this.linkLogRepository.Delete(id);
                        }

                        return response;
                }
        }
}

/*<Codenesium>
    <Hash>55a928bc9a80ab3bb3c7a52695e9de5f</Hash>
</Codenesium>*/