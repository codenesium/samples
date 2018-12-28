using AdventureWorksNS.Api.Contracts;
using AdventureWorksNS.Api.DataAccess;
using MediatR;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace AdventureWorksNS.Api.Services
{
	public abstract class AbstractDepartmentService : AbstractService
	{
		private IMediator mediator;

		protected IDepartmentRepository DepartmentRepository { get; private set; }

		protected IApiDepartmentServerRequestModelValidator DepartmentModelValidator { get; private set; }

		protected IBOLDepartmentMapper BolDepartmentMapper { get; private set; }

		protected IDALDepartmentMapper DalDepartmentMapper { get; private set; }

		private ILogger logger;

		public AbstractDepartmentService(
			ILogger logger,
			IMediator mediator,
			IDepartmentRepository departmentRepository,
			IApiDepartmentServerRequestModelValidator departmentModelValidator,
			IBOLDepartmentMapper bolDepartmentMapper,
			IDALDepartmentMapper dalDepartmentMapper)
			: base()
		{
			this.DepartmentRepository = departmentRepository;
			this.DepartmentModelValidator = departmentModelValidator;
			this.BolDepartmentMapper = bolDepartmentMapper;
			this.DalDepartmentMapper = dalDepartmentMapper;
			this.logger = logger;

			this.mediator = mediator;
		}

		public virtual async Task<List<ApiDepartmentServerResponseModel>> All(int limit = 0, int offset = int.MaxValue)
		{
			var records = await this.DepartmentRepository.All(limit, offset);

			return this.BolDepartmentMapper.MapBOToModel(this.DalDepartmentMapper.MapEFToBO(records));
		}

		public virtual async Task<ApiDepartmentServerResponseModel> Get(short departmentID)
		{
			var record = await this.DepartmentRepository.Get(departmentID);

			if (record == null)
			{
				return null;
			}
			else
			{
				return this.BolDepartmentMapper.MapBOToModel(this.DalDepartmentMapper.MapEFToBO(record));
			}
		}

		public virtual async Task<CreateResponse<ApiDepartmentServerResponseModel>> Create(
			ApiDepartmentServerRequestModel model)
		{
			CreateResponse<ApiDepartmentServerResponseModel> response = ValidationResponseFactory<ApiDepartmentServerResponseModel>.CreateResponse(await this.DepartmentModelValidator.ValidateCreateAsync(model));

			if (response.Success)
			{
				var bo = this.BolDepartmentMapper.MapModelToBO(default(short), model);
				var record = await this.DepartmentRepository.Create(this.DalDepartmentMapper.MapBOToEF(bo));

				var businessObject = this.DalDepartmentMapper.MapEFToBO(record);
				response.SetRecord(this.BolDepartmentMapper.MapBOToModel(businessObject));
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
				var bo = this.BolDepartmentMapper.MapModelToBO(departmentID, model);
				await this.DepartmentRepository.Update(this.DalDepartmentMapper.MapBOToEF(bo));

				var record = await this.DepartmentRepository.Get(departmentID);

				var businessObject = this.DalDepartmentMapper.MapEFToBO(record);
				var apiModel = this.BolDepartmentMapper.MapBOToModel(businessObject);
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
				return this.BolDepartmentMapper.MapBOToModel(this.DalDepartmentMapper.MapEFToBO(record));
			}
		}
	}
}

/*<Codenesium>
    <Hash>899b859da4622d6f9e5a95edf332cfa0</Hash>
</Codenesium>*/