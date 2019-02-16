using AdventureWorksNS.Api.Contracts;
using AdventureWorksNS.Api.DataAccess;
using MediatR;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace AdventureWorksNS.Api.Services
{
	public abstract class AbstractPersonService : AbstractService
	{
		private IMediator mediator;

		protected IPersonRepository PersonRepository { get; private set; }

		protected IApiPersonServerRequestModelValidator PersonModelValidator { get; private set; }

		protected IDALPersonMapper DalPersonMapper { get; private set; }

		protected IDALPasswordMapper DalPasswordMapper { get; private set; }

		private ILogger logger;

		public AbstractPersonService(
			ILogger logger,
			IMediator mediator,
			IPersonRepository personRepository,
			IApiPersonServerRequestModelValidator personModelValidator,
			IDALPersonMapper dalPersonMapper,
			IDALPasswordMapper dalPasswordMapper)
			: base()
		{
			this.PersonRepository = personRepository;
			this.PersonModelValidator = personModelValidator;
			this.DalPersonMapper = dalPersonMapper;
			this.DalPasswordMapper = dalPasswordMapper;
			this.logger = logger;

			this.mediator = mediator;
		}

		public virtual async Task<List<ApiPersonServerResponseModel>> All(int limit = 0, int offset = int.MaxValue, string query = "")
		{
			var records = await this.PersonRepository.All(limit, offset, query);

			return this.DalPersonMapper.MapBOToModel(records);
		}

		public virtual async Task<ApiPersonServerResponseModel> Get(int businessEntityID)
		{
			var record = await this.PersonRepository.Get(businessEntityID);

			if (record == null)
			{
				return null;
			}
			else
			{
				return this.DalPersonMapper.MapBOToModel(record);
			}
		}

		public virtual async Task<CreateResponse<ApiPersonServerResponseModel>> Create(
			ApiPersonServerRequestModel model)
		{
			CreateResponse<ApiPersonServerResponseModel> response = ValidationResponseFactory<ApiPersonServerResponseModel>.CreateResponse(await this.PersonModelValidator.ValidateCreateAsync(model));

			if (response.Success)
			{
				var bo = this.DalPersonMapper.MapModelToBO(default(int), model);
				var record = await this.PersonRepository.Create(bo);

				response.SetRecord(this.DalPersonMapper.MapBOToModel(record));
				await this.mediator.Publish(new PersonCreatedNotification(response.Record));
			}

			return response;
		}

		public virtual async Task<UpdateResponse<ApiPersonServerResponseModel>> Update(
			int businessEntityID,
			ApiPersonServerRequestModel model)
		{
			var validationResult = await this.PersonModelValidator.ValidateUpdateAsync(businessEntityID, model);

			if (validationResult.IsValid)
			{
				var bo = this.DalPersonMapper.MapModelToBO(businessEntityID, model);
				await this.PersonRepository.Update(bo);

				var record = await this.PersonRepository.Get(businessEntityID);

				var apiModel = this.DalPersonMapper.MapBOToModel(record);
				await this.mediator.Publish(new PersonUpdatedNotification(apiModel));

				return ValidationResponseFactory<ApiPersonServerResponseModel>.UpdateResponse(apiModel);
			}
			else
			{
				return ValidationResponseFactory<ApiPersonServerResponseModel>.UpdateResponse(validationResult);
			}
		}

		public virtual async Task<ActionResponse> Delete(
			int businessEntityID)
		{
			ActionResponse response = ValidationResponseFactory<object>.ActionResponse(await this.PersonModelValidator.ValidateDeleteAsync(businessEntityID));

			if (response.Success)
			{
				await this.PersonRepository.Delete(businessEntityID);

				await this.mediator.Publish(new PersonDeletedNotification(businessEntityID));
			}

			return response;
		}

		public async virtual Task<ApiPersonServerResponseModel> ByRowguid(Guid rowguid)
		{
			Person record = await this.PersonRepository.ByRowguid(rowguid);

			if (record == null)
			{
				return null;
			}
			else
			{
				return this.DalPersonMapper.MapBOToModel(record);
			}
		}

		public async virtual Task<List<ApiPersonServerResponseModel>> ByLastNameFirstNameMiddleName(string lastName, string firstName, string middleName, int limit = 0, int offset = int.MaxValue)
		{
			List<Person> records = await this.PersonRepository.ByLastNameFirstNameMiddleName(lastName, firstName, middleName, limit, offset);

			return this.DalPersonMapper.MapBOToModel(records);
		}

		public async virtual Task<List<ApiPersonServerResponseModel>> ByAdditionalContactInfo(string additionalContactInfo, int limit = 0, int offset = int.MaxValue)
		{
			List<Person> records = await this.PersonRepository.ByAdditionalContactInfo(additionalContactInfo, limit, offset);

			return this.DalPersonMapper.MapBOToModel(records);
		}

		public async virtual Task<List<ApiPersonServerResponseModel>> ByDemographic(string demographic, int limit = 0, int offset = int.MaxValue)
		{
			List<Person> records = await this.PersonRepository.ByDemographic(demographic, limit, offset);

			return this.DalPersonMapper.MapBOToModel(records);
		}

		public async virtual Task<List<ApiPasswordServerResponseModel>> PasswordsByBusinessEntityID(int businessEntityID, int limit = int.MaxValue, int offset = 0)
		{
			List<Password> records = await this.PersonRepository.PasswordsByBusinessEntityID(businessEntityID, limit, offset);

			return this.DalPasswordMapper.MapBOToModel(records);
		}
	}
}

/*<Codenesium>
    <Hash>ba7046e28b5125d2f9edc27b67de0660</Hash>
</Codenesium>*/