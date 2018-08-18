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
	public abstract class AbstractBadgesService : AbstractService
	{
		protected IBadgesRepository BadgesRepository { get; private set; }

		protected IApiBadgesRequestModelValidator BadgesModelValidator { get; private set; }

		protected IBOLBadgesMapper BolBadgesMapper { get; private set; }

		protected IDALBadgesMapper DalBadgesMapper { get; private set; }

		private ILogger logger;

		public AbstractBadgesService(
			ILogger logger,
			IBadgesRepository badgesRepository,
			IApiBadgesRequestModelValidator badgesModelValidator,
			IBOLBadgesMapper bolBadgesMapper,
			IDALBadgesMapper dalBadgesMapper)
			: base()
		{
			this.BadgesRepository = badgesRepository;
			this.BadgesModelValidator = badgesModelValidator;
			this.BolBadgesMapper = bolBadgesMapper;
			this.DalBadgesMapper = dalBadgesMapper;
			this.logger = logger;
		}

		public virtual async Task<List<ApiBadgesResponseModel>> All(int limit = 0, int offset = int.MaxValue)
		{
			var records = await this.BadgesRepository.All(limit, offset);

			return this.BolBadgesMapper.MapBOToModel(this.DalBadgesMapper.MapEFToBO(records));
		}

		public virtual async Task<ApiBadgesResponseModel> Get(int id)
		{
			var record = await this.BadgesRepository.Get(id);

			if (record == null)
			{
				return null;
			}
			else
			{
				return this.BolBadgesMapper.MapBOToModel(this.DalBadgesMapper.MapEFToBO(record));
			}
		}

		public virtual async Task<CreateResponse<ApiBadgesResponseModel>> Create(
			ApiBadgesRequestModel model)
		{
			CreateResponse<ApiBadgesResponseModel> response = new CreateResponse<ApiBadgesResponseModel>(await this.BadgesModelValidator.ValidateCreateAsync(model));
			if (response.Success)
			{
				var bo = this.BolBadgesMapper.MapModelToBO(default(int), model);
				var record = await this.BadgesRepository.Create(this.DalBadgesMapper.MapBOToEF(bo));

				response.SetRecord(this.BolBadgesMapper.MapBOToModel(this.DalBadgesMapper.MapEFToBO(record)));
			}

			return response;
		}

		public virtual async Task<UpdateResponse<ApiBadgesResponseModel>> Update(
			int id,
			ApiBadgesRequestModel model)
		{
			var validationResult = await this.BadgesModelValidator.ValidateUpdateAsync(id, model);

			if (validationResult.IsValid)
			{
				var bo = this.BolBadgesMapper.MapModelToBO(id, model);
				await this.BadgesRepository.Update(this.DalBadgesMapper.MapBOToEF(bo));

				var record = await this.BadgesRepository.Get(id);

				return new UpdateResponse<ApiBadgesResponseModel>(this.BolBadgesMapper.MapBOToModel(this.DalBadgesMapper.MapEFToBO(record)));
			}
			else
			{
				return new UpdateResponse<ApiBadgesResponseModel>(validationResult);
			}
		}

		public virtual async Task<ActionResponse> Delete(
			int id)
		{
			ActionResponse response = new ActionResponse(await this.BadgesModelValidator.ValidateDeleteAsync(id));
			if (response.Success)
			{
				await this.BadgesRepository.Delete(id);
			}

			return response;
		}
	}
}

/*<Codenesium>
    <Hash>49b81a96f196c6e0ea530c41cdfc8568</Hash>
</Codenesium>*/