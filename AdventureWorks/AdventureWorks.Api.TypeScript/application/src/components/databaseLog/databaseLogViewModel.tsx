export default class DatabaseLogViewModel {
  databaseLogID: number;
  databaseUser: string;
  postTime: any;
  schema: string;
  tsql: string;
  xmlEvent: string;

  constructor() {
    this.databaseLogID = 0;
    this.databaseUser = '';
    this.postTime = undefined;
    this.schema = '';
    this.tsql = '';
    this.xmlEvent = '';
  }

  setProperties(
    databaseLogID: number,
    databaseUser: string,
    postTime: any,
    schema: string,
    tsql: string,
    xmlEvent: string
  ): void {
    this.databaseLogID = databaseLogID;
    this.databaseUser = databaseUser;
    this.postTime = postTime;
    this.schema = schema;
    this.tsql = tsql;
    this.xmlEvent = xmlEvent;
  }
}


/*<Codenesium>
    <Hash>95081dd7d424254115570029e2cb8f63</Hash>
</Codenesium>*/