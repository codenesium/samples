using Codenesium.DataConversionExtensions.AspNetCore;
using System;
using System.Collections.Generic;
using Microsoft.Extensions.Logging;
using Microsoft.EntityFrameworkCore;
using System.Linq;
using System.Linq.Dynamic.Core;
using System.Linq.Expressions;
using System.Threading.Tasks;
using PetShippingNS.Api.Contracts;
using PetShippingNS.Api.DataAccess;

namespace PetShippingNS.Api.BusinessObjects
{
	public abstract class AbstractBOCountryRequirement: AbstractBOManager
	{
		private ICountryRequirementRepository countryRequirementRepository;
		private IApiCountryRequirementRequestModelValidator countryRequirementModelValidator;
		private IBOLCountryRequirementMapper countryRequirementMapper;
		private ILogger logger;

		public AbstractBOCountryRequirement(
			ILogger logger,
			ICountryRequirementRepository countryRequirementRepository,
			IApiCountryRequirementRequestModelValidator countryRequirementModelValidator,
			IBOLCountryRequirementMapper countryRequirementMapper)
			: base()

		{
			this.countryRequirementRepository = countryRequirementRepository;
			this.countryRequirementModelValidator = countryRequirementModelValidator;
			this.countryRequirementMapper = countryRequirementMapper;
			this.logger = logger;
		}

		public virtual async Task<List<ApiCountryRequirementResponseModel>> All(int skip = 0, int take = int.MaxValue, string orderClause = "")
		{
			var records = await this.countryRequirementRepository.All(skip, take, orderClause);

			return this.countryRequirementMapper.MapDTOToModel(records);
		}

		public virtual async Task<ApiCountryRequirementResponseModel> Get(int id)
		{
			var record = await countryRequirementRepository.Get(id);

			return this.countryRequirementMapper.MapDTOToModel(record);
		}

		public virtual async Task<CreateResponse<ApiCountryRequirementResponseModel>> Create(
			ApiCountryRequirementRequestModel model)
		{
			CreateResponse<ApiCountryRequirementResponseModel> response = new CreateResponse<ApiCountryRequirementResponseModel>(await this.countryRequirementModelValidator.ValidateCreateAsync(model));
			if (response.Success)
			{
				var dto = this.countryRequirementMapper.MapModelToDTO(default (int), model);
				var record = await this.countryRequirementRepository.Create(dto);

				response.SetRecord(this.countryRequirementMapper.MapDTOToModel(record));
			}
			return response;
		}

		public virtual async Task<ActionResponse> Update(
			int id,
			ApiCountryRequirementRequestModel model)
		{
			ActionResponse response = new ActionResponse(await this.countryRequirementModelValidator.ValidateUpdateAsync(id, model));

			if (response.Success)
			{
				var dto = this.countryRequirementMapper.MapModelToDTO(id, model);
				await this.countryRequirementRepository.Update(id, dto);
			}

			return response;
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
    <Hash>2faf96c6e33dcd06b28740f9a16fdfea</Hash>
</Codenesium>*/