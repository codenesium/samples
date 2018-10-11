using Codenesium.DataConversionExtensions;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Dynamic.Core;
using System.Linq.Expressions;
using System.Threading.Tasks;
using TestsNS.Api.Contracts;
using TestsNS.Api.DataAccess;

namespace TestsNS.Api.Services
{
	public abstract class AbstractVPersonService : AbstractService
	{
		protected IVPersonRepository VPersonRepository { get; private set; }

		protected IApiVPersonRequestModelValidator VPersonModelValidator { get; private set; }

		protected IBOLVPersonMapper BolVPersonMapper { get; private set; }

		protected IDALVPersonMapper DalVPersonMapper { get; private set; }

		private ILogger logger;

		public AbstractVPersonService(
			ILogger logger,
			IVPersonRepository vPersonRepository,
			IApiVPersonRequestModelValidator vPersonModelValidator,
			IBOLVPersonMapper bolVPersonMapper,
			IDALVPersonMapper dalVPersonMapper)
			: base()
		{
			this.VPersonRepository = vPersonRepository;
			this.VPersonModelValidator = vPersonModelValidator;
			this.BolVPersonMapper = bolVPersonMapper;
			this.DalVPersonMapper = dalVPersonMapper;
			this.logger = logger;
		}

		public virtual async Task<List<ApiVPersonResponseModel>> All(int limit = 0, int offset = int.MaxValue)
		{
			var records = await this.VPersonRepository.All(limit, offset);

			return this.BolVPersonMapper.MapBOToModel(this.DalVPersonMapper.MapEFToBO(records));
		}

		public virtual async Task<ApiVPersonResponseModel> Get(int personId)
		{
			var record = await this.VPersonRepository.Get(personId);

			if (record == null)
			{
				return null;
			}
			else
			{
				return this.BolVPersonMapper.MapBOToModel(this.DalVPersonMapper.MapEFToBO(record));
			}
		}
	}
}

/*<Codenesium>
    <Hash>68092f4ea2252184a815fea45fa0f134</Hash>
</Codenesium>*/