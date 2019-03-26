using AdventureWorksNS.Api.Contracts;
using AdventureWorksNS.Api.DataAccess;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace AdventureWorksNS.Api.Services
{
	public abstract class AbstractContactTypeService : AbstractService
	{
		private MediatR.IMediator mediator;

		protected IContactTypeRepository ContactTypeRepository { get; private set; }

		protected IApiContactTypeServerRequestModelValidator ContactTypeModelValidator { get; private set; }

		protected IDALContactTypeMapper DalContactTypeMapper { get; private set; }

		private ILogger logger;

		public AbstractContactTypeService(
			ILogger logger,
			MediatR.IMediator mediator,
			IContactTypeRepository contactTypeRepository,
			IApiContactTypeServerRequestModelValidator contactTypeModelValidator,
			IDALContactTypeMapper dalContactTypeMapper)
			: base()
		{
			this.ContactTypeRepository = contactTypeRepository;
			this.ContactTypeModelValidator = contactTypeModelValidator;
			this.DalContactTypeMapper = dalContactTypeMapper;
			this.logger = logger;

			this.mediator = mediator;
		}

		public virtual async Task<List<ApiContactTypeServerResponseModel>> All(int limit = 0, int offset = int.MaxValue, string query = "")
		{
			List<ContactType> records = await this.ContactTypeRepository.All(limit, offset, query);

			return this.DalContactTypeMapper.MapEntityToModel(records);
		}

		public virtual async Task<ApiContactTypeServerResponseModel> Get(int contactTypeID)
		{
			ContactType record = await this.ContactTypeRepository.Get(contactTypeID);

			if (record == null)
			{
				return null;
			}
			else
			{
				return this.DalContactTypeMapper.MapEntityToModel(record);
			}
		}

		public virtual async Task<CreateResponse<ApiContactTypeServerResponseModel>> Create(
			ApiContactTypeServerRequestModel model)
		{
			CreateResponse<ApiContactTypeServerResponseModel> response = ValidationResponseFactory<ApiContactTypeServerResponseModel>.CreateResponse(await this.ContactTypeModelValidator.ValidateCreateAsync(model));

			if (response.Success)
			{
				ContactType record = this.DalContactTypeMapper.MapModelToEntity(default(int), model);
				record = await this.ContactTypeRepository.Create(record);

				response.SetRecord(this.DalContactTypeMapper.MapEntityToModel(record));
				await this.mediator.Publish(new ContactTypeCreatedNotification(response.Record));
			}

			return response;
		}

		public virtual async Task<UpdateResponse<ApiContactTypeServerResponseModel>> Update(
			int contactTypeID,
			ApiContactTypeServerRequestModel model)
		{
			var validationResult = await this.ContactTypeModelValidator.ValidateUpdateAsync(contactTypeID, model);

			if (validationResult.IsValid)
			{
				ContactType record = this.DalContactTypeMapper.MapModelToEntity(contactTypeID, model);
				await this.ContactTypeRepository.Update(record);

				record = await this.ContactTypeRepository.Get(contactTypeID);

				ApiContactTypeServerResponseModel apiModel = this.DalContactTypeMapper.MapEntityToModel(record);
				await this.mediator.Publish(new ContactTypeUpdatedNotification(apiModel));

				return ValidationResponseFactory<ApiContactTypeServerResponseModel>.UpdateResponse(apiModel);
			}
			else
			{
				return ValidationResponseFactory<ApiContactTypeServerResponseModel>.UpdateResponse(validationResult);
			}
		}

		public virtual async Task<ActionResponse> Delete(
			int contactTypeID)
		{
			ActionResponse response = ValidationResponseFactory<object>.ActionResponse(await this.ContactTypeModelValidator.ValidateDeleteAsync(contactTypeID));

			if (response.Success)
			{
				await this.ContactTypeRepository.Delete(contactTypeID);

				await this.mediator.Publish(new ContactTypeDeletedNotification(contactTypeID));
			}

			return response;
		}

		public async virtual Task<ApiContactTypeServerResponseModel> ByName(string name)
		{
			ContactType record = await this.ContactTypeRepository.ByName(name);

			if (record == null)
			{
				return null;
			}
			else
			{
				return this.DalContactTypeMapper.MapEntityToModel(record);
			}
		}
	}
}

/*<Codenesium>
    <Hash>2b48db78045196f47c85d8504bb6dd96</Hash>
</Codenesium>*/