using Codenesium.DataConversionExtensions.AspNetCore;
using System;
using System.Collections.Generic;
using Microsoft.Extensions.Logging;
using Microsoft.EntityFrameworkCore;
using System.Linq;
using System.Linq.Dynamic.Core;
using System.Linq.Expressions;
using NebulaNS.Api.Contracts;

namespace NebulaNS.Api.DataAccess
{
	public abstract class AbstractChainStatusRepository
	{
		protected ApplicationDbContext Context { get; }
		protected ILogger Logger { get; }
		protected IObjectMapper Mapper { get; }

		public AbstractChainStatusRepository(
			IObjectMapper mapper,
			ILogger logger,
			ApplicationDbContext context)
		{
			this.Mapper = mapper;
			this.Logger = logger;
			this.Context = context;
		}

		public virtual int Create(
			ChainStatusModel model)
		{
			EFChainStatus record = new EFChainStatus();

			this.Mapper.ChainStatusMapModelToEF(
				default (int),
				model,
				record);

			this.Context.Set<EFChainStatus>().Add(record);
			this.Context.SaveChanges();
			return record.Id;
		}

		public virtual void Update(
			int id,
			ChainStatusModel model)
		{
			EFChainStatus record = this.SearchLinqEF(x => x.Id == id).FirstOrDefault();
			if (record == null)
			{
				throw new RecordNotFoundException($"Unable to find id:{id}");
			}
			else
			{
				this.Mapper.ChainStatusMapModelToEF(
					id,
					model,
					record);
				this.Context.SaveChanges();
			}
		}

		public virtual void Delete(
			int id)
		{
			EFChainStatus record = this.SearchLinqEF(x => x.Id == id).FirstOrDefault();

			if (record == null)
			{
				return;
			}
			else
			{
				this.Context.Set<EFChainStatus>().Remove(record);
				this.Context.SaveChanges();
			}
		}

		public virtual ApiResponse GetById(int id)
		{
			return this.SearchLinqPOCO(x => x.Id == id);
		}

		public virtual POCOChainStatus GetByIdDirect(int id)
		{
			return this.SearchLinqPOCO(x => x.Id == id).ChainStatus.FirstOrDefault();
		}

		public virtual ApiResponse GetWhere(Expression<Func<EFChainStatus, bool>> predicate, int skip = 0, int take = int.MaxValue, string orderClause = "")
		{
			return this.SearchLinqPOCO(predicate, skip, take, orderClause);
		}

		public virtual ApiResponse GetWhereDynamic(string predicate, int skip = 0, int take = int.MaxValue, string orderClause = "")
		{
			return this.SearchLinqPOCODynamic(predicate, skip, take, orderClause);
		}

		public virtual List<POCOChainStatus> GetWhereDirect(Expression<Func<EFChainStatus, bool>> predicate, int skip = 0, int take = int.MaxValue, string orderClause = "")
		{
			return this.SearchLinqPOCO(predicate, skip, take, orderClause).ChainStatus;
		}

		private ApiResponse SearchLinqPOCO(Expression<Func<EFChainStatus, bool>> predicate, int skip = 0, int take = int.MaxValue, string orderClause = "")
		{
			ApiResponse response = new ApiResponse();

			List<EFChainStatus> records = this.SearchLinqEF(predicate, skip, take, orderClause);
			records.ForEach(x => this.Mapper.ChainStatusMapEFToPOCO(x, response));
			return response;
		}

		private ApiResponse SearchLinqPOCODynamic(string predicate, int skip = 0, int take = int.MaxValue, string orderClause = "")
		{
			ApiResponse response = new ApiResponse();

			List<EFChainStatus> records = this.SearchLinqEFDynamic(predicate, skip, take, orderClause);
			records.ForEach(x => this.Mapper.ChainStatusMapEFToPOCO(x, response));
			return response;
		}

		protected virtual List<EFChainStatus> SearchLinqEF(Expression<Func<EFChainStatus, bool>> predicate, int skip = 0, int take = int.MaxValue, string orderClause = "")
		{
			throw new NotImplementedException("This method should be implemented in a derived class");
		}

		protected virtual List<EFChainStatus> SearchLinqEFDynamic(string predicate, int skip = 0, int take = int.MaxValue, string orderClause = "")
		{
			throw new NotImplementedException("This method should be implemented in a derived class");
		}
	}
}

/*<Codenesium>
    <Hash>55fe9f936623584a0858e34c43225955</Hash>
</Codenesium>*/