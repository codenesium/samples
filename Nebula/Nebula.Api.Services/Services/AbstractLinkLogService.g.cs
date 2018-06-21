using Codenesium.DataConversionExtensions.AspNetCore;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;
using NebulaNS.Api.Contracts;
using NebulaNS.Api.DataAccess;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Dynamic.Core;
using System.Linq.Expressions;
using System.Threading.Tasks;

namespace NebulaNS.Api.Services
{
        public abstract class AbstractLinkLogService : AbstractService
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
                        IBOLLinkLogMapper bolLinkLogMapper,
                        IDALLinkLogMapper dalLinkLogMapper)
                        : base()
                {
                        this.linkLogRepository = linkLogRepository;
                        this.linkLogModelValidator = linkLogModelValidator;
                        this.bolLinkLogMapper = bolLinkLogMapper;
                        this.dalLinkLogMapper = dalLinkLogMapper;
                        this.logger = logger;
                }

                public virtual async Task<List<ApiLinkLogResponseModel>> All(int limit = 0, int offset = int.MaxValue)
                {
                        var records = await this.linkLogRepository.All(limit, offset);

                        return this.bolLinkLogMapper.MapBOToModel(this.dalLinkLogMapper.MapEFToBO(records));
                }

                public virtual async Task<ApiLinkLogResponseModel> Get(int id)
                {
                        var record = await this.linkLogRepository.Get(id);

                        if (record == null)
                        {
                                return null;
                        }
                        else
                        {
                                return this.bolLinkLogMapper.MapBOToModel(this.dalLinkLogMapper.MapEFToBO(record));
                        }
                }

                public virtual async Task<CreateResponse<ApiLinkLogResponseModel>> Create(
                        ApiLinkLogRequestModel model)
                {
                        CreateResponse<ApiLinkLogResponseModel> response = new CreateResponse<ApiLinkLogResponseModel>(await this.linkLogModelValidator.ValidateCreateAsync(model));
                        if (response.Success)
                        {
                                var bo = this.bolLinkLogMapper.MapModelToBO(default(int), model);
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
    <Hash>8fbbb3911d25d1fda6e7422475cd7e8e</Hash>
</Codenesium>*/