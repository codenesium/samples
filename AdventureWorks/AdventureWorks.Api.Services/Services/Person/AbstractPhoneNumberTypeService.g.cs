using AdventureWorksNS.Api.Contracts;
using AdventureWorksNS.Api.DataAccess;
using MediatR;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace AdventureWorksNS.Api.Services
{
	public abstract class AbstractPhoneNumberTypeService : AbstractService
	{
		private IMediator mediator;

		protected IPhoneNumberTypeRepository PhoneNumberTypeRepository { get; private set; }

		protected IApiPhoneNumberTypeServerRequestModelValidator PhoneNumberTypeModelValidator { get; private set; }

		protected IDALPhoneNumberTypeMapper DalPhoneNumberTypeMapper { get; private set; }

		private ILogger logger;

		public AbstractPhoneNumberTypeService(
			ILogger logger,
			IMediator mediator,
			IPhoneNumberTypeRepository phoneNumberTypeRepository,
			IApiPhoneNumberTypeServerRequestModelValidator phoneNumberTypeModelValidator,
			IDALPhoneNumberTypeMapper dalPhoneNumberTypeMapper)
			: base()
		{
			this.PhoneNumberTypeRepository = phoneNumberTypeRepository;
			this.PhoneNumberTypeModelValidator = phoneNumberTypeModelValidator;
			this.DalPhoneNumberTypeMapper = dalPhoneNumberTypeMapper;
			this.logger = logger;

			this.mediator = mediator;
		}

		public virtual async Task<List<ApiPhoneNumberTypeServerResponseModel>> All(int limit = 0, int offset = int.MaxValue, string query = "")
		{
			var records = await this.PhoneNumberTypeRepository.All(limit, offset, query);

			return this.DalPhoneNumberTypeMapper.MapBOToModel(records);
		}

		public virtual async Task<ApiPhoneNumberTypeServerResponseModel> Get(int phoneNumberTypeID)
		{
			var record = await this.PhoneNumberTypeRepository.Get(phoneNumberTypeID);

			if (record == null)
			{
				return null;
			}
			else
			{
				return this.DalPhoneNumberTypeMapper.MapBOToModel(record);
			}
		}

		public virtual async Task<CreateResponse<ApiPhoneNumberTypeServerResponseModel>> Create(
			ApiPhoneNumberTypeServerRequestModel model)
		{
			CreateResponse<ApiPhoneNumberTypeServerResponseModel> response = ValidationResponseFactory<ApiPhoneNumberTypeServerResponseModel>.CreateResponse(await this.PhoneNumberTypeModelValidator.ValidateCreateAsync(model));

			if (response.Success)
			{
				var bo = this.DalPhoneNumberTypeMapper.MapModelToBO(default(int), model);
				var record = await this.PhoneNumberTypeRepository.Create(bo);

				response.SetRecord(this.DalPhoneNumberTypeMapper.MapBOToModel(record));
				await this.mediator.Publish(new PhoneNumberTypeCreatedNotification(response.Record));
			}

			return response;
		}

		public virtual async Task<UpdateResponse<ApiPhoneNumberTypeServerResponseModel>> Update(
			int phoneNumberTypeID,
			ApiPhoneNumberTypeServerRequestModel model)
		{
			var validationResult = await this.PhoneNumberTypeModelValidator.ValidateUpdateAsync(phoneNumberTypeID, model);

			if (validationResult.IsValid)
			{
				var bo = this.DalPhoneNumberTypeMapper.MapModelToBO(phoneNumberTypeID, model);
				await this.PhoneNumberTypeRepository.Update(bo);

				var record = await this.PhoneNumberTypeRepository.Get(phoneNumberTypeID);

				var apiModel = this.DalPhoneNumberTypeMapper.MapBOToModel(record);
				await this.mediator.Publish(new PhoneNumberTypeUpdatedNotification(apiModel));

				return ValidationResponseFactory<ApiPhoneNumberTypeServerResponseModel>.UpdateResponse(apiModel);
			}
			else
			{
				return ValidationResponseFactory<ApiPhoneNumberTypeServerResponseModel>.UpdateResponse(validationResult);
			}
		}

		public virtual async Task<ActionResponse> Delete(
			int phoneNumberTypeID)
		{
			ActionResponse response = ValidationResponseFactory<object>.ActionResponse(await this.PhoneNumberTypeModelValidator.ValidateDeleteAsync(phoneNumberTypeID));

			if (response.Success)
			{
				await this.PhoneNumberTypeRepository.Delete(phoneNumberTypeID);

				await this.mediator.Publish(new PhoneNumberTypeDeletedNotification(phoneNumberTypeID));
			}

			return response;
		}
	}
}

/*<Codenesium>
    <Hash>b511b95ce85eead2d830a76386d7bea3</Hash>
</Codenesium>*/