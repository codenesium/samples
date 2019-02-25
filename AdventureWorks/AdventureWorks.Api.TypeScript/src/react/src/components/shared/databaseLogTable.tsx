import React, { Component, FormEvent } from 'react';
import axios from 'axios';
import { Constants, ApiRoutes, ClientRoutes } from '../../constants';
import * as Api from '../../api/models';
import DatabaseLogMapper from '../databaseLog/databaseLogMapper';
import DatabaseLogViewModel from '../databaseLog/databaseLogViewModel';
import { Form, Input, Button, Spin, Alert } from 'antd';
import { WrappedFormUtils } from 'antd/es/form/Form';
import ReactTable from "react-table";

interface DatabaseLogTableComponentProps {
  databaseLogID:number,
  apiRoute:string;
  history: any;
  match: any;
}

interface DatabaseLogTableComponentState {
  loading: boolean;
  loaded: boolean;
  errorOccurred: boolean;
  errorMessage: string;
  filteredRecords : Array<DatabaseLogViewModel>;
}

export class  DatabaseLogTableComponent extends React.Component<
DatabaseLogTableComponentProps,
DatabaseLogTableComponentState
> {
  state = {
    loading: false,
    loaded: true,
    errorOccurred: false,
    errorMessage: '',
    filteredRecords:[]
  };

handleEditClick(e:any, row: DatabaseLogViewModel) {
  this.props.history.push(ClientRoutes.DatabaseLogs + '/edit/' + row.id);
}

handleDetailClick(e:any, row: DatabaseLogViewModel) {
  this.props.history.push(ClientRoutes.DatabaseLogs + '/' + row.id);
}

  componentDidMount() {
    this.setState({ ...this.state, loading: true });

    axios
      .get(this.props.apiRoute,
        {
          headers: {
            'Content-Type': 'application/json',
          },
        }
      )
      .then(
        resp => {
          let response = resp.data as Array<Api.DatabaseLogClientResponseModel>;

          console.log(response);

          let mapper = new DatabaseLogMapper();
          
          let databaseLogs:Array<DatabaseLogViewModel> = [];

          response.forEach(x =>
          {
              databaseLogs.push(mapper.mapApiResponseToViewModel(x));
          });
          this.setState({
            ...this.state,
            filteredRecords: databaseLogs,
            loading: false,
            loaded: true,
            errorOccurred: false,
            errorMessage: '',
          });
        },
        error => {
          console.log(error);
          this.setState({
            ...this.state,
            loading: false,
            loaded: false,
            errorOccurred: true,
            errorMessage: 'Error from API',
          });
        }
      );
  }

  render() {
    
	let message: JSX.Element = <div />;
    if (this.state.errorOccurred) {
      message = <Alert message={this.state.errorMessage} type="error" />;
    }

    if (this.state.loading) {
       return <Spin size="large" />;
    }
	else if (this.state.errorOccurred) {
	  return <Alert message={this.state.errorMessage} type='error' />;
	}
	 else if (this.state.loaded) {
      return (
	  <div>
		{message}
         <ReactTable 
                data={this.state.filteredRecords}
				defaultPageSize={10}
                columns={[{
                    Header: 'DatabaseLogs',
                    columns: [
					  {
                      Header: 'DatabaseLogID',
                      accessor: 'databaseLogID',
                      Cell: (props) => {
                      return <span>{String(props.original.databaseLogID)}</span>;
                      }           
                    },  {
                      Header: 'DatabaseUser',
                      accessor: 'databaseUser',
                      Cell: (props) => {
                      return <span>{String(props.original.databaseUser)}</span>;
                      }           
                    },  {
                      Header: 'PostTime',
                      accessor: 'postTime',
                      Cell: (props) => {
                      return <span>{String(props.original.postTime)}</span>;
                      }           
                    },  {
                      Header: 'Schema',
                      accessor: 'schema',
                      Cell: (props) => {
                      return <span>{String(props.original.schema)}</span>;
                      }           
                    },  {
                      Header: 'TSQL',
                      accessor: 'tsql',
                      Cell: (props) => {
                      return <span>{String(props.original.tsql)}</span>;
                      }           
                    },  {
                      Header: 'XmlEvent',
                      accessor: 'xmlEvent',
                      Cell: (props) => {
                      return <span>{String(props.original.xmlEvent)}</span>;
                      }           
                    },
                    {
                        Header: 'Actions',
                        Cell: row => (<div>
					    <Button
                          type="primary" 
                          onClick={(e:any) => {
                            this.handleDetailClick(
                              e,
                              row.original as DatabaseLogViewModel
                            );
                          }}
                        >
                          <i className="fas fa-search" />
                        </Button>
                        &nbsp;
                        <Button
                          type="primary" 
                          onClick={(e:any) => {
                            this.handleEditClick(
                              e,
                              row.original as DatabaseLogViewModel
                            );
                          }}
                        >
                          <i className="fas fa-edit" />
                        </Button>
                        </div>)
                    }],
                    
                  }]} />
			</div>
      );
    } else {
      return null;
    }
  }
}

/*<Codenesium>
    <Hash>72cbded2f29c7241624242d60ddbdf81</Hash>
</Codenesium>*/