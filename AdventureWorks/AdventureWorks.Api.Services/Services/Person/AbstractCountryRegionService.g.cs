using AdventureWorksNS.Api.Contracts;
using AdventureWorksNS.Api.DataAccess;
using MediatR;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace AdventureWorksNS.Api.Services
{
	public abstract class AbstractCountryRegionService : AbstractService
	{
		private IMediator mediator;

		protected ICountryRegionRepository CountryRegionRepository { get; private set; }

		protected IApiCountryRegionServerRequestModelValidator CountryRegionModelValidator { get; private set; }

		protected IDALCountryRegionMapper DalCountryRegionMapper { get; private set; }

		protected IDALStateProvinceMapper DalStateProvinceMapper { get; private set; }

		private ILogger logger;

		public AbstractCountryRegionService(
			ILogger logger,
			IMediator mediator,
			ICountryRegionRepository countryRegionRepository,
			IApiCountryRegionServerRequestModelValidator countryRegionModelValidator,
			IDALCountryRegionMapper dalCountryRegionMapper,
			IDALStateProvinceMapper dalStateProvinceMapper)
			: base()
		{
			this.CountryRegionRepository = countryRegionRepository;
			this.CountryRegionModelValidator = countryRegionModelValidator;
			this.DalCountryRegionMapper = dalCountryRegionMapper;
			this.DalStateProvinceMapper = dalStateProvinceMapper;
			this.logger = logger;

			this.mediator = mediator;
		}

		public virtual async Task<List<ApiCountryRegionServerResponseModel>> All(int limit = 0, int offset = int.MaxValue, string query = "")
		{
			var records = await this.CountryRegionRepository.All(limit, offset, query);

			return this.DalCountryRegionMapper.MapBOToModel(records);
		}

		public virtual async Task<ApiCountryRegionServerResponseModel> Get(string countryRegionCode)
		{
			var record = await this.CountryRegionRepository.Get(countryRegionCode);

			if (record == null)
			{
				return null;
			}
			else
			{
				return this.DalCountryRegionMapper.MapBOToModel(record);
			}
		}

		public virtual async Task<CreateResponse<ApiCountryRegionServerResponseModel>> Create(
			ApiCountryRegionServerRequestModel model)
		{
			CreateResponse<ApiCountryRegionServerResponseModel> response = ValidationResponseFactory<ApiCountryRegionServerResponseModel>.CreateResponse(await this.CountryRegionModelValidator.ValidateCreateAsync(model));

			if (response.Success)
			{
				var bo = this.DalCountryRegionMapper.MapModelToBO(default(string), model);
				var record = await this.CountryRegionRepository.Create(bo);

				response.SetRecord(this.DalCountryRegionMapper.MapBOToModel(record));
				await this.mediator.Publish(new CountryRegionCreatedNotification(response.Record));
			}

			return response;
		}

		public virtual async Task<UpdateResponse<ApiCountryRegionServerResponseModel>> Update(
			string countryRegionCode,
			ApiCountryRegionServerRequestModel model)
		{
			var validationResult = await this.CountryRegionModelValidator.ValidateUpdateAsync(countryRegionCode, model);

			if (validationResult.IsValid)
			{
				var bo = this.DalCountryRegionMapper.MapModelToBO(countryRegionCode, model);
				await this.CountryRegionRepository.Update(bo);

				var record = await this.CountryRegionRepository.Get(countryRegionCode);

				var apiModel = this.DalCountryRegionMapper.MapBOToModel(record);
				await this.mediator.Publish(new CountryRegionUpdatedNotification(apiModel));

				return ValidationResponseFactory<ApiCountryRegionServerResponseModel>.UpdateResponse(apiModel);
			}
			else
			{
				return ValidationResponseFactory<ApiCountryRegionServerResponseModel>.UpdateResponse(validationResult);
			}
		}

		public virtual async Task<ActionResponse> Delete(
			string countryRegionCode)
		{
			ActionResponse response = ValidationResponseFactory<object>.ActionResponse(await this.CountryRegionModelValidator.ValidateDeleteAsync(countryRegionCode));

			if (response.Success)
			{
				await this.CountryRegionRepository.Delete(countryRegionCode);

				await this.mediator.Publish(new CountryRegionDeletedNotification(countryRegionCode));
			}

			return response;
		}

		public async virtual Task<ApiCountryRegionServerResponseModel> ByName(string name)
		{
			CountryRegion record = await this.CountryRegionRepository.ByName(name);

			if (record == null)
			{
				return null;
			}
			else
			{
				return this.DalCountryRegionMapper.MapBOToModel(record);
			}
		}

		public async virtual Task<List<ApiStateProvinceServerResponseModel>> StateProvincesByCountryRegionCode(string countryRegionCode, int limit = int.MaxValue, int offset = 0)
		{
			List<StateProvince> records = await this.CountryRegionRepository.StateProvincesByCountryRegionCode(countryRegionCode, limit, offset);

			return this.DalStateProvinceMapper.MapBOToModel(records);
		}
	}
}

/*<Codenesium>
    <Hash>d4b1a7a42e3c5b2c8ba3b2bd43f6251a</Hash>
</Codenesium>*/