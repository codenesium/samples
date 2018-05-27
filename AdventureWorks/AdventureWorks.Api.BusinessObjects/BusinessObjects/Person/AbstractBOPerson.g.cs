using Codenesium.DataConversionExtensions.AspNetCore;
using System;
using System.Collections.Generic;
using Microsoft.Extensions.Logging;
using Microsoft.EntityFrameworkCore;
using System.Linq;
using System.Linq.Dynamic.Core;
using System.Linq.Expressions;
using System.Threading.Tasks;
using AdventureWorksNS.Api.Contracts;
using AdventureWorksNS.Api.DataAccess;

namespace AdventureWorksNS.Api.BusinessObjects
{
	public abstract class AbstractBOPerson: AbstractBOManager
	{
		private IPersonRepository personRepository;
		private IApiPersonRequestModelValidator personModelValidator;
		private IBOLPersonMapper personMapper;
		private ILogger logger;

		public AbstractBOPerson(
			ILogger logger,
			IPersonRepository personRepository,
			IApiPersonRequestModelValidator personModelValidator,
			IBOLPersonMapper personMapper)
			: base()

		{
			this.personRepository = personRepository;
			this.personModelValidator = personModelValidator;
			this.personMapper = personMapper;
			this.logger = logger;
		}

		public virtual async Task<List<ApiPersonResponseModel>> All(int skip = 0, int take = int.MaxValue, string orderClause = "")
		{
			var records = await this.personRepository.All(skip, take, orderClause);

			return this.personMapper.MapDTOToModel(records);
		}

		public virtual async Task<ApiPersonResponseModel> Get(int businessEntityID)
		{
			var record = await personRepository.Get(businessEntityID);

			return this.personMapper.MapDTOToModel(record);
		}

		public virtual async Task<CreateResponse<ApiPersonResponseModel>> Create(
			ApiPersonRequestModel model)
		{
			CreateResponse<ApiPersonResponseModel> response = new CreateResponse<ApiPersonResponseModel>(await this.personModelValidator.ValidateCreateAsync(model));
			if (response.Success)
			{
				var dto = this.personMapper.MapModelToDTO(default (int), model);
				var record = await this.personRepository.Create(dto);

				response.SetRecord(this.personMapper.MapDTOToModel(record));
			}
			return response;
		}

		public virtual async Task<ActionResponse> Update(
			int businessEntityID,
			ApiPersonRequestModel model)
		{
			ActionResponse response = new ActionResponse(await this.personModelValidator.ValidateUpdateAsync(businessEntityID, model));

			if (response.Success)
			{
				var dto = this.personMapper.MapModelToDTO(businessEntityID, model);
				await this.personRepository.Update(businessEntityID, dto);
			}

			return response;
		}

		public virtual async Task<ActionResponse> Delete(
			int businessEntityID)
		{
			ActionResponse response = new ActionResponse(await this.personModelValidator.ValidateDeleteAsync(businessEntityID));

			if (response.Success)
			{
				await this.personRepository.Delete(businessEntityID);
			}
			return response;
		}

		public async Task<List<ApiPersonResponseModel>> GetLastNameFirstNameMiddleName(string lastName,string firstName,string middleName)
		{
			List<DTOPerson> records = await this.personRepository.GetLastNameFirstNameMiddleName(lastName,firstName,middleName);

			return this.personMapper.MapDTOToModel(records);
		}
		public async Task<List<ApiPersonResponseModel>> GetAdditionalContactInfo(string additionalContactInfo)
		{
			List<DTOPerson> records = await this.personRepository.GetAdditionalContactInfo(additionalContactInfo);

			return this.personMapper.MapDTOToModel(records);
		}
		public async Task<List<ApiPersonResponseModel>> GetDemographics(string demographics)
		{
			List<DTOPerson> records = await this.personRepository.GetDemographics(demographics);

			return this.personMapper.MapDTOToModel(records);
		}
	}
}

/*<Codenesium>
    <Hash>704b8cb45f26d2779f953fa5bdeeec4f</Hash>
</Codenesium>*/