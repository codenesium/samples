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
	public abstract class AbstractCommentsService : AbstractService
	{
		protected ICommentsRepository CommentsRepository { get; private set; }

		protected IApiCommentsRequestModelValidator CommentsModelValidator { get; private set; }

		protected IBOLCommentsMapper BolCommentsMapper { get; private set; }

		protected IDALCommentsMapper DalCommentsMapper { get; private set; }

		private ILogger logger;

		public AbstractCommentsService(
			ILogger logger,
			ICommentsRepository commentsRepository,
			IApiCommentsRequestModelValidator commentsModelValidator,
			IBOLCommentsMapper bolCommentsMapper,
			IDALCommentsMapper dalCommentsMapper)
			: base()
		{
			this.CommentsRepository = commentsRepository;
			this.CommentsModelValidator = commentsModelValidator;
			this.BolCommentsMapper = bolCommentsMapper;
			this.DalCommentsMapper = dalCommentsMapper;
			this.logger = logger;
		}

		public virtual async Task<List<ApiCommentsResponseModel>> All(int limit = 0, int offset = int.MaxValue)
		{
			var records = await this.CommentsRepository.All(limit, offset);

			return this.BolCommentsMapper.MapBOToModel(this.DalCommentsMapper.MapEFToBO(records));
		}

		public virtual async Task<ApiCommentsResponseModel> Get(int id)
		{
			var record = await this.CommentsRepository.Get(id);

			if (record == null)
			{
				return null;
			}
			else
			{
				return this.BolCommentsMapper.MapBOToModel(this.DalCommentsMapper.MapEFToBO(record));
			}
		}

		public virtual async Task<CreateResponse<ApiCommentsResponseModel>> Create(
			ApiCommentsRequestModel model)
		{
			CreateResponse<ApiCommentsResponseModel> response = new CreateResponse<ApiCommentsResponseModel>(await this.CommentsModelValidator.ValidateCreateAsync(model));
			if (response.Success)
			{
				var bo = this.BolCommentsMapper.MapModelToBO(default(int), model);
				var record = await this.CommentsRepository.Create(this.DalCommentsMapper.MapBOToEF(bo));

				response.SetRecord(this.BolCommentsMapper.MapBOToModel(this.DalCommentsMapper.MapEFToBO(record)));
			}

			return response;
		}

		public virtual async Task<UpdateResponse<ApiCommentsResponseModel>> Update(
			int id,
			ApiCommentsRequestModel model)
		{
			var validationResult = await this.CommentsModelValidator.ValidateUpdateAsync(id, model);

			if (validationResult.IsValid)
			{
				var bo = this.BolCommentsMapper.MapModelToBO(id, model);
				await this.CommentsRepository.Update(this.DalCommentsMapper.MapBOToEF(bo));

				var record = await this.CommentsRepository.Get(id);

				return new UpdateResponse<ApiCommentsResponseModel>(this.BolCommentsMapper.MapBOToModel(this.DalCommentsMapper.MapEFToBO(record)));
			}
			else
			{
				return new UpdateResponse<ApiCommentsResponseModel>(validationResult);
			}
		}

		public virtual async Task<ActionResponse> Delete(
			int id)
		{
			ActionResponse response = new ActionResponse(await this.CommentsModelValidator.ValidateDeleteAsync(id));
			if (response.Success)
			{
				await this.CommentsRepository.Delete(id);
			}

			return response;
		}
	}
}

/*<Codenesium>
    <Hash>7e523d8458c1c44eb47248e7adba1498</Hash>
</Codenesium>*/