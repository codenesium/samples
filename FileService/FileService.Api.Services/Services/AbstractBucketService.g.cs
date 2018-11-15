using FileServiceNS.Api.Contracts;
using FileServiceNS.Api.DataAccess;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace FileServiceNS.Api.Services
{
	public abstract class AbstractBucketService : AbstractService
	{
		protected IBucketRepository BucketRepository { get; private set; }

		protected IApiBucketServerRequestModelValidator BucketModelValidator { get; private set; }

		protected IBOLBucketMapper BolBucketMapper { get; private set; }

		protected IDALBucketMapper DalBucketMapper { get; private set; }

		protected IBOLFileMapper BolFileMapper { get; private set; }

		protected IDALFileMapper DalFileMapper { get; private set; }

		private ILogger logger;

		public AbstractBucketService(
			ILogger logger,
			IBucketRepository bucketRepository,
			IApiBucketServerRequestModelValidator bucketModelValidator,
			IBOLBucketMapper bolBucketMapper,
			IDALBucketMapper dalBucketMapper,
			IBOLFileMapper bolFileMapper,
			IDALFileMapper dalFileMapper)
			: base()
		{
			this.BucketRepository = bucketRepository;
			this.BucketModelValidator = bucketModelValidator;
			this.BolBucketMapper = bolBucketMapper;
			this.DalBucketMapper = dalBucketMapper;
			this.BolFileMapper = bolFileMapper;
			this.DalFileMapper = dalFileMapper;
			this.logger = logger;
		}

		public virtual async Task<List<ApiBucketServerResponseModel>> All(int limit = 0, int offset = int.MaxValue)
		{
			var records = await this.BucketRepository.All(limit, offset);

			return this.BolBucketMapper.MapBOToModel(this.DalBucketMapper.MapEFToBO(records));
		}

		public virtual async Task<ApiBucketServerResponseModel> Get(int id)
		{
			var record = await this.BucketRepository.Get(id);

			if (record == null)
			{
				return null;
			}
			else
			{
				return this.BolBucketMapper.MapBOToModel(this.DalBucketMapper.MapEFToBO(record));
			}
		}

		public virtual async Task<CreateResponse<ApiBucketServerResponseModel>> Create(
			ApiBucketServerRequestModel model)
		{
			CreateResponse<ApiBucketServerResponseModel> response = ValidationResponseFactory<ApiBucketServerResponseModel>.CreateResponse(await this.BucketModelValidator.ValidateCreateAsync(model));

			if (response.Success)
			{
				var bo = this.BolBucketMapper.MapModelToBO(default(int), model);
				var record = await this.BucketRepository.Create(this.DalBucketMapper.MapBOToEF(bo));

				response.SetRecord(this.BolBucketMapper.MapBOToModel(this.DalBucketMapper.MapEFToBO(record)));
			}

			return response;
		}

		public virtual async Task<UpdateResponse<ApiBucketServerResponseModel>> Update(
			int id,
			ApiBucketServerRequestModel model)
		{
			var validationResult = await this.BucketModelValidator.ValidateUpdateAsync(id, model);

			if (validationResult.IsValid)
			{
				var bo = this.BolBucketMapper.MapModelToBO(id, model);
				await this.BucketRepository.Update(this.DalBucketMapper.MapBOToEF(bo));

				var record = await this.BucketRepository.Get(id);

				return ValidationResponseFactory<ApiBucketServerResponseModel>.UpdateResponse(this.BolBucketMapper.MapBOToModel(this.DalBucketMapper.MapEFToBO(record)));
			}
			else
			{
				return ValidationResponseFactory<ApiBucketServerResponseModel>.UpdateResponse(validationResult);
			}
		}

		public virtual async Task<ActionResponse> Delete(
			int id)
		{
			ActionResponse response = ValidationResponseFactory<object>.ActionResponse(await this.BucketModelValidator.ValidateDeleteAsync(id));

			if (response.Success)
			{
				await this.BucketRepository.Delete(id);
			}

			return response;
		}

		public async virtual Task<ApiBucketServerResponseModel> ByExternalId(Guid externalId)
		{
			Bucket record = await this.BucketRepository.ByExternalId(externalId);

			if (record == null)
			{
				return null;
			}
			else
			{
				return this.BolBucketMapper.MapBOToModel(this.DalBucketMapper.MapEFToBO(record));
			}
		}

		public async virtual Task<ApiBucketServerResponseModel> ByName(string name)
		{
			Bucket record = await this.BucketRepository.ByName(name);

			if (record == null)
			{
				return null;
			}
			else
			{
				return this.BolBucketMapper.MapBOToModel(this.DalBucketMapper.MapEFToBO(record));
			}
		}

		public async virtual Task<List<ApiFileServerResponseModel>> FilesByBucketId(int bucketId, int limit = int.MaxValue, int offset = 0)
		{
			List<File> records = await this.BucketRepository.FilesByBucketId(bucketId, limit, offset);

			return this.BolFileMapper.MapBOToModel(this.DalFileMapper.MapEFToBO(records));
		}
	}
}

/*<Codenesium>
    <Hash>26c68b3429916e83636da71385702a69</Hash>
</Codenesium>*/