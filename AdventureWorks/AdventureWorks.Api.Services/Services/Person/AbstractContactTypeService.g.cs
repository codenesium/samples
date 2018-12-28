using AdventureWorksNS.Api.Contracts;
using AdventureWorksNS.Api.DataAccess;
using MediatR;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace AdventureWorksNS.Api.Services
{
	public abstract class AbstractContactTypeService : AbstractService
	{
		private IMediator mediator;

		protected IContactTypeRepository ContactTypeRepository { get; private set; }

		protected IApiContactTypeServerRequestModelValidator ContactTypeModelValidator { get; private set; }

		protected IBOLContactTypeMapper BolContactTypeMapper { get; private set; }

		protected IDALContactTypeMapper DalContactTypeMapper { get; private set; }

		private ILogger logger;

		public AbstractContactTypeService(
			ILogger logger,
			IMediator mediator,
			IContactTypeRepository contactTypeRepository,
			IApiContactTypeServerRequestModelValidator contactTypeModelValidator,
			IBOLContactTypeMapper bolContactTypeMapper,
			IDALContactTypeMapper dalContactTypeMapper)
			: base()
		{
			this.ContactTypeRepository = contactTypeRepository;
			this.ContactTypeModelValidator = contactTypeModelValidator;
			this.BolContactTypeMapper = bolContactTypeMapper;
			this.DalContactTypeMapper = dalContactTypeMapper;
			this.logger = logger;

			this.mediator = mediator;
		}

		public virtual async Task<List<ApiContactTypeServerResponseModel>> All(int limit = 0, int offset = int.MaxValue)
		{
			var records = await this.ContactTypeRepository.All(limit, offset);

			return this.BolContactTypeMapper.MapBOToModel(this.DalContactTypeMapper.MapEFToBO(records));
		}

		public virtual async Task<ApiContactTypeServerResponseModel> Get(int contactTypeID)
		{
			var record = await this.ContactTypeRepository.Get(contactTypeID);

			if (record == null)
			{
				return null;
			}
			else
			{
				return this.BolContactTypeMapper.MapBOToModel(this.DalContactTypeMapper.MapEFToBO(record));
			}
		}

		public virtual async Task<CreateResponse<ApiContactTypeServerResponseModel>> Create(
			ApiContactTypeServerRequestModel model)
		{
			CreateResponse<ApiContactTypeServerResponseModel> response = ValidationResponseFactory<ApiContactTypeServerResponseModel>.CreateResponse(await this.ContactTypeModelValidator.ValidateCreateAsync(model));

			if (response.Success)
			{
				var bo = this.BolContactTypeMapper.MapModelToBO(default(int), model);
				var record = await this.ContactTypeRepository.Create(this.DalContactTypeMapper.MapBOToEF(bo));

				var businessObject = this.DalContactTypeMapper.MapEFToBO(record);
				response.SetRecord(this.BolContactTypeMapper.MapBOToModel(businessObject));
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
				var bo = this.BolContactTypeMapper.MapModelToBO(contactTypeID, model);
				await this.ContactTypeRepository.Update(this.DalContactTypeMapper.MapBOToEF(bo));

				var record = await this.ContactTypeRepository.Get(contactTypeID);

				var businessObject = this.DalContactTypeMapper.MapEFToBO(record);
				var apiModel = this.BolContactTypeMapper.MapBOToModel(businessObject);
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
				return this.BolContactTypeMapper.MapBOToModel(this.DalContactTypeMapper.MapEFToBO(record));
			}
		}
	}
}

/*<Codenesium>
    <Hash>f8dc43898ea8ce1eeed97d2b8ecd2ca8</Hash>
</Codenesium>*/