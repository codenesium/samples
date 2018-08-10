using AdventureWorksNS.Api.Contracts;
using AdventureWorksNS.Api.DataAccess;
using Codenesium.DataConversionExtensions;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Dynamic.Core;
using System.Linq.Expressions;
using System.Threading.Tasks;

namespace AdventureWorksNS.Api.Services
{
	public abstract class AbstractPersonService : AbstractService
	{
		protected IPersonRepository PersonRepository { get; private set; }

		protected IApiPersonRequestModelValidator PersonModelValidator { get; private set; }

		protected IBOLPersonMapper BolPersonMapper { get; private set; }

		protected IDALPersonMapper DalPersonMapper { get; private set; }

		protected IBOLBusinessEntityContactMapper BolBusinessEntityContactMapper { get; private set; }

		protected IDALBusinessEntityContactMapper DalBusinessEntityContactMapper { get; private set; }
		protected IBOLEmailAddressMapper BolEmailAddressMapper { get; private set; }

		protected IDALEmailAddressMapper DalEmailAddressMapper { get; private set; }
		protected IBOLPasswordMapper BolPasswordMapper { get; private set; }

		protected IDALPasswordMapper DalPasswordMapper { get; private set; }
		protected IBOLPersonPhoneMapper BolPersonPhoneMapper { get; private set; }

		protected IDALPersonPhoneMapper DalPersonPhoneMapper { get; private set; }

		private ILogger logger;

		public AbstractPersonService(
			ILogger logger,
			IPersonRepository personRepository,
			IApiPersonRequestModelValidator personModelValidator,
			IBOLPersonMapper bolPersonMapper,
			IDALPersonMapper dalPersonMapper,
			IBOLBusinessEntityContactMapper bolBusinessEntityContactMapper,
			IDALBusinessEntityContactMapper dalBusinessEntityContactMapper,
			IBOLEmailAddressMapper bolEmailAddressMapper,
			IDALEmailAddressMapper dalEmailAddressMapper,
			IBOLPasswordMapper bolPasswordMapper,
			IDALPasswordMapper dalPasswordMapper,
			IBOLPersonPhoneMapper bolPersonPhoneMapper,
			IDALPersonPhoneMapper dalPersonPhoneMapper)
			: base()
		{
			this.PersonRepository = personRepository;
			this.PersonModelValidator = personModelValidator;
			this.BolPersonMapper = bolPersonMapper;
			this.DalPersonMapper = dalPersonMapper;
			this.BolBusinessEntityContactMapper = bolBusinessEntityContactMapper;
			this.DalBusinessEntityContactMapper = dalBusinessEntityContactMapper;
			this.BolEmailAddressMapper = bolEmailAddressMapper;
			this.DalEmailAddressMapper = dalEmailAddressMapper;
			this.BolPasswordMapper = bolPasswordMapper;
			this.DalPasswordMapper = dalPasswordMapper;
			this.BolPersonPhoneMapper = bolPersonPhoneMapper;
			this.DalPersonPhoneMapper = dalPersonPhoneMapper;
			this.logger = logger;
		}

		public virtual async Task<List<ApiPersonResponseModel>> All(int limit = 0, int offset = int.MaxValue)
		{
			var records = await this.PersonRepository.All(limit, offset);

			return this.BolPersonMapper.MapBOToModel(this.DalPersonMapper.MapEFToBO(records));
		}

		public virtual async Task<ApiPersonResponseModel> Get(int businessEntityID)
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

		public virtual async Task<CreateResponse<ApiPersonResponseModel>> Create(
			ApiPersonRequestModel model)
		{
			CreateResponse<ApiPersonResponseModel> response = new CreateResponse<ApiPersonResponseModel>(await this.PersonModelValidator.ValidateCreateAsync(model));
			if (response.Success)
			{
				var bo = this.BolPersonMapper.MapModelToBO(default(int), model);
				var record = await this.PersonRepository.Create(this.DalPersonMapper.MapBOToEF(bo));

				response.SetRecord(this.BolPersonMapper.MapBOToModel(this.DalPersonMapper.MapEFToBO(record)));
			}

			return response;
		}

