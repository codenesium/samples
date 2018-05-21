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
		private IApiStateProvinceModelValidator stateProvinceModelValidator;
		private ILogger logger;

		public AbstractBOStateProvince(
			ILogger logger,
			IStateProvinceRepository stateProvinceRepository,
			IApiStateProvinceModelValidator stateProvinceModelValidator)
			: base()

		{
			this.stateProvinceRepository = stateProvinceRepository;
			this.stateProvinceModelValidator = stateProvinceModelValidator;
			this.logger = logger;
		}

		public virtual Task<List<POCOStateProvince>> All(int skip = 0, int take = int.MaxValue, string orderClause = "")
		{
			return this.stateProvinceRepository.All(skip, take, orderClause);
		}

		public virtual Task<POCOStateProvince> Get(int stateProvinceID)
		{
			return this.stateProvinceRepository.Get(stateProvinceID);
		}

		public virtual async Task<CreateResponse<POCOStateProvince>> Create(
			ApiStateProvinceModel model)
		{
			CreateResponse<POCOStateProvince> response = new CreateResponse<POCOStateProvince>(await this.stateProvinceModelValidator.ValidateCreateAsync(model));
			if (response.Success)
			{
				POCOStateProvince record = await this.stateProvinceRepository.Create(model);

				response.SetRecord(record);
			}

			return response;
		}

		public virtual async Task<ActionResponse> Update(
			int stateProvinceID,
			ApiStateProvinceModel model)
		{
			ActionResponse response = new ActionResponse(await this.stateProvinceModelValidator.ValidateUpdateAsync(stateProvinceID, model));

			if (response.Success)
			{
				await this.stateProvinceRepository.Update(stateProvinceID, model);
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

		public async Task<POCOStateProvince> GetName(string name)
		{
			return await this.stateProvinceRepository.GetName(name);
		}
		public async Task<POCOStateProvince> GetStateProvinceCodeCountryRegionCode(string stateProvinceCode,string countryRegionCode)
		{
			return await this.stateProvinceRepository.GetStateProvinceCodeCountryRegionCode(stateProvinceCode,countryRegionCode);
		}
	}
}

/*<Codenesium>
    <Hash>13220ef9364d8e8899d99652045113c9</Hash>
</Codenesium>*/