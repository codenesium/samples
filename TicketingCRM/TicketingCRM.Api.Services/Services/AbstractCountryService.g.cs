using Codenesium.DataConversionExtensions;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Dynamic.Core;
using System.Linq.Expressions;
using System.Threading.Tasks;
using TicketingCRMNS.Api.Contracts;
using TicketingCRMNS.Api.DataAccess;

namespace TicketingCRMNS.Api.Services
{
	public abstract class AbstractCountryService : AbstractService
	{
		protected ICountryRepository CountryRepository { get; private set; }

		protected IApiCountryRequestModelValidator CountryModelValidator { get; private set; }

		protected IBOLCountryMapper BolCountryMapper { get; private set; }

		protected IDALCountryMapper DalCountryMapper { get; private set; }

		protected IBOLProvinceMapper BolProvinceMapper { get; private set; }

		protected IDALProvinceMapper DalProvinceMapper { get; private set; }

		private ILogger logger;

		public AbstractCountryService(
			ILogger logger,
			ICountryRepository countryRepository,
			IApiCountryRequestModelValidator countryModelValidator,
			IBOLCountryMapper bolCountryMapper,
			IDALCountryMapper dalCountryMapper,
			IBOLProvinceMapper bolProvinceMapper,
			IDALProvinceMapper dalProvinceMapper)
			: base()
		{
			this.CountryRepository = countryRepository;
			this.CountryModelValidator = countryModelValidator;
			this.BolCountryMapper = bolCountryMapper;
			this.DalCountryMapper = dalCountryMapper;
			this.BolProvinceMapper = bolProvinceMapper;
			this.DalProvinceMapper = dalProvinceMapper;
			this.logger = logger;
		}

		public virtual async Task<List<ApiCountryResponseModel>> All(int limit = 0, int offset = int.MaxValue)
		{
			var records = await this.CountryRepository.All(limit, offset);

			return this.BolCountryMapper.MapBOToModel(this.DalCountryMapper.MapEFToBO(records));
		}

		public virtual async Task<ApiCountryResponseModel> Get(int id)
		{
			var record = await this.CountryRepository.Get(id);

			if (record == null)
			{
				return null;
			}
			else
			{
				return this.BolCountryMapper.MapBOToModel(this.DalCountryMapper.MapEFToBO(record));
			}
		}

		public virtual async Task<CreateResponse<ApiCountryResponseModel>> Create(
			ApiCountryRequestModel model)
		{
			CreateResponse<ApiCountryResponseModel> response = new CreateResponse<ApiCountryResponseModel>(await this.CountryModelValidator.ValidateCreateAsync(model));
			if (response.Success)
			{
				var bo = this.BolCountryMapper.MapModelToBO(default(int), model);
				var record = await this.CountryRepository.Create(this.DalCountryMapper.MapBOToEF(bo));

				response.SetRecord(this.BolCountryMapper.MapBOToModel(this.DalCountryMapper.MapEFToBO(record)));
			}

			return response;
		}

		public virtual async Task<UpdateResponse<ApiCountryResponseModel>> Update(
			int id,
			ApiCountryRequestModel model)
		{
			var validationResult = await this.CountryModelValidator.ValidateUpdateAsync(id, model);

			if (validationResult.IsValid)
			{
				var bo = this.BolCountryMapper.MapModelToBO(id, model);
				await this.CountryRepository.Update(this.DalCountryMapper.MapBOToEF(bo));

				var record = await this.CountryRepository.Get(id);

				return new UpdateResponse<ApiCountryResponseModel>(this.BolCountryMapper.MapBOToModel(this.DalCountryMapper.MapEFToBO(record)));
			}
			else
			{
				return new UpdateResponse<ApiCountryResponseModel>(validationResult);
			}
		}

		public virtual async Task<ActionResponse> Delete(
			int id)
		{
			ActionResponse response = new ActionResponse(await this.CountryModelValidator.ValidateDeleteAsync(id));
			if (response.Success)
			{
				await this.CountryRepository.Delete(id);
			}

			return response;
		}

		public async virtual Task<List<ApiProvinceResponseModel>> Provinces(int countryId, int limit = int.MaxValue, int offset = 0)
		{
			List<Province> records = await this.CountryRepository.Provinces(countryId, limit, offset);

			return this.BolProvinceMapper.MapBOToModel(this.DalProvinceMapper.MapEFToBO(records));
		}
	}
}

/*<Codenesium>
    <Hash>3058e5ad727a8d5b4c794d011f7d76c9</Hash>
</Codenesium>*/