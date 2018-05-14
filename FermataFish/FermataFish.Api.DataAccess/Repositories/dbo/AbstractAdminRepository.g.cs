using Codenesium.DataConversionExtensions.AspNetCore;
using System;
using System.Collections.Generic;
using Microsoft.Extensions.Logging;
using Microsoft.EntityFrameworkCore;
using System.Linq;
using System.Linq.Dynamic.Core;
using System.Linq.Expressions;
using FermataFishNS.Api.Contracts;

namespace FermataFishNS.Api.DataAccess
{
	public abstract class AbstractAdminRepository
	{
		protected ApplicationDbContext Context { get; }
		protected ILogger Logger { get; }
		protected IObjectMapper Mapper { get; }

		public AbstractAdminRepository(
			IObjectMapper mapper,
			ILogger logger,
			ApplicationDbContext context)
		{
			this.Mapper = mapper;
			this.Logger = logger;
			this.Context = context;
		}

		public virtual List<POCOAdmin> All(int skip = 0, int take = int.MaxValue, string orderClause = "")
		{
			return this.SearchLinqPOCO(x => true, skip, take, orderClause);
		}

		public virtual POCOAdmin Get(int id)
		{
			return this.SearchLinqPOCO(x => x.Id == id).FirstOrDefault();
		}

		public virtual POCOAdmin Create(
			AdminModel model)
		{
			Admin record = new Admin();

			this.Mapper.AdminMapModelToEF(
				default (int),
				model,
				record);

			this.Context.Set<Admin>().Add(record);
			this.Context.SaveChanges();
			return this.Mapper.AdminMapEFToPOCO(record);
		}

		public virtual void Update(
			int id,
			AdminModel model)
		{
			Admin record = this.SearchLinqEF(x => x.Id == id).FirstOrDefault();
			if (record == null)
			{
				throw new RecordNotFoundException($"Unable to find id:{id}");
			}
			else
			{
				this.Mapper.AdminMapModelToEF(
					id,
					model,
					record);
				this.Context.SaveChanges();
			}
		}

		public virtual void Delete(
			int id)
		{
			Admin record = this.SearchLinqEF(x => x.Id == id).FirstOrDefault();

			if (record == null)
			{
				return;
			}
			else
			{
				this.Context.Set<Admin>().Remove(record);
				this.Context.SaveChanges();
			}
		}

		protected List<POCOAdmin> Where(Expression<Func<Admin, bool>> predicate, int skip = 0, int take = int.MaxValue, string orderClause = "")
		{
			return this.SearchLinqPOCO(predicate, skip, take, orderClause);
		}

		private List<POCOAdmin> SearchLinqPOCO(Expression<Func<Admin, bool>> predicate, int skip = 0, int take = int.MaxValue, string orderClause = "")
		{
			List<POCOAdmin> response = new List<POCOAdmin>();
			List<Admin> records = this.SearchLinqEF(predicate, skip, take, orderClause);
			records.ForEach(x => response.Add(this.Mapper.AdminMapEFToPOCO(x)));
			return response;
		}

		private List<Admin> SearchLinqEF(Expression<Func<Admin, bool>> predicate, int skip = 0, int take = int.MaxValue, string orderClause = "")
		{
			if (string.IsNullOrWhiteSpace(orderClause))
			{
				orderClause = $"{nameof(Admin.Id)} ASC";
			}
			return this.Context.Set<Admin>().Where(predicate).AsQueryable().OrderBy(orderClause).Skip(skip).Take(take).ToList<Admin>();
		}

		private List<Admin> SearchLinqEFDynamic(string predicate, int skip = 0, int take = int.MaxValue, string orderClause = "")
		{
			if (string.IsNullOrWhiteSpace(orderClause))
			{
				orderClause = $"{nameof(Admin.Id)} ASC";
			}

			return this.Context.Set<Admin>().Where(predicate).AsQueryable().OrderBy(orderClause).Skip(skip).Take(take).ToList<Admin>();
		}
	}
}

/*<Codenesium>
    <Hash>227332409e862790a3f9a9c66123e3f5</Hash>
</Codenesium>*/