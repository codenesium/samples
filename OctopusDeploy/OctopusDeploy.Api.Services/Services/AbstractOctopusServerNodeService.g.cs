using Codenesium.DataConversionExtensions;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;
using OctopusDeployNS.Api.Contracts;
using OctopusDeployNS.Api.DataAccess;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Dynamic.Core;
using System.Linq.Expressions;
using System.Threading.Tasks;

namespace OctopusDeployNS.Api.Services
{
	public abstract class AbstractOctopusServerNodeService : AbstractService
	{
		protected IOctopusServerNodeRepository OctopusServerNodeRepository { get; private set; }

		protected IApiOctopusServerNodeRequestModelValidator OctopusServerNodeModelValidator { get; private set; }

		protected IBOLOctopusServerNodeMapper BolOctopusServerNodeMapper { get; private set; }

		protected IDALOctopusServerNodeMapper DalOctopusServerNodeMapper { get; private set; }

		private ILogger logger;

		public AbstractOctopusServerNodeService(
			ILogger logger,
			IOctopusServerNodeRepository octopusServerNodeRepository,
			IApiOctopusServerNodeRequestModelValidator octopusServerNodeModelValidator,
			IBOLOctopusServerNodeMapper bolOctopusServerNodeMapper,
			IDALOctopusServerNodeMapper dalOctopusServerNodeMapper)
			: base()
		{
			this.OctopusServerNodeRepository = octopusServerNodeRepository;
			this.OctopusServerNodeModelValidator = octopusServerNodeModelValidator;
			this.BolOctopusServerNodeMapper = bolOctopusServerNodeMapper;
			this.DalOctopusServerNodeMapper = dalOctopusServerNodeMapper;
			this.logger = logger;
		}

		public virtual async Task<List<ApiOctopusServerNodeResponseModel>> All(int limit = 0, int offset = int.MaxValue)
		{
			var records = await this.OctopusServerNodeRepository.All(limit, offset);

			return this.BolOctopusServerNodeMapper.MapBOToModel(this.DalOctopusServerNodeMapper.MapEFToBO(records));
		}

		public virtual async Task<ApiOctopusServerNodeResponseModel> Get(string id)
		{
			var record = await this.OctopusServerNodeRepository.Get(id);

			if (record == null)
			{
				return null;
			}
			else
			{
				return this.BolOctopusServerNodeMapper.MapBOToModel(this.DalOctopusServerNodeMapper.MapEFToBO(record));
			}
		}

		public virtual async Task<CreateResponse<ApiOctopusServerNodeResponseModel>> Create(
			ApiOctopusServerNodeRequestModel model)
		{
			CreateResponse<ApiOctopusServerNodeResponseModel> response = new CreateResponse<ApiOctopusServerNodeResponseModel>(await this.OctopusServerNodeModelValidator.ValidateCreateAsync(model));
			if (response.Success)
			{
				var bo = this.BolOctopusServerNodeMapper.MapModelToBO(default(string), model);
				var record = await this.OctopusServerNodeRepository.Create(this.DalOctopusServerNodeMapper.MapBOToEF(bo));

				response.SetRecord(this.BolOctopusServerNodeMapper.MapBOToModel(this.DalOctopusServerNodeMapper.MapEFToBO(record)));
			}

			return response;
		}

		public virtual async Task<UpdateResponse<ApiOctopusServerNodeResponseModel>> Update(
			string id,
			ApiOctopusServerNodeRequestModel model)
		{
			var validationResult = await this.OctopusServerNodeModelValidator.ValidateUpdateAsync(id, model);

			if (validationResult.IsValid)
			{
				var bo = this.BolOctopusServerNodeMapper.MapModelToBO(id, model);
				await this.OctopusServerNodeRepository.Update(this.DalOctopusServerNodeMapper.MapBOToEF(bo));

				var record = await this.OctopusServerNodeRepository.Get(id);

				return new UpdateResponse<ApiOctopusServerNodeResponseModel>(this.BolOctopusServerNodeMapper.MapBOToModel(this.DalOctopusServerNodeMapper.MapEFToBO(record)));
			}
			else
			{
				return new UpdateResponse<ApiOctopusServerNodeResponseModel>(validationResult);
			}
		}

		public virtual async Task<ActionResponse> Delete(
			string id)
		{
			ActionResponse response = new ActionResponse(await this.OctopusServerNodeModelValidator.ValidateDeleteAsync(id));
			if (response.Success)
			{
				await this.OctopusServerNodeRepository.Delete(id);
			}

			return response;
		}
	}
}

/*<Codenesium>
    <Hash>e1d07df1bd524a5907c099f80b99fa7e</Hash>
</Codenesium>*/