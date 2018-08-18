using Codenesium.DataConversionExtensions;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;
using StackOverflowNS.Api.Contracts;
using StackOverflowNS.Api.DataAccess;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Dynamic.Core;
using System.Linq.Expressions;
using System.Threading.Tasks;

namespace StackOverflowNS.Api.Services
{
	public abstract class AbstractPostLinksService : AbstractService
	{
		protected IPostLinksRepository PostLinksRepository { get; private set; }

		protected IApiPostLinksRequestModelValidator PostLinksModelValidator { get; private set; }

		protected IBOLPostLinksMapper BolPostLinksMapper { get; private set; }

		protected IDALPostLinksMapper DalPostLinksMapper { get; private set; }

		private ILogger logger;

		public AbstractPostLinksService(
			ILogger logger,
			IPostLinksRepository postLinksRepository,
			IApiPostLinksRequestModelValidator postLinksModelValidator,
			IBOLPostLinksMapper bolPostLinksMapper,
			IDALPostLinksMapper dalPostLinksMapper)
			: base()
		{
			this.PostLinksRepository = postLinksRepository;
			this.PostLinksModelValidator = postLinksModelValidator;
			this.BolPostLinksMapper = bolPostLinksMapper;
			this.DalPostLinksMapper = dalPostLinksMapper;
			this.logger = logger;
		}

		public virtual async Task<List<ApiPostLinksResponseModel>> All(int limit = 0, int offset = int.MaxValue)
		{
			var records = await this.PostLinksRepository.All(limit, offset);

			return this.BolPostLinksMapper.MapBOToModel(this.DalPostLinksMapper.MapEFToBO(records));
		}

		public virtual async Task<ApiPostLinksResponseModel> Get(int id)
		{
			var record = await this.PostLinksRepository.Get(id);

			if (record == null)
			{
				return null;
			}
			else
			{
				return this.BolPostLinksMapper.MapBOToModel(this.DalPostLinksMapper.MapEFToBO(record));
			}
		}

		public virtual async Task<CreateResponse<ApiPostLinksResponseModel>> Create(
			ApiPostLinksRequestModel model)
		{
			CreateResponse<ApiPostLinksResponseModel> response = new CreateResponse<ApiPostLinksResponseModel>(await this.PostLinksModelValidator.ValidateCreateAsync(model));
			if (response.Success)
			{
				var bo = this.BolPostLinksMapper.MapModelToBO(default(int), model);
				var record = await this.PostLinksRepository.Create(this.DalPostLinksMapper.MapBOToEF(bo));

				response.SetRecord(this.BolPostLinksMapper.MapBOToModel(this.DalPostLinksMapper.MapEFToBO(record)));
			}

			return response;
		}

		public virtual async Task<UpdateResponse<ApiPostLinksResponseModel>> Update(
			int id,
			ApiPostLinksRequestModel model)
		{
			var validationResult = await this.PostLinksModelValidator.ValidateUpdateAsync(id, model);

			if (validationResult.IsValid)
			{
				var bo = this.BolPostLinksMapper.MapModelToBO(id, model);
				await this.PostLinksRepository.Update(this.DalPostLinksMapper.MapBOToEF(bo));

				var record = await this.PostLinksRepository.Get(id);

				return new UpdateResponse<ApiPostLinksResponseModel>(this.BolPostLinksMapper.MapBOToModel(this.DalPostLinksMapper.MapEFToBO(record)));
			}
			else
			{
				return new UpdateResponse<ApiPostLinksResponseModel>(validationResult);
			}
		}

		public virtual async Task<ActionResponse> Delete(
			int id)
		{
			ActionResponse response = new ActionResponse(await this.PostLinksModelValidator.ValidateDeleteAsync(id));
			if (response.Success)
			{
				await this.PostLinksRepository.Delete(id);
			}

			return response;
		}
	}
}

/*<Codenesium>
    <Hash>fe77b950e216f165ce686d387359ceaa</Hash>
</Codenesium>*/