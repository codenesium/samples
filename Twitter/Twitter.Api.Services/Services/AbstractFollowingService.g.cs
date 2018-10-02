using Codenesium.DataConversionExtensions;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Dynamic.Core;
using System.Linq.Expressions;
using System.Threading.Tasks;
using TwitterNS.Api.Contracts;
using TwitterNS.Api.DataAccess;

namespace TwitterNS.Api.Services
{
	public abstract class AbstractFollowingService : AbstractService
	{
		protected IFollowingRepository FollowingRepository { get; private set; }

		protected IApiFollowingRequestModelValidator FollowingModelValidator { get; private set; }

		protected IBOLFollowingMapper BolFollowingMapper { get; private set; }

		protected IDALFollowingMapper DalFollowingMapper { get; private set; }

		private ILogger logger;

		public AbstractFollowingService(
			ILogger logger,
			IFollowingRepository followingRepository,
			IApiFollowingRequestModelValidator followingModelValidator,
			IBOLFollowingMapper bolFollowingMapper,
			IDALFollowingMapper dalFollowingMapper)
			: base()
		{
			this.FollowingRepository = followingRepository;
			this.FollowingModelValidator = followingModelValidator;
			this.BolFollowingMapper = bolFollowingMapper;
			this.DalFollowingMapper = dalFollowingMapper;
			this.logger = logger;
		}

		public virtual async Task<List<ApiFollowingResponseModel>> All(int limit = 0, int offset = int.MaxValue)
		{
			var records = await this.FollowingRepository.All(limit, offset);

			return this.BolFollowingMapper.MapBOToModel(this.DalFollowingMapper.MapEFToBO(records));
		}

		public virtual async Task<ApiFollowingResponseModel> Get(string userId)
		{
			var record = await this.FollowingRepository.Get(userId);

			if (record == null)
			{
				return null;
			}
			else
			{
				return this.BolFollowingMapper.MapBOToModel(this.DalFollowingMapper.MapEFToBO(record));
			}
		}

		public virtual async Task<CreateResponse<ApiFollowingResponseModel>> Create(
			ApiFollowingRequestModel model)
		{
			CreateResponse<ApiFollowingResponseModel> response = new CreateResponse<ApiFollowingResponseModel>(await this.FollowingModelValidator.ValidateCreateAsync(model));
			if (response.Success)
			{
				var bo = this.BolFollowingMapper.MapModelToBO(default(string), model);
				var record = await this.FollowingRepository.Create(this.DalFollowingMapper.MapBOToEF(bo));

				response.SetRecord(this.BolFollowingMapper.MapBOToModel(this.DalFollowingMapper.MapEFToBO(record)));
			}

			return response;
		}

		public virtual async Task<UpdateResponse<ApiFollowingResponseModel>> Update(
			string userId,
			ApiFollowingRequestModel model)
		{
			var validationResult = await this.FollowingModelValidator.ValidateUpdateAsync(userId, model);

			if (validationResult.IsValid)
			{
				var bo = this.BolFollowingMapper.MapModelToBO(userId, model);
				await this.FollowingRepository.Update(this.DalFollowingMapper.MapBOToEF(bo));

				var record = await this.FollowingRepository.Get(userId);

				return new UpdateResponse<ApiFollowingResponseModel>(this.BolFollowingMapper.MapBOToModel(this.DalFollowingMapper.MapEFToBO(record)));
			}
			else
			{
				return new UpdateResponse<ApiFollowingResponseModel>(validationResult);
			}
		}

		public virtual async Task<ActionResponse> Delete(
			string userId)
		{
			ActionResponse response = new ActionResponse(await this.FollowingModelValidator.ValidateDeleteAsync(userId));
			if (response.Success)
			{
				await this.FollowingRepository.Delete(userId);
			}

			return response;
		}
	}
}

/*<Codenesium>
    <Hash>05ae8e6d674239bff8cf9a4cfce6572f</Hash>
</Codenesium>*/