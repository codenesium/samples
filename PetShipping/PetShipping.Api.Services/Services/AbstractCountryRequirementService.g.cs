using Codenesium.DataConversionExtensions.AspNetCore;
using System;
using System.Collections.Generic;
using Microsoft.Extensions.Logging;
using Microsoft.EntityFrameworkCore;
using System.Linq;
using System.Linq.Dynamic.Core;
using System.Linq.Expressions;
using System.Threading.Tasks;
using PetShippingNS.Api.Contracts;
using PetShippingNS.Api.DataAccess;

namespace PetShippingNS.Api.Services
{
	public abstract class AbstractCountryRequirementService: AbstractService
	{
		private ICountryRequirementRepository countryRequirementRepository;
		private IApiCountryRequirementRequestModelValidator countryRequirementModelValidator;
		private IBOLCountryRequirementMapper BOLCountryRequirementMapper;
		private IDALCountryRequirementMapper DALCountryRequirementMapper;
		private ILogger logger;

		public AbstractCountryRequirementService(
			ILogger logger,
			ICountryRequirementRepository countryRequirementRepository,
			IApiCountryRequirementRequestModelValidator countryRequirementModelValidator,
			IBOLCountryRequirementMapper bolcountryRequirementMapper,
			IDALCountryRequirementMapper dalcountryRequirementMapper)
			: base()

		{
			this.countryRequirementRepository = countryRequirementRepository;
			this.countryRequirementModelValidator = countryRequirementModelValidator;
			this.BOLCountryRequirementMapper = bolcountryRequirementMapper;
			this.DALCountryRequirementMapper = dalcountryRequirementMapper;
			this.logger = logger;
		}

		public virtual async Task<List<ApiCountryRequirementResponseModel>> All(int skip = 0, int take = int.MaxValue, string orderClause = "")
		{
			var records = await this.countryRequirementRepository.All(skip, take, orderClause);

			return this.BOLCountryRequirementMapper.MapBOToModel(this.DALCountryRequirementMapper.MapEFToBO(records));
		}

		public virtual async Task<ApiCountryRequirementResponseModel> Get(int id)
		{
			var record = await countryRequirementRepository.Get(id);

			return this.BOLCountryRequirementMapper.MapBOToModel(this.DALCountryRequirementMapper.MapEFToBO(record));
		}

		public virtual async Task<CreateResponse<ApiCountryRequirementResponseModel>> Create(
			ApiCountryRequirementRequestModel model)
		{
			CreateResponse<ApiCountryRequirementResponseModel> response = new CreateResponse<ApiCountryRequirementResponseModel>(await this.countryRequirementModelValidator.ValidateCreateAsync(model));
			if (response.Success)
			{
				var bo = this.BOLCountryRequirementMapper.MapModelToBO(default (int), model);
				var record = await this.countryRequirementRepository.Create(this.DALCountryRequirementMapper.MapBOToEF(bo));

				response.SetRecord(this.BOLCountryRequirementMapper.MapBOToModel(this.DALCountryRequirementMapper.MapEFToBO(record)));
			}
			return response;
		}

		public virtual async Task<ActionResponse> Update(
			int id,
			ApiCountryRequirementRequestModel model)
		{
			ActionResponse response = new ActionResponse(await this.countryRequirementModelValidator.ValidateUpdateAsync(id, model));

			if (response.Success)
			{
				var bo = this.BOLCountryRequirementMapper.MapModelToBO(id, model);
				await this.countryRequirementRepository.Update(this.DALCountryRequirementMapper.MapBOToEF(bo));
			}

			return response;
		}

		public virtual async Task<ActionResponse> Delete(
			int id)
		{
			ActionResponse response = new ActionResponse(await this.countryRequirementModelValidator.ValidateDeleteAsync(id));

			if (response.Success)
			{
				await this.countryRequirementRepository.Delete(id);
			}
			return response;
		}
	}
}

/*<Codenesium>
    <Hash>cfc59c3e796ce06ab955d090c1fd2a46</Hash>
</Codenesium>*/