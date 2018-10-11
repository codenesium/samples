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
	public abstract class AbstractVProductAndDescriptionService : AbstractService
	{
		protected IVProductAndDescriptionRepository VProductAndDescriptionRepository { get; private set; }

		protected IApiVProductAndDescriptionRequestModelValidator VProductAndDescriptionModelValidator { get; private set; }

		protected IBOLVProductAndDescriptionMapper BolVProductAndDescriptionMapper { get; private set; }

		protected IDALVProductAndDescriptionMapper DalVProductAndDescriptionMapper { get; private set; }

		private ILogger logger;

		public AbstractVProductAndDescriptionService(
			ILogger logger,
			IVProductAndDescriptionRepository vProductAndDescriptionRepository,
			IApiVProductAndDescriptionRequestModelValidator vProductAndDescriptionModelValidator,
			IBOLVProductAndDescriptionMapper bolVProductAndDescriptionMapper,
			IDALVProductAndDescriptionMapper dalVProductAndDescriptionMapper)
			: base()
		{
			this.VProductAndDescriptionRepository = vProductAndDescriptionRepository;
			this.VProductAndDescriptionModelValidator = vProductAndDescriptionModelValidator;
			this.BolVProductAndDescriptionMapper = bolVProductAndDescriptionMapper;
			this.DalVProductAndDescriptionMapper = dalVProductAndDescriptionMapper;
			this.logger = logger;
		}

		public virtual async Task<List<ApiVProductAndDescriptionResponseModel>> All(int limit = 0, int offset = int.MaxValue)
		{
			var records = await this.VProductAndDescriptionRepository.All(limit, offset);

			return this.BolVProductAndDescriptionMapper.MapBOToModel(this.DalVProductAndDescriptionMapper.MapEFToBO(records));
		}

		public virtual async Task<ApiVProductAndDescriptionResponseModel> Get(string cultureID)
		{
			var record = await this.VProductAndDescriptionRepository.Get(cultureID);

			if (record == null)
			{
				return null;
			}
			else
			{
				return this.BolVProductAndDescriptionMapper.MapBOToModel(this.DalVProductAndDescriptionMapper.MapEFToBO(record));
			}
		}
	}
}

/*<Codenesium>
    <Hash>0ecec88e3dfffbfbed11623941d49262</Hash>
</Codenesium>*/