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
		protected IBucketRepository BucketRepository { get; private set; }

		protected IApiBucketRequestModelValidator BucketModelValidator { get; private set; }

		protected IBOLBucketMapper BolBucketMapper { get; private set; }

		protected IDALBucketMapper DalBucketMapper { get; private set; }

		protected IBOLFileMapper BolFileMapper { get; private set; }

		protected IDALFileMapper DalFileMapper { get; private set; }

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
			this.BucketRepository = bucketRepository;
			this.BucketModelValidator = bucketModelValidator;
			this.BolBucketMapper = bolBucketMapper;
			this.DalBucketMapper = dalBucketMapper;
			this.BolFileMapper = bolFileMapper;
			this.DalFileMapper = dalFileMapper;
			this.logger = logger;
		}

		public virtual async Task<List<ApiBucketResponseModel>> All(int limit = 0, int offset = int.MaxValue)
		{
			var records = await this.BucketRepository.All(limit, offset);

			return this.BolBucketMapper.MapBOToModel(this.DalBucketMapper.MapEFToBO(records));
		}

		public virtual async Task<ApiBucketResponseModel> Get(int id)
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

		public virtual async Task<CreateResponse<ApiBucketResponseModel>> Create(
			ApiBucketRequestModel model)
		{
			CreateResponse<ApiBucketResponseModel> response = new CreateResponse<ApiBucketResponseModel>(await this.BucketModelValidator.ValidateCreateAsync(model));
			if (response.Success)
			{
				var bo = this.BolBucketMapper.MapModelToBO(default(int), model);
				var record = await this.BucketRepository.Create(this.DalBucketMapper.MapBOToEF(bo));

				response.SetRecord(this.BolBucketMapper.MapBOToModel(this.DalBucketMapper.MapEFToBO(record)));
			}

			return response;
		}

		public virtual async Task<UpdateResponse<ApiBucketResponseModel>> Update(
			int id,
			ApiBucketRequestModel model)
		{
			var validationResult = await this.BucketModelValidator.ValidateUpdateAsync(id, model);

			if (validationResult.IsValid)
			{
				var bo = this.BolBucketMapper.MapModelToBO(id, model);
				await this.BucketRepository.Update(this.DalBucketMapper.MapBOToEF(bo));

				var record = await this.BucketRepository.Get(id);

				return new UpdateResponse<ApiBucketResponseModel>(this.BolBucketMapper.MapBOToModel(this.DalBucketMapper.MapEFToBO(record)));
			}
			else
			{
				return new UpdateResponse<ApiBucketResponseModel>(validationResult);
			}
		}

		public virtual async Task<ActionResponse> Delete(
			int id)
		{
			ActionResponse response = new ActionResponse(await this.BucketModelValidator.ValidateDeleteAsync(id));
			if (response.Success)
			{
				await this.BucketRepository.Delete(id);
			}

			return response;
		}

		public async Task<ApiBucketResponseModel> ByExternalId(Guid externalId)
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

		public async Task<ApiBucketResponseModel> ByName(string name)
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

		public async virtual Task<List<ApiFileResponseModel>> FilesByBucketId(int bucketId, int limit = int.MaxValue, int offset = 0)
		{
			List<File> records = await this.BucketRepository.FilesByBucketId(bucketId, limit, offset);

			return this.BolFileMapper.MapBOToModel(this.DalFileMapper.MapEFToBO(records));
		}
	}
}

/*<Codenesium>
    <Hash>aa851e63e5f3db556f20b5241449c5a5</Hash>
</Codenesium>*/