using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;

namespace TestsNS.Api.Client
{
	public partial class ApiResponse
	{
		public ApiResponse()
		{
		}

		public void Merge(ApiResponse from)
		{
			from.ColumnSameAsFKTables.ForEach(x => this.AddColumnSameAsFKTable(x));
			from.CompositePrimaryKeys.ForEach(x => this.AddCompositePrimaryKey(x));
			from.IncludedColumnTests.ForEach(x => this.AddIncludedColumnTest(x));
			from.People.ForEach(x => this.AddPerson(x));
			from.RowVersionChecks.ForEach(x => this.AddRowVersionCheck(x));
			from.SelfReferences.ForEach(x => this.AddSelfReference(x));
			from.Tables.ForEach(x => this.AddTable(x));
			from.TestAllFieldTypes.ForEach(x => this.AddTestAllFieldType(x));
			from.TestAllFieldTypesNullables.ForEach(x => this.AddTestAllFieldTypesNullable(x));
			from.TimestampChecks.ForEach(x => this.AddTimestampCheck(x));
			from.VPersons.ForEach(x => this.AddVPerson(x));
			from.SchemaAPersons.ForEach(x => this.AddSchemaAPerson(x));
			from.SchemaBPersons.ForEach(x => this.AddSchemaBPerson(x));
			from.PersonRefs.ForEach(x => this.AddPersonRef(x));
		}

		public List<ApiColumnSameAsFKTableClientResponseModel> ColumnSameAsFKTables { get; private set; } = new List<ApiColumnSameAsFKTableClientResponseModel>();

		public List<ApiCompositePrimaryKeyClientResponseModel> CompositePrimaryKeys { get; private set; } = new List<ApiCompositePrimaryKeyClientResponseModel>();

		public List<ApiIncludedColumnTestClientResponseModel> IncludedColumnTests { get; private set; } = new List<ApiIncludedColumnTestClientResponseModel>();

		public List<ApiPersonClientResponseModel> People { get; private set; } = new List<ApiPersonClientResponseModel>();

		public List<ApiRowVersionCheckClientResponseModel> RowVersionChecks { get; private set; } = new List<ApiRowVersionCheckClientResponseModel>();

		public List<ApiSelfReferenceClientResponseModel> SelfReferences { get; private set; } = new List<ApiSelfReferenceClientResponseModel>();

		public List<ApiTableClientResponseModel> Tables { get; private set; } = new List<ApiTableClientResponseModel>();

		public List<ApiTestAllFieldTypeClientResponseModel> TestAllFieldTypes { get; private set; } = new List<ApiTestAllFieldTypeClientResponseModel>();

		public List<ApiTestAllFieldTypesNullableClientResponseModel> TestAllFieldTypesNullables { get; private set; } = new List<ApiTestAllFieldTypesNullableClientResponseModel>();

		public List<ApiTimestampCheckClientResponseModel> TimestampChecks { get; private set; } = new List<ApiTimestampCheckClientResponseModel>();

		public List<ApiVPersonClientResponseModel> VPersons { get; private set; } = new List<ApiVPersonClientResponseModel>();

		public List<ApiSchemaAPersonClientResponseModel> SchemaAPersons { get; private set; } = new List<ApiSchemaAPersonClientResponseModel>();

		public List<ApiSchemaBPersonClientResponseModel> SchemaBPersons { get; private set; } = new List<ApiSchemaBPersonClientResponseModel>();

		public List<ApiPersonRefClientResponseModel> PersonRefs { get; private set; } = new List<ApiPersonRefClientResponseModel>();

		public void AddColumnSameAsFKTable(ApiColumnSameAsFKTableClientResponseModel item)
		{
			if (!this.ColumnSameAsFKTables.Any(x => x.Id == item.Id))
			{
				this.ColumnSameAsFKTables.Add(item);
			}
		}

		public void AddCompositePrimaryKey(ApiCompositePrimaryKeyClientResponseModel item)
		{
			if (!this.CompositePrimaryKeys.Any(x => x.Id == item.Id))
			{
				this.CompositePrimaryKeys.Add(item);
			}
		}

		public void AddIncludedColumnTest(ApiIncludedColumnTestClientResponseModel item)
		{
			if (!this.IncludedColumnTests.Any(x => x.Id == item.Id))
			{
				this.IncludedColumnTests.Add(item);
			}
		}

		public void AddPerson(ApiPersonClientResponseModel item)
		{
			if (!this.People.Any(x => x.PersonId == item.PersonId))
			{
				this.People.Add(item);
			}
		}

		public void AddRowVersionCheck(ApiRowVersionCheckClientResponseModel item)
		{
			if (!this.RowVersionChecks.Any(x => x.Id == item.Id))
			{
				this.RowVersionChecks.Add(item);
			}
		}

		public void AddSelfReference(ApiSelfReferenceClientResponseModel item)
		{
			if (!this.SelfReferences.Any(x => x.Id == item.Id))
			{
				this.SelfReferences.Add(item);
			}
		}

		public void AddTable(ApiTableClientResponseModel item)
		{
			if (!this.Tables.Any(x => x.Id == item.Id))
			{
				this.Tables.Add(item);
			}
		}

		public void AddTestAllFieldType(ApiTestAllFieldTypeClientResponseModel item)
		{
			if (!this.TestAllFieldTypes.Any(x => x.Id == item.Id))
			{
				this.TestAllFieldTypes.Add(item);
			}
		}

		public void AddTestAllFieldTypesNullable(ApiTestAllFieldTypesNullableClientResponseModel item)
		{
			if (!this.TestAllFieldTypesNullables.Any(x => x.Id == item.Id))
			{
				this.TestAllFieldTypesNullables.Add(item);
			}
		}

		public void AddTimestampCheck(ApiTimestampCheckClientResponseModel item)
		{
			if (!this.TimestampChecks.Any(x => x.Id == item.Id))
			{
				this.TimestampChecks.Add(item);
			}
		}

		public void AddVPerson(ApiVPersonClientResponseModel item)
		{
			if (!this.VPersons.Any(x => x.PersonId == item.PersonId))
			{
				this.VPersons.Add(item);
			}
		}

		public void AddSchemaAPerson(ApiSchemaAPersonClientResponseModel item)
		{
			if (!this.SchemaAPersons.Any(x => x.Id == item.Id))
			{
				this.SchemaAPersons.Add(item);
			}
		}

		public void AddSchemaBPerson(ApiSchemaBPersonClientResponseModel item)
		{
			if (!this.SchemaBPersons.Any(x => x.Id == item.Id))
			{
				this.SchemaBPersons.Add(item);
			}
		}

		public void AddPersonRef(ApiPersonRefClientResponseModel item)
		{
			if (!this.PersonRefs.Any(x => x.Id == item.Id))
			{
				this.PersonRefs.Add(item);
			}
		}
	}
}

/*<Codenesium>
    <Hash>ed5e2784fbad2cef167eaed59cdfc945</Hash>
</Codenesium>*/