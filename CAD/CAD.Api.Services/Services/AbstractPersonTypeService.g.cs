using CADNS.Api.Contracts;
using CADNS.Api.DataAccess;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace CADNS.Api.Services
{
	public abstract class AbstractPersonTypeService : AbstractService
	{
		private MediatR.IMediator mediator;

		protected IPersonTypeRepository PersonTypeRepository { get; private set; }

		protected IApiPersonTypeServerRequestModelValidator PersonTypeModelValidator { get; private set; }

		protected IDALPersonTypeMapper DalPersonTypeMapper { get; private set; }

		protected IDALCallPersonMapper DalCallPersonMapper { get; private set; }

		private ILogger logger;

		public AbstractPersonTypeService(
			ILogger logger,
			MediatR.IMediator mediator,
			IPersonTypeRepository personTypeRepository,
			IApiPersonTypeServerRequestModelValidator personTypeModelValidator,
			IDALPersonTypeMapper dalPersonTypeMapper,
			IDALCallPersonMapper dalCallPersonMapper)
			: base()
		{
			this.PersonTypeRepository = personTypeRepository;
			this.PersonTypeModelValidator = personTypeModelValidator;
			this.DalPersonTypeMapper = dalPersonTypeMapper;
			this.DalCallPersonMapper = dalCallPersonMapper;
			this.logger = logger;

			this.mediator = mediator;
		}

		public virtual async Task<List<ApiPersonTypeServerResponseModel>> All(int limit = 0, int offset = int.MaxValue, string query = "")
		{
			List<PersonType> records = await this.PersonTypeRepository.All(limit, offset, query);

			return this.DalPersonTypeMapper.MapEntityToModel(records);
		}

		public virtual async Task<ApiPersonTypeServerResponseModel> Get(int id)
		{
			PersonType record = await this.PersonTypeRepository.Get(id);

			if (record == null)
			{
				return null;
			}
			else
			{
				return this.DalPersonTypeMapper.MapEntityToModel(record);
			}
		}

		public virtual async Task<CreateResponse<ApiPersonTypeServerResponseModel>> Create(
			ApiPersonTypeServerRequestModel model)
		{
			CreateResponse<ApiPersonTypeServerResponseModel> response = ValidationResponseFactory<ApiPersonTypeServerResponseModel>.CreateResponse(await this.PersonTypeModelValidator.ValidateCreateAsync(model));

			if (response.Success)
			{
				PersonType record = this.DalPersonTypeMapper.MapModelToEntity(default(int), model);
				record = await this.PersonTypeRepository.Create(record);

				response.SetRecord(this.DalPersonTypeMapper.MapEntityToModel(record));
				await this.mediator.Publish(new PersonTypeCreatedNotification(response.Record));
			}

			return response;
		}

		public virtual async Task<UpdateResponse<ApiPersonTypeServerResponseModel>> Update(
			int id,
			ApiPersonTypeServerRequestModel model)
		{
			var validationResult = await this.PersonTypeModelValidator.ValidateUpdateAsync(id, model);

			if (validationResult.IsValid)
			{
				PersonType record = this.DalPersonTypeMapper.MapModelToEntity(id, model);
				await this.PersonTypeRepository.Update(record);

				record = await this.PersonTypeRepository.Get(id);

				ApiPersonTypeServerResponseModel apiModel = this.DalPersonTypeMapper.MapEntityToModel(record);
				await this.mediator.Publish(new PersonTypeUpdatedNotification(apiModel));

				return ValidationResponseFactory<ApiPersonTypeServerResponseModel>.UpdateResponse(apiModel);
			}
			else
			{
				return ValidationResponseFactory<ApiPersonTypeServerResponseModel>.UpdateResponse(validationResult);
			}
		}

		public virtual async Task<ActionResponse> Delete(
			int id)
		{
			ActionResponse response = ValidationResponseFactory<object>.ActionResponse(await this.PersonTypeModelValidator.ValidateDeleteAsync(id));

			if (response.Success)
			{
				await this.PersonTypeRepository.Delete(id);

				await this.mediator.Publish(new PersonTypeDeletedNotification(id));
			}

			return response;
		}

		public async virtual Task<List<ApiCallPersonServerResponseModel>> CallPersonsByPersonTypeId(int personTypeId, int limit = int.MaxValue, int offset = 0)
		{
			List<CallPerson> records = await this.PersonTypeRepository.CallPersonsByPersonTypeId(personTypeId, limit, offset);

			return this.DalCallPersonMapper.MapEntityToModel(records);
		}
	}
}

/*<Codenesium>
    <Hash>a524e083ebef6a77e0ba77461d934797</Hash>
</Codenesium>*/