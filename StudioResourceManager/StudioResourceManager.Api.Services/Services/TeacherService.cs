using Microsoft.Extensions.Logging;
using StudioResourceManagerNS.Api.Contracts;
using StudioResourceManagerNS.Api.DataAccess;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace StudioResourceManagerNS.Api.Services
{
	public class TeacherService : AbstractService, ITeacherService
	{
		private MediatR.IMediator mediator;

		protected ITeacherRepository TeacherRepository { get; private set; }

		protected IApiTeacherServerRequestModelValidator TeacherModelValidator { get; private set; }

		protected IDALTeacherMapper DalTeacherMapper { get; private set; }

		protected IDALEventTeacherMapper DalEventTeacherMapper { get; private set; }

		protected IDALRateMapper DalRateMapper { get; private set; }

		protected IDALTeacherTeacherSkillMapper DalTeacherTeacherSkillMapper { get; private set; }

		private ILogger logger;

		public TeacherService(
			ILogger<ITeacherService> logger,
			MediatR.IMediator mediator,
			ITeacherRepository teacherRepository,
			IApiTeacherServerRequestModelValidator teacherModelValidator,
			IDALTeacherMapper dalTeacherMapper,
			IDALEventTeacherMapper dalEventTeacherMapper,
			IDALRateMapper dalRateMapper,
			IDALTeacherTeacherSkillMapper dalTeacherTeacherSkillMapper)
			: base()
		{
			this.TeacherRepository = teacherRepository;
			this.TeacherModelValidator = teacherModelValidator;
			this.DalTeacherMapper = dalTeacherMapper;
			this.DalEventTeacherMapper = dalEventTeacherMapper;
			this.DalRateMapper = dalRateMapper;
			this.DalTeacherTeacherSkillMapper = dalTeacherTeacherSkillMapper;
			this.logger = logger;

			this.mediator = mediator;
		}

		public virtual async Task<List<ApiTeacherServerResponseModel>> All(int limit = 0, int offset = int.MaxValue, string query = "")
		{
			List<Teacher> records = await this.TeacherRepository.All(limit, offset, query);

			return this.DalTeacherMapper.MapEntityToModel(records);
		}

		public virtual async Task<ApiTeacherServerResponseModel> Get(int id)
		{
			Teacher record = await this.TeacherRepository.Get(id);

			if (record == null)
			{
				return null;
			}
			else
			{
				return this.DalTeacherMapper.MapEntityToModel(record);
			}
		}

		public virtual async Task<CreateResponse<ApiTeacherServerResponseModel>> Create(
			ApiTeacherServerRequestModel model)
		{
			CreateResponse<ApiTeacherServerResponseModel> response = ValidationResponseFactory<ApiTeacherServerResponseModel>.CreateResponse(await this.TeacherModelValidator.ValidateCreateAsync(model));

			if (response.Success)
			{
				Teacher record = this.DalTeacherMapper.MapModelToEntity(default(int), model);
				record = await this.TeacherRepository.Create(record);

				response.SetRecord(this.DalTeacherMapper.MapEntityToModel(record));
				await this.mediator.Publish(new TeacherCreatedNotification(response.Record));
			}

			return response;
		}

		public virtual async Task<UpdateResponse<ApiTeacherServerResponseModel>> Update(
			int id,
			ApiTeacherServerRequestModel model)
		{
			var validationResult = await this.TeacherModelValidator.ValidateUpdateAsync(id, model);

			if (validationResult.IsValid)
			{
				Teacher record = this.DalTeacherMapper.MapModelToEntity(id, model);
				await this.TeacherRepository.Update(record);

				record = await this.TeacherRepository.Get(id);

				ApiTeacherServerResponseModel apiModel = this.DalTeacherMapper.MapEntityToModel(record);
				await this.mediator.Publish(new TeacherUpdatedNotification(apiModel));

				return ValidationResponseFactory<ApiTeacherServerResponseModel>.UpdateResponse(apiModel);
			}
			else
			{
				return ValidationResponseFactory<ApiTeacherServerResponseModel>.UpdateResponse(validationResult);
			}
		}

		public virtual async Task<ActionResponse> Delete(
			int id)
		{
			ActionResponse response = ValidationResponseFactory<object>.ActionResponse(await this.TeacherModelValidator.ValidateDeleteAsync(id));

			if (response.Success)
			{
				await this.TeacherRepository.Delete(id);

				await this.mediator.Publish(new TeacherDeletedNotification(id));
			}

			return response;
		}

		public async virtual Task<List<ApiTeacherServerResponseModel>> ByUserId(int userId, int limit = 0, int offset = int.MaxValue)
		{
			List<Teacher> records = await this.TeacherRepository.ByUserId(userId, limit, offset);

			return this.DalTeacherMapper.MapEntityToModel(records);
		}

		public async virtual Task<List<ApiEventTeacherServerResponseModel>> EventTeachersByTeacherId(int teacherId, int limit = int.MaxValue, int offset = 0)
		{
			List<EventTeacher> records = await this.TeacherRepository.EventTeachersByTeacherId(teacherId, limit, offset);

			return this.DalEventTeacherMapper.MapEntityToModel(records);
		}

		public async virtual Task<List<ApiRateServerResponseModel>> RatesByTeacherId(int teacherId, int limit = int.MaxValue, int offset = 0)
		{
			List<Rate> records = await this.TeacherRepository.RatesByTeacherId(teacherId, limit, offset);

			return this.DalRateMapper.MapEntityToModel(records);
		}

		public async virtual Task<List<ApiTeacherTeacherSkillServerResponseModel>> TeacherTeacherSkillsByTeacherId(int teacherId, int limit = int.MaxValue, int offset = 0)
		{
			List<TeacherTeacherSkill> records = await this.TeacherRepository.TeacherTeacherSkillsByTeacherId(teacherId, limit, offset);

			return this.DalTeacherTeacherSkillMapper.MapEntityToModel(records);
		}
	}
}

/*<Codenesium>
    <Hash>66612b58673158c14d1a36e8d6b4be30</Hash>
    <Hello>
		This code was generated using the Codenesium platform. You can visit our site at https://www.codenesium.com. 
	</Hello>
</Codenesium>*/