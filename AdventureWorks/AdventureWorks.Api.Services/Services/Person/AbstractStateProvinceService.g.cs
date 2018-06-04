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

namespace AdventureWorksNS.Api.Services
{
	public abstract class AbstractStateProvinceService: AbstractService
	{
		private IStateProvinceRepository stateProvinceRepository;
		private IApiStateProvinceRequestModelValidator stateProvinceModelValidator;
		private IBOLStateProvinceMapper BOLStateProvinceMapper;
		private IDALStateProvinceMapper DALStateProvinceMapper;
		private ILogger logger;

		public AbstractStateProvinceService(
			ILogger logger,
			IStateProvinceRepository stateProvinceRepository,
			IApiStateProvinceRequestModelValidator stateProvinceModelValidator,
			IBOLStateProvinceMapper bolstateProvinceMapper,
			IDALStateProvinceMapper dalstateProvinceMapper)
			: base()

		{
			this.stateProvinceRepository = stateProvinceRepository;
			this.stateProvinceModelValidator = stateProvinceModelValidator;
			this.BOLStateProvinceMapper = bolstateProvinceMapper;
			this.DALStateProvinceMapper = dalstateProvinceMapper;
			this.logger = logger;
		}

		public virtual async Task<List<ApiStateProvinceResponseModel>> All(int skip = 0, int take = int.MaxValue, string orderClause = "")
		{
			var records = await this.stateProvinceRepository.All(skip, take, orderClause);

			return this.BOLStateProvinceMapper.MapBOToModel(this.DALStateProvinceMapper.MapEFToBO(records));
		}

		public virtual async Task<ApiStateProvinceResponseModel> Get(int stateProvinceID)
		{
			var record = await stateProvinceRepository.Get(stateProvinceID);

			return this.BOLStateProvinceMapper.MapBOToModel(this.DALStateProvinceMapper.MapEFToBO(record));
		}

		public virtual async Task<CreateResponse<ApiStateProvinceResponseModel>> Create(
			ApiStateProvinceRequestModel model)
		{
			CreateResponse<ApiStateProvinceResponseModel> response = new CreateResponse<ApiStateProvinceResponseModel>(await this.stateProvinceModelValidator.ValidateCreateAsync(model));
			if (response.Success)
			{
				var bo = this.BOLStateProvinceMapper.MapModelToBO(default (int), model);
				var record = await this.stateProvinceRepository.Create(this.DALStateProvinceMapper.MapBOToEF(bo));

				response.SetRecord(this.BOLStateProvinceMapper.MapBOToModel(this.DALStateProvinceMapper.MapEFToBO(record)));
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
				var bo = this.BOLStateProvinceMapper.MapModelToBO(stateProvinceID, model);
				await this.stateProvinceRepository.Update(this.DALStateProvinceMapper.MapBOToEF(bo));
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
			StateProvince record = await this.stateProvinceRepository.GetName(name);

			return this.BOLStateProvinceMapper.MapBOToModel(this.DALStateProvinceMapper.MapEFToBO(record));
		}
		public async Task<ApiStateProvinceResponseModel> GetStateProvinceCodeCountryRegionCode(string stateProvinceCode,string countryRegionCode)
		{
			StateProvince record = await this.stateProvinceRepository.GetStateProvinceCodeCountryRegionCode(stateProvinceCode,countryRegionCode);

			return this.BOLStateProvinceMapper.MapBOToModel(this.DALStateProvinceMapper.MapEFToBO(record));
		}
	}
}

/*<Codenesium>
    <Hash>e5a5994ced3636d8709c158fa500979d</Hash>
</Codenesium>*/