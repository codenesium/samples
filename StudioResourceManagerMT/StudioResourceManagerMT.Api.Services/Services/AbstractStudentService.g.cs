using MediatR;
using Microsoft.Extensions.Logging;
using StudioResourceManagerMTNS.Api.Contracts;
using StudioResourceManagerMTNS.Api.DataAccess;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace StudioResourceManagerMTNS.Api.Services
{
	public abstract class AbstractStudentService : AbstractService
	{
		private IMediator mediator;

		protected IStudentRepository StudentRepository { get; private set; }

		protected IApiStudentServerRequestModelValidator StudentModelValidator { get; private set; }

		protected IDALStudentMapper DalStudentMapper { get; private set; }

		private ILogger logger;

		public AbstractStudentService(
			ILogger logger,
			IMediator mediator,
			IStudentRepository studentRepository,
			IApiStudentServerRequestModelValidator studentModelValidator,
			IDALStudentMapper dalStudentMapper)
			: base()
		{
			this.StudentRepository = studentRepository;
			this.StudentModelValidator = studentModelValidator;
			this.DalStudentMapper = dalStudentMapper;
			this.logger = logger;

			this.mediator = mediator;
		}

		public virtual async Task<List<ApiStudentServerResponseModel>> All(int limit = 0, int offset = int.MaxValue, string query = "")
		{
			List<Student> records = await this.StudentRepository.All(limit, offset, query);

			return this.DalStudentMapper.MapEntityToModel(records);
		}

		public virtual async Task<ApiStudentServerResponseModel> Get(int id)
		{
			Student record = await this.StudentRepository.Get(id);

			if (record == null)
			{
				return null;
			}
			else
			{
				return this.DalStudentMapper.MapEntityToModel(record);
			}
		}

		public virtual async Task<CreateResponse<ApiStudentServerResponseModel>> Create(
			ApiStudentServerRequestModel model)
		{
			CreateResponse<ApiStudentServerResponseModel> response = ValidationResponseFactory<ApiStudentServerResponseModel>.CreateResponse(await this.StudentModelValidator.ValidateCreateAsync(model));

			if (response.Success)
			{
				Student record = this.DalStudentMapper.MapModelToEntity(default(int), model);
				record = await this.StudentRepository.Create(record);

				response.SetRecord(this.DalStudentMapper.MapEntityToModel(record));
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
				Student record = this.DalStudentMapper.MapModelToEntity(id, model);
				await this.StudentRepository.Update(record);

				record = await this.StudentRepository.Get(id);

				ApiStudentServerResponseModel apiModel = this.DalStudentMapper.MapEntityToModel(record);
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
	}
}

/*<Codenesium>
    <Hash>b0df32e6bc071a0ab0eeec9f179f9bdb</Hash>
</Codenesium>*/