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
	public abstract class AbstractLibraryVariableSetService : AbstractService
	{
		protected ILibraryVariableSetRepository LibraryVariableSetRepository { get; private set; }

		protected IApiLibraryVariableSetRequestModelValidator LibraryVariableSetModelValidator { get; private set; }

		protected IBOLLibraryVariableSetMapper BolLibraryVariableSetMapper { get; private set; }

		protected IDALLibraryVariableSetMapper DalLibraryVariableSetMapper { get; private set; }

		private ILogger logger;

		public AbstractLibraryVariableSetService(
			ILogger logger,
			ILibraryVariableSetRepository libraryVariableSetRepository,
			IApiLibraryVariableSetRequestModelValidator libraryVariableSetModelValidator,
			IBOLLibraryVariableSetMapper bolLibraryVariableSetMapper,
			IDALLibraryVariableSetMapper dalLibraryVariableSetMapper)
			: base()
		{
			this.LibraryVariableSetRepository = libraryVariableSetRepository;
			this.LibraryVariableSetModelValidator = libraryVariableSetModelValidator;
			this.BolLibraryVariableSetMapper = bolLibraryVariableSetMapper;
			this.DalLibraryVariableSetMapper = dalLibraryVariableSetMapper;
			this.logger = logger;
		}

		public virtual async Task<List<ApiLibraryVariableSetResponseModel>> All(int limit = 0, int offset = int.MaxValue)
		{
			var records = await this.LibraryVariableSetRepository.All(limit, offset);

			return this.BolLibraryVariableSetMapper.MapBOToModel(this.DalLibraryVariableSetMapper.MapEFToBO(records));
		}

		public virtual async Task<ApiLibraryVariableSetResponseModel> Get(string id)
		{
			var record = await this.LibraryVariableSetRepository.Get(id);

			if (record == null)
			{
				return null;
			}
			else
			{
				return this.BolLibraryVariableSetMapper.MapBOToModel(this.DalLibraryVariableSetMapper.MapEFToBO(record));
			}
		}

		public virtual async Task<CreateResponse<ApiLibraryVariableSetResponseModel>> Create(
			ApiLibraryVariableSetRequestModel model)
		{
			CreateResponse<ApiLibraryVariableSetResponseModel> response = new CreateResponse<ApiLibraryVariableSetResponseModel>(await this.LibraryVariableSetModelValidator.ValidateCreateAsync(model));
			if (response.Success)
			{
				var bo = this.BolLibraryVariableSetMapper.MapModelToBO(default(string), model);
				var record = await this.LibraryVariableSetRepository.Create(this.DalLibraryVariableSetMapper.MapBOToEF(bo));

				response.SetRecord(this.BolLibraryVariableSetMapper.MapBOToModel(this.DalLibraryVariableSetMapper.MapEFToBO(record)));
			}

			return response;
		}

		public virtual async Task<UpdateResponse<ApiLibraryVariableSetResponseModel>> Update(
			string id,
			ApiLibraryVariableSetRequestModel model)
		{
			var validationResult = await this.LibraryVariableSetModelValidator.ValidateUpdateAsync(id, model);

			if (validationResult.IsValid)
			{
				var bo = this.BolLibraryVariableSetMapper.MapModelToBO(id, model);
				await this.LibraryVariableSetRepository.Update(this.DalLibraryVariableSetMapper.MapBOToEF(bo));

				var record = await this.LibraryVariableSetRepository.Get(id);

				return new UpdateResponse<ApiLibraryVariableSetResponseModel>(this.BolLibraryVariableSetMapper.MapBOToModel(this.DalLibraryVariableSetMapper.MapEFToBO(record)));
			}
			else
			{
				return new UpdateResponse<ApiLibraryVariableSetResponseModel>(validationResult);
			}
		}

		public virtual async Task<ActionResponse> Delete(
			string id)
		{
			ActionResponse response = new ActionResponse(await this.LibraryVariableSetModelValidator.ValidateDeleteAsync(id));
			if (response.Success)
			{
				await this.LibraryVariableSetRepository.Delete(id);
			}

			return response;
		}

		public async Task<ApiLibraryVariableSetResponseModel> ByName(string name)
		{
			LibraryVariableSet record = await this.LibraryVariableSetRepository.ByName(name);

			if (record == null)
			{
				return null;
			}
			else
			{
				return this.BolLibraryVariableSetMapper.MapBOToModel(this.DalLibraryVariableSetMapper.MapEFToBO(record));
			}
		}
	}
}

/*<Codenesium>
    <Hash>3bd1da3927dba64fe0e159e004d5350c</Hash>
</Codenesium>*/