using MediatR;
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
		private IMediator mediator;

		protected ICountryRepository CountryRepository { get; private set; }

		protected IApiCountryServerRequestModelValidator CountryModelValidator { get; private set; }

		protected IBOLCountryMapper BolCountryMapper { get; private set; }

		protected IDALCountryMapper DalCountryMapper { get; private set; }

		protected IBOLCountryRequirementMapper BolCountryRequirementMapper { get; private set; }

		protected IDALCountryRequirementMapper DalCountryRequirementMapper { get; private set; }

		protected IBOLDestinationMapper BolDestinationMapper { get; private set; }

		protected IDALDestinationMapper DalDestinationMapper { get; private set; }

		private ILogger logger;

		public AbstractCountryService(
			ILogger logger,
			IMediator mediator,
			ICountryRepository countryRepository,
			IApiCountryServerRequestModelValidator countryModelValidator,
			IBOLCountryMapper bolCountryMapper,
			IDALCountryMapper dalCountryMapper,
			IBOLCountryRequirementMapper bolCountryRequirementMapper,
			IDALCountryRequirementMapper dalCountryRequirementMapper,
			IBOLDestinationMapper bolDestinationMapper,
			IDALDestinationMapper dalDestinationMapper)
			: base()
		{
			this.CountryRepository = countryRepository;
			this.CountryModelValidator = countryModelValidator;
			this.BolCountryMapper = bolCountryMapper;
			this.DalCountryMapper = dalCountryMapper;
			this.BolCountryRequirementMapper = bolCountryRequirementMapper;
			this.DalCountryRequirementMapper = dalCountryRequirementMapper;
			this.BolDestinationMapper = bolDestinationMapper;
			this.DalDestinationMapper = dalDestinationMapper;
			this.logger = logger;

			this.mediator = mediator;
		}

		public virtual async Task<List<ApiCountryServerResponseModel>> All(int limit = 0, int offset = int.MaxValue)
		{
			var records = await this.CountryRepository.All(limit, offset);

			return this.BolCountryMapper.MapBOToModel(this.DalCountryMapper.MapEFToBO(records));
		}

		public virtual async Task<ApiCountryServerResponseModel> Get(int id)
		{
			var record = await this.CountryRepository.Get(id);

			if (record == null)
			{
				return null;
			}
			else
			{
				return this.BolCountryMapper.MapBOToModel(this.DalCountryMapper.MapEFToBO(record));
			}
		}

		public virtual async Task<CreateResponse<ApiCountryServerResponseModel>> Create(
			ApiCountryServerRequestModel model)
		{
			CreateResponse<ApiCountryServerResponseModel> response = ValidationResponseFactory<ApiCountryServerResponseModel>.CreateResponse(await this.CountryModelValidator.ValidateCreateAsync(model));

			if (response.Success)
			{
				var bo = this.BolCountryMapper.MapModelToBO(default(int), model);
				var record = await this.CountryRepository.Create(this.DalCountryMapper.MapBOToEF(bo));

				var businessObject = this.DalCountryMapper.MapEFToBO(record);
				response.SetRecord(this.BolCountryMapper.MapBOToModel(businessObject));
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
				var bo = this.BolCountryMapper.MapModelToBO(id, model);
				await this.CountryRepository.Update(this.DalCountryMapper.MapBOToEF(bo));

				var record = await this.CountryRepository.Get(id);

				var businessObject = this.DalCountryMapper.MapEFToBO(record);
				var apiModel = this.BolCountryMapper.MapBOToModel(businessObject);
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

			return this.BolCountryRequirementMapper.MapBOToModel(this.DalCountryRequirementMapper.MapEFToBO(records));
		}

		public async virtual Task<List<ApiDestinationServerResponseModel>> DestinationsByCountryId(int countryId, int limit = int.MaxValue, int offset = 0)
		{
			List<Destination> records = await this.CountryRepository.DestinationsByCountryId(countryId, limit, offset);

			return this.BolDestinationMapper.MapBOToModel(this.DalDestinationMapper.MapEFToBO(records));
		}
	}
}

/*<Codenesium>
    <Hash>76421e7bcadd2728b17a64fcdd56b709</Hash>
</Codenesium>*/