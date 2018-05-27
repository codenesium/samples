using Codenesium.DataConversionExtensions.AspNetCore;
using System;
using System.Collections.Generic;
using Microsoft.Extensions.Logging;
using Microsoft.EntityFrameworkCore;
using System.Linq;
using System.Linq.Dynamic.Core;
using System.Linq.Expressions;
using System.Threading.Tasks;
using NebulaNS.Api.Contracts;
using NebulaNS.Api.DataAccess;

namespace NebulaNS.Api.BusinessObjects
{
	public abstract class AbstractBOChainStatus: AbstractBOManager
	{
		private IChainStatusRepository chainStatusRepository;
		private IApiChainStatusRequestModelValidator chainStatusModelValidator;
		private IBOLChainStatusMapper chainStatusMapper;
		private ILogger logger;

		public AbstractBOChainStatus(
			ILogger logger,
			IChainStatusRepository chainStatusRepository,
			IApiChainStatusRequestModelValidator chainStatusModelValidator,
			IBOLChainStatusMapper chainStatusMapper)
			: base()

		{
			this.chainStatusRepository = chainStatusRepository;
			this.chainStatusModelValidator = chainStatusModelValidator;
			this.chainStatusMapper = chainStatusMapper;
			this.logger = logger;
		}

		public virtual async Task<List<ApiChainStatusResponseModel>> All(int skip = 0, int take = int.MaxValue, string orderClause = "")
		{
			var records = await this.chainStatusRepository.All(skip, take, orderClause);

			return this.chainStatusMapper.MapDTOToModel(records);
		}

		public virtual async Task<ApiChainStatusResponseModel> Get(int id)
		{
			var record = await chainStatusRepository.Get(id);

			return this.chainStatusMapper.MapDTOToModel(record);
		}

		public virtual async Task<CreateResponse<ApiChainStatusResponseModel>> Create(
			ApiChainStatusRequestModel model)
		{
			CreateResponse<ApiChainStatusResponseModel> response = new CreateResponse<ApiChainStatusResponseModel>(await this.chainStatusModelValidator.ValidateCreateAsync(model));
			if (response.Success)
			{
				var dto = this.chainStatusMapper.MapModelToDTO(default (int), model);
				var record = await this.chainStatusRepository.Create(dto);

				response.SetRecord(this.chainStatusMapper.MapDTOToModel(record));
			}
			return response;
		}

		public virtual async Task<ActionResponse> Update(
			int id,
			ApiChainStatusRequestModel model)
		{
			ActionResponse response = new ActionResponse(await this.chainStatusModelValidator.ValidateUpdateAsync(id, model));

			if (response.Success)
			{
				var dto = this.chainStatusMapper.MapModelToDTO(id, model);
				await this.chainStatusRepository.Update(id, dto);
			}

			return response;
		}

		public virtual async Task<ActionResponse> Delete(
			int id)
		{
			ActionResponse response = new ActionResponse(await this.chainStatusModelValidator.ValidateDeleteAsync(id));

			if (response.Success)
			{
				await this.chainStatusRepository.Delete(id);
			}
			return response;
		}

		public async Task<ApiChainStatusResponseModel> GetName(string name)
		{
			DTOChainStatus record = await this.chainStatusRepository.GetName(name);

			return this.chainStatusMapper.MapDTOToModel(record);
		}
	}
}

/*<Codenesium>
    <Hash>33bd15d2469d9c18a297bbc99f844b9f</Hash>
</Codenesium>*/