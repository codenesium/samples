using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using TicketingCRMNS.Api.Contracts;
using TicketingCRMNS.Api.DataAccess;

namespace TicketingCRMNS.Api.Services
{
	public abstract class AbstractCountryService : AbstractService
	{
		private MediatR.IMediator mediator;

		protected ICountryRepository CountryRepository { get; private set; }

		protected IApiCountryServerRequestModelValidator CountryModelValidator { get; private set; }

		protected IDALCountryMapper DalCountryMapper { get; private set; }

		protected IDALProvinceMapper DalProvinceMapper { get; private set; }

		private ILogger logger;

		public AbstractCountryService(
			ILogger logger,
			MediatR.IMediator mediator,
			ICountryRepository countryRepository,
			IApiCountryServerRequestModelValidator countryModelValidator,
			IDALCountryMapper dalCountryMapper,
			IDALProvinceMapper dalProvinceMapper)
			: base()
		{
			this.CountryRepository = countryRepository;
			this.CountryModelValidator = countryModelValidator;
			this.DalCountryMapper = dalCountryMapper;
			this.DalProvinceMapper = dalProvinceMapper;
			this.logger = logger;

			this.mediator = mediator;
		}

		public virtual async Task<List<ApiCountryServerResponseModel>> All(int limit = 0, int offset = int.MaxValue, string query = "")
		{
			List<Country> records = await this.CountryRepository.All(limit, offset, query);

			return this.DalCountryMapper.MapEntityToModel(records);
		}

		public virtual async Task<ApiCountryServerResponseModel> Get(int id)
		{
			Country record = await this.CountryRepository.Get(id);

			if (record == null)
			{
				return null;
			}
			else
			{
				return this.DalCountryMapper.MapEntityToModel(record);
			}
		}

		public virtual async Task<CreateResponse<ApiCountryServerResponseModel>> Create(
			ApiCountryServerRequestModel model)
		{
			CreateResponse<ApiCountryServerResponseModel> response = ValidationResponseFactory<ApiCountryServerResponseModel>.CreateResponse(await this.CountryModelValidator.ValidateCreateAsync(model));

			if (response.Success)
			{
				Country record = this.DalCountryMapper.MapModelToEntity(default(int), model);
				record = await this.CountryRepository.Create(record);

				response.SetRecord(this.DalCountryMapper.MapEntityToModel(record));
				await this.mediator.Publish(new CountryCreatedNotification(response.Record));
			}

			return response;
		}

		public virtual async Task<UpdateResponse<ApiCountryServerResponseModel>> Update(
			int id,
			ApiCountryServerRequestModel model)
		{
			var validationResult = await this.CountryModelValidator.ValidateUpdateAsync(id, model);

			if (validationResult.IsValid)
			{
				Country record = this.DalCountryMapper.MapModelToEntity(id, model);
				await this.CountryRepository.Update(record);

				record = await this.CountryRepository.Get(id);

				ApiCountryServerResponseModel apiModel = this.DalCountryMapper.MapEntityToModel(record);
				await this.mediator.Publish(new CountryUpdatedNotification(apiModel));

				return ValidationResponseFactory<ApiCountryServerResponseModel>.UpdateResponse(apiModel);
			}
			else
			{
				return ValidationResponseFactory<ApiCountryServerResponseModel>.UpdateResponse(validationResult);
			}
		}

		public virtual async Task<ActionResponse> Delete(
			int id)
		{
			ActionResponse response = ValidationResponseFactory<object>.ActionResponse(await this.CountryModelValidator.ValidateDeleteAsync(id));

			if (response.Success)
			{
				await this.CountryRepository.Delete(id);

				await this.mediator.Publish(new CountryDeletedNotification(id));
			}

			return response;
		}

		public async virtual Task<List<ApiProvinceServerResponseModel>> ProvincesByCountryId(int countryId, int limit = int.MaxValue, int offset = 0)
		{
			List<Province> records = await this.CountryRepository.ProvincesByCountryId(countryId, limit, offset);

			return this.DalProvinceMapper.MapEntityToModel(records);
		}
	}
}

/*<Codenesium>
    <Hash>a1e16e1f3e4e18182e4afd5181426ac2</Hash>
</Codenesium>*/