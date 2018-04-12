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
	public abstract class AbstractRateRepository
	{
		protected ApplicationDbContext context;
		protected ILogger logger;

		public AbstractRateRepository(
			ILogger logger,
			ApplicationDbContext context)
		{
			this.logger = logger;
			this.context = context;
		}

		public virtual int Create(
			decimal amountPerMinute,
			int teacherSkillId,
			int teacherId)
		{
			var record = new EFRate();

			MapPOCOToEF(
				0,
				amountPerMinute,
				teacherSkillId,
				teacherId,
				record);

			this.context.Set<EFRate>().Add(record);
			this.context.SaveChanges();
			return record.Id;
		}

		public virtual void Update(
			int id,
			decimal amountPerMinute,
			int teacherSkillId,
			int teacherId)
		{
			var record = this.SearchLinqEF(x => x.Id == id).FirstOrDefault();
			if (record == null)
			{
				this.logger.LogError($"Unable to find id:{id}");
			}
			else
			{
				MapPOCOToEF(
					id,
					amountPerMinute,
					teacherSkillId,
					teacherId,
					record);
				this.context.SaveChanges();
			}
		}

		public virtual void Delete(
			int id)
		{
			var record = this.SearchLinqEF(x => x.Id == id).FirstOrDefault();

			if (record == null)
			{
				return;
			}
			else
			{
				this.context.Set<EFRate>().Remove(record);
				this.context.SaveChanges();
			}
		}

		public virtual Response GetById(int id)
		{
			var response = new Response();

			this.SearchLinqPOCO(x => x.Id == id, response);
			return response;
		}

		public virtual POCORate GetByIdDirect(int id)
		{
			var response = new Response();

			this.SearchLinqPOCO(x => x.Id == id, response);
			return response.Rates.FirstOrDefault();
		}

		public virtual Response GetWhere(Expression<Func<EFRate, bool>> predicate, int skip = 0, int take = int.MaxValue, string orderClause = "")
		{
			var response = new Response();

			this.SearchLinqPOCO(predicate, response, skip, take, orderClause);
			return response;
		}

		public virtual Response GetWhereDynamic(string predicate, int skip = 0, int take = int.MaxValue, string orderClause = "")
		{
			var response = new Response();

			this.SearchLinqPOCODynamic(predicate, response, skip, take, orderClause);
			return response;
		}

		public virtual List<POCORate> GetWhereDirect(Expression<Func<EFRate, bool>> predicate, int skip = 0, int take = int.MaxValue, string orderClause = "")
		{
			var response = new Response();

			this.SearchLinqPOCO(predicate, response, skip, take, orderClause);
			return response.Rates;
		}

		private void SearchLinqPOCO(Expression<Func<EFRate, bool>> predicate, Response response, int skip = 0, int take = int.MaxValue, string orderClause = "")
		{
			List<EFRate> records = this.SearchLinqEF(predicate, skip, take, orderClause);
			records.ForEach(x => MapEFToPOCO(x, response));
		}

		private void SearchLinqPOCODynamic(string predicate, Response response, int skip = 0, int take = int.MaxValue, string orderClause = "")
		{
			List<EFRate> records = this.SearchLinqEFDynamic(predicate, skip, take, orderClause);
			records.ForEach(x => MapEFToPOCO(x, response));
		}

		protected virtual List<EFRate> SearchLinqEF(Expression<Func<EFRate, bool>> predicate, int skip = 0, int take = int.MaxValue, string orderClause = "")
		{
			throw new NotImplementedException("This method should be implemented in a derived class");
		}

		protected virtual List<EFRate> SearchLinqEFDynamic(string predicate, int skip = 0, int take = int.MaxValue, string orderClause = "")
		{
			throw new NotImplementedException("This method should be implemented in a derived class");
		}

		public static void MapPOCOToEF(
			int id,
			decimal amountPerMinute,
			int teacherSkillId,
			int teacherId,
			EFRate efRate)
		{
			efRate.SetProperties(id.ToInt(), amountPerMinute, teacherSkillId.ToInt(), teacherId.ToInt());
		}

		public static void MapEFToPOCO(
			EFRate efRate,
			Response response)
		{
			if (efRate == null)
			{
				return;
			}

			response.AddRate(new POCORate(efRate.Id.ToInt(), efRate.AmountPerMinute, efRate.TeacherSkillId.ToInt(), efRate.TeacherId.ToInt()));

			TeacherSkillRepository.MapEFToPOCO(efRate.TeacherSkill, response);

			TeacherRepository.MapEFToPOCO(efRate.Teacher, response);
		}
	}
}

/*<Codenesium>
    <Hash>c289e49f26f71f36009b5b37c7434f76</Hash>
</Codenesium>*/