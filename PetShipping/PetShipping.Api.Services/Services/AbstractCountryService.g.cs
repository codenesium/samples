using Codenesium.DataConversionExtensions;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;
using PetShippingNS.Api.Contracts;
using PetShippingNS.Api.DataAccess;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Dynamic.Core;
using System.Linq.Expressions;
using System.Threading.Tasks;

namespace PetShippingNS.Api.Services
{
	public abstract class AbstractCountryService : AbstractService
	{
		private ICountryRepository countryRepository;

		private IApiCountryRequestModelValidator countryModelValidator;

		private IBOLCountryMapper bolCountryMapper;

		private IDALCountryMapper dalCountryMapper;

		private IBOLCountryRequirementMapper bolCountryRequirementMapper;

		private IDALCountryRequirementMapper dalCountryRequirementMapper;
		private IBOLDestinationMapper bolDestinationMapper;

		private IDALDestinationMapper dalDestinationMapper;

		private ILogger logger;

		public AbstractCountryService(
			ILogger logger,
			ICountryRepository countryRepository,
			IApiCountryRequestModelValidator countryModelValidator,
			IBOLCountryMapper bolCountryMapper,
			IDALCountryMapper dalCountryMapper,
			IBOLCountryRequirementMapper bolCountryRequirementMapper,
			IDALCountryRequirementMapper dalCountryRequirementMapper,
			IBOLDestinationMapper bolDestinationMapper,
			IDALDestinationMapper dalDestinationMapper)
			: base()
		{
			this.countryRepository = countryRepository;
			this.countryModelValidator = countryModelValidator;
			this.bolCountryMapper = bolCountryMapper;
			this.dalCountryMapper = dalCountryMapper;
			this.bolCountryRequirementMapper = bolCountryRequirementMapper;
			this.dalCountryRequirementMapper = dalCountryRequirementMapper;
			this.bolDestinationMapper = bolDestinationMapper;
			this.dalDestinationMapper = dalDestinationMapper;
			this.logger = logger;
		}

		public virtual async Task<List<ApiCountryResponseModel>> All(int limit = 0, int offset = int.MaxValue)
		{
			var records = await this.countryRepository.All(limit, offset);

			return this.bolCountryMapper.MapBOToModel(this.dalCountryMapper.MapEFToBO(records));
		}

		public virtual async Task<ApiCountryResponseModel> Get(int id)
		{
			var record = await this.countryRepository.Get(id);

			if (record == null)
			{
				return null;
			}
			else
			{
				return this.bolCountryMapper.MapBOToModel(this.dalCountryMapper.MapEFToBO(record));
			}
		}

		public virtual async Task<CreateResponse<ApiCountryResponseModel>> Create(
			ApiCountryRequestModel model)
		{
			CreateResponse<ApiCountryResponseModel> response = new CreateResponse<ApiCountryResponseModel>(await this.countryModelValidator.ValidateCreateAsync(model));
			if (response.Success)
			{
				var bo = this.bolCountryMapper.MapModelToBO(default(int), model);
				var record = await this.countryRepository.Create(this.dalCountryMapper.MapBOToEF(bo));

				response.SetRecord(this.bolCountryMapper.MapBOToModel(this.dalCountryMapper.MapEFToBO(record)));
			}

			return response;
		}

		public virtual async Task<UpdateResponse<ApiCountryResponseModel>> Update(
			int id,
			ApiCountryRequestModel model)
		{
			var validationResult = await this.countryModelValidator.ValidateUpdateAsync(id, model);

			if (validationResult.IsValid)
			{
				var bo = this.bolCountryMapper.MapModelToBO(id, model);
				await this.countryRepository.Update(this.dalCountryMapper.MapBOToEF(bo));

				var record = await this.countryRepository.Get(id);

				return new UpdateResponse<ApiCountryResponseModel>(this.bolCountryMapper.MapBOToModel(this.dalCountryMapper.MapEFToBO(record)));
			}
			else
			{
				return new UpdateResponse<ApiCountryResponseModel>(validationResult);
			}
		}

		public virtual async Task<ActionResponse> Delete(
			int id)
		{
			ActionResponse response = new ActionResponse(await this.countryModelValidator.ValidateDeleteAsync(id));
			if (response.Success)
			{
				await this.countryRepository.Delete(id);
			}

			return response;
		}

		public async virtual Task<List<ApiCountryRequirementResponseModel>> CountryRequirements(int countryId, int limit = int.MaxValue, int offset = 0)
		{
			List<CountryRequirement> records = await this.countryRepository.CountryRequirements(countryId, limit, offset);

			return this.bolCountryRequirementMapper.MapBOToModel(this.dalCountryRequirementMapper.MapEFToBO(records));
		}

		public async virtual Task<List<ApiDestinationResponseModel>> Destinations(int countryId, int limit = int.MaxValue, int offset = 0)
		{
			List<Destination> records = await this.countryRepository.Destinations(countryId, limit, offset);

			return this.bolDestinationMapper.MapBOToModel(this.dalDestinationMapper.MapEFToBO(records));
		}
	}
}

/*<Codenesium>
    <Hash>2b2f268ea5b0b80fd783594b816c1cc3</Hash>
</Codenesium>*/