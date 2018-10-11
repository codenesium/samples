using Codenesium.DataConversionExtensions;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;
using StudioResourceManagerNS.Api.Contracts;
using StudioResourceManagerNS.Api.DataAccess;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Dynamic.Core;
using System.Linq.Expressions;
using System.Threading.Tasks;

namespace StudioResourceManagerNS.Api.Services
{
	public abstract class AbstractVEventService : AbstractService
	{
		protected IVEventRepository VEventRepository { get; private set; }

		protected IApiVEventRequestModelValidator VEventModelValidator { get; private set; }

		protected IBOLVEventMapper BolVEventMapper { get; private set; }

		protected IDALVEventMapper DalVEventMapper { get; private set; }

		private ILogger logger;

		public AbstractVEventService(
			ILogger logger,
			IVEventRepository vEventRepository,
			IApiVEventRequestModelValidator vEventModelValidator,
			IBOLVEventMapper bolVEventMapper,
			IDALVEventMapper dalVEventMapper)
			: base()
		{
			this.VEventRepository = vEventRepository;
			this.VEventModelValidator = vEventModelValidator;
			this.BolVEventMapper = bolVEventMapper;
			this.DalVEventMapper = dalVEventMapper;
			this.logger = logger;
		}

		public virtual async Task<List<ApiVEventResponseModel>> All(int limit = 0, int offset = int.MaxValue)
		{
			var records = await this.VEventRepository.All(limit, offset);

			return this.BolVEventMapper.MapBOToModel(this.DalVEventMapper.MapEFToBO(records));
		}

		public virtual async Task<ApiVEventResponseModel> Get(int id)
		{
			var record = await this.VEventRepository.Get(id);

			if (record == null)
			{
				return null;
			}
			else
			{
				return this.BolVEventMapper.MapBOToModel(this.DalVEventMapper.MapEFToBO(record));
			}
		}
	}
}

/*<Codenesium>
    <Hash>4d902c08227c89ceb82597eff002b9c8</Hash>
</Codenesium>*/