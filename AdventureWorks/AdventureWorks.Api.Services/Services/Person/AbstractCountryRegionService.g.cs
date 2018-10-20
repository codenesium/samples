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
	public abstract class AbstractCountryRegionService : AbstractService
	{
		protected ICountryRegionRepository CountryRegionRepository { get; private set; }

		protected IApiCountryRegionRequestModelValidator CountryRegionModelValidator { get; private set; }

		protected IBOLCountryRegionMapper BolCountryRegionMapper { get; private set; }

		protected IDALCountryRegionMapper DalCountryRegionMapper { get; private set; }

		protected IBOLStateProvinceMapper BolStateProvinceMapper { get; private set; }

		protected IDALStateProvinceMapper DalStateProvinceMapper { get; private set; }

		private ILogger logger;

		public AbstractCountryRegionService(
			ILogger logger,
			ICountryRegionRepository countryRegionRepository,
			IApiCountryRegionRequestModelValidator countryRegionModelValidator,
			IBOLCountryRegionMapper bolCountryRegionMapper,
			IDALCountryRegionMapper dalCountryRegionMapper,
			IBOLStateProvinceMapper bolStateProvinceMapper,
			IDALStateProvinceMapper dalStateProvinceMapper)
			: base()
		{
			this.CountryRegionRepository = countryRegionRepository;
			this.CountryRegionModelValidator = countryRegionModelValidator;
			this.BolCountryRegionMapper = bolCountryRegionMapper;
			this.DalCountryRegionMapper = dalCountryRegionMapper;
			this.BolStateProvinceMapper = bolStateProvinceMapper;
			this.DalStateProvinceMapper = dalStateProvinceMapper;
			this.logger = logger;
		}

		public virtual async Task<List<ApiCountryRegionResponseModel>> All(int limit = 0, int offset = int.MaxValue)
		{
			var records = await this.CountryRegionRepository.All(limit, offset);

			return this.BolCountryRegionMapper.MapBOToModel(this.DalCountryRegionMapper.MapEFToBO(records));
		}

		public virtual async Task<ApiCountryRegionResponseModel> Get(string countryRegionCode)
		{
			var record = await this.CountryRegionRepository.Get(countryRegionCode);

			if (record == null)
			{
				return null;
			}
			else
			{
				return this.BolCountryRegionMapper.MapBOToModel(this.DalCountryRegionMapper.MapEFToBO(record));
			}
		}

		public virtual async Task<CreateResponse<ApiCountryRegionResponseModel>> Create(
			ApiCountryRegionRequestModel model)
		{
			CreateResponse<ApiCountryRegionResponseModel> response = new CreateResponse<ApiCountryRegionResponseModel>(await this.CountryRegionModelValidator.ValidateCreateAsync(model));
			if (response.Success)
			{
				var bo = this.BolCountryRegionMapper.MapModelToBO(default(string), model);
				var record = await this.CountryRegionRepository.Create(this.DalCountryRegionMapper.MapBOToEF(bo));

				response.SetRecord(this.BolCountryRegionMapper.MapBOToModel(this.DalCountryRegionMapper.MapEFToBO(record)));
			}

			return response;
		}

		public virtual async Task<UpdateResponse<ApiCountryRegionResponseModel>> Update(
			string countryRegionCode,
			ApiCountryRegionRequestModel model)
		{
			var validationResult = await this.CountryRegionModelValidator.ValidateUpdateAsync(countryRegionCode, model);

			if (validationResult.IsValid)
			{
				var bo = this.BolCountryRegionMapper.MapModelToBO(countryRegionCode, model);
				await this.CountryRegionRepository.Update(this.DalCountryRegionMapper.MapBOToEF(bo));

				var record = await this.CountryRegionRepository.Get(countryRegionCode);

				return new UpdateResponse<ApiCountryRegionResponseModel>(this.BolCountryRegionMapper.MapBOToModel(this.DalCountryRegionMapper.MapEFToBO(record)));
			}
			else
			{
				return new UpdateResponse<ApiCountryRegionResponseModel>(validationResult);
			}
		}

		public virtual async Task<ActionResponse> Delete(
			string countryRegionCode)
		{
			ActionResponse response = new ActionResponse(await this.CountryRegionModelValidator.ValidateDeleteAsync(countryRegionCode));
			if (response.Success)
			{
				await this.CountryRegionRepository.Delete(countryRegionCode);
			}

			return response;
		}

		public async Task<ApiCountryRegionResponseModel> ByName(string name)
		{
			CountryRegion record = await this.CountryRegionRepository.ByName(name);

			if (record == null)
			{
				return null;
			}
			else
			{
				return this.BolCountryRegionMapper.MapBOToModel(this.DalCountryRegionMapper.MapEFToBO(record));
			}
		}

		public async virtual Task<List<ApiStateProvinceResponseModel>> StateProvincesByCountryRegionCode(string countryRegionCode, int limit = int.MaxValue, int offset = 0)
		{
			List<StateProvince> records = await this.CountryRegionRepository.StateProvincesByCountryRegionCode(countryRegionCode, limit, offset);

			return this.BolStateProvinceMapper.MapBOToModel(this.DalStateProvinceMapper.MapEFToBO(records));
		}
	}
}

/*<Codenesium>
    <Hash>e5ae124087c85a40527417e66bbccae3</Hash>
</Codenesium>*/