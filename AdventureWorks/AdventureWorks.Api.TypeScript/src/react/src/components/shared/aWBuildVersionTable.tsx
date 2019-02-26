import React, { Component, FormEvent } from 'react';
import axios from 'axios';
import { Constants, ApiRoutes, ClientRoutes } from '../../constants';
import * as Api from '../../api/models';
import AWBuildVersionMapper from '../aWBuildVersion/aWBuildVersionMapper';
import AWBuildVersionViewModel from '../aWBuildVersion/aWBuildVersionViewModel';
import { Form, Input, Button, Spin, Alert } from 'antd';
import { WrappedFormUtils } from 'antd/es/form/Form';
import ReactTable from "react-table";

interface AWBuildVersionTableComponentProps {
  systemInformationID:number,
  apiRoute:string;
  history: any;
  match: any;
}

interface AWBuildVersionTableComponentState {
  loading: boolean;
  loaded: boolean;
  errorOccurred: boolean;
  errorMessage: string;
  filteredRecords : Array<AWBuildVersionViewModel>;
}

export class  AWBuildVersionTableComponent extends React.Component<
AWBuildVersionTableComponentProps,
AWBuildVersionTableComponentState
> {
  state = {
    loading: false,
    loaded: true,
    errorOccurred: false,
    errorMessage: '',
    filteredRecords:[]
  };

handleEditClick(e:any, row: AWBuildVersionViewModel) {
  this.props.history.push(ClientRoutes.AWBuildVersions + '/edit/' + row.id);
}

handleDetailClick(e:any, row: AWBuildVersionViewModel) {
  this.props.history.push(ClientRoutes.AWBuildVersions + '/' + row.id);
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
          let response = resp.data as Array<Api.AWBuildVersionClientResponseModel>;

          console.log(response);

          let mapper = new AWBuildVersionMapper();
          
          let aWBuildVersions:Array<AWBuildVersionViewModel> = [];

          response.forEach(x =>
          {
              aWBuildVersions.push(mapper.mapApiResponseToViewModel(x));
          });
          this.setState({
            ...this.state,
            filteredRecords: aWBuildVersions,
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
                    Header: 'AWBuildVersions',
                    columns: [
					  {
                      Header: 'Database Version',
                      accessor: 'database_Version',
                      Cell: (props) => {
                      return <span>{String(props.original.database_Version)}</span>;
                      }           
                    },  {
                      Header: 'ModifiedDate',
                      accessor: 'modifiedDate',
                      Cell: (props) => {
                      return <span>{String(props.original.modifiedDate)}</span>;
                      }           
                    },  {
                      Header: 'SystemInformationID',
                      accessor: 'systemInformationID',
                      Cell: (props) => {
                      return <span>{String(props.original.systemInformationID)}</span>;
                      }           
                    },  {
                      Header: 'VersionDate',
                      accessor: 'versionDate',
                      Cell: (props) => {
                      return <span>{String(props.original.versionDate)}</span>;
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
                              row.original as AWBuildVersionViewModel
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
                              row.original as AWBuildVersionViewModel
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
    <Hash>3b0ea3b6e8d9ac601f8f3db5987147ce</Hash>
</Codenesium>*/