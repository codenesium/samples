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
	public abstract class AbstractBOLinkStatus: AbstractBOManager
	{
		private ILinkStatusRepository linkStatusRepository;
		private IApiLinkStatusRequestModelValidator linkStatusModelValidator;
		private IBOLLinkStatusMapper linkStatusMapper;
		private ILogger logger;

		public AbstractBOLinkStatus(
			ILogger logger,
			ILinkStatusRepository linkStatusRepository,
			IApiLinkStatusRequestModelValidator linkStatusModelValidator,
			IBOLLinkStatusMapper linkStatusMapper)
			: base()

		{
			this.linkStatusRepository = linkStatusRepository;
			this.linkStatusModelValidator = linkStatusModelValidator;
			this.linkStatusMapper = linkStatusMapper;
			this.logger = logger;
		}

		public virtual async Task<List<ApiLinkStatusResponseModel>> All(int skip = 0, int take = int.MaxValue, string orderClause = "")
		{
			var records = await this.linkStatusRepository.All(skip, take, orderClause);

			return this.linkStatusMapper.MapDTOToModel(records);
		}

		public virtual async Task<ApiLinkStatusResponseModel> Get(int id)
		{
			var record = await linkStatusRepository.Get(id);

			return this.linkStatusMapper.MapDTOToModel(record);
		}

		public virtual async Task<CreateResponse<ApiLinkStatusResponseModel>> Create(
			ApiLinkStatusRequestModel model)
		{
			CreateResponse<ApiLinkStatusResponseModel> response = new CreateResponse<ApiLinkStatusResponseModel>(await this.linkStatusModelValidator.ValidateCreateAsync(model));
			if (response.Success)
			{
				var dto = this.linkStatusMapper.MapModelToDTO(default (int), model);
				var record = await this.linkStatusRepository.Create(dto);

				response.SetRecord(this.linkStatusMapper.MapDTOToModel(record));
			}
			return response;
		}

		public virtual async Task<ActionResponse> Update(
			int id,
			ApiLinkStatusRequestModel model)
		{
			ActionResponse response = new ActionResponse(await this.linkStatusModelValidator.ValidateUpdateAsync(id, model));

			if (response.Success)
			{
				var dto = this.linkStatusMapper.MapModelToDTO(id, model);
				await this.linkStatusRepository.Update(id, dto);
			}

			return response;
		}

		public virtual async Task<ActionResponse> Delete(
			int id)
		{
			ActionResponse response = new ActionResponse(await this.linkStatusModelValidator.ValidateDeleteAsync(id));

			if (response.Success)
			{
				await this.linkStatusRepository.Delete(id);
			}
			return response;
		}

		public async Task<ApiLinkStatusResponseModel> GetName(string name)
		{
			DTOLinkStatus record = await this.linkStatusRepository.GetName(name);

			return this.linkStatusMapper.MapDTOToModel(record);
		}
	}
}

/*<Codenesium>
    <Hash>a2ef1733741731d2c16ae7509c983a59</Hash>
</Codenesium>*/