		public virtual async Task<UpdateResponse<ApiPersonResponseModel>> Update(
			int businessEntityID,
			ApiPersonRequestModel model)
		{
			var validationResult = await this.PersonModelValidator.ValidateUpdateAsync(businessEntityID, model);

			if (validationResult.IsValid)
			{
				var bo = this.BolPersonMapper.MapModelToBO(businessEntityID, model);
				await this.PersonRepository.Update(this.DalPersonMapper.MapBOToEF(bo));

				var record = await this.PersonRepository.Get(businessEntityID);

				return new UpdateResponse<ApiPersonResponseModel>(this.BolPersonMapper.MapBOToModel(this.DalPersonMapper.MapEFToBO(record)));
			}
			else
			{
				return new UpdateResponse<ApiPersonResponseModel>(validationResult);
			}
		}

		public virtual async Task<ActionResponse> Delete(
			int businessEntityID)
		{
			ActionResponse response = new ActionResponse(await this.PersonModelValidator.ValidateDeleteAsync(businessEntityID));
			if (response.Success)
			{
				await this.PersonRepository.Delete(businessEntityID);
			}

			return response;
		}

		public async Task<List<ApiPersonResponseModel>> ByLastNameFirstNameMiddleName(string lastName, string firstName, string middleName)
		{
			List<Person> records = await this.PersonRepository.ByLastNameFirstNameMiddleName(lastName, firstName, middleName);

			return this.BolPersonMapper.MapBOToModel(this.DalPersonMapper.MapEFToBO(records));
		}

		public async Task<List<ApiPersonResponseModel>> ByAdditionalContactInfo(string additionalContactInfo)
		{
			List<Person> records = await this.PersonRepository.ByAdditionalContactInfo(additionalContactInfo);

			return this.BolPersonMapper.MapBOToModel(this.DalPersonMapper.MapEFToBO(records));
		}

		public async Task<List<ApiPersonResponseModel>> ByDemographic(string demographic)
		{
			List<Person> records = await this.PersonRepository.ByDemographic(demographic);

			return this.BolPersonMapper.MapBOToModel(this.DalPersonMapper.MapEFToBO(records));
		}

		public async virtual Task<List<ApiBusinessEntityContactResponseModel>> BusinessEntityContacts(int personID, int limit = int.MaxValue, int offset = 0)
		{
			List<BusinessEntityContact> records = await this.PersonRepository.BusinessEntityContacts(personID, limit, offset);

			return this.BolBusinessEntityContactMapper.MapBOToModel(this.DalBusinessEntityContactMapper.MapEFToBO(records));
		}

		public async virtual Task<List<ApiEmailAddressResponseModel>> EmailAddresses(int businessEntityID, int limit = int.MaxValue, int offset = 0)
		{
			List<EmailAddress> records = await this.PersonRepository.EmailAddresses(businessEntityID, limit, offset);

			return this.BolEmailAddressMapper.MapBOToModel(this.DalEmailAddressMapper.MapEFToBO(records));
		}

		public async virtual Task<List<ApiPasswordResponseModel>> Passwords(int businessEntityID, int limit = int.MaxValue, int offset = 0)
		{
			List<Password> records = await this.PersonRepository.Passwords(businessEntityID, limit, offset);

			return this.BolPasswordMapper.MapBOToModel(this.DalPasswordMapper.MapEFToBO(records));
		}

		public async virtual Task<List<ApiPersonPhoneResponseModel>> PersonPhones(int businessEntityID, int limit = int.MaxValue, int offset = 0)
		{
			List<PersonPhone> records = await this.PersonRepository.PersonPhones(businessEntityID, limit, offset);

			return this.BolPersonPhoneMapper.MapBOToModel(this.DalPersonPhoneMapper.MapEFToBO(records));
		}
	}
}

/*<Codenesium>
    <Hash>8dfd5373ff76371907e37284ce88b1f9</Hash>
</Codenesium>*/