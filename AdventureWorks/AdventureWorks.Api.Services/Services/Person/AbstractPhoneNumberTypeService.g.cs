using AdventureWorksNS.Api.Contracts;
using AdventureWorksNS.Api.DataAccess;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace AdventureWorksNS.Api.Services
{
	public abstract class AbstractPhoneNumberTypeService : AbstractService
	{
		private MediatR.IMediator mediator;

		protected IPhoneNumberTypeRepository PhoneNumberTypeRepository { get; private set; }

		protected IApiPhoneNumberTypeServerRequestModelValidator PhoneNumberTypeModelValidator { get; private set; }

		protected IDALPhoneNumberTypeMapper DalPhoneNumberTypeMapper { get; private set; }

		private ILogger logger;

		public AbstractPhoneNumberTypeService(
			ILogger logger,
			MediatR.IMediator mediator,
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
			List<PhoneNumberType> records = await this.PhoneNumberTypeRepository.All(limit, offset, query);

			return this.DalPhoneNumberTypeMapper.MapEntityToModel(records);
		}

		public virtual async Task<ApiPhoneNumberTypeServerResponseModel> Get(int phoneNumberTypeID)
		{
			PhoneNumberType record = await this.PhoneNumberTypeRepository.Get(phoneNumberTypeID);

			if (record == null)
			{
				return null;
			}
			else
			{
				return this.DalPhoneNumberTypeMapper.MapEntityToModel(record);
			}
		}

		public virtual async Task<CreateResponse<ApiPhoneNumberTypeServerResponseModel>> Create(
			ApiPhoneNumberTypeServerRequestModel model)
		{
			CreateResponse<ApiPhoneNumberTypeServerResponseModel> response = ValidationResponseFactory<ApiPhoneNumberTypeServerResponseModel>.CreateResponse(await this.PhoneNumberTypeModelValidator.ValidateCreateAsync(model));

			if (response.Success)
			{
				PhoneNumberType record = this.DalPhoneNumberTypeMapper.MapModelToEntity(default(int), model);
				record = await this.PhoneNumberTypeRepository.Create(record);

				response.SetRecord(this.DalPhoneNumberTypeMapper.MapEntityToModel(record));
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
				PhoneNumberType record = this.DalPhoneNumberTypeMapper.MapModelToEntity(phoneNumberTypeID, model);
				await this.PhoneNumberTypeRepository.Update(record);

				record = await this.PhoneNumberTypeRepository.Get(phoneNumberTypeID);

				ApiPhoneNumberTypeServerResponseModel apiModel = this.DalPhoneNumberTypeMapper.MapEntityToModel(record);
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
    <Hash>1805c0bf5a829e15df2fcf2eb47da92d</Hash>
</Codenesium>*/