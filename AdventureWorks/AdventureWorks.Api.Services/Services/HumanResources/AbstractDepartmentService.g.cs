using AdventureWorksNS.Api.Contracts;
using AdventureWorksNS.Api.DataAccess;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace AdventureWorksNS.Api.Services
{
	public abstract class AbstractDepartmentService : AbstractService
	{
		private MediatR.IMediator mediator;

		protected IDepartmentRepository DepartmentRepository { get; private set; }

		protected IApiDepartmentServerRequestModelValidator DepartmentModelValidator { get; private set; }

		protected IDALDepartmentMapper DalDepartmentMapper { get; private set; }

		private ILogger logger;

		public AbstractDepartmentService(
			ILogger logger,
			MediatR.IMediator mediator,
			IDepartmentRepository departmentRepository,
			IApiDepartmentServerRequestModelValidator departmentModelValidator,
			IDALDepartmentMapper dalDepartmentMapper)
			: base()
		{
			this.DepartmentRepository = departmentRepository;
			this.DepartmentModelValidator = departmentModelValidator;
			this.DalDepartmentMapper = dalDepartmentMapper;
			this.logger = logger;

			this.mediator = mediator;
		}

		public virtual async Task<List<ApiDepartmentServerResponseModel>> All(int limit = 0, int offset = int.MaxValue, string query = "")
		{
			List<Department> records = await this.DepartmentRepository.All(limit, offset, query);

			return this.DalDepartmentMapper.MapEntityToModel(records);
		}

		public virtual async Task<ApiDepartmentServerResponseModel> Get(short departmentID)
		{
			Department record = await this.DepartmentRepository.Get(departmentID);

			if (record == null)
			{
				return null;
			}
			else
			{
				return this.DalDepartmentMapper.MapEntityToModel(record);
			}
		}

		public virtual async Task<CreateResponse<ApiDepartmentServerResponseModel>> Create(
			ApiDepartmentServerRequestModel model)
		{
			CreateResponse<ApiDepartmentServerResponseModel> response = ValidationResponseFactory<ApiDepartmentServerResponseModel>.CreateResponse(await this.DepartmentModelValidator.ValidateCreateAsync(model));

			if (response.Success)
			{
				Department record = this.DalDepartmentMapper.MapModelToEntity(default(short), model);
				record = await this.DepartmentRepository.Create(record);

				response.SetRecord(this.DalDepartmentMapper.MapEntityToModel(record));
				await this.mediator.Publish(new DepartmentCreatedNotification(response.Record));
			}

			return response;
		}

		public virtual async Task<UpdateResponse<ApiDepartmentServerResponseModel>> Update(
			short departmentID,
			ApiDepartmentServerRequestModel model)
		{
			var validationResult = await this.DepartmentModelValidator.ValidateUpdateAsync(departmentID, model);

			if (validationResult.IsValid)
			{
				Department record = this.DalDepartmentMapper.MapModelToEntity(departmentID, model);
				await this.DepartmentRepository.Update(record);

				record = await this.DepartmentRepository.Get(departmentID);

				ApiDepartmentServerResponseModel apiModel = this.DalDepartmentMapper.MapEntityToModel(record);
				await this.mediator.Publish(new DepartmentUpdatedNotification(apiModel));

				return ValidationResponseFactory<ApiDepartmentServerResponseModel>.UpdateResponse(apiModel);
			}
			else
			{
				return ValidationResponseFactory<ApiDepartmentServerResponseModel>.UpdateResponse(validationResult);
			}
		}

		public virtual async Task<ActionResponse> Delete(
			short departmentID)
		{
			ActionResponse response = ValidationResponseFactory<object>.ActionResponse(await this.DepartmentModelValidator.ValidateDeleteAsync(departmentID));

			if (response.Success)
			{
				await this.DepartmentRepository.Delete(departmentID);

				await this.mediator.Publish(new DepartmentDeletedNotification(departmentID));
			}

			return response;
		}

		public async virtual Task<ApiDepartmentServerResponseModel> ByName(string name)
		{
			Department record = await this.DepartmentRepository.ByName(name);

			if (record == null)
			{
				return null;
			}
			else
			{
				return this.DalDepartmentMapper.MapEntityToModel(record);
			}
		}
	}
}

/*<Codenesium>
    <Hash>1864d35e91cb4f824d0b88c188113b57</Hash>
</Codenesium>*/