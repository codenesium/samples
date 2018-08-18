using AdventureWorksNS.Api.Contracts;
using AdventureWorksNS.Api.DataAccess;
using Codenesium.DataConversionExtensions;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Dynamic.Core;
using System.Linq.Expressions;
using System.Threading.Tasks;

namespace AdventureWorksNS.Api.Services
{
	public abstract class AbstractStateProvinceService : AbstractService
	{
		protected IStateProvinceRepository StateProvinceRepository { get; private set; }

		protected IApiStateProvinceRequestModelValidator StateProvinceModelValidator { get; private set; }

		protected IBOLStateProvinceMapper BolStateProvinceMapper { get; private set; }

		protected IDALStateProvinceMapper DalStateProvinceMapper { get; private set; }

		protected IBOLAddressMapper BolAddressMapper { get; private set; }

		protected IDALAddressMapper DalAddressMapper { get; private set; }

		private ILogger logger;

		public AbstractStateProvinceService(
			ILogger logger,
			IStateProvinceRepository stateProvinceRepository,
			IApiStateProvinceRequestModelValidator stateProvinceModelValidator,
			IBOLStateProvinceMapper bolStateProvinceMapper,
			IDALStateProvinceMapper dalStateProvinceMapper,
			IBOLAddressMapper bolAddressMapper,
			IDALAddressMapper dalAddressMapper)
			: base()
		{
			this.StateProvinceRepository = stateProvinceRepository;
			this.StateProvinceModelValidator = stateProvinceModelValidator;
			this.BolStateProvinceMapper = bolStateProvinceMapper;
			this.DalStateProvinceMapper = dalStateProvinceMapper;
			this.BolAddressMapper = bolAddressMapper;
			this.DalAddressMapper = dalAddressMapper;
			this.logger = logger;
		}

		public virtual async Task<List<ApiStateProvinceResponseModel>> All(int limit = 0, int offset = int.MaxValue)
		{
			var records = await this.StateProvinceRepository.All(limit, offset);

			return this.BolStateProvinceMapper.MapBOToModel(this.DalStateProvinceMapper.MapEFToBO(records));
		}

		public virtual async Task<ApiStateProvinceResponseModel> Get(int stateProvinceID)
		{
			var record = await this.StateProvinceRepository.Get(stateProvinceID);

			if (record == null)
			{
				return null;
			}
			else
			{
				return this.BolStateProvinceMapper.MapBOToModel(this.DalStateProvinceMapper.MapEFToBO(record));
			}
		}

		public virtual async Task<CreateResponse<ApiStateProvinceResponseModel>> Create(
			ApiStateProvinceRequestModel model)
		{
			CreateResponse<ApiStateProvinceResponseModel> response = new CreateResponse<ApiStateProvinceResponseModel>(await this.StateProvinceModelValidator.ValidateCreateAsync(model));
			if (response.Success)
			{
				var bo = this.BolStateProvinceMapper.MapModelToBO(default(int), model);
				var record = await this.StateProvinceRepository.Create(this.DalStateProvinceMapper.MapBOToEF(bo));

				response.SetRecord(this.BolStateProvinceMapper.MapBOToModel(this.DalStateProvinceMapper.MapEFToBO(record)));
			}

			return response;
		}

		public virtual async Task<UpdateResponse<ApiStateProvinceResponseModel>> Update(
			int stateProvinceID,
			ApiStateProvinceRequestModel model)
		{
			var validationResult = await this.StateProvinceModelValidator.ValidateUpdateAsync(stateProvinceID, model);

			if (validationResult.IsValid)
			{
				var bo = this.BolStateProvinceMapper.MapModelToBO(stateProvinceID, model);
				await this.StateProvinceRepository.Update(this.DalStateProvinceMapper.MapBOToEF(bo));

				var record = await this.StateProvinceRepository.Get(stateProvinceID);

				return new UpdateResponse<ApiStateProvinceResponseModel>(this.BolStateProvinceMapper.MapBOToModel(this.DalStateProvinceMapper.MapEFToBO(record)));
			}
			else
			{
				return new UpdateResponse<ApiStateProvinceResponseModel>(validationResult);
			}
		}

		public virtual async Task<ActionResponse> Delete(
			int stateProvinceID)
		{
			ActionResponse response = new ActionResponse(await this.StateProvinceModelValidator.ValidateDeleteAsync(stateProvinceID));
			if (response.Success)
			{
				await this.StateProvinceRepository.Delete(stateProvinceID);
			}

			return response;
		}

		public async Task<ApiStateProvinceResponseModel> ByName(string name)
		{
			StateProvince record = await this.StateProvinceRepository.ByName(name);

			if (record == null)
			{
				return null;
			}
			else
			{
				return this.BolStateProvinceMapper.MapBOToModel(this.DalStateProvinceMapper.MapEFToBO(record));
			}
		}

		public async Task<ApiStateProvinceResponseModel> ByStateProvinceCodeCountryRegionCode(string stateProvinceCode, string countryRegionCode)
		{
			StateProvince record = await this.StateProvinceRepository.ByStateProvinceCodeCountryRegionCode(stateProvinceCode, countryRegionCode);

			if (record == null)
			{
				return null;
			}
			else
			{
				return this.BolStateProvinceMapper.MapBOToModel(this.DalStateProvinceMapper.MapEFToBO(record));
			}
		}

		public async virtual Task<List<ApiAddressResponseModel>> Addresses(int stateProvinceID, int limit = int.MaxValue, int offset = 0)
		{
			List<Address> records = await this.StateProvinceRepository.Addresses(stateProvinceID, limit, offset);

			return this.BolAddressMapper.MapBOToModel(this.DalAddressMapper.MapEFToBO(records));
		}
	}
}

/*<Codenesium>
    <Hash>c4d90e17c65b525c98bc79db62fb68e9</Hash>
</Codenesium>*/