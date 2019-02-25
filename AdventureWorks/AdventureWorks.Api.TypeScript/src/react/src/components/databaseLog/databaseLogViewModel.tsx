import moment from 'moment';

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
    this.databaseLogID = moment(databaseLogID, 'YYYY-MM-DD');
    this.databaseUser = moment(databaseUser, 'YYYY-MM-DD');
    this.postTime = moment(postTime, 'YYYY-MM-DD');
    this.schema = moment(schema, 'YYYY-MM-DD');
    this.tsql = moment(tsql, 'YYYY-MM-DD');
    this.xmlEvent = moment(xmlEvent, 'YYYY-MM-DD');
  }

  toDisplay(): string {
    return String();
  }
}


/*<Codenesium>
    <Hash>b3c583671f4cb74df797cf0d158ea5fe</Hash>
</Codenesium>*/