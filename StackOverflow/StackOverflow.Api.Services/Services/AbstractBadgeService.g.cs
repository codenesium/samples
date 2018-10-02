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
	public abstract class AbstractBadgeService : AbstractService
	{
		protected IBadgeRepository BadgeRepository { get; private set; }

		protected IApiBadgeRequestModelValidator BadgeModelValidator { get; private set; }

		protected IBOLBadgeMapper BolBadgeMapper { get; private set; }

		protected IDALBadgeMapper DalBadgeMapper { get; private set; }

		private ILogger logger;

		public AbstractBadgeService(
			ILogger logger,
			IBadgeRepository badgeRepository,
			IApiBadgeRequestModelValidator badgeModelValidator,
			IBOLBadgeMapper bolBadgeMapper,
			IDALBadgeMapper dalBadgeMapper)
			: base()
		{
			this.BadgeRepository = badgeRepository;
			this.BadgeModelValidator = badgeModelValidator;
			this.BolBadgeMapper = bolBadgeMapper;
			this.DalBadgeMapper = dalBadgeMapper;
			this.logger = logger;
		}

		public virtual async Task<List<ApiBadgeResponseModel>> All(int limit = 0, int offset = int.MaxValue)
		{
			var records = await this.BadgeRepository.All(limit, offset);

			return this.BolBadgeMapper.MapBOToModel(this.DalBadgeMapper.MapEFToBO(records));
		}

		public virtual async Task<ApiBadgeResponseModel> Get(int id)
		{
			var record = await this.BadgeRepository.Get(id);

			if (record == null)
			{
				return null;
			}
			else
			{
				return this.BolBadgeMapper.MapBOToModel(this.DalBadgeMapper.MapEFToBO(record));
			}
		}

		public virtual async Task<CreateResponse<ApiBadgeResponseModel>> Create(
			ApiBadgeRequestModel model)
		{
			CreateResponse<ApiBadgeResponseModel> response = new CreateResponse<ApiBadgeResponseModel>(await this.BadgeModelValidator.ValidateCreateAsync(model));
			if (response.Success)
			{
				var bo = this.BolBadgeMapper.MapModelToBO(default(int), model);
				var record = await this.BadgeRepository.Create(this.DalBadgeMapper.MapBOToEF(bo));

				response.SetRecord(this.BolBadgeMapper.MapBOToModel(this.DalBadgeMapper.MapEFToBO(record)));
			}

			return response;
		}

		public virtual async Task<UpdateResponse<ApiBadgeResponseModel>> Update(
			int id,
			ApiBadgeRequestModel model)
		{
			var validationResult = await this.BadgeModelValidator.ValidateUpdateAsync(id, model);

			if (validationResult.IsValid)
			{
				var bo = this.BolBadgeMapper.MapModelToBO(id, model);
				await this.BadgeRepository.Update(this.DalBadgeMapper.MapBOToEF(bo));

				var record = await this.BadgeRepository.Get(id);

				return new UpdateResponse<ApiBadgeResponseModel>(this.BolBadgeMapper.MapBOToModel(this.DalBadgeMapper.MapEFToBO(record)));
			}
			else
			{
				return new UpdateResponse<ApiBadgeResponseModel>(validationResult);
			}
		}

		public virtual async Task<ActionResponse> Delete(
			int id)
		{
			ActionResponse response = new ActionResponse(await this.BadgeModelValidator.ValidateDeleteAsync(id));
			if (response.Success)
			{
				await this.BadgeRepository.Delete(id);
			}

			return response;
		}
	}
}

/*<Codenesium>
    <Hash>8c053da5988b6feb2bec4bb53183c2ed</Hash>
</Codenesium>*/