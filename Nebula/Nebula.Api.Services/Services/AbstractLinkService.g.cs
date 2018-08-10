using Codenesium.DataConversionExtensions;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;
using NebulaNS.Api.Contracts;
using NebulaNS.Api.DataAccess;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Dynamic.Core;
using System.Linq.Expressions;
using System.Threading.Tasks;

namespace NebulaNS.Api.Services
{
	public abstract class AbstractLinkService : AbstractService
	{
		protected ILinkRepository LinkRepository { get; private set; }

		protected IApiLinkRequestModelValidator LinkModelValidator { get; private set; }

		protected IBOLLinkMapper BolLinkMapper { get; private set; }

		protected IDALLinkMapper DalLinkMapper { get; private set; }

		protected IBOLLinkLogMapper BolLinkLogMapper { get; private set; }

		protected IDALLinkLogMapper DalLinkLogMapper { get; private set; }

		private ILogger logger;

		public AbstractLinkService(
			ILogger logger,
			ILinkRepository linkRepository,
			IApiLinkRequestModelValidator linkModelValidator,
			IBOLLinkMapper bolLinkMapper,
			IDALLinkMapper dalLinkMapper,
			IBOLLinkLogMapper bolLinkLogMapper,
			IDALLinkLogMapper dalLinkLogMapper)
			: base()
		{
			this.LinkRepository = linkRepository;
			this.LinkModelValidator = linkModelValidator;
			this.BolLinkMapper = bolLinkMapper;
			this.DalLinkMapper = dalLinkMapper;
			this.BolLinkLogMapper = bolLinkLogMapper;
			this.DalLinkLogMapper = dalLinkLogMapper;
			this.logger = logger;
		}

		public virtual async Task<List<ApiLinkResponseModel>> All(int limit = 0, int offset = int.MaxValue)
		{
			var records = await this.LinkRepository.All(limit, offset);

			return this.BolLinkMapper.MapBOToModel(this.DalLinkMapper.MapEFToBO(records));
		}

		public virtual async Task<ApiLinkResponseModel> Get(int id)
		{
			var record = await this.LinkRepository.Get(id);

			if (record == null)
			{
				return null;
			}
			else
			{
				return this.BolLinkMapper.MapBOToModel(this.DalLinkMapper.MapEFToBO(record));
			}
		}

		public virtual async Task<CreateResponse<ApiLinkResponseModel>> Create(
			ApiLinkRequestModel model)
		{
			CreateResponse<ApiLinkResponseModel> response = new CreateResponse<ApiLinkResponseModel>(await this.LinkModelValidator.ValidateCreateAsync(model));
			if (response.Success)
			{
				var bo = this.BolLinkMapper.MapModelToBO(default(int), model);
				var record = await this.LinkRepository.Create(this.DalLinkMapper.MapBOToEF(bo));

				response.SetRecord(this.BolLinkMapper.MapBOToModel(this.DalLinkMapper.MapEFToBO(record)));
			}

			return response;
		}

		public virtual async Task<UpdateResponse<ApiLinkResponseModel>> Update(
			int id,
			ApiLinkRequestModel model)
		{
			var validationResult = await this.LinkModelValidator.ValidateUpdateAsync(id, model);

			if (validationResult.IsValid)
			{
				var bo = this.BolLinkMapper.MapModelToBO(id, model);
				await this.LinkRepository.Update(this.DalLinkMapper.MapBOToEF(bo));

				var record = await this.LinkRepository.Get(id);

				return new UpdateResponse<ApiLinkResponseModel>(this.BolLinkMapper.MapBOToModel(this.DalLinkMapper.MapEFToBO(record)));
			}
			else
			{
				return new UpdateResponse<ApiLinkResponseModel>(validationResult);
			}
		}

		public virtual async Task<ActionResponse> Delete(
			int id)
		{
			ActionResponse response = new ActionResponse(await this.LinkModelValidator.ValidateDeleteAsync(id));
			if (response.Success)
			{
				await this.LinkRepository.Delete(id);
			}

			return response;
		}

		public async virtual Task<List<ApiLinkLogResponseModel>> LinkLogs(int linkId, int limit = int.MaxValue, int offset = 0)
		{
			List<LinkLog> records = await this.LinkRepository.LinkLogs(linkId, limit, offset);

			return this.BolLinkLogMapper.MapBOToModel(this.DalLinkLogMapper.MapEFToBO(records));
		}
	}
}

/*<Codenesium>
    <Hash>e9ed7ef8f8bc2b9743781322f64c0307</Hash>
</Codenesium>*/