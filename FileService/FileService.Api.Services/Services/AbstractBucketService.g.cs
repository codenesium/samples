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
        public abstract class AbstractBucketService : AbstractService
        {
                private IBucketRepository bucketRepository;

                private IApiBucketRequestModelValidator bucketModelValidator;

                private IBOLBucketMapper bolBucketMapper;

                private IDALBucketMapper dalBucketMapper;

                private IBOLFileMapper bolFileMapper;

                private IDALFileMapper dalFileMapper;

                private ILogger logger;

                public AbstractBucketService(
                        ILogger logger,
                        IBucketRepository bucketRepository,
                        IApiBucketRequestModelValidator bucketModelValidator,
                        IBOLBucketMapper bolBucketMapper,
                        IDALBucketMapper dalBucketMapper,
                        IBOLFileMapper bolFileMapper,
                        IDALFileMapper dalFileMapper)
                        : base()
                {
                        this.bucketRepository = bucketRepository;
                        this.bucketModelValidator = bucketModelValidator;
                        this.bolBucketMapper = bolBucketMapper;
                        this.dalBucketMapper = dalBucketMapper;
                        this.bolFileMapper = bolFileMapper;
                        this.dalFileMapper = dalFileMapper;
                        this.logger = logger;
                }

                public virtual async Task<List<ApiBucketResponseModel>> All(int limit = 0, int offset = int.MaxValue)
                {
                        var records = await this.bucketRepository.All(limit, offset);

                        return this.bolBucketMapper.MapBOToModel(this.dalBucketMapper.MapEFToBO(records));
                }

                public virtual async Task<ApiBucketResponseModel> Get(int id)
                {
                        var record = await this.bucketRepository.Get(id);

                        if (record == null)
                        {
                                return null;
                        }
                        else
                        {
                                return this.bolBucketMapper.MapBOToModel(this.dalBucketMapper.MapEFToBO(record));
                        }
                }

                public virtual async Task<CreateResponse<ApiBucketResponseModel>> Create(
                        ApiBucketRequestModel model)
                {
                        CreateResponse<ApiBucketResponseModel> response = new CreateResponse<ApiBucketResponseModel>(await this.bucketModelValidator.ValidateCreateAsync(model));
                        if (response.Success)
                        {
                                var bo = this.bolBucketMapper.MapModelToBO(default(int), model);
                                var record = await this.bucketRepository.Create(this.dalBucketMapper.MapBOToEF(bo));

                                response.SetRecord(this.bolBucketMapper.MapBOToModel(this.dalBucketMapper.MapEFToBO(record)));
                        }

                        return response;
                }

                public virtual async Task<ActionResponse> Update(
                        int id,
                        ApiBucketRequestModel model)
                {
                        ActionResponse response = new ActionResponse(await this.bucketModelValidator.ValidateUpdateAsync(id, model));
                        if (response.Success)
                        {
                                var bo = this.bolBucketMapper.MapModelToBO(id, model);
                                await this.bucketRepository.Update(this.dalBucketMapper.MapBOToEF(bo));
                        }

                        return response;
                }

                public virtual async Task<ActionResponse> Delete(
                        int id)
                {
                        ActionResponse response = new ActionResponse(await this.bucketModelValidator.ValidateDeleteAsync(id));
                        if (response.Success)
                        {
                                await this.bucketRepository.Delete(id);
                        }

                        return response;
                }

                public async Task<ApiBucketResponseModel> GetExternalId(Guid externalId)
                {
                        Bucket record = await this.bucketRepository.GetExternalId(externalId);

                        if (record == null)
                        {
                                return null;
                        }
                        else
                        {
                                return this.bolBucketMapper.MapBOToModel(this.dalBucketMapper.MapEFToBO(record));
                        }
                }

                public async Task<ApiBucketResponseModel> GetName(string name)
                {
                        Bucket record = await this.bucketRepository.GetName(name);

                        if (record == null)
                        {
                                return null;
                        }
                        else
                        {
                                return this.bolBucketMapper.MapBOToModel(this.dalBucketMapper.MapEFToBO(record));
                        }
                }

                public async virtual Task<List<ApiFileResponseModel>> Files(int bucketId, int limit = int.MaxValue, int offset = 0)
                {
                        List<File> records = await this.bucketRepository.Files(bucketId, limit, offset);

                        return this.bolFileMapper.MapBOToModel(this.dalFileMapper.MapEFToBO(records));
                }
        }
}

/*<Codenesium>
    <Hash>106153169bb9508bbeb774a981c0b003</Hash>
</Codenesium>*/