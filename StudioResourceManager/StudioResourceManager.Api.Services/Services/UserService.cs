using Microsoft.Extensions.Logging;
using StudioResourceManagerNS.Api.Contracts;
using StudioResourceManagerNS.Api.DataAccess;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace StudioResourceManagerNS.Api.Services
{
	public class UserService : AbstractService, IUserService
	{
		private MediatR.IMediator mediator;

		protected IUserRepository UserRepository { get; private set; }

		protected IApiUserServerRequestModelValidator UserModelValidator { get; private set; }

		protected IDALUserMapper DalUserMapper { get; private set; }

		protected IDALAdminMapper DalAdminMapper { get; private set; }

		protected IDALStudentMapper DalStudentMapper { get; private set; }

		protected IDALTeacherMapper DalTeacherMapper { get; private set; }

		private ILogger logger;

		public UserService(
			ILogger<IUserService> logger,
			MediatR.IMediator mediator,
			IUserRepository userRepository,
			IApiUserServerRequestModelValidator userModelValidator,
			IDALUserMapper dalUserMapper,
			IDALAdminMapper dalAdminMapper,
			IDALStudentMapper dalStudentMapper,
			IDALTeacherMapper dalTeacherMapper)
			: base()
		{
			this.UserRepository = userRepository;
			this.UserModelValidator = userModelValidator;
			this.DalUserMapper = dalUserMapper;
			this.DalAdminMapper = dalAdminMapper;
			this.DalStudentMapper = dalStudentMapper;
			this.DalTeacherMapper = dalTeacherMapper;
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

		public async virtual Task<List<ApiAdminServerResponseModel>> AdminsByUserId(int userId, int limit = int.MaxValue, int offset = 0)
		{
			List<Admin> records = await this.UserRepository.AdminsByUserId(userId, limit, offset);

			return this.DalAdminMapper.MapEntityToModel(records);
		}

		public async virtual Task<List<ApiStudentServerResponseModel>> StudentsByUserId(int userId, int limit = int.MaxValue, int offset = 0)
		{
			List<Student> records = await this.UserRepository.StudentsByUserId(userId, limit, offset);

			return this.DalStudentMapper.MapEntityToModel(records);
		}

		public async virtual Task<List<ApiTeacherServerResponseModel>> TeachersByUserId(int userId, int limit = int.MaxValue, int offset = 0)
		{
			List<Teacher> records = await this.UserRepository.TeachersByUserId(userId, limit, offset);

			return this.DalTeacherMapper.MapEntityToModel(records);
		}
	}
}

/*<Codenesium>
    <Hash>3b04e60ad2642168137c37acb18af5fc</Hash>
    <Hello>
		This code was generated using the Codenesium platform. You can visit our site at https://www.codenesium.com. 
	</Hello>
</Codenesium>*/