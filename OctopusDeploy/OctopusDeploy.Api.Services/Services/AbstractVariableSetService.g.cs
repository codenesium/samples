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
	public abstract class AbstractVariableSetService : AbstractService
	{
		protected IVariableSetRepository VariableSetRepository { get; private set; }

		protected IApiVariableSetRequestModelValidator VariableSetModelValidator { get; private set; }

		protected IBOLVariableSetMapper BolVariableSetMapper { get; private set; }

		protected IDALVariableSetMapper DalVariableSetMapper { get; private set; }

		private ILogger logger;

		public AbstractVariableSetService(
			ILogger logger,
			IVariableSetRepository variableSetRepository,
			IApiVariableSetRequestModelValidator variableSetModelValidator,
			IBOLVariableSetMapper bolVariableSetMapper,
			IDALVariableSetMapper dalVariableSetMapper)
			: base()
		{
			this.VariableSetRepository = variableSetRepository;
			this.VariableSetModelValidator = variableSetModelValidator;
			this.BolVariableSetMapper = bolVariableSetMapper;
			this.DalVariableSetMapper = dalVariableSetMapper;
			this.logger = logger;
		}

		public virtual async Task<List<ApiVariableSetResponseModel>> All(int limit = 0, int offset = int.MaxValue)
		{
			var records = await this.VariableSetRepository.All(limit, offset);

			return this.BolVariableSetMapper.MapBOToModel(this.DalVariableSetMapper.MapEFToBO(records));
		}

		public virtual async Task<ApiVariableSetResponseModel> Get(string id)
		{
			var record = await this.VariableSetRepository.Get(id);

			if (record == null)
			{
				return null;
			}
			else
			{
				return this.BolVariableSetMapper.MapBOToModel(this.DalVariableSetMapper.MapEFToBO(record));
			}
		}

		public virtual async Task<CreateResponse<ApiVariableSetResponseModel>> Create(
			ApiVariableSetRequestModel model)
		{
			CreateResponse<ApiVariableSetResponseModel> response = new CreateResponse<ApiVariableSetResponseModel>(await this.VariableSetModelValidator.ValidateCreateAsync(model));
			if (response.Success)
			{
				var bo = this.BolVariableSetMapper.MapModelToBO(default(string), model);
				var record = await this.VariableSetRepository.Create(this.DalVariableSetMapper.MapBOToEF(bo));

				response.SetRecord(this.BolVariableSetMapper.MapBOToModel(this.DalVariableSetMapper.MapEFToBO(record)));
			}

			return response;
		}

		public virtual async Task<UpdateResponse<ApiVariableSetResponseModel>> Update(
			string id,
			ApiVariableSetRequestModel model)
		{
			var validationResult = await this.VariableSetModelValidator.ValidateUpdateAsync(id, model);

			if (validationResult.IsValid)
			{
				var bo = this.BolVariableSetMapper.MapModelToBO(id, model);
				await this.VariableSetRepository.Update(this.DalVariableSetMapper.MapBOToEF(bo));

				var record = await this.VariableSetRepository.Get(id);

				return new UpdateResponse<ApiVariableSetResponseModel>(this.BolVariableSetMapper.MapBOToModel(this.DalVariableSetMapper.MapEFToBO(record)));
			}
			else
			{
				return new UpdateResponse<ApiVariableSetResponseModel>(validationResult);
			}
		}

		public virtual async Task<ActionResponse> Delete(
			string id)
		{
			ActionResponse response = new ActionResponse(await this.VariableSetModelValidator.ValidateDeleteAsync(id));
			if (response.Success)
			{
				await this.VariableSetRepository.Delete(id);
			}

			return response;
		}
	}
}

/*<Codenesium>
    <Hash>ad1e4f1060d5488f1cd61712902c7146</Hash>
</Codenesium>*/