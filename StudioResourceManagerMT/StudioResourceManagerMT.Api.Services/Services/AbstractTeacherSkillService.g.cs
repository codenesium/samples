using Microsoft.Extensions.Logging;
using StudioResourceManagerMTNS.Api.Contracts;
using StudioResourceManagerMTNS.Api.DataAccess;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace StudioResourceManagerMTNS.Api.Services
{
	public abstract class AbstractTeacherSkillService : AbstractService
	{
		private MediatR.IMediator mediator;

		protected ITeacherSkillRepository TeacherSkillRepository { get; private set; }

		protected IApiTeacherSkillServerRequestModelValidator TeacherSkillModelValidator { get; private set; }

		protected IDALTeacherSkillMapper DalTeacherSkillMapper { get; private set; }

		private ILogger logger;

		public AbstractTeacherSkillService(
			ILogger logger,
			MediatR.IMediator mediator,
			ITeacherSkillRepository teacherSkillRepository,
			IApiTeacherSkillServerRequestModelValidator teacherSkillModelValidator,
			IDALTeacherSkillMapper dalTeacherSkillMapper)
			: base()
		{
			this.TeacherSkillRepository = teacherSkillRepository;
			this.TeacherSkillModelValidator = teacherSkillModelValidator;
			this.DalTeacherSkillMapper = dalTeacherSkillMapper;
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
	}
}

/*<Codenesium>
    <Hash>f220fabfbd947986cf537d473c88f913</Hash>
</Codenesium>*/