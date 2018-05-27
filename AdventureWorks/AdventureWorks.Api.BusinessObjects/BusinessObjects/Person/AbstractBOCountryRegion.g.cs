using Codenesium.DataConversionExtensions.AspNetCore;
using System;
using System.Collections.Generic;
using Microsoft.Extensions.Logging;
using Microsoft.EntityFrameworkCore;
using System.Linq;
using System.Linq.Dynamic.Core;
using System.Linq.Expressions;
using System.Threading.Tasks;
using AdventureWorksNS.Api.Contracts;
using AdventureWorksNS.Api.DataAccess;

namespace AdventureWorksNS.Api.BusinessObjects
{
	public abstract class AbstractBOCountryRegion: AbstractBOManager
	{
		private ICountryRegionRepository countryRegionRepository;
		private IApiCountryRegionRequestModelValidator countryRegionModelValidator;
		private IBOLCountryRegionMapper countryRegionMapper;
		private ILogger logger;

		public AbstractBOCountryRegion(
			ILogger logger,
			ICountryRegionRepository countryRegionRepository,
			IApiCountryRegionRequestModelValidator countryRegionModelValidator,
			IBOLCountryRegionMapper countryRegionMapper)
			: base()

		{
			this.countryRegionRepository = countryRegionRepository;
			this.countryRegionModelValidator = countryRegionModelValidator;
			this.countryRegionMapper = countryRegionMapper;
			this.logger = logger;
		}

		public virtual async Task<List<ApiCountryRegionResponseModel>> All(int skip = 0, int take = int.MaxValue, string orderClause = "")
		{
			var records = await this.countryRegionRepository.All(skip, take, orderClause);

			return this.countryRegionMapper.MapDTOToModel(records);
		}

		public virtual async Task<ApiCountryRegionResponseModel> Get(string countryRegionCode)
		{
			var record = await countryRegionRepository.Get(countryRegionCode);

			return this.countryRegionMapper.MapDTOToModel(record);
		}

		public virtual async Task<CreateResponse<ApiCountryRegionResponseModel>> Create(
			ApiCountryRegionRequestModel model)
		{
			CreateResponse<ApiCountryRegionResponseModel> response = new CreateResponse<ApiCountryRegionResponseModel>(await this.countryRegionModelValidator.ValidateCreateAsync(model));
			if (response.Success)
			{
				var dto = this.countryRegionMapper.MapModelToDTO(default (string), model);
				var record = await this.countryRegionRepository.Create(dto);

				response.SetRecord(this.countryRegionMapper.MapDTOToModel(record));
			}
			return response;
		}

		public virtual async Task<ActionResponse> Update(
			string countryRegionCode,
			ApiCountryRegionRequestModel model)
		{
			ActionResponse response = new ActionResponse(await this.countryRegionModelValidator.ValidateUpdateAsync(countryRegionCode, model));

			if (response.Success)
			{
				var dto = this.countryRegionMapper.MapModelToDTO(countryRegionCode, model);
				await this.countryRegionRepository.Update(countryRegionCode, dto);
			}

			return response;
		}

		public virtual async Task<ActionResponse> Delete(
			string countryRegionCode)
		{
			ActionResponse response = new ActionResponse(await this.countryRegionModelValidator.ValidateDeleteAsync(countryRegionCode));

			if (response.Success)
			{
				await this.countryRegionRepository.Delete(countryRegionCode);
			}
			return response;
		}

		public async Task<ApiCountryRegionResponseModel> GetName(string name)
		{
			DTOCountryRegion record = await this.countryRegionRepository.GetName(name);

			return this.countryRegionMapper.MapDTOToModel(record);
		}
	}
}

/*<Codenesium>
    <Hash>6c630c4e10ae5f3e344247925151d3a1</Hash>
</Codenesium>*/