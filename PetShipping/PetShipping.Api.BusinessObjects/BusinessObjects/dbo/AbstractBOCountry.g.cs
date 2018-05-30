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
	public abstract class AbstractBOCountry: AbstractBOManager
	{
		private ICountryRepository countryRepository;
		private IApiCountryRequestModelValidator countryModelValidator;
		private IBOLCountryMapper countryMapper;
		private ILogger logger;

		public AbstractBOCountry(
			ILogger logger,
			ICountryRepository countryRepository,
			IApiCountryRequestModelValidator countryModelValidator,
			IBOLCountryMapper countryMapper)
			: base()

		{
			this.countryRepository = countryRepository;
			this.countryModelValidator = countryModelValidator;
			this.countryMapper = countryMapper;
			this.logger = logger;
		}

		public virtual async Task<List<ApiCountryResponseModel>> All(int skip = 0, int take = int.MaxValue, string orderClause = "")
		{
			var records = await this.countryRepository.All(skip, take, orderClause);

			return this.countryMapper.MapDTOToModel(records);
		}

		public virtual async Task<ApiCountryResponseModel> Get(int id)
		{
			var record = await countryRepository.Get(id);

			return this.countryMapper.MapDTOToModel(record);
		}

		public virtual async Task<CreateResponse<ApiCountryResponseModel>> Create(
			ApiCountryRequestModel model)
		{
			CreateResponse<ApiCountryResponseModel> response = new CreateResponse<ApiCountryResponseModel>(await this.countryModelValidator.ValidateCreateAsync(model));
			if (response.Success)
			{
				var dto = this.countryMapper.MapModelToDTO(default (int), model);
				var record = await this.countryRepository.Create(dto);

				response.SetRecord(this.countryMapper.MapDTOToModel(record));
			}
			return response;
		}

		public virtual async Task<ActionResponse> Update(
			int id,
			ApiCountryRequestModel model)
		{
			ActionResponse response = new ActionResponse(await this.countryModelValidator.ValidateUpdateAsync(id, model));

			if (response.Success)
			{
				var dto = this.countryMapper.MapModelToDTO(id, model);
				await this.countryRepository.Update(id, dto);
			}

			return response;
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
	}
}

/*<Codenesium>
    <Hash>8790fb80768115e4e2a01386b077ccdc</Hash>
</Codenesium>*/