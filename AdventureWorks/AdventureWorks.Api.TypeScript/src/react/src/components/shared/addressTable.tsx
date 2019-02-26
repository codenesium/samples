import React, { Component, FormEvent } from 'react';
import axios from 'axios';
import { Constants, ApiRoutes, ClientRoutes } from '../../constants';
import * as Api from '../../api/models';
import AddressMapper from '../address/addressMapper';
import AddressViewModel from '../address/addressViewModel';
import { Form, Input, Button, Spin, Alert } from 'antd';
import { WrappedFormUtils } from 'antd/es/form/Form';
import ReactTable from "react-table";

interface AddressTableComponentProps {
  addressID:number,
  apiRoute:string;
  history: any;
  match: any;
}

interface AddressTableComponentState {
  loading: boolean;
  loaded: boolean;
  errorOccurred: boolean;
  errorMessage: string;
  filteredRecords : Array<AddressViewModel>;
}

export class  AddressTableComponent extends React.Component<
AddressTableComponentProps,
AddressTableComponentState
> {
  state = {
    loading: false,
    loaded: true,
    errorOccurred: false,
    errorMessage: '',
    filteredRecords:[]
  };

handleEditClick(e:any, row: AddressViewModel) {
  this.props.history.push(ClientRoutes.Addresses + '/edit/' + row.id);
}

 handleDetailClick(e:any, row: AddressViewModel) {
   this.props.history.push(ClientRoutes.Addresses + '/' + row.id);
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
          let response = resp.data as Array<Api.AddressClientResponseModel>;

          console.log(response);

          let mapper = new AddressMapper();
          
          let addresses:Array<AddressViewModel> = [];

          response.forEach(x =>
          {
              addresses.push(mapper.mapApiResponseToViewModel(x));
          });
          this.setState({
            ...this.state,
            filteredRecords: addresses,
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
                    Header: 'Addresses',
                    columns: [
					  {
                      Header: 'AddressID',
                      accessor: 'addressID',
                      Cell: (props) => {
                      return <span>{String(props.original.addressID)}</span>;
                      }           
                    },  {
                      Header: 'AddressLine1',
                      accessor: 'addressLine1',
                      Cell: (props) => {
                      return <span>{String(props.original.addressLine1)}</span>;
                      }           
                    },  {
                      Header: 'AddressLine2',
                      accessor: 'addressLine2',
                      Cell: (props) => {
                      return <span>{String(props.original.addressLine2)}</span>;
                      }           
                    },  {
                      Header: 'City',
                      accessor: 'city',
                      Cell: (props) => {
                      return <span>{String(props.original.city)}</span>;
                      }           
                    },  {
                      Header: 'ModifiedDate',
                      accessor: 'modifiedDate',
                      Cell: (props) => {
                      return <span>{String(props.original.modifiedDate)}</span>;
                      }           
                    },  {
                      Header: 'PostalCode',
                      accessor: 'postalCode',
                      Cell: (props) => {
                      return <span>{String(props.original.postalCode)}</span>;
                      }           
                    },  {
                      Header: 'Rowguid',
                      accessor: 'rowguid',
                      Cell: (props) => {
                      return <span>{String(props.original.rowguid)}</span>;
                      }           
                    },  {
                      Header: 'StateProvinceID',
                      accessor: 'stateProvinceID',
                      Cell: (props) => {
                        return <a href='' onClick={(e) => { e.preventDefault(); this.props.history.push(ClientRoutes.StateProvinces + '/' + props.original.stateProvinceID); }}>
                          {String(
                            props.original.stateProvinceIDNavigation.toDisplay()
                          )}
                        </a>
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
                              row.original as AddressViewModel
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
                              row.original as AddressViewModel
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
    <Hash>6bf4508b361f6a96c35d4711276a8a8f</Hash>
</Codenesium>*/