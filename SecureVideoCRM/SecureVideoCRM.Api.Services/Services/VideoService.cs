using Microsoft.Extensions.Logging;
using SecureVideoCRMNS.Api.Contracts;
using SecureVideoCRMNS.Api.DataAccess;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace SecureVideoCRMNS.Api.Services
{
	public class VideoService : AbstractService, IVideoService
	{
		private MediatR.IMediator mediator;

		protected IVideoRepository VideoRepository { get; private set; }

		protected IApiVideoServerRequestModelValidator VideoModelValidator { get; private set; }

		protected IDALVideoMapper DalVideoMapper { get; private set; }

		private ILogger logger;

		public VideoService(
			ILogger<IVideoService> logger,
			MediatR.IMediator mediator,
			IVideoRepository videoRepository,
			IApiVideoServerRequestModelValidator videoModelValidator,
			IDALVideoMapper dalVideoMapper)
			: base()
		{
			this.VideoRepository = videoRepository;
			this.VideoModelValidator = videoModelValidator;
			this.DalVideoMapper = dalVideoMapper;
			this.logger = logger;

			this.mediator = mediator;
		}

		public virtual async Task<List<ApiVideoServerResponseModel>> All(int limit = 0, int offset = int.MaxValue, string query = "")
		{
			List<Video> records = await this.VideoRepository.All(limit, offset, query);

			return this.DalVideoMapper.MapEntityToModel(records);
		}

		public virtual async Task<ApiVideoServerResponseModel> Get(int id)
		{
			Video record = await this.VideoRepository.Get(id);

			if (record == null)
			{
				return null;
			}
			else
			{
				return this.DalVideoMapper.MapEntityToModel(record);
			}
		}

		public virtual async Task<CreateResponse<ApiVideoServerResponseModel>> Create(
			ApiVideoServerRequestModel model)
		{
			CreateResponse<ApiVideoServerResponseModel> response = ValidationResponseFactory<ApiVideoServerResponseModel>.CreateResponse(await this.VideoModelValidator.ValidateCreateAsync(model));

			if (response.Success)
			{
				Video record = this.DalVideoMapper.MapModelToEntity(default(int), model);
				record = await this.VideoRepository.Create(record);

				response.SetRecord(this.DalVideoMapper.MapEntityToModel(record));
				await this.mediator.Publish(new VideoCreatedNotification(response.Record));
			}

			return response;
		}

		public virtual async Task<UpdateResponse<ApiVideoServerResponseModel>> Update(
			int id,
			ApiVideoServerRequestModel model)
		{
			var validationResult = await this.VideoModelValidator.ValidateUpdateAsync(id, model);

			if (validationResult.IsValid)
			{
				Video record = this.DalVideoMapper.MapModelToEntity(id, model);
				await this.VideoRepository.Update(record);

				record = await this.VideoRepository.Get(id);

				ApiVideoServerResponseModel apiModel = this.DalVideoMapper.MapEntityToModel(record);
				await this.mediator.Publish(new VideoUpdatedNotification(apiModel));

				return ValidationResponseFactory<ApiVideoServerResponseModel>.UpdateResponse(apiModel);
			}
			else
			{
				return ValidationResponseFactory<ApiVideoServerResponseModel>.UpdateResponse(validationResult);
			}
		}

		public virtual async Task<ActionResponse> Delete(
			int id)
		{
			ActionResponse response = ValidationResponseFactory<object>.ActionResponse(await this.VideoModelValidator.ValidateDeleteAsync(id));

			if (response.Success)
			{
				await this.VideoRepository.Delete(id);

				await this.mediator.Publish(new VideoDeletedNotification(id));
			}

			return response;
		}
	}
}

/*<Codenesium>
    <Hash>642099dc582ad0d87a8c41a94618151d</Hash>
    <Hello>
		This code was generated using the Codenesium platform. You can visit our site at https://www.codenesium.com. 
	</Hello>
</Codenesium>*/