using Microsoft.Extensions.Logging;
using PetShippingNS.Api.Contracts;
using PetShippingNS.Api.DataAccess;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace PetShippingNS.Api.Services
{
	public abstract class AbstractCountryService : AbstractService
	{
		private MediatR.IMediator mediator;

		protected ICountryRepository CountryRepository { get; private set; }

		protected IApiCountryServerRequestModelValidator CountryModelValidator { get; private set; }

		protected IDALCountryMapper DalCountryMapper { get; private set; }

		protected IDALCountryRequirementMapper DalCountryRequirementMapper { get; private set; }

		protected IDALDestinationMapper DalDestinationMapper { get; private set; }

		private ILogger logger;

		public AbstractCountryService(
			ILogger logger,
			MediatR.IMediator mediator,
			ICountryRepository countryRepository,
			IApiCountryServerRequestModelValidator countryModelValidator,
			IDALCountryMapper dalCountryMapper,
			IDALCountryRequirementMapper dalCountryRequirementMapper,
			IDALDestinationMapper dalDestinationMapper)
			: base()
		{
			this.CountryRepository = countryRepository;
			this.CountryModelValidator = countryModelValidator;
			this.DalCountryMapper = dalCountryMapper;
			this.DalCountryRequirementMapper = dalCountryRequirementMapper;
			this.DalDestinationMapper = dalDestinationMapper;
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

		public async virtual Task<List<ApiCountryRequirementServerResponseModel>> CountryRequirementsByCountryId(int countryId, int limit = int.MaxValue, int offset = 0)
		{
			List<CountryRequirement> records = await this.CountryRepository.CountryRequirementsByCountryId(countryId, limit, offset);

			return this.DalCountryRequirementMapper.MapEntityToModel(records);
		}

		public async virtual Task<List<ApiDestinationServerResponseModel>> DestinationsByCountryId(int countryId, int limit = int.MaxValue, int offset = 0)
		{
			List<Destination> records = await this.CountryRepository.DestinationsByCountryId(countryId, limit, offset);

			return this.DalDestinationMapper.MapEntityToModel(records);
		}
	}
}

/*<Codenesium>
    <Hash>481cd1400cb099d0687ab6c89bbcf9eb</Hash>
</Codenesium>*/