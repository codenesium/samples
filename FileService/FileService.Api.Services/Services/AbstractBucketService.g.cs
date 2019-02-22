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
		private MediatR.IMediator mediator;

		protected IBucketRepository BucketRepository { get; private set; }

		protected IApiBucketServerRequestModelValidator BucketModelValidator { get; private set; }

		protected IDALBucketMapper DalBucketMapper { get; private set; }

		protected IDALFileMapper DalFileMapper { get; private set; }

		private ILogger logger;

		public AbstractBucketService(
			ILogger logger,
			MediatR.IMediator mediator,
			IBucketRepository bucketRepository,
			IApiBucketServerRequestModelValidator bucketModelValidator,
			IDALBucketMapper dalBucketMapper,
			IDALFileMapper dalFileMapper)
			: base()
		{
			this.BucketRepository = bucketRepository;
			this.BucketModelValidator = bucketModelValidator;
			this.DalBucketMapper = dalBucketMapper;
			this.DalFileMapper = dalFileMapper;
			this.logger = logger;

			this.mediator = mediator;
		}

		public virtual async Task<List<ApiBucketServerResponseModel>> All(int limit = 0, int offset = int.MaxValue, string query = "")
		{
			List<Bucket> records = await this.BucketRepository.All(limit, offset, query);

			return this.DalBucketMapper.MapEntityToModel(records);
		}

		public virtual async Task<ApiBucketServerResponseModel> Get(int id)
		{
			Bucket record = await this.BucketRepository.Get(id);

			if (record == null)
			{
				return null;
			}
			else
			{
				return this.DalBucketMapper.MapEntityToModel(record);
			}
		}

		public virtual async Task<CreateResponse<ApiBucketServerResponseModel>> Create(
			ApiBucketServerRequestModel model)
		{
			CreateResponse<ApiBucketServerResponseModel> response = ValidationResponseFactory<ApiBucketServerResponseModel>.CreateResponse(await this.BucketModelValidator.ValidateCreateAsync(model));

			if (response.Success)
			{
				Bucket record = this.DalBucketMapper.MapModelToEntity(default(int), model);
				record = await this.BucketRepository.Create(record);

				response.SetRecord(this.DalBucketMapper.MapEntityToModel(record));
				await this.mediator.Publish(new BucketCreatedNotification(response.Record));
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
				Bucket record = this.DalBucketMapper.MapModelToEntity(id, model);
				await this.BucketRepository.Update(record);

				record = await this.BucketRepository.Get(id);

				ApiBucketServerResponseModel apiModel = this.DalBucketMapper.MapEntityToModel(record);
				await this.mediator.Publish(new BucketUpdatedNotification(apiModel));

				return ValidationResponseFactory<ApiBucketServerResponseModel>.UpdateResponse(apiModel);
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

				await this.mediator.Publish(new BucketDeletedNotification(id));
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
				return this.DalBucketMapper.MapEntityToModel(record);
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
				return this.DalBucketMapper.MapEntityToModel(record);
			}
		}

		public async virtual Task<List<ApiFileServerResponseModel>> FilesByBucketId(int bucketId, int limit = int.MaxValue, int offset = 0)
		{
			List<File> records = await this.BucketRepository.FilesByBucketId(bucketId, limit, offset);

			return this.DalFileMapper.MapEntityToModel(records);
		}
	}
}

/*<Codenesium>
    <Hash>f713b9c2fc19808fa46c5523ca61c02e</Hash>
</Codenesium>*/