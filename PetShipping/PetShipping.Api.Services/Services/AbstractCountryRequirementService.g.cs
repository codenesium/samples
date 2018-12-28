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

		protected IBOLCountryRequirementMapper BolCountryRequirementMapper { get; private set; }

		protected IDALCountryRequirementMapper DalCountryRequirementMapper { get; private set; }

		private ILogger logger;

		public AbstractCountryRequirementService(
			ILogger logger,
			IMediator mediator,
			ICountryRequirementRepository countryRequirementRepository,
			IApiCountryRequirementServerRequestModelValidator countryRequirementModelValidator,
			IBOLCountryRequirementMapper bolCountryRequirementMapper,
			IDALCountryRequirementMapper dalCountryRequirementMapper)
			: base()
		{
			this.CountryRequirementRepository = countryRequirementRepository;
			this.CountryRequirementModelValidator = countryRequirementModelValidator;
			this.BolCountryRequirementMapper = bolCountryRequirementMapper;
			this.DalCountryRequirementMapper = dalCountryRequirementMapper;
			this.logger = logger;

			this.mediator = mediator;
		}

		public virtual async Task<List<ApiCountryRequirementServerResponseModel>> All(int limit = 0, int offset = int.MaxValue)
		{
			var records = await this.CountryRequirementRepository.All(limit, offset);

			return this.BolCountryRequirementMapper.MapBOToModel(this.DalCountryRequirementMapper.MapEFToBO(records));
		}

		public virtual async Task<ApiCountryRequirementServerResponseModel> Get(int id)
		{
			var record = await this.CountryRequirementRepository.Get(id);

			if (record == null)
			{
				return null;
			}
			else
			{
				return this.BolCountryRequirementMapper.MapBOToModel(this.DalCountryRequirementMapper.MapEFToBO(record));
			}
		}

		public virtual async Task<CreateResponse<ApiCountryRequirementServerResponseModel>> Create(
			ApiCountryRequirementServerRequestModel model)
		{
			CreateResponse<ApiCountryRequirementServerResponseModel> response = ValidationResponseFactory<ApiCountryRequirementServerResponseModel>.CreateResponse(await this.CountryRequirementModelValidator.ValidateCreateAsync(model));

			if (response.Success)
			{
				var bo = this.BolCountryRequirementMapper.MapModelToBO(default(int), model);
				var record = await this.CountryRequirementRepository.Create(this.DalCountryRequirementMapper.MapBOToEF(bo));

				var businessObject = this.DalCountryRequirementMapper.MapEFToBO(record);
				response.SetRecord(this.BolCountryRequirementMapper.MapBOToModel(businessObject));
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
				var bo = this.BolCountryRequirementMapper.MapModelToBO(id, model);
				await this.CountryRequirementRepository.Update(this.DalCountryRequirementMapper.MapBOToEF(bo));

				var record = await this.CountryRequirementRepository.Get(id);

				var businessObject = this.DalCountryRequirementMapper.MapEFToBO(record);
				var apiModel = this.BolCountryRequirementMapper.MapBOToModel(businessObject);
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
    <Hash>d1715a94516783b432f37a2815fb7734</Hash>
</Codenesium>*/