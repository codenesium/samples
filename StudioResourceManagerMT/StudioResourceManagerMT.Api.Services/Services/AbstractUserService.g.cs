using Microsoft.Extensions.Logging;
using StudioResourceManagerMTNS.Api.Contracts;
using StudioResourceManagerMTNS.Api.DataAccess;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace StudioResourceManagerMTNS.Api.Services
{
	public abstract class AbstractUserService : AbstractService
	{
		private MediatR.IMediator mediator;

		protected IUserRepository UserRepository { get; private set; }

		protected IApiUserServerRequestModelValidator UserModelValidator { get; private set; }

		protected IDALUserMapper DalUserMapper { get; private set; }

		private ILogger logger;

		public AbstractUserService(
			ILogger logger,
			MediatR.IMediator mediator,
			IUserRepository userRepository,
			IApiUserServerRequestModelValidator userModelValidator,
			IDALUserMapper dalUserMapper)
			: base()
		{
			this.UserRepository = userRepository;
			this.UserModelValidator = userModelValidator;
			this.DalUserMapper = dalUserMapper;
			this.logger = logger;

			this.mediator = mediator;
		}

		public virtual async Task<List<ApiUserServerResponseModel>> All(int limit = 0, int offset = int.MaxValue, string query = "")
		{
			List<User> records = await this.UserRepository.All(limit, offset, query);

			return this.DalUserMapper.MapEntityToModel(records);
		}

		public virtual async Task<ApiUserServerResponseModel> Get(int id)
		{
			User record = await this.UserRepository.Get(id);

			if (record == null)
			{
				return null;
			}
			else
			{
				return this.DalUserMapper.MapEntityToModel(record);
			}
		}

		public virtual async Task<CreateResponse<ApiUserServerResponseModel>> Create(
			ApiUserServerRequestModel model)
		{
			CreateResponse<ApiUserServerResponseModel> response = ValidationResponseFactory<ApiUserServerResponseModel>.CreateResponse(await this.UserModelValidator.ValidateCreateAsync(model));

			if (response.Success)
			{
				User record = this.DalUserMapper.MapModelToEntity(default(int), model);
				record = await this.UserRepository.Create(record);

				response.SetRecord(this.DalUserMapper.MapEntityToModel(record));
				await this.mediator.Publish(new UserCreatedNotification(response.Record));
			}

			return response;
		}

		public virtual async Task<UpdateResponse<ApiUserServerResponseModel>> Update(
			int id,
			ApiUserServerRequestModel model)
		{
			var validationResult = await this.UserModelValidator.ValidateUpdateAsync(id, model);

			if (validationResult.IsValid)
			{
				User record = this.DalUserMapper.MapModelToEntity(id, model);
				await this.UserRepository.Update(record);

				record = await this.UserRepository.Get(id);

				ApiUserServerResponseModel apiModel = this.DalUserMapper.MapEntityToModel(record);
				await this.mediator.Publish(new UserUpdatedNotification(apiModel));

				return ValidationResponseFactory<ApiUserServerResponseModel>.UpdateResponse(apiModel);
			}
			else
			{
				return ValidationResponseFactory<ApiUserServerResponseModel>.UpdateResponse(validationResult);
			}
		}

		public virtual async Task<ActionResponse> Delete(
			int id)
		{
			ActionResponse response = ValidationResponseFactory<object>.ActionResponse(await this.UserModelValidator.ValidateDeleteAsync(id));

			if (response.Success)
			{
				await this.UserRepository.Delete(id);

				await this.mediator.Publish(new UserDeletedNotification(id));
			}

			return response;
		}
	}
}

/*<Codenesium>
    <Hash>4629759495c6ea28a888748bbd4985d2</Hash>
</Codenesium>*/