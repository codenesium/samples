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
	public abstract class AbstractCountryRequirementService : AbstractService
	{
		protected ICountryRequirementRepository CountryRequirementRepository { get; private set; }

		protected IApiCountryRequirementRequestModelValidator CountryRequirementModelValidator { get; private set; }

		protected IBOLCountryRequirementMapper BolCountryRequirementMapper { get; private set; }

		protected IDALCountryRequirementMapper DalCountryRequirementMapper { get; private set; }

		private ILogger logger;

		public AbstractCountryRequirementService(
			ILogger logger,
			ICountryRequirementRepository countryRequirementRepository,
			IApiCountryRequirementRequestModelValidator countryRequirementModelValidator,
			IBOLCountryRequirementMapper bolCountryRequirementMapper,
			IDALCountryRequirementMapper dalCountryRequirementMapper)
			: base()
		{
			this.CountryRequirementRepository = countryRequirementRepository;
			this.CountryRequirementModelValidator = countryRequirementModelValidator;
			this.BolCountryRequirementMapper = bolCountryRequirementMapper;
			this.DalCountryRequirementMapper = dalCountryRequirementMapper;
			this.logger = logger;
		}

		public virtual async Task<List<ApiCountryRequirementResponseModel>> All(int limit = 0, int offset = int.MaxValue)
		{
			var records = await this.CountryRequirementRepository.All(limit, offset);

			return this.BolCountryRequirementMapper.MapBOToModel(this.DalCountryRequirementMapper.MapEFToBO(records));
		}

		public virtual async Task<ApiCountryRequirementResponseModel> Get(int id)
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

		public virtual async Task<CreateResponse<ApiCountryRequirementResponseModel>> Create(
			ApiCountryRequirementRequestModel model)
		{
			CreateResponse<ApiCountryRequirementResponseModel> response = new CreateResponse<ApiCountryRequirementResponseModel>(await this.CountryRequirementModelValidator.ValidateCreateAsync(model));
			if (response.Success)
			{
				var bo = this.BolCountryRequirementMapper.MapModelToBO(default(int), model);
				var record = await this.CountryRequirementRepository.Create(this.DalCountryRequirementMapper.MapBOToEF(bo));

				response.SetRecord(this.BolCountryRequirementMapper.MapBOToModel(this.DalCountryRequirementMapper.MapEFToBO(record)));
			}

			return response;
		}

		public virtual async Task<UpdateResponse<ApiCountryRequirementResponseModel>> Update(
			int id,
			ApiCountryRequirementRequestModel model)
		{
			var validationResult = await this.CountryRequirementModelValidator.ValidateUpdateAsync(id, model);

			if (validationResult.IsValid)
			{
				var bo = this.BolCountryRequirementMapper.MapModelToBO(id, model);
				await this.CountryRequirementRepository.Update(this.DalCountryRequirementMapper.MapBOToEF(bo));

				var record = await this.CountryRequirementRepository.Get(id);

				return new UpdateResponse<ApiCountryRequirementResponseModel>(this.BolCountryRequirementMapper.MapBOToModel(this.DalCountryRequirementMapper.MapEFToBO(record)));
			}
			else
			{
				return new UpdateResponse<ApiCountryRequirementResponseModel>(validationResult);
			}
		}

		public virtual async Task<ActionResponse> Delete(
			int id)
		{
			ActionResponse response = new ActionResponse(await this.CountryRequirementModelValidator.ValidateDeleteAsync(id));
			if (response.Success)
			{
				await this.CountryRequirementRepository.Delete(id);
			}

			return response;
		}
	}
}

/*<Codenesium>
    <Hash>060719504988627f3c55e430c1266352</Hash>
</Codenesium>*/