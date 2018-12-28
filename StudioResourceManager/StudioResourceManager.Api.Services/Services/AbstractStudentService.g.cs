using MediatR;
using Microsoft.Extensions.Logging;
using StudioResourceManagerNS.Api.Contracts;
using StudioResourceManagerNS.Api.DataAccess;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace StudioResourceManagerNS.Api.Services
{
	public abstract class AbstractStudentService : AbstractService
	{
		private IMediator mediator;

		protected IStudentRepository StudentRepository { get; private set; }

		protected IApiStudentServerRequestModelValidator StudentModelValidator { get; private set; }

		protected IBOLStudentMapper BolStudentMapper { get; private set; }

		protected IDALStudentMapper DalStudentMapper { get; private set; }

		private ILogger logger;

		public AbstractStudentService(
			ILogger logger,
			IMediator mediator,
			IStudentRepository studentRepository,
			IApiStudentServerRequestModelValidator studentModelValidator,
			IBOLStudentMapper bolStudentMapper,
			IDALStudentMapper dalStudentMapper)
			: base()
		{
			this.StudentRepository = studentRepository;
			this.StudentModelValidator = studentModelValidator;
			this.BolStudentMapper = bolStudentMapper;
			this.DalStudentMapper = dalStudentMapper;
			this.logger = logger;

			this.mediator = mediator;
		}

		public virtual async Task<List<ApiStudentServerResponseModel>> All(int limit = 0, int offset = int.MaxValue)
		{
			var records = await this.StudentRepository.All(limit, offset);

			return this.BolStudentMapper.MapBOToModel(this.DalStudentMapper.MapEFToBO(records));
		}

		public virtual async Task<ApiStudentServerResponseModel> Get(int id)
		{
			var record = await this.StudentRepository.Get(id);

			if (record == null)
			{
				return null;
			}
			else
			{
				return this.BolStudentMapper.MapBOToModel(this.DalStudentMapper.MapEFToBO(record));
			}
		}

		public virtual async Task<CreateResponse<ApiStudentServerResponseModel>> Create(
			ApiStudentServerRequestModel model)
		{
			CreateResponse<ApiStudentServerResponseModel> response = ValidationResponseFactory<ApiStudentServerResponseModel>.CreateResponse(await this.StudentModelValidator.ValidateCreateAsync(model));

			if (response.Success)
			{
				var bo = this.BolStudentMapper.MapModelToBO(default(int), model);
				var record = await this.StudentRepository.Create(this.DalStudentMapper.MapBOToEF(bo));

				var businessObject = this.DalStudentMapper.MapEFToBO(record);
				response.SetRecord(this.BolStudentMapper.MapBOToModel(businessObject));
				await this.mediator.Publish(new StudentCreatedNotification(response.Record));
			}

			return response;
		}

		public virtual async Task<UpdateResponse<ApiStudentServerResponseModel>> Update(
			int id,
			ApiStudentServerRequestModel model)
		{
			var validationResult = await this.StudentModelValidator.ValidateUpdateAsync(id, model);

			if (validationResult.IsValid)
			{
				var bo = this.BolStudentMapper.MapModelToBO(id, model);
				await this.StudentRepository.Update(this.DalStudentMapper.MapBOToEF(bo));

				var record = await this.StudentRepository.Get(id);

				var businessObject = this.DalStudentMapper.MapEFToBO(record);
				var apiModel = this.BolStudentMapper.MapBOToModel(businessObject);
				await this.mediator.Publish(new StudentUpdatedNotification(apiModel));

				return ValidationResponseFactory<ApiStudentServerResponseModel>.UpdateResponse(apiModel);
			}
			else
			{
				return ValidationResponseFactory<ApiStudentServerResponseModel>.UpdateResponse(validationResult);
			}
		}

		public virtual async Task<ActionResponse> Delete(
			int id)
		{
			ActionResponse response = ValidationResponseFactory<object>.ActionResponse(await this.StudentModelValidator.ValidateDeleteAsync(id));

			if (response.Success)
			{
				await this.StudentRepository.Delete(id);

				await this.mediator.Publish(new StudentDeletedNotification(id));
			}

			return response;
		}

		public async virtual Task<List<ApiStudentServerResponseModel>> ByFamilyId(int familyId, int limit = 0, int offset = int.MaxValue)
		{
			List<Student> records = await this.StudentRepository.ByFamilyId(familyId, limit, offset);

			return this.BolStudentMapper.MapBOToModel(this.DalStudentMapper.MapEFToBO(records));
		}

		public async virtual Task<List<ApiStudentServerResponseModel>> ByUserId(int userId, int limit = 0, int offset = int.MaxValue)
		{
			List<Student> records = await this.StudentRepository.ByUserId(userId, limit, offset);

			return this.BolStudentMapper.MapBOToModel(this.DalStudentMapper.MapEFToBO(records));
		}

		public async virtual Task<List<ApiStudentServerResponseModel>> ByEventId(int eventId, int limit = int.MaxValue, int offset = 0)
		{
			List<Student> records = await this.StudentRepository.ByEventId(eventId, limit, offset);

			return this.BolStudentMapper.MapBOToModel(this.DalStudentMapper.MapEFToBO(records));
		}
	}
}

/*<Codenesium>
    <Hash>e0e135a79a3f98902b102fff0b34cb54</Hash>
</Codenesium>*/