using Microsoft.Extensions.Logging;
using StudioResourceManagerMTNS.Api.Contracts;
using StudioResourceManagerMTNS.Api.DataAccess;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace StudioResourceManagerMTNS.Api.Services
{
	public abstract class AbstractTeacherTeacherSkillService : AbstractService
	{
		private MediatR.IMediator mediator;

		protected ITeacherTeacherSkillRepository TeacherTeacherSkillRepository { get; private set; }

		protected IApiTeacherTeacherSkillServerRequestModelValidator TeacherTeacherSkillModelValidator { get; private set; }

		protected IDALTeacherTeacherSkillMapper DalTeacherTeacherSkillMapper { get; private set; }

		private ILogger logger;

		public AbstractTeacherTeacherSkillService(
			ILogger logger,
			MediatR.IMediator mediator,
			ITeacherTeacherSkillRepository teacherTeacherSkillRepository,
			IApiTeacherTeacherSkillServerRequestModelValidator teacherTeacherSkillModelValidator,
			IDALTeacherTeacherSkillMapper dalTeacherTeacherSkillMapper)
			: base()
		{
			this.TeacherTeacherSkillRepository = teacherTeacherSkillRepository;
			this.TeacherTeacherSkillModelValidator = teacherTeacherSkillModelValidator;
			this.DalTeacherTeacherSkillMapper = dalTeacherTeacherSkillMapper;
			this.logger = logger;

			this.mediator = mediator;
		}

		public virtual async Task<List<ApiTeacherTeacherSkillServerResponseModel>> All(int limit = 0, int offset = int.MaxValue, string query = "")
		{
			List<TeacherTeacherSkill> records = await this.TeacherTeacherSkillRepository.All(limit, offset, query);

			return this.DalTeacherTeacherSkillMapper.MapEntityToModel(records);
		}

		public virtual async Task<ApiTeacherTeacherSkillServerResponseModel> Get(int id)
		{
			TeacherTeacherSkill record = await this.TeacherTeacherSkillRepository.Get(id);

			if (record == null)
			{
				return null;
			}
			else
			{
				return this.DalTeacherTeacherSkillMapper.MapEntityToModel(record);
			}
		}

		public virtual async Task<CreateResponse<ApiTeacherTeacherSkillServerResponseModel>> Create(
			ApiTeacherTeacherSkillServerRequestModel model)
		{
			CreateResponse<ApiTeacherTeacherSkillServerResponseModel> response = ValidationResponseFactory<ApiTeacherTeacherSkillServerResponseModel>.CreateResponse(await this.TeacherTeacherSkillModelValidator.ValidateCreateAsync(model));

			if (response.Success)
			{
				TeacherTeacherSkill record = this.DalTeacherTeacherSkillMapper.MapModelToEntity(default(int), model);
				record = await this.TeacherTeacherSkillRepository.Create(record);

				response.SetRecord(this.DalTeacherTeacherSkillMapper.MapEntityToModel(record));
				await this.mediator.Publish(new TeacherTeacherSkillCreatedNotification(response.Record));
			}

			return response;
		}

		public virtual async Task<UpdateResponse<ApiTeacherTeacherSkillServerResponseModel>> Update(
			int id,
			ApiTeacherTeacherSkillServerRequestModel model)
		{
			var validationResult = await this.TeacherTeacherSkillModelValidator.ValidateUpdateAsync(id, model);

			if (validationResult.IsValid)
			{
				TeacherTeacherSkill record = this.DalTeacherTeacherSkillMapper.MapModelToEntity(id, model);
				await this.TeacherTeacherSkillRepository.Update(record);

				record = await this.TeacherTeacherSkillRepository.Get(id);

				ApiTeacherTeacherSkillServerResponseModel apiModel = this.DalTeacherTeacherSkillMapper.MapEntityToModel(record);
				await this.mediator.Publish(new TeacherTeacherSkillUpdatedNotification(apiModel));

				return ValidationResponseFactory<ApiTeacherTeacherSkillServerResponseModel>.UpdateResponse(apiModel);
			}
			else
			{
				return ValidationResponseFactory<ApiTeacherTeacherSkillServerResponseModel>.UpdateResponse(validationResult);
			}
		}

		public virtual async Task<ActionResponse> Delete(
			int id)
		{
			ActionResponse response = ValidationResponseFactory<object>.ActionResponse(await this.TeacherTeacherSkillModelValidator.ValidateDeleteAsync(id));

			if (response.Success)
			{
				await this.TeacherTeacherSkillRepository.Delete(id);

				await this.mediator.Publish(new TeacherTeacherSkillDeletedNotification(id));
			}

			return response;
		}
	}
}

/*<Codenesium>
    <Hash>a209c6f05510d7ecd95700987bef4e20</Hash>
</Codenesium>*/