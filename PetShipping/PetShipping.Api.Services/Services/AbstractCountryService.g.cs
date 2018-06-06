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
	public abstract class AbstractCountryService: AbstractService
	{
		private ICountryRepository countryRepository;
		private IApiCountryRequestModelValidator countryModelValidator;
		private IBOLCountryMapper bolCountryMapper;
		private IDALCountryMapper dalCountryMapper;
		private ILogger logger;

		public AbstractCountryService(
			ILogger logger,
			ICountryRepository countryRepository,
			IApiCountryRequestModelValidator countryModelValidator,
			IBOLCountryMapper bolcountryMapper,
			IDALCountryMapper dalcountryMapper)
			: base()

		{
			this.countryRepository = countryRepository;
			this.countryModelValidator = countryModelValidator;
			this.bolCountryMapper = bolcountryMapper;
			this.dalCountryMapper = dalcountryMapper;
			this.logger = logger;
		}

		public virtual async Task<List<ApiCountryResponseModel>> All(int skip = 0, int take = int.MaxValue, string orderClause = "")
		{
			var records = await this.countryRepository.All(skip, take, orderClause);

			return this.bolCountryMapper.MapBOToModel(this.dalCountryMapper.MapEFToBO(records));
		}

		public virtual async Task<ApiCountryResponseModel> Get(int id)
		{
			var record = await countryRepository.Get(id);

			return this.bolCountryMapper.MapBOToModel(this.dalCountryMapper.MapEFToBO(record));
		}

		public virtual async Task<CreateResponse<ApiCountryResponseModel>> Create(
			ApiCountryRequestModel model)
		{
			CreateResponse<ApiCountryResponseModel> response = new CreateResponse<ApiCountryResponseModel>(await this.countryModelValidator.ValidateCreateAsync(model));
			if (response.Success)
			{
				var bo = this.bolCountryMapper.MapModelToBO(default (int), model);
				var record = await this.countryRepository.Create(this.dalCountryMapper.MapBOToEF(bo));

				response.SetRecord(this.bolCountryMapper.MapBOToModel(this.dalCountryMapper.MapEFToBO(record)));
			}
			return response;
		}

		public virtual async Task<ActionResponse> Update(
			int id,
			ApiCountryRequestModel model)
		{
			ActionResponse response = new ActionResponse(await this.countryModelValidator.ValidateUpdateAsync(id, model));

			if (response.Success)
			{
				var bo = this.bolCountryMapper.MapModelToBO(id, model);
				await this.countryRepository.Update(this.dalCountryMapper.MapBOToEF(bo));
			}

			return response;
		}

		public virtual async Task<ActionResponse> Delete(
			int id)
		{
			ActionResponse response = new ActionResponse(await this.countryModelValidator.ValidateDeleteAsync(id));

			if (response.Success)
			{
				await this.countryRepository.Delete(id);
			}
			return response;
		}
	}
}

/*<Codenesium>
    <Hash>71c1fb7c28461e70b3b8ea75254af449</Hash>
</Codenesium>*/