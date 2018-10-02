using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;

namespace TestsNS.Api.Contracts
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

		public List<ApiColumnSameAsFKTableResponseModel> ColumnSameAsFKTables { get; private set; } = new List<ApiColumnSameAsFKTableResponseModel>();

		public List<ApiCompositePrimaryKeyResponseModel> CompositePrimaryKeys { get; private set; } = new List<ApiCompositePrimaryKeyResponseModel>();

		public List<ApiIncludedColumnTestResponseModel> IncludedColumnTests { get; private set; } = new List<ApiIncludedColumnTestResponseModel>();

		public List<ApiPersonResponseModel> People { get; private set; } = new List<ApiPersonResponseModel>();

		public List<ApiRowVersionCheckResponseModel> RowVersionChecks { get; private set; } = new List<ApiRowVersionCheckResponseModel>();

		public List<ApiSelfReferenceResponseModel> SelfReferences { get; private set; } = new List<ApiSelfReferenceResponseModel>();

		public List<ApiTableResponseModel> Tables { get; private set; } = new List<ApiTableResponseModel>();

		public List<ApiTestAllFieldTypeResponseModel> TestAllFieldTypes { get; private set; } = new List<ApiTestAllFieldTypeResponseModel>();

		public List<ApiTestAllFieldTypesNullableResponseModel> TestAllFieldTypesNullables { get; private set; } = new List<ApiTestAllFieldTypesNullableResponseModel>();

		public List<ApiTimestampCheckResponseModel> TimestampChecks { get; private set; } = new List<ApiTimestampCheckResponseModel>();

		public List<ApiVPersonResponseModel> VPersons { get; private set; } = new List<ApiVPersonResponseModel>();

		public List<ApiSchemaAPersonResponseModel> SchemaAPersons { get; private set; } = new List<ApiSchemaAPersonResponseModel>();

		public List<ApiSchemaBPersonResponseModel> SchemaBPersons { get; private set; } = new List<ApiSchemaBPersonResponseModel>();

		public List<ApiPersonRefResponseModel> PersonRefs { get; private set; } = new List<ApiPersonRefResponseModel>();

		[JsonIgnore]
		public bool ShouldSerializeColumnSameAsFKTablesValue { get; private set; } = true;

		public bool ShouldSerializeColumnSameAsFKTables()
		{
			return this.ShouldSerializeColumnSameAsFKTablesValue;
		}

		public void AddColumnSameAsFKTable(ApiColumnSameAsFKTableResponseModel item)
		{
			if (!this.ColumnSameAsFKTables.Any(x => x.Id == item.Id))
			{
				this.ColumnSameAsFKTables.Add(item);
			}
		}

		[JsonIgnore]
		public bool ShouldSerializeCompositePrimaryKeysValue { get; private set; } = true;

		public bool ShouldSerializeCompositePrimaryKeys()
		{
			return this.ShouldSerializeCompositePrimaryKeysValue;
		}

		public void AddCompositePrimaryKey(ApiCompositePrimaryKeyResponseModel item)
		{
			if (!this.CompositePrimaryKeys.Any(x => x.Id == item.Id))
			{
				this.CompositePrimaryKeys.Add(item);
			}
		}

		[JsonIgnore]
		public bool ShouldSerializeIncludedColumnTestsValue { get; private set; } = true;

		public bool ShouldSerializeIncludedColumnTests()
		{
			return this.ShouldSerializeIncludedColumnTestsValue;
		}

		public void AddIncludedColumnTest(ApiIncludedColumnTestResponseModel item)
		{
			if (!this.IncludedColumnTests.Any(x => x.Id == item.Id))
			{
				this.IncludedColumnTests.Add(item);
			}
		}

		[JsonIgnore]
		public bool ShouldSerializePeopleValue { get; private set; } = true;

		public bool ShouldSerializePeople()
		{
			return this.ShouldSerializePeopleValue;
		}

		public void AddPerson(ApiPersonResponseModel item)
		{
			if (!this.People.Any(x => x.PersonId == item.PersonId))
			{
				this.People.Add(item);
			}
		}

		[JsonIgnore]
		public bool ShouldSerializeRowVersionChecksValue { get; private set; } = true;

		public bool ShouldSerializeRowVersionChecks()
		{
			return this.ShouldSerializeRowVersionChecksValue;
		}

		public void AddRowVersionCheck(ApiRowVersionCheckResponseModel item)
		{
			if (!this.RowVersionChecks.Any(x => x.Id == item.Id))
			{
				this.RowVersionChecks.Add(item);
			}
		}

		[JsonIgnore]
		public bool ShouldSerializeSelfReferencesValue { get; private set; } = true;

		public bool ShouldSerializeSelfReferences()
		{
			return this.ShouldSerializeSelfReferencesValue;
		}

		public void AddSelfReference(ApiSelfReferenceResponseModel item)
		{
			if (!this.SelfReferences.Any(x => x.Id == item.Id))
			{
				this.SelfReferences.Add(item);
			}
		}

		[JsonIgnore]
		public bool ShouldSerializeTablesValue { get; private set; } = true;

		public bool ShouldSerializeTables()
		{
			return this.ShouldSerializeTablesValue;
		}

		public void AddTable(ApiTableResponseModel item)
		{
			if (!this.Tables.Any(x => x.Id == item.Id))
			{
				this.Tables.Add(item);
			}
		}

		[JsonIgnore]
		public bool ShouldSerializeTestAllFieldTypesValue { get; private set; } = true;

		public bool ShouldSerializeTestAllFieldTypes()
		{
			return this.ShouldSerializeTestAllFieldTypesValue;
		}

		public void AddTestAllFieldType(ApiTestAllFieldTypeResponseModel item)
		{
			if (!this.TestAllFieldTypes.Any(x => x.Id == item.Id))
			{
				this.TestAllFieldTypes.Add(item);
			}
		}

		[JsonIgnore]
		public bool ShouldSerializeTestAllFieldTypesNullablesValue { get; private set; } = true;

		public bool ShouldSerializeTestAllFieldTypesNullables()
		{
			return this.ShouldSerializeTestAllFieldTypesNullablesValue;
		}

		public void AddTestAllFieldTypesNullable(ApiTestAllFieldTypesNullableResponseModel item)
		{
			if (!this.TestAllFieldTypesNullables.Any(x => x.Id == item.Id))
			{
				this.TestAllFieldTypesNullables.Add(item);
			}
		}

		[JsonIgnore]
		public bool ShouldSerializeTimestampChecksValue { get; private set; } = true;

		public bool ShouldSerializeTimestampChecks()
		{
			return this.ShouldSerializeTimestampChecksValue;
		}

		public void AddTimestampCheck(ApiTimestampCheckResponseModel item)
		{
			if (!this.TimestampChecks.Any(x => x.Id == item.Id))
			{
				this.TimestampChecks.Add(item);
			}
		}

		[JsonIgnore]
		public bool ShouldSerializeVPersonsValue { get; private set; } = true;

		public bool ShouldSerializeVPersons()
		{
			return this.ShouldSerializeVPersonsValue;
		}

		public void AddVPerson(ApiVPersonResponseModel item)
		{
			if (!this.VPersons.Any(x => x.PersonId == item.PersonId))
			{
				this.VPersons.Add(item);
			}
		}

		[JsonIgnore]
		public bool ShouldSerializeSchemaAPersonsValue { get; private set; } = true;

		public bool ShouldSerializeSchemaAPersons()
		{
			return this.ShouldSerializeSchemaAPersonsValue;
		}

		public void AddSchemaAPerson(ApiSchemaAPersonResponseModel item)
		{
			if (!this.SchemaAPersons.Any(x => x.Id == item.Id))
			{
				this.SchemaAPersons.Add(item);
			}
		}

		[JsonIgnore]
		public bool ShouldSerializeSchemaBPersonsValue { get; private set; } = true;

		public bool ShouldSerializeSchemaBPersons()
		{
			return this.ShouldSerializeSchemaBPersonsValue;
		}

		public void AddSchemaBPerson(ApiSchemaBPersonResponseModel item)
		{
			if (!this.SchemaBPersons.Any(x => x.Id == item.Id))
			{
				this.SchemaBPersons.Add(item);
			}
		}

		[JsonIgnore]
		public bool ShouldSerializePersonRefsValue { get; private set; } = true;

		public bool ShouldSerializePersonRefs()
		{
			return this.ShouldSerializePersonRefsValue;
		}

		public void AddPersonRef(ApiPersonRefResponseModel item)
		{
			if (!this.PersonRefs.Any(x => x.Id == item.Id))
			{
				this.PersonRefs.Add(item);
			}
		}

		public void DisableSerializationOfEmptyFields()
		{
			if (this.ColumnSameAsFKTables.Count == 0)
			{
				this.ShouldSerializeColumnSameAsFKTablesValue = false;
			}

			if (this.CompositePrimaryKeys.Count == 0)
			{
				this.ShouldSerializeCompositePrimaryKeysValue = false;
			}

			if (this.IncludedColumnTests.Count == 0)
			{
				this.ShouldSerializeIncludedColumnTestsValue = false;
			}

			if (this.People.Count == 0)
			{
				this.ShouldSerializePeopleValue = false;
			}

			if (this.RowVersionChecks.Count == 0)
			{
				this.ShouldSerializeRowVersionChecksValue = false;
			}

			if (this.SelfReferences.Count == 0)
			{
				this.ShouldSerializeSelfReferencesValue = false;
			}

			if (this.Tables.Count == 0)
			{
				this.ShouldSerializeTablesValue = false;
			}

			if (this.TestAllFieldTypes.Count == 0)
			{
				this.ShouldSerializeTestAllFieldTypesValue = false;
			}

			if (this.TestAllFieldTypesNullables.Count == 0)
			{
				this.ShouldSerializeTestAllFieldTypesNullablesValue = false;
			}

			if (this.TimestampChecks.Count == 0)
			{
				this.ShouldSerializeTimestampChecksValue = false;
			}

			if (this.VPersons.Count == 0)
			{
				this.ShouldSerializeVPersonsValue = false;
			}

			if (this.SchemaAPersons.Count == 0)
			{
				this.ShouldSerializeSchemaAPersonsValue = false;
			}

			if (this.SchemaBPersons.Count == 0)
			{
				this.ShouldSerializeSchemaBPersonsValue = false;
			}

			if (this.PersonRefs.Count == 0)
			{
				this.ShouldSerializePersonRefsValue = false;
			}
		}
	}
}

/*<Codenesium>
    <Hash>bbe1ba5a9fe92b73a8e2eb3a1fd4e30c</Hash>
</Codenesium>*/