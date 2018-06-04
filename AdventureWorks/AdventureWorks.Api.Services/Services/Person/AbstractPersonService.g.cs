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

namespace AdventureWorksNS.Api.Services
{
	public abstract class AbstractPersonService: AbstractService
	{
		private IPersonRepository personRepository;
		private IApiPersonRequestModelValidator personModelValidator;
		private IBOLPersonMapper BOLPersonMapper;
		private IDALPersonMapper DALPersonMapper;
		private ILogger logger;

		public AbstractPersonService(
			ILogger logger,
			IPersonRepository personRepository,
			IApiPersonRequestModelValidator personModelValidator,
			IBOLPersonMapper bolpersonMapper,
			IDALPersonMapper dalpersonMapper)
			: base()

		{
			this.personRepository = personRepository;
			this.personModelValidator = personModelValidator;
			this.BOLPersonMapper = bolpersonMapper;
			this.DALPersonMapper = dalpersonMapper;
			this.logger = logger;
		}

		public virtual async Task<List<ApiPersonResponseModel>> All(int skip = 0, int take = int.MaxValue, string orderClause = "")
		{
			var records = await this.personRepository.All(skip, take, orderClause);

			return this.BOLPersonMapper.MapBOToModel(this.DALPersonMapper.MapEFToBO(records));
		}

		public virtual async Task<ApiPersonResponseModel> Get(int businessEntityID)
		{
			var record = await personRepository.Get(businessEntityID);

			return this.BOLPersonMapper.MapBOToModel(this.DALPersonMapper.MapEFToBO(record));
		}

		public virtual async Task<CreateResponse<ApiPersonResponseModel>> Create(
			ApiPersonRequestModel model)
		{
			CreateResponse<ApiPersonResponseModel> response = new CreateResponse<ApiPersonResponseModel>(await this.personModelValidator.ValidateCreateAsync(model));
			if (response.Success)
			{
				var bo = this.BOLPersonMapper.MapModelToBO(default (int), model);
				var record = await this.personRepository.Create(this.DALPersonMapper.MapBOToEF(bo));

				response.SetRecord(this.BOLPersonMapper.MapBOToModel(this.DALPersonMapper.MapEFToBO(record)));
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
				var bo = this.BOLPersonMapper.MapModelToBO(businessEntityID, model);
				await this.personRepository.Update(this.DALPersonMapper.MapBOToEF(bo));
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
			List<Person> records = await this.personRepository.GetLastNameFirstNameMiddleName(lastName,firstName,middleName);

			return this.BOLPersonMapper.MapBOToModel(this.DALPersonMapper.MapEFToBO(records));
		}
		public async Task<List<ApiPersonResponseModel>> GetAdditionalContactInfo(string additionalContactInfo)
		{
			List<Person> records = await this.personRepository.GetAdditionalContactInfo(additionalContactInfo);

			return this.BOLPersonMapper.MapBOToModel(this.DALPersonMapper.MapEFToBO(records));
		}
		public async Task<List<ApiPersonResponseModel>> GetDemographics(string demographics)
		{
			List<Person> records = await this.personRepository.GetDemographics(demographics);

			return this.BOLPersonMapper.MapBOToModel(this.DALPersonMapper.MapEFToBO(records));
		}
	}
}

/*<Codenesium>
    <Hash>f087b8ba86a949a497895346305ac7a1</Hash>
</Codenesium>*/