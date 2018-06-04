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
	public abstract class AbstractCountryRegionService: AbstractService
	{
		private ICountryRegionRepository countryRegionRepository;
		private IApiCountryRegionRequestModelValidator countryRegionModelValidator;
		private IBOLCountryRegionMapper BOLCountryRegionMapper;
		private IDALCountryRegionMapper DALCountryRegionMapper;
		private ILogger logger;

		public AbstractCountryRegionService(
			ILogger logger,
			ICountryRegionRepository countryRegionRepository,
			IApiCountryRegionRequestModelValidator countryRegionModelValidator,
			IBOLCountryRegionMapper bolcountryRegionMapper,
			IDALCountryRegionMapper dalcountryRegionMapper)
			: base()

		{
			this.countryRegionRepository = countryRegionRepository;
			this.countryRegionModelValidator = countryRegionModelValidator;
			this.BOLCountryRegionMapper = bolcountryRegionMapper;
			this.DALCountryRegionMapper = dalcountryRegionMapper;
			this.logger = logger;
		}

		public virtual async Task<List<ApiCountryRegionResponseModel>> All(int skip = 0, int take = int.MaxValue, string orderClause = "")
		{
			var records = await this.countryRegionRepository.All(skip, take, orderClause);

			return this.BOLCountryRegionMapper.MapBOToModel(this.DALCountryRegionMapper.MapEFToBO(records));
		}

		public virtual async Task<ApiCountryRegionResponseModel> Get(string countryRegionCode)
		{
			var record = await countryRegionRepository.Get(countryRegionCode);

			return this.BOLCountryRegionMapper.MapBOToModel(this.DALCountryRegionMapper.MapEFToBO(record));
		}

		public virtual async Task<CreateResponse<ApiCountryRegionResponseModel>> Create(
			ApiCountryRegionRequestModel model)
		{
			CreateResponse<ApiCountryRegionResponseModel> response = new CreateResponse<ApiCountryRegionResponseModel>(await this.countryRegionModelValidator.ValidateCreateAsync(model));
			if (response.Success)
			{
				var bo = this.BOLCountryRegionMapper.MapModelToBO(default (string), model);
				var record = await this.countryRegionRepository.Create(this.DALCountryRegionMapper.MapBOToEF(bo));

				response.SetRecord(this.BOLCountryRegionMapper.MapBOToModel(this.DALCountryRegionMapper.MapEFToBO(record)));
			}
			return response;
		}

		public virtual async Task<ActionResponse> Update(
			string countryRegionCode,
			ApiCountryRegionRequestModel model)
		{
			ActionResponse response = new ActionResponse(await this.countryRegionModelValidator.ValidateUpdateAsync(countryRegionCode, model));

			if (response.Success)
			{
				var bo = this.BOLCountryRegionMapper.MapModelToBO(countryRegionCode, model);
				await this.countryRegionRepository.Update(this.DALCountryRegionMapper.MapBOToEF(bo));
			}

			return response;
		}

		public virtual async Task<ActionResponse> Delete(
			string countryRegionCode)
		{
			ActionResponse response = new ActionResponse(await this.countryRegionModelValidator.ValidateDeleteAsync(countryRegionCode));

			if (response.Success)
			{
				await this.countryRegionRepository.Delete(countryRegionCode);
			}
			return response;
		}

		public async Task<ApiCountryRegionResponseModel> GetName(string name)
		{
			CountryRegion record = await this.countryRegionRepository.GetName(name);

			return this.BOLCountryRegionMapper.MapBOToModel(this.DALCountryRegionMapper.MapEFToBO(record));
		}
	}
}

/*<Codenesium>
    <Hash>b097310a152f20057ecd30d8c314c405</Hash>
</Codenesium>*/