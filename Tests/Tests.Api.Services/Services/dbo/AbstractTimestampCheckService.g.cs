using Codenesium.DataConversionExtensions;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Dynamic.Core;
using System.Linq.Expressions;
using System.Threading.Tasks;
using TestsNS.Api.Contracts;
using TestsNS.Api.DataAccess;

namespace TestsNS.Api.Services
{
        public abstract class AbstractTimestampCheckService : AbstractService
        {
                private ITimestampCheckRepository timestampCheckRepository;

                private IApiTimestampCheckRequestModelValidator timestampCheckModelValidator;

                private IBOLTimestampCheckMapper bolTimestampCheckMapper;

                private IDALTimestampCheckMapper dalTimestampCheckMapper;

                private ILogger logger;

                public AbstractTimestampCheckService(
                        ILogger logger,
                        ITimestampCheckRepository timestampCheckRepository,
                        IApiTimestampCheckRequestModelValidator timestampCheckModelValidator,
                        IBOLTimestampCheckMapper bolTimestampCheckMapper,
                        IDALTimestampCheckMapper dalTimestampCheckMapper)
                        : base()
                {
                        this.timestampCheckRepository = timestampCheckRepository;
                        this.timestampCheckModelValidator = timestampCheckModelValidator;
                        this.bolTimestampCheckMapper = bolTimestampCheckMapper;
                        this.dalTimestampCheckMapper = dalTimestampCheckMapper;
                        this.logger = logger;
                }

                public virtual async Task<List<ApiTimestampCheckResponseModel>> All(int limit = 0, int offset = int.MaxValue)
                {
                        var records = await this.timestampCheckRepository.All(limit, offset);

                        return this.bolTimestampCheckMapper.MapBOToModel(this.dalTimestampCheckMapper.MapEFToBO(records));
                }

                public virtual async Task<ApiTimestampCheckResponseModel> Get(int id)
                {
                        var record = await this.timestampCheckRepository.Get(id);

                        if (record == null)
                        {
                                return null;
                        }
                        else
                        {
                                return this.bolTimestampCheckMapper.MapBOToModel(this.dalTimestampCheckMapper.MapEFToBO(record));
                        }
                }

                public virtual async Task<CreateResponse<ApiTimestampCheckResponseModel>> Create(
                        ApiTimestampCheckRequestModel model)
                {
                        CreateResponse<ApiTimestampCheckResponseModel> response = new CreateResponse<ApiTimestampCheckResponseModel>(await this.timestampCheckModelValidator.ValidateCreateAsync(model));
                        if (response.Success)
                        {
                                var bo = this.bolTimestampCheckMapper.MapModelToBO(default(int), model);
                                var record = await this.timestampCheckRepository.Create(this.dalTimestampCheckMapper.MapBOToEF(bo));

                                response.SetRecord(this.bolTimestampCheckMapper.MapBOToModel(this.dalTimestampCheckMapper.MapEFToBO(record)));
                        }

                        return response;
                }

                public virtual async Task<UpdateResponse<ApiTimestampCheckResponseModel>> Update(
                        int id,
                        ApiTimestampCheckRequestModel model)
                {
                        var validationResult = await this.timestampCheckModelValidator.ValidateUpdateAsync(id, model);

                        if (validationResult.IsValid)
                        {
                                var bo = this.bolTimestampCheckMapper.MapModelToBO(id, model);
                                await this.timestampCheckRepository.Update(this.dalTimestampCheckMapper.MapBOToEF(bo));

                                var record = await this.timestampCheckRepository.Get(id);

                                return new UpdateResponse<ApiTimestampCheckResponseModel>(this.bolTimestampCheckMapper.MapBOToModel(this.dalTimestampCheckMapper.MapEFToBO(record)));
                        }
                        else
                        {
                                return new UpdateResponse<ApiTimestampCheckResponseModel>(validationResult);
                        }
                }

                public virtual async Task<ActionResponse> Delete(
                        int id)
                {
                        ActionResponse response = new ActionResponse(await this.timestampCheckModelValidator.ValidateDeleteAsync(id));
                        if (response.Success)
                        {
                                await this.timestampCheckRepository.Delete(id);
                        }

                        return response;
                }
        }
}

/*<Codenesium>
    <Hash>1c20eb595cfd1646d998a3d55be72722</Hash>
</Codenesium>*/