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

		protected IBOLPersonMapper BolPersonMapper { get; private set; }

		protected IDALPersonMapper DalPersonMapper { get; private set; }

		protected IBOLPasswordMapper BolPasswordMapper { get; private set; }

		protected IDALPasswordMapper DalPasswordMapper { get; private set; }

		private ILogger logger;

		public AbstractPersonService(
			ILogger logger,
			IMediator mediator,
			IPersonRepository personRepository,
			IApiPersonServerRequestModelValidator personModelValidator,
			IBOLPersonMapper bolPersonMapper,
			IDALPersonMapper dalPersonMapper,
			IBOLPasswordMapper bolPasswordMapper,
			IDALPasswordMapper dalPasswordMapper)
			: base()
		{
			this.PersonRepository = personRepository;
			this.PersonModelValidator = personModelValidator;
			this.BolPersonMapper = bolPersonMapper;
			this.DalPersonMapper = dalPersonMapper;
			this.BolPasswordMapper = bolPasswordMapper;
			this.DalPasswordMapper = dalPasswordMapper;
			this.logger = logger;

			this.mediator = mediator;
		}

		public virtual async Task<List<ApiPersonServerResponseModel>> All(int limit = 0, int offset = int.MaxValue)
		{
			var records = await this.PersonRepository.All(limit, offset);

			return this.BolPersonMapper.MapBOToModel(this.DalPersonMapper.MapEFToBO(records));
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
				return this.BolPersonMapper.MapBOToModel(this.DalPersonMapper.MapEFToBO(record));
			}
		}

		public virtual async Task<CreateResponse<ApiPersonServerResponseModel>> Create(
			ApiPersonServerRequestModel model)
		{
			CreateResponse<ApiPersonServerResponseModel> response = ValidationResponseFactory<ApiPersonServerResponseModel>.CreateResponse(await this.PersonModelValidator.ValidateCreateAsync(model));

			if (response.Success)
			{
				var bo = this.BolPersonMapper.MapModelToBO(default(int), model);
				var record = await this.PersonRepository.Create(this.DalPersonMapper.MapBOToEF(bo));

				var businessObject = this.DalPersonMapper.MapEFToBO(record);
				response.SetRecord(this.BolPersonMapper.MapBOToModel(businessObject));
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
				var bo = this.BolPersonMapper.MapModelToBO(businessEntityID, model);
				await this.PersonRepository.Update(this.DalPersonMapper.MapBOToEF(bo));

				var record = await this.PersonRepository.Get(businessEntityID);

				var businessObject = this.DalPersonMapper.MapEFToBO(record);
				var apiModel = this.BolPersonMapper.MapBOToModel(businessObject);
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
				return this.BolPersonMapper.MapBOToModel(this.DalPersonMapper.MapEFToBO(record));
			}
		}

		public async virtual Task<List<ApiPersonServerResponseModel>> ByLastNameFirstNameMiddleName(string lastName, string firstName, string middleName, int limit = 0, int offset = int.MaxValue)
		{
			List<Person> records = await this.PersonRepository.ByLastNameFirstNameMiddleName(lastName, firstName, middleName, limit, offset);

			return this.BolPersonMapper.MapBOToModel(this.DalPersonMapper.MapEFToBO(records));
		}

		public async virtual Task<List<ApiPersonServerResponseModel>> ByAdditionalContactInfo(string additionalContactInfo, int limit = 0, int offset = int.MaxValue)
		{
			List<Person> records = await this.PersonRepository.ByAdditionalContactInfo(additionalContactInfo, limit, offset);

			return this.BolPersonMapper.MapBOToModel(this.DalPersonMapper.MapEFToBO(records));
		}

		public async virtual Task<List<ApiPersonServerResponseModel>> ByDemographic(string demographic, int limit = 0, int offset = int.MaxValue)
		{
			List<Person> records = await this.PersonRepository.ByDemographic(demographic, limit, offset);

			return this.BolPersonMapper.MapBOToModel(this.DalPersonMapper.MapEFToBO(records));
		}

		public async virtual Task<List<ApiPasswordServerResponseModel>> PasswordsByBusinessEntityID(int businessEntityID, int limit = int.MaxValue, int offset = 0)
		{
			List<Password> records = await this.PersonRepository.PasswordsByBusinessEntityID(businessEntityID, limit, offset);

			return this.BolPasswordMapper.MapBOToModel(this.DalPasswordMapper.MapEFToBO(records));
		}
	}
}

/*<Codenesium>
    <Hash>521d8ab653c732697cc0fcf0f46e2b45</Hash>
</Codenesium>*/