using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using TwitterNS.Api.Contracts;
using TwitterNS.Api.DataAccess;

namespace TwitterNS.Api.Services
{
	public class FollowingService : AbstractService, IFollowingService
	{
		private MediatR.IMediator mediator;

		protected IFollowingRepository FollowingRepository { get; private set; }

		protected IApiFollowingServerRequestModelValidator FollowingModelValidator { get; private set; }

		protected IDALFollowingMapper DalFollowingMapper { get; private set; }

		private ILogger logger;

		public FollowingService(
			ILogger<IFollowingService> logger,
			MediatR.IMediator mediator,
			IFollowingRepository followingRepository,
			IApiFollowingServerRequestModelValidator followingModelValidator,
			IDALFollowingMapper dalFollowingMapper)
			: base()
		{
			this.FollowingRepository = followingRepository;
			this.FollowingModelValidator = followingModelValidator;
			this.DalFollowingMapper = dalFollowingMapper;
			this.logger = logger;

			this.mediator = mediator;
		}

		public virtual async Task<List<ApiFollowingServerResponseModel>> All(int limit = 0, int offset = int.MaxValue, string query = "")
		{
			List<Following> records = await this.FollowingRepository.All(limit, offset, query);

			return this.DalFollowingMapper.MapEntityToModel(records);
		}

		public virtual async Task<ApiFollowingServerResponseModel> Get(int userId)
		{
			Following record = await this.FollowingRepository.Get(userId);

			if (record == null)
			{
				return null;
			}
			else
			{
				return this.DalFollowingMapper.MapEntityToModel(record);
			}
		}

		public virtual async Task<CreateResponse<ApiFollowingServerResponseModel>> Create(
			ApiFollowingServerRequestModel model)
		{
			CreateResponse<ApiFollowingServerResponseModel> response = ValidationResponseFactory<ApiFollowingServerResponseModel>.CreateResponse(await this.FollowingModelValidator.ValidateCreateAsync(model));

			if (response.Success)
			{
				Following record = this.DalFollowingMapper.MapModelToEntity(default(int), model);
				record = await this.FollowingRepository.Create(record);

				response.SetRecord(this.DalFollowingMapper.MapEntityToModel(record));
				await this.mediator.Publish(new FollowingCreatedNotification(response.Record));
			}

			return response;
		}

		public virtual async Task<UpdateResponse<ApiFollowingServerResponseModel>> Update(
			int userId,
			ApiFollowingServerRequestModel model)
		{
			var validationResult = await this.FollowingModelValidator.ValidateUpdateAsync(userId, model);

			if (validationResult.IsValid)
			{
				Following record = this.DalFollowingMapper.MapModelToEntity(userId, model);
				await this.FollowingRepository.Update(record);

				record = await this.FollowingRepository.Get(userId);

				ApiFollowingServerResponseModel apiModel = this.DalFollowingMapper.MapEntityToModel(record);
				await this.mediator.Publish(new FollowingUpdatedNotification(apiModel));

				return ValidationResponseFactory<ApiFollowingServerResponseModel>.UpdateResponse(apiModel);
			}
			else
			{
				return ValidationResponseFactory<ApiFollowingServerResponseModel>.UpdateResponse(validationResult);
			}
		}

		public virtual async Task<ActionResponse> Delete(
			int userId)
		{
			ActionResponse response = ValidationResponseFactory<object>.ActionResponse(await this.FollowingModelValidator.ValidateDeleteAsync(userId));

			if (response.Success)
			{
				await this.FollowingRepository.Delete(userId);

				await this.mediator.Publish(new FollowingDeletedNotification(userId));
			}

			return response;
		}
	}
}

/*<Codenesium>
    <Hash>54f87f274345776235088e4a7ab17ef9</Hash>
    <Hello>
		This code was generated using the Codenesium platform. You can visit our site at https://www.codenesium.com. 
	</Hello>
</Codenesium>*/