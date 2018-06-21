using Codenesium.DataConversionExtensions.AspNetCore;
using FileServiceNS.Api.Contracts;
using FileServiceNS.Api.DataAccess;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Dynamic.Core;
using System.Linq.Expressions;
using System.Threading.Tasks;

namespace FileServiceNS.Api.Services
{
        public abstract class AbstractFileService : AbstractService
        {
                private IFileRepository fileRepository;

                private IApiFileRequestModelValidator fileModelValidator;

                private IBOLFileMapper bolFileMapper;

                private IDALFileMapper dalFileMapper;

                private ILogger logger;

                public AbstractFileService(
                        ILogger logger,
                        IFileRepository fileRepository,
                        IApiFileRequestModelValidator fileModelValidator,
                        IBOLFileMapper bolFileMapper,
                        IDALFileMapper dalFileMapper)
                        : base()
                {
                        this.fileRepository = fileRepository;
                        this.fileModelValidator = fileModelValidator;
                        this.bolFileMapper = bolFileMapper;
                        this.dalFileMapper = dalFileMapper;
                        this.logger = logger;
                }

                public virtual async Task<List<ApiFileResponseModel>> All(int limit = 0, int offset = int.MaxValue)
                {
                        var records = await this.fileRepository.All(limit, offset);

                        return this.bolFileMapper.MapBOToModel(this.dalFileMapper.MapEFToBO(records));
                }

                public virtual async Task<ApiFileResponseModel> Get(int id)
                {
                        var record = await this.fileRepository.Get(id);

                        if (record == null)
                        {
                                return null;
                        }
                        else
                        {
                                return this.bolFileMapper.MapBOToModel(this.dalFileMapper.MapEFToBO(record));
                        }
                }

                public virtual async Task<CreateResponse<ApiFileResponseModel>> Create(
                        ApiFileRequestModel model)
                {
                        CreateResponse<ApiFileResponseModel> response = new CreateResponse<ApiFileResponseModel>(await this.fileModelValidator.ValidateCreateAsync(model));
                        if (response.Success)
                        {
                                var bo = this.bolFileMapper.MapModelToBO(default(int), model);
                                var record = await this.fileRepository.Create(this.dalFileMapper.MapBOToEF(bo));

                                response.SetRecord(this.bolFileMapper.MapBOToModel(this.dalFileMapper.MapEFToBO(record)));
                        }

                        return response;
                }

                public virtual async Task<ActionResponse> Update(
                        int id,
                        ApiFileRequestModel model)
                {
                        ActionResponse response = new ActionResponse(await this.fileModelValidator.ValidateUpdateAsync(id, model));
                        if (response.Success)
                        {
                                var bo = this.bolFileMapper.MapModelToBO(id, model);
                                await this.fileRepository.Update(this.dalFileMapper.MapBOToEF(bo));
                        }

                        return response;
                }

                public virtual async Task<ActionResponse> Delete(
                        int id)
                {
                        ActionResponse response = new ActionResponse(await this.fileModelValidator.ValidateDeleteAsync(id));
                        if (response.Success)
                        {
                                await this.fileRepository.Delete(id);
                        }

                        return response;
                }
        }
}

/*<Codenesium>
    <Hash>47de3c2644760d34254dc4738cf45983</Hash>
</Codenesium>*/