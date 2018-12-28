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

		protected IBOLCountryRegionMapper BolCountryRegionMapper { get; private set; }

		protected IDALCountryRegionMapper DalCountryRegionMapper { get; private set; }

		protected IBOLStateProvinceMapper BolStateProvinceMapper { get; private set; }

		protected IDALStateProvinceMapper DalStateProvinceMapper { get; private set; }

		private ILogger logger;

		public AbstractCountryRegionService(
			ILogger logger,
			IMediator mediator,
			ICountryRegionRepository countryRegionRepository,
			IApiCountryRegionServerRequestModelValidator countryRegionModelValidator,
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

			this.mediator = mediator;
		}

		public virtual async Task<List<ApiCountryRegionServerResponseModel>> All(int limit = 0, int offset = int.MaxValue)
		{
			var records = await this.CountryRegionRepository.All(limit, offset);

			return this.BolCountryRegionMapper.MapBOToModel(this.DalCountryRegionMapper.MapEFToBO(records));
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
				return this.BolCountryRegionMapper.MapBOToModel(this.DalCountryRegionMapper.MapEFToBO(record));
			}
		}

		public virtual async Task<CreateResponse<ApiCountryRegionServerResponseModel>> Create(
			ApiCountryRegionServerRequestModel model)
		{
			CreateResponse<ApiCountryRegionServerResponseModel> response = ValidationResponseFactory<ApiCountryRegionServerResponseModel>.CreateResponse(await this.CountryRegionModelValidator.ValidateCreateAsync(model));

			if (response.Success)
			{
				var bo = this.BolCountryRegionMapper.MapModelToBO(default(string), model);
				var record = await this.CountryRegionRepository.Create(this.DalCountryRegionMapper.MapBOToEF(bo));

				var businessObject = this.DalCountryRegionMapper.MapEFToBO(record);
				response.SetRecord(this.BolCountryRegionMapper.MapBOToModel(businessObject));
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
				var bo = this.BolCountryRegionMapper.MapModelToBO(countryRegionCode, model);
				await this.CountryRegionRepository.Update(this.DalCountryRegionMapper.MapBOToEF(bo));

				var record = await this.CountryRegionRepository.Get(countryRegionCode);

				var businessObject = this.DalCountryRegionMapper.MapEFToBO(record);
				var apiModel = this.BolCountryRegionMapper.MapBOToModel(businessObject);
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
				return this.BolCountryRegionMapper.MapBOToModel(this.DalCountryRegionMapper.MapEFToBO(record));
			}
		}

		public async virtual Task<List<ApiStateProvinceServerResponseModel>> StateProvincesByCountryRegionCode(string countryRegionCode, int limit = int.MaxValue, int offset = 0)
		{
			List<StateProvince> records = await this.CountryRegionRepository.StateProvincesByCountryRegionCode(countryRegionCode, limit, offset);

			return this.BolStateProvinceMapper.MapBOToModel(this.DalStateProvinceMapper.MapEFToBO(records));
		}
	}
}

/*<Codenesium>
    <Hash>e608734522aaf02362e7e45931cde061</Hash>
</Codenesium>*/