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
		private ICountryRequirementRepository countryRequirementRepository;

		private IApiCountryRequirementRequestModelValidator countryRequirementModelValidator;

		private IBOLCountryRequirementMapper bolCountryRequirementMapper;

		private IDALCountryRequirementMapper dalCountryRequirementMapper;

		private ILogger logger;

		public AbstractCountryRequirementService(
			ILogger logger,
			ICountryRequirementRepository countryRequirementRepository,
			IApiCountryRequirementRequestModelValidator countryRequirementModelValidator,
			IBOLCountryRequirementMapper bolCountryRequirementMapper,
			IDALCountryRequirementMapper dalCountryRequirementMapper)
			: base()
		{
			this.countryRequirementRepository = countryRequirementRepository;
			this.countryRequirementModelValidator = countryRequirementModelValidator;
			this.bolCountryRequirementMapper = bolCountryRequirementMapper;
			this.dalCountryRequirementMapper = dalCountryRequirementMapper;
			this.logger = logger;
		}

		public virtual async Task<List<ApiCountryRequirementResponseModel>> All(int limit = 0, int offset = int.MaxValue)
		{
			var records = await this.countryRequirementRepository.All(limit, offset);

			return this.bolCountryRequirementMapper.MapBOToModel(this.dalCountryRequirementMapper.MapEFToBO(records));
		}

		public virtual async Task<ApiCountryRequirementResponseModel> Get(int id)
		{
			var record = await this.countryRequirementRepository.Get(id);

			if (record == null)
			{
				return null;
			}
			else
			{
				return this.bolCountryRequirementMapper.MapBOToModel(this.dalCountryRequirementMapper.MapEFToBO(record));
			}
		}

		public virtual async Task<CreateResponse<ApiCountryRequirementResponseModel>> Create(
			ApiCountryRequirementRequestModel model)
		{
			CreateResponse<ApiCountryRequirementResponseModel> response = new CreateResponse<ApiCountryRequirementResponseModel>(await this.countryRequirementModelValidator.ValidateCreateAsync(model));
			if (response.Success)
			{
				var bo = this.bolCountryRequirementMapper.MapModelToBO(default(int), model);
				var record = await this.countryRequirementRepository.Create(this.dalCountryRequirementMapper.MapBOToEF(bo));

				response.SetRecord(this.bolCountryRequirementMapper.MapBOToModel(this.dalCountryRequirementMapper.MapEFToBO(record)));
			}

			return response;
		}

		public virtual async Task<UpdateResponse<ApiCountryRequirementResponseModel>> Update(
			int id,
			ApiCountryRequirementRequestModel model)
		{
			var validationResult = await this.countryRequirementModelValidator.ValidateUpdateAsync(id, model);

			if (validationResult.IsValid)
			{
				var bo = this.bolCountryRequirementMapper.MapModelToBO(id, model);
				await this.countryRequirementRepository.Update(this.dalCountryRequirementMapper.MapBOToEF(bo));

				var record = await this.countryRequirementRepository.Get(id);

				return new UpdateResponse<ApiCountryRequirementResponseModel>(this.bolCountryRequirementMapper.MapBOToModel(this.dalCountryRequirementMapper.MapEFToBO(record)));
			}
			else
			{
				return new UpdateResponse<ApiCountryRequirementResponseModel>(validationResult);
			}
		}

		public virtual async Task<ActionResponse> Delete(
			int id)
		{
			ActionResponse response = new ActionResponse(await this.countryRequirementModelValidator.ValidateDeleteAsync(id));
			if (response.Success)
			{
				await this.countryRequirementRepository.Delete(id);
			}

			return response;
		}
	}
}

/*<Codenesium>
    <Hash>70d0177dd9ea1552eebf8fce9a1d9d36</Hash>
</Codenesium>*/