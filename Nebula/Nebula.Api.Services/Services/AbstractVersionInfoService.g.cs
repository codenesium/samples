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
        public abstract class AbstractVersionInfoService: AbstractService
        {
                private IVersionInfoRepository versionInfoRepository;

                private IApiVersionInfoRequestModelValidator versionInfoModelValidator;

                private IBOLVersionInfoMapper bolVersionInfoMapper;

                private IDALVersionInfoMapper dalVersionInfoMapper;

                private ILogger logger;

                public AbstractVersionInfoService(
                        ILogger logger,
                        IVersionInfoRepository versionInfoRepository,
                        IApiVersionInfoRequestModelValidator versionInfoModelValidator,
                        IBOLVersionInfoMapper bolVersionInfoMapper,
                        IDALVersionInfoMapper dalVersionInfoMapper

                        )
                        : base()

                {
                        this.versionInfoRepository = versionInfoRepository;
                        this.versionInfoModelValidator = versionInfoModelValidator;
                        this.bolVersionInfoMapper = bolVersionInfoMapper;
                        this.dalVersionInfoMapper = dalVersionInfoMapper;
                        this.logger = logger;
                }

                public virtual async Task<List<ApiVersionInfoResponseModel>> All(int limit = 0, int offset = int.MaxValue, string orderClause = "")
                {
                        var records = await this.versionInfoRepository.All(limit, offset, orderClause);

                        return this.bolVersionInfoMapper.MapBOToModel(this.dalVersionInfoMapper.MapEFToBO(records));
                }

                public virtual async Task<ApiVersionInfoResponseModel> Get(long version)
                {
                        var record = await this.versionInfoRepository.Get(version);

                        return this.bolVersionInfoMapper.MapBOToModel(this.dalVersionInfoMapper.MapEFToBO(record));
                }

                public virtual async Task<CreateResponse<ApiVersionInfoResponseModel>> Create(
                        ApiVersionInfoRequestModel model)
                {
                        CreateResponse<ApiVersionInfoResponseModel> response = new CreateResponse<ApiVersionInfoResponseModel>(await this.versionInfoModelValidator.ValidateCreateAsync(model));
                        if (response.Success)
                        {
                                var bo = this.bolVersionInfoMapper.MapModelToBO(default (long), model);
                                var record = await this.versionInfoRepository.Create(this.dalVersionInfoMapper.MapBOToEF(bo));

                                response.SetRecord(this.bolVersionInfoMapper.MapBOToModel(this.dalVersionInfoMapper.MapEFToBO(record)));
                        }

                        return response;
                }

                public virtual async Task<ActionResponse> Update(
                        long version,
                        ApiVersionInfoRequestModel model)
                {
                        ActionResponse response = new ActionResponse(await this.versionInfoModelValidator.ValidateUpdateAsync(version, model));

                        if (response.Success)
                        {
                                var bo = this.bolVersionInfoMapper.MapModelToBO(version, model);
                                await this.versionInfoRepository.Update(this.dalVersionInfoMapper.MapBOToEF(bo));
                        }

                        return response;
                }

                public virtual async Task<ActionResponse> Delete(
                        long version)
                {
                        ActionResponse response = new ActionResponse(await this.versionInfoModelValidator.ValidateDeleteAsync(version));

                        if (response.Success)
                        {
                                await this.versionInfoRepository.Delete(version);
                        }

                        return response;
                }

                public async Task<ApiVersionInfoResponseModel> GetVersion(long version)
                {
                        VersionInfo record = await this.versionInfoRepository.GetVersion(version);

                        return this.bolVersionInfoMapper.MapBOToModel(this.dalVersionInfoMapper.MapEFToBO(record));
                }
        }
}

/*<Codenesium>
    <Hash>1433d2bc58fad3fa8f927b631a9a8086</Hash>
</Codenesium>*/