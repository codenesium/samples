using MediatR;
using Microsoft.Extensions.Logging;
using PetShippingNS.Api.Contracts;
using PetShippingNS.Api.DataAccess;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace PetShippingNS.Api.Services
{
	public abstract class AbstractCountryRequirementService : AbstractService
	{
		private IMediator mediator;

		protected ICountryRequirementRepository CountryRequirementRepository { get; private set; }

		protected IApiCountryRequirementServerRequestModelValidator CountryRequirementModelValidator { get; private set; }

		protected IDALCountryRequirementMapper DalCountryRequirementMapper { get; private set; }

		private ILogger logger;

		public AbstractCountryRequirementService(
			ILogger logger,
			IMediator mediator,
			ICountryRequirementRepository countryRequirementRepository,
			IApiCountryRequirementServerRequestModelValidator countryRequirementModelValidator,
			IDALCountryRequirementMapper dalCountryRequirementMapper)
			: base()
		{
			this.CountryRequirementRepository = countryRequirementRepository;
			this.CountryRequirementModelValidator = countryRequirementModelValidator;
			this.DalCountryRequirementMapper = dalCountryRequirementMapper;
			this.logger = logger;

			this.mediator = mediator;
		}

		public virtual async Task<List<ApiCountryRequirementServerResponseModel>> All(int limit = 0, int offset = int.MaxValue, string query = "")
		{
			List<CountryRequirement> records = await this.CountryRequirementRepository.All(limit, offset, query);

			return this.DalCountryRequirementMapper.MapEntityToModel(records);
		}

		public virtual async Task<ApiCountryRequirementServerResponseModel> Get(int id)
		{
			CountryRequirement record = await this.CountryRequirementRepository.Get(id);

			if (record == null)
			{
				return null;
			}
			else
			{
				return this.DalCountryRequirementMapper.MapEntityToModel(record);
			}
		}

		public virtual async Task<CreateResponse<ApiCountryRequirementServerResponseModel>> Create(
			ApiCountryRequirementServerRequestModel model)
		{
			CreateResponse<ApiCountryRequirementServerResponseModel> response = ValidationResponseFactory<ApiCountryRequirementServerResponseModel>.CreateResponse(await this.CountryRequirementModelValidator.ValidateCreateAsync(model));

			if (response.Success)
			{
				CountryRequirement record = this.DalCountryRequirementMapper.MapModelToEntity(default(int), model);
				record = await this.CountryRequirementRepository.Create(record);

				response.SetRecord(this.DalCountryRequirementMapper.MapEntityToModel(record));
				await this.mediator.Publish(new CountryRequirementCreatedNotification(response.Record));
			}

			return response;
		}

		public virtual async Task<UpdateResponse<ApiCountryRequirementServerResponseModel>> Update(
			int id,
			ApiCountryRequirementServerRequestModel model)
		{
			var validationResult = await this.CountryRequirementModelValidator.ValidateUpdateAsync(id, model);

			if (validationResult.IsValid)
			{
				CountryRequirement record = this.DalCountryRequirementMapper.MapModelToEntity(id, model);
				await this.CountryRequirementRepository.Update(record);

				record = await this.CountryRequirementRepository.Get(id);

				ApiCountryRequirementServerResponseModel apiModel = this.DalCountryRequirementMapper.MapEntityToModel(record);
				await this.mediator.Publish(new CountryRequirementUpdatedNotification(apiModel));

				return ValidationResponseFactory<ApiCountryRequirementServerResponseModel>.UpdateResponse(apiModel);
			}
			else
			{
				return ValidationResponseFactory<ApiCountryRequirementServerResponseModel>.UpdateResponse(validationResult);
			}
		}

		public virtual async Task<ActionResponse> Delete(
			int id)
		{
			ActionResponse response = ValidationResponseFactory<object>.ActionResponse(await this.CountryRequirementModelValidator.ValidateDeleteAsync(id));

			if (response.Success)
			{
				await this.CountryRequirementRepository.Delete(id);

				await this.mediator.Publish(new CountryRequirementDeletedNotification(id));
			}

			return response;
		}
	}
}

/*<Codenesium>
    <Hash>b9c1beb025309a542981a8c679442561</Hash>
</Codenesium>*/