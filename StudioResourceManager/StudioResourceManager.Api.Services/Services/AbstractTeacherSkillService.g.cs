using MediatR;
using Microsoft.Extensions.Logging;
using StudioResourceManagerNS.Api.Contracts;
using StudioResourceManagerNS.Api.DataAccess;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace StudioResourceManagerNS.Api.Services
{
	public abstract class AbstractTeacherSkillService : AbstractService
	{
		private IMediator mediator;

		protected ITeacherSkillRepository TeacherSkillRepository { get; private set; }

		protected IApiTeacherSkillServerRequestModelValidator TeacherSkillModelValidator { get; private set; }

		protected IDALTeacherSkillMapper DalTeacherSkillMapper { get; private set; }

		protected IDALRateMapper DalRateMapper { get; private set; }

		private ILogger logger;

		public AbstractTeacherSkillService(
			ILogger logger,
			IMediator mediator,
			ITeacherSkillRepository teacherSkillRepository,
			IApiTeacherSkillServerRequestModelValidator teacherSkillModelValidator,
			IDALTeacherSkillMapper dalTeacherSkillMapper,
			IDALRateMapper dalRateMapper)
			: base()
		{
			this.TeacherSkillRepository = teacherSkillRepository;
			this.TeacherSkillModelValidator = teacherSkillModelValidator;
			this.DalTeacherSkillMapper = dalTeacherSkillMapper;
			this.DalRateMapper = dalRateMapper;
			this.logger = logger;

			this.mediator = mediator;
		}

		public virtual async Task<List<ApiTeacherSkillServerResponseModel>> All(int limit = 0, int offset = int.MaxValue, string query = "")
		{
			List<TeacherSkill> records = await this.TeacherSkillRepository.All(limit, offset, query);

			return this.DalTeacherSkillMapper.MapEntityToModel(records);
		}

		public virtual async Task<ApiTeacherSkillServerResponseModel> Get(int id)
		{
			TeacherSkill record = await this.TeacherSkillRepository.Get(id);

			if (record == null)
			{
				return null;
			}
			else
			{
				return this.DalTeacherSkillMapper.MapEntityToModel(record);
			}
		}

		public virtual async Task<CreateResponse<ApiTeacherSkillServerResponseModel>> Create(
			ApiTeacherSkillServerRequestModel model)
		{
			CreateResponse<ApiTeacherSkillServerResponseModel> response = ValidationResponseFactory<ApiTeacherSkillServerResponseModel>.CreateResponse(await this.TeacherSkillModelValidator.ValidateCreateAsync(model));

			if (response.Success)
			{
				TeacherSkill record = this.DalTeacherSkillMapper.MapModelToEntity(default(int), model);
				record = await this.TeacherSkillRepository.Create(record);

				response.SetRecord(this.DalTeacherSkillMapper.MapEntityToModel(record));
				await this.mediator.Publish(new TeacherSkillCreatedNotification(response.Record));
			}

			return response;
		}

		public virtual async Task<UpdateResponse<ApiTeacherSkillServerResponseModel>> Update(
			int id,
			ApiTeacherSkillServerRequestModel model)
		{
			var validationResult = await this.TeacherSkillModelValidator.ValidateUpdateAsync(id, model);

			if (validationResult.IsValid)
			{
				TeacherSkill record = this.DalTeacherSkillMapper.MapModelToEntity(id, model);
				await this.TeacherSkillRepository.Update(record);

				record = await this.TeacherSkillRepository.Get(id);

				ApiTeacherSkillServerResponseModel apiModel = this.DalTeacherSkillMapper.MapEntityToModel(record);
				await this.mediator.Publish(new TeacherSkillUpdatedNotification(apiModel));

				return ValidationResponseFactory<ApiTeacherSkillServerResponseModel>.UpdateResponse(apiModel);
			}
			else
			{
				return ValidationResponseFactory<ApiTeacherSkillServerResponseModel>.UpdateResponse(validationResult);
			}
		}

		public virtual async Task<ActionResponse> Delete(
			int id)
		{
			ActionResponse response = ValidationResponseFactory<object>.ActionResponse(await this.TeacherSkillModelValidator.ValidateDeleteAsync(id));

			if (response.Success)
			{
				await this.TeacherSkillRepository.Delete(id);

				await this.mediator.Publish(new TeacherSkillDeletedNotification(id));
			}

			return response;
		}

		public async virtual Task<List<ApiRateServerResponseModel>> RatesByTeacherSkillId(int teacherSkillId, int limit = int.MaxValue, int offset = 0)
		{
			List<Rate> records = await this.TeacherSkillRepository.RatesByTeacherSkillId(teacherSkillId, limit, offset);

			return this.DalRateMapper.MapEntityToModel(records);
		}
	}
}

/*<Codenesium>
    <Hash>5ff0d3f1bd67822a6fb3daa5fd3628d5</Hash>
</Codenesium>*/