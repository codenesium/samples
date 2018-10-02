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
	public abstract class AbstractVStateProvinceCountryRegionService : AbstractService
	{
		protected IVStateProvinceCountryRegionRepository VStateProvinceCountryRegionRepository { get; private set; }

		protected IApiVStateProvinceCountryRegionRequestModelValidator VStateProvinceCountryRegionModelValidator { get; private set; }

		protected IBOLVStateProvinceCountryRegionMapper BolVStateProvinceCountryRegionMapper { get; private set; }

		protected IDALVStateProvinceCountryRegionMapper DalVStateProvinceCountryRegionMapper { get; private set; }

		private ILogger logger;

		public AbstractVStateProvinceCountryRegionService(
			ILogger logger,
			IVStateProvinceCountryRegionRepository vStateProvinceCountryRegionRepository,
			IApiVStateProvinceCountryRegionRequestModelValidator vStateProvinceCountryRegionModelValidator,
			IBOLVStateProvinceCountryRegionMapper bolVStateProvinceCountryRegionMapper,
			IDALVStateProvinceCountryRegionMapper dalVStateProvinceCountryRegionMapper)
			: base()
		{
			this.VStateProvinceCountryRegionRepository = vStateProvinceCountryRegionRepository;
			this.VStateProvinceCountryRegionModelValidator = vStateProvinceCountryRegionModelValidator;
			this.BolVStateProvinceCountryRegionMapper = bolVStateProvinceCountryRegionMapper;
			this.DalVStateProvinceCountryRegionMapper = dalVStateProvinceCountryRegionMapper;
			this.logger = logger;
		}

		public virtual async Task<List<ApiVStateProvinceCountryRegionResponseModel>> All(int limit = 0, int offset = int.MaxValue)
		{
			var records = await this.VStateProvinceCountryRegionRepository.All(limit, offset);

			return this.BolVStateProvinceCountryRegionMapper.MapBOToModel(this.DalVStateProvinceCountryRegionMapper.MapEFToBO(records));
		}

		public virtual async Task<ApiVStateProvinceCountryRegionResponseModel> Get(int stateProvinceID)
		{
			var record = await this.VStateProvinceCountryRegionRepository.Get(stateProvinceID);

			if (record == null)
			{
				return null;
			}
			else
			{
				return this.BolVStateProvinceCountryRegionMapper.MapBOToModel(this.DalVStateProvinceCountryRegionMapper.MapEFToBO(record));
			}
		}

		public virtual async Task<CreateResponse<ApiVStateProvinceCountryRegionResponseModel>> Create(
			ApiVStateProvinceCountryRegionRequestModel model)
		{
			CreateResponse<ApiVStateProvinceCountryRegionResponseModel> response = new CreateResponse<ApiVStateProvinceCountryRegionResponseModel>(await this.VStateProvinceCountryRegionModelValidator.ValidateCreateAsync(model));
			if (response.Success)
			{
				var bo = this.BolVStateProvinceCountryRegionMapper.MapModelToBO(default(int), model);
				var record = await this.VStateProvinceCountryRegionRepository.Create(this.DalVStateProvinceCountryRegionMapper.MapBOToEF(bo));

				response.SetRecord(this.BolVStateProvinceCountryRegionMapper.MapBOToModel(this.DalVStateProvinceCountryRegionMapper.MapEFToBO(record)));
			}

			return response;
		}

		public virtual async Task<UpdateResponse<ApiVStateProvinceCountryRegionResponseModel>> Update(
			int stateProvinceID,
			ApiVStateProvinceCountryRegionRequestModel model)
		{
			var validationResult = await this.VStateProvinceCountryRegionModelValidator.ValidateUpdateAsync(stateProvinceID, model);

			if (validationResult.IsValid)
			{
				var bo = this.BolVStateProvinceCountryRegionMapper.MapModelToBO(stateProvinceID, model);
				await this.VStateProvinceCountryRegionRepository.Update(this.DalVStateProvinceCountryRegionMapper.MapBOToEF(bo));

				var record = await this.VStateProvinceCountryRegionRepository.Get(stateProvinceID);

				return new UpdateResponse<ApiVStateProvinceCountryRegionResponseModel>(this.BolVStateProvinceCountryRegionMapper.MapBOToModel(this.DalVStateProvinceCountryRegionMapper.MapEFToBO(record)));
			}
			else
			{
				return new UpdateResponse<ApiVStateProvinceCountryRegionResponseModel>(validationResult);
			}
		}

		public virtual async Task<ActionResponse> Delete(
			int stateProvinceID)
		{
			ActionResponse response = new ActionResponse(await this.VStateProvinceCountryRegionModelValidator.ValidateDeleteAsync(stateProvinceID));
			if (response.Success)
			{
				await this.VStateProvinceCountryRegionRepository.Delete(stateProvinceID);
			}

			return response;
		}

		public async Task<ApiVStateProvinceCountryRegionResponseModel> ByStateProvinceIDCountryRegionCode(int stateProvinceID, string countryRegionCode)
		{
			VStateProvinceCountryRegion record = await this.VStateProvinceCountryRegionRepository.ByStateProvinceIDCountryRegionCode(stateProvinceID, countryRegionCode);

			if (record == null)
			{
				return null;
			}
			else
			{
				return this.BolVStateProvinceCountryRegionMapper.MapBOToModel(this.DalVStateProvinceCountryRegionMapper.MapEFToBO(record));
			}
		}
	}
}

/*<Codenesium>
    <Hash>e353abfb762b765ee7dee69b4e0258a0</Hash>
</Codenesium>*/