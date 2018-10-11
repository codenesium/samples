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
	}
}

/*<Codenesium>
    <Hash>3d822272d6c986d8b1d3a7567db3b1d1</Hash>
</Codenesium>*/