using Codenesium.DataConversionExtensions;
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
        public abstract class AbstractFileTypeService : AbstractService
        {
                private IFileTypeRepository fileTypeRepository;

                private IApiFileTypeRequestModelValidator fileTypeModelValidator;

                private IBOLFileTypeMapper bolFileTypeMapper;

                private IDALFileTypeMapper dalFileTypeMapper;

                private IBOLFileMapper bolFileMapper;

                private IDALFileMapper dalFileMapper;

                private ILogger logger;

                public AbstractFileTypeService(
                        ILogger logger,
                        IFileTypeRepository fileTypeRepository,
                        IApiFileTypeRequestModelValidator fileTypeModelValidator,
                        IBOLFileTypeMapper bolFileTypeMapper,
                        IDALFileTypeMapper dalFileTypeMapper,
                        IBOLFileMapper bolFileMapper,
                        IDALFileMapper dalFileMapper)
                        : base()
                {
                        this.fileTypeRepository = fileTypeRepository;
                        this.fileTypeModelValidator = fileTypeModelValidator;
                        this.bolFileTypeMapper = bolFileTypeMapper;
                        this.dalFileTypeMapper = dalFileTypeMapper;
                        this.bolFileMapper = bolFileMapper;
                        this.dalFileMapper = dalFileMapper;
                        this.logger = logger;
                }

                public virtual async Task<List<ApiFileTypeResponseModel>> All(int limit = 0, int offset = int.MaxValue)
                {
                        var records = await this.fileTypeRepository.All(limit, offset);

                        return this.bolFileTypeMapper.MapBOToModel(this.dalFileTypeMapper.MapEFToBO(records));
                }

                public virtual async Task<ApiFileTypeResponseModel> Get(int id)
                {
                        var record = await this.fileTypeRepository.Get(id);

                        if (record == null)
                        {
                                return null;
                        }
                        else
                        {
                                return this.bolFileTypeMapper.MapBOToModel(this.dalFileTypeMapper.MapEFToBO(record));
                        }
                }

                public virtual async Task<CreateResponse<ApiFileTypeResponseModel>> Create(
                        ApiFileTypeRequestModel model)
                {
                        CreateResponse<ApiFileTypeResponseModel> response = new CreateResponse<ApiFileTypeResponseModel>(await this.fileTypeModelValidator.ValidateCreateAsync(model));
                        if (response.Success)
                        {
                                var bo = this.bolFileTypeMapper.MapModelToBO(default(int), model);
                                var record = await this.fileTypeRepository.Create(this.dalFileTypeMapper.MapBOToEF(bo));

                                response.SetRecord(this.bolFileTypeMapper.MapBOToModel(this.dalFileTypeMapper.MapEFToBO(record)));
                        }

                        return response;
                }

                public virtual async Task<ActionResponse> Update(
                        int id,
                        ApiFileTypeRequestModel model)
                {
                        ActionResponse response = new ActionResponse(await this.fileTypeModelValidator.ValidateUpdateAsync(id, model));
                        if (response.Success)
                        {
                                var bo = this.bolFileTypeMapper.MapModelToBO(id, model);
                                await this.fileTypeRepository.Update(this.dalFileTypeMapper.MapBOToEF(bo));
                        }

                        return response;
                }

                public virtual async Task<ActionResponse> Delete(
                        int id)
                {
                        ActionResponse response = new ActionResponse(await this.fileTypeModelValidator.ValidateDeleteAsync(id));
                        if (response.Success)
                        {
                                await this.fileTypeRepository.Delete(id);
                        }

                        return response;
                }

                public async virtual Task<List<ApiFileResponseModel>> Files(int fileTypeId, int limit = int.MaxValue, int offset = 0)
                {
                        List<File> records = await this.fileTypeRepository.Files(fileTypeId, limit, offset);

                        return this.bolFileMapper.MapBOToModel(this.dalFileMapper.MapEFToBO(records));
                }
        }
}

/*<Codenesium>
    <Hash>8e0027a7382bf9d15d32724aaa2f9f17</Hash>
</Codenesium>*/