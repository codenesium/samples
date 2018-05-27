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
	public abstract class AbstractBOStateProvince: AbstractBOManager
	{
		private IStateProvinceRepository stateProvinceRepository;
		private IApiStateProvinceRequestModelValidator stateProvinceModelValidator;
		private IBOLStateProvinceMapper stateProvinceMapper;
		private ILogger logger;

		public AbstractBOStateProvince(
			ILogger logger,
			IStateProvinceRepository stateProvinceRepository,
			IApiStateProvinceRequestModelValidator stateProvinceModelValidator,
			IBOLStateProvinceMapper stateProvinceMapper)
			: base()

		{
			this.stateProvinceRepository = stateProvinceRepository;
			this.stateProvinceModelValidator = stateProvinceModelValidator;
			this.stateProvinceMapper = stateProvinceMapper;
			this.logger = logger;
		}

		public virtual async Task<List<ApiStateProvinceResponseModel>> All(int skip = 0, int take = int.MaxValue, string orderClause = "")
		{
			var records = await this.stateProvinceRepository.All(skip, take, orderClause);

			return this.stateProvinceMapper.MapDTOToModel(records);
		}

		public virtual async Task<ApiStateProvinceResponseModel> Get(int stateProvinceID)
		{
			var record = await stateProvinceRepository.Get(stateProvinceID);

			return this.stateProvinceMapper.MapDTOToModel(record);
		}

		public virtual async Task<CreateResponse<ApiStateProvinceResponseModel>> Create(
			ApiStateProvinceRequestModel model)
		{
			CreateResponse<ApiStateProvinceResponseModel> response = new CreateResponse<ApiStateProvinceResponseModel>(await this.stateProvinceModelValidator.ValidateCreateAsync(model));
			if (response.Success)
			{
				var dto = this.stateProvinceMapper.MapModelToDTO(default (int), model);
				var record = await this.stateProvinceRepository.Create(dto);

				response.SetRecord(this.stateProvinceMapper.MapDTOToModel(record));
			}
			return response;
		}

		public virtual async Task<ActionResponse> Update(
			int stateProvinceID,
			ApiStateProvinceRequestModel model)
		{
			ActionResponse response = new ActionResponse(await this.stateProvinceModelValidator.ValidateUpdateAsync(stateProvinceID, model));

			if (response.Success)
			{
				var dto = this.stateProvinceMapper.MapModelToDTO(stateProvinceID, model);
				await this.stateProvinceRepository.Update(stateProvinceID, dto);
			}

			return response;
		}

		public virtual async Task<ActionResponse> Delete(
			int stateProvinceID)
		{
			ActionResponse response = new ActionResponse(await this.stateProvinceModelValidator.ValidateDeleteAsync(stateProvinceID));

			if (response.Success)
			{
				await this.stateProvinceRepository.Delete(stateProvinceID);
			}
			return response;
		}

		public async Task<ApiStateProvinceResponseModel> GetName(string name)
		{
			DTOStateProvince record = await this.stateProvinceRepository.GetName(name);

			return this.stateProvinceMapper.MapDTOToModel(record);
		}
		public async Task<ApiStateProvinceResponseModel> GetStateProvinceCodeCountryRegionCode(string stateProvinceCode,string countryRegionCode)
		{
			DTOStateProvince record = await this.stateProvinceRepository.GetStateProvinceCodeCountryRegionCode(stateProvinceCode,countryRegionCode);

			return this.stateProvinceMapper.MapDTOToModel(record);
		}
	}
}

/*<Codenesium>
    <Hash>a52b65cf92988ba531d3001d6d7eb981</Hash>
</Codenesium>*/