using MediatR;
using Microsoft.Extensions.Logging;
using StudioResourceManagerNS.Api.Contracts;
using StudioResourceManagerNS.Api.DataAccess;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace StudioResourceManagerNS.Api.Services
{
	public abstract class AbstractTeacherService : AbstractService
	{
		private IMediator mediator;

		protected ITeacherRepository TeacherRepository { get; private set; }

		protected IApiTeacherServerRequestModelValidator TeacherModelValidator { get; private set; }

		protected IBOLTeacherMapper BolTeacherMapper { get; private set; }

		protected IDALTeacherMapper DalTeacherMapper { get; private set; }

		protected IBOLRateMapper BolRateMapper { get; private set; }

		protected IDALRateMapper DalRateMapper { get; private set; }

		private ILogger logger;

		public AbstractTeacherService(
			ILogger logger,
			IMediator mediator,
			ITeacherRepository teacherRepository,
			IApiTeacherServerRequestModelValidator teacherModelValidator,
			IBOLTeacherMapper bolTeacherMapper,
			IDALTeacherMapper dalTeacherMapper,
			IBOLRateMapper bolRateMapper,
			IDALRateMapper dalRateMapper)
			: base()
		{
			this.TeacherRepository = teacherRepository;
			this.TeacherModelValidator = teacherModelValidator;
			this.BolTeacherMapper = bolTeacherMapper;
			this.DalTeacherMapper = dalTeacherMapper;
			this.BolRateMapper = bolRateMapper;
			this.DalRateMapper = dalRateMapper;
			this.logger = logger;

			this.mediator = mediator;
		}

		public virtual async Task<List<ApiTeacherServerResponseModel>> All(int limit = 0, int offset = int.MaxValue)
		{
			var records = await this.TeacherRepository.All(limit, offset);

			return this.BolTeacherMapper.MapBOToModel(this.DalTeacherMapper.MapEFToBO(records));
		}

		public virtual async Task<ApiTeacherServerResponseModel> Get(int id)
		{
			var record = await this.TeacherRepository.Get(id);

			if (record == null)
			{
				return null;
			}
			else
			{
				return this.BolTeacherMapper.MapBOToModel(this.DalTeacherMapper.MapEFToBO(record));
			}
		}

		public virtual async Task<CreateResponse<ApiTeacherServerResponseModel>> Create(
			ApiTeacherServerRequestModel model)
		{
			CreateResponse<ApiTeacherServerResponseModel> response = ValidationResponseFactory<ApiTeacherServerResponseModel>.CreateResponse(await this.TeacherModelValidator.ValidateCreateAsync(model));

			if (response.Success)
			{
				var bo = this.BolTeacherMapper.MapModelToBO(default(int), model);
				var record = await this.TeacherRepository.Create(this.DalTeacherMapper.MapBOToEF(bo));

				var businessObject = this.DalTeacherMapper.MapEFToBO(record);
				response.SetRecord(this.BolTeacherMapper.MapBOToModel(businessObject));
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
				var bo = this.BolTeacherMapper.MapModelToBO(id, model);
				await this.TeacherRepository.Update(this.DalTeacherMapper.MapBOToEF(bo));

				var record = await this.TeacherRepository.Get(id);

				var businessObject = this.DalTeacherMapper.MapEFToBO(record);
				var apiModel = this.BolTeacherMapper.MapBOToModel(businessObject);
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

			return this.BolTeacherMapper.MapBOToModel(this.DalTeacherMapper.MapEFToBO(records));
		}

		public async virtual Task<List<ApiRateServerResponseModel>> RatesByTeacherId(int teacherId, int limit = int.MaxValue, int offset = 0)
		{
			List<Rate> records = await this.TeacherRepository.RatesByTeacherId(teacherId, limit, offset);

			return this.BolRateMapper.MapBOToModel(this.DalRateMapper.MapEFToBO(records));
		}

		public async virtual Task<List<ApiTeacherServerResponseModel>> ByEventId(int eventId, int limit = int.MaxValue, int offset = 0)
		{
			List<Teacher> records = await this.TeacherRepository.ByEventId(eventId, limit, offset);

			return this.BolTeacherMapper.MapBOToModel(this.DalTeacherMapper.MapEFToBO(records));
		}
	}
}

/*<Codenesium>
    <Hash>b1a2a8c84e61e0f7e92f99204161cfd4</Hash>
</Codenesium>*/