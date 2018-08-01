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
		private ICountryRegionRepository countryRegionRepository;

		private IApiCountryRegionRequestModelValidator countryRegionModelValidator;

		private IBOLCountryRegionMapper bolCountryRegionMapper;

		private IDALCountryRegionMapper dalCountryRegionMapper;

		private IBOLStateProvinceMapper bolStateProvinceMapper;

		private IDALStateProvinceMapper dalStateProvinceMapper;

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
			this.countryRegionRepository = countryRegionRepository;
			this.countryRegionModelValidator = countryRegionModelValidator;
			this.bolCountryRegionMapper = bolCountryRegionMapper;
			this.dalCountryRegionMapper = dalCountryRegionMapper;
			this.bolStateProvinceMapper = bolStateProvinceMapper;
			this.dalStateProvinceMapper = dalStateProvinceMapper;
			this.logger = logger;
		}

		public virtual async Task<List<ApiCountryRegionResponseModel>> All(int limit = 0, int offset = int.MaxValue)
		{
			var records = await this.countryRegionRepository.All(limit, offset);

			return this.bolCountryRegionMapper.MapBOToModel(this.dalCountryRegionMapper.MapEFToBO(records));
		}

		public virtual async Task<ApiCountryRegionResponseModel> Get(string countryRegionCode)
		{
			var record = await this.countryRegionRepository.Get(countryRegionCode);

			if (record == null)
			{
				return null;
			}
			else
			{
				return this.bolCountryRegionMapper.MapBOToModel(this.dalCountryRegionMapper.MapEFToBO(record));
			}
		}

		public virtual async Task<CreateResponse<ApiCountryRegionResponseModel>> Create(
			ApiCountryRegionRequestModel model)
		{
			CreateResponse<ApiCountryRegionResponseModel> response = new CreateResponse<ApiCountryRegionResponseModel>(await this.countryRegionModelValidator.ValidateCreateAsync(model));
			if (response.Success)
			{
				var bo = this.bolCountryRegionMapper.MapModelToBO(default(string), model);
				var record = await this.countryRegionRepository.Create(this.dalCountryRegionMapper.MapBOToEF(bo));

				response.SetRecord(this.bolCountryRegionMapper.MapBOToModel(this.dalCountryRegionMapper.MapEFToBO(record)));
			}

			return response;
		}

		public virtual async Task<UpdateResponse<ApiCountryRegionResponseModel>> Update(
			string countryRegionCode,
			ApiCountryRegionRequestModel model)
		{
			var validationResult = await this.countryRegionModelValidator.ValidateUpdateAsync(countryRegionCode, model);

			if (validationResult.IsValid)
			{
				var bo = this.bolCountryRegionMapper.MapModelToBO(countryRegionCode, model);
				await this.countryRegionRepository.Update(this.dalCountryRegionMapper.MapBOToEF(bo));

				var record = await this.countryRegionRepository.Get(countryRegionCode);

				return new UpdateResponse<ApiCountryRegionResponseModel>(this.bolCountryRegionMapper.MapBOToModel(this.dalCountryRegionMapper.MapEFToBO(record)));
			}
			else
			{
				return new UpdateResponse<ApiCountryRegionResponseModel>(validationResult);
			}
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

		public async Task<ApiCountryRegionResponseModel> ByName(string name)
		{
			CountryRegion record = await this.countryRegionRepository.ByName(name);

			if (record == null)
			{
				return null;
			}
			else
			{
				return this.bolCountryRegionMapper.MapBOToModel(this.dalCountryRegionMapper.MapEFToBO(record));
			}
		}

		public async virtual Task<List<ApiStateProvinceResponseModel>> StateProvinces(string countryRegionCode, int limit = int.MaxValue, int offset = 0)
		{
			List<StateProvince> records = await this.countryRegionRepository.StateProvinces(countryRegionCode, limit, offset);

			return this.bolStateProvinceMapper.MapBOToModel(this.dalStateProvinceMapper.MapEFToBO(records));
		}
	}
}

/*<Codenesium>
    <Hash>ae47c177f508380aa2393e05f959d414</Hash>
</Codenesium>*/