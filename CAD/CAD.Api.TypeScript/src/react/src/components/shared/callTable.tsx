import React, { Component, FormEvent } from 'react';
import axios from 'axios';
import { Constants, ApiRoutes, ClientRoutes } from '../../constants';
import * as Api from '../../api/models';
import CallMapper from '../call/callMapper';
import CallViewModel from '../call/callViewModel';
import { Form, Input, Button, Spin, Alert } from 'antd';
import { WrappedFormUtils } from 'antd/es/form/Form';
import ReactTable from "react-table";

interface CallTableComponentProps {
  id:number,
  apiRoute:string;
  history: any;
  match: any;
}

interface CallTableComponentState {
  loading: boolean;
  loaded: boolean;
  errorOccurred: boolean;
  errorMessage: string;
  filteredRecords : Array<CallViewModel>;
}

export class  CallTableComponent extends React.Component<
CallTableComponentProps,
CallTableComponentState
> {
  state = {
    loading: false,
    loaded: true,
    errorOccurred: false,
    errorMessage: '',
    filteredRecords:[]
  };

handleEditClick(e:any, row: CallViewModel) {
  this.props.history.push(ClientRoutes.Calls + '/edit/' + row.id);
}

 handleDetailClick(e:any, row: CallViewModel) {
   this.props.history.push(ClientRoutes.Calls + '/' + row.id);
 }

  componentDidMount() {
	this.loadRecords();
  }

  loadRecords() {
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
          let response = resp.data as Array<Api.CallClientResponseModel>;

          console.log(response);

          let mapper = new CallMapper();
          
          let calls:Array<CallViewModel> = [];

          response.forEach(x =>
          {
              calls.push(mapper.mapApiResponseToViewModel(x));
          });
          this.setState({
            ...this.state,
            filteredRecords: calls,
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
                    Header: 'Calls',
                    columns: [
					  {
                      Header: 'AddressId',
                      accessor: 'addressId',
                      Cell: (props) => {
                        return <a href='' onClick={(e) => { e.preventDefault(); this.props.history.push(ClientRoutes.Addresses + '/' + props.original.addressId); }}>
                          {String(
                            props.original.addressIdNavigation.toDisplay()
                          )}
                        </a>
                      }           
                    },  {
                      Header: 'CallDispositionId',
                      accessor: 'callDispositionId',
                      Cell: (props) => {
                        return <a href='' onClick={(e) => { e.preventDefault(); this.props.history.push(ClientRoutes.CallDispositions + '/' + props.original.callDispositionId); }}>
                          {String(
                            props.original.callDispositionIdNavigation.toDisplay()
                          )}
                        </a>
                      }           
                    },  {
                      Header: 'CallStatusId',
                      accessor: 'callStatusId',
                      Cell: (props) => {
                        return <a href='' onClick={(e) => { e.preventDefault(); this.props.history.push(ClientRoutes.CallStatus + '/' + props.original.callStatusId); }}>
                          {String(
                            props.original.callStatusIdNavigation.toDisplay()
                          )}
                        </a>
                      }           
                    },  {
                      Header: 'CallString',
                      accessor: 'callString',
                      Cell: (props) => {
                      return <span>{String(props.original.callString)}</span>;
                      }           
                    },  {
                      Header: 'CallTypeId',
                      accessor: 'callTypeId',
                      Cell: (props) => {
                        return <a href='' onClick={(e) => { e.preventDefault(); this.props.history.push(ClientRoutes.CallTypes + '/' + props.original.callTypeId); }}>
                          {String(
                            props.original.callTypeIdNavigation.toDisplay()
                          )}
                        </a>
                      }           
                    },  {
                      Header: 'DateCleared',
                      accessor: 'dateCleared',
                      Cell: (props) => {
                      return <span>{String(props.original.dateCleared)}</span>;
                      }           
                    },  {
                      Header: 'DateCreated',
                      accessor: 'dateCreated',
                      Cell: (props) => {
                      return <span>{String(props.original.dateCreated)}</span>;
                      }           
                    },  {
                      Header: 'DateDispatched',
                      accessor: 'dateDispatched',
                      Cell: (props) => {
                      return <span>{String(props.original.dateDispatched)}</span>;
                      }           
                    },  {
                      Header: 'QuickCallNumber',
                      accessor: 'quickCallNumber',
                      Cell: (props) => {
                      return <span>{String(props.original.quickCallNumber)}</span>;
                      }           
                    },
                    {
                        Header: 'Actions',
					    minWidth:150,
                        Cell: row => (<div>
					    <Button
                          type="primary" 
                          onClick={(e:any) => {
                            this.handleDetailClick(
                              e,
                              row.original as CallViewModel
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
                              row.original as CallViewModel
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
    <Hash>8e164ff960fb2471205162a2f6df4293</Hash>
</Codenesium>*/