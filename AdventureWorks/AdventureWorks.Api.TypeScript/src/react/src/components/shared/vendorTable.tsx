import React, { Component, FormEvent } from 'react';
import axios from 'axios';
import { Constants, ApiRoutes, ClientRoutes } from '../../constants';
import * as Api from '../../api/models';
import VendorMapper from '../vendor/vendorMapper';
import VendorViewModel from '../vendor/vendorViewModel';
import { Form, Input, Button, Spin, Alert } from 'antd';
import { WrappedFormUtils } from 'antd/es/form/Form';
import ReactTable from "react-table";

interface VendorTableComponentProps {
  businessEntityID:number,
  apiRoute:string;
  history: any;
  match: any;
}

interface VendorTableComponentState {
  loading: boolean;
  loaded: boolean;
  errorOccurred: boolean;
  errorMessage: string;
  filteredRecords : Array<VendorViewModel>;
}

export class  VendorTableComponent extends React.Component<
VendorTableComponentProps,
VendorTableComponentState
> {
  state = {
    loading: false,
    loaded: true,
    errorOccurred: false,
    errorMessage: '',
    filteredRecords:[]
  };

handleEditClick(e:any, row: VendorViewModel) {
  this.props.history.push(ClientRoutes.Vendors + '/edit/' + row.id);
}

 handleDetailClick(e:any, row: VendorViewModel) {
   this.props.history.push(ClientRoutes.Vendors + '/' + row.id);
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
          let response = resp.data as Array<Api.VendorClientResponseModel>;

          console.log(response);

          let mapper = new VendorMapper();
          
          let vendors:Array<VendorViewModel> = [];

          response.forEach(x =>
          {
              vendors.push(mapper.mapApiResponseToViewModel(x));
          });
          this.setState({
            ...this.state,
            filteredRecords: vendors,
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
                    Header: 'Vendors',
                    columns: [
					  {
                      Header: 'AccountNumber',
                      accessor: 'accountNumber',
                      Cell: (props) => {
                      return <span>{String(props.original.accountNumber)}</span>;
                      }           
                    },  {
                      Header: 'ActiveFlag',
                      accessor: 'activeFlag',
                      Cell: (props) => {
                      return <span>{String(props.original.activeFlag)}</span>;
                      }           
                    },  {
                      Header: 'BusinessEntityID',
                      accessor: 'businessEntityID',
                      Cell: (props) => {
                      return <span>{String(props.original.businessEntityID)}</span>;
                      }           
                    },  {
                      Header: 'CreditRating',
                      accessor: 'creditRating',
                      Cell: (props) => {
                      return <span>{String(props.original.creditRating)}</span>;
                      }           
                    },  {
                      Header: 'ModifiedDate',
                      accessor: 'modifiedDate',
                      Cell: (props) => {
                      return <span>{String(props.original.modifiedDate)}</span>;
                      }           
                    },  {
                      Header: 'Name',
                      accessor: 'name',
                      Cell: (props) => {
                      return <span>{String(props.original.name)}</span>;
                      }           
                    },  {
                      Header: 'PreferredVendorStatus',
                      accessor: 'preferredVendorStatu',
                      Cell: (props) => {
                      return <span>{String(props.original.preferredVendorStatu)}</span>;
                      }           
                    },  {
                      Header: 'PurchasingWebServiceURL',
                      accessor: 'purchasingWebServiceURL',
                      Cell: (props) => {
                      return <span>{String(props.original.purchasingWebServiceURL)}</span>;
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
                              row.original as VendorViewModel
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
                              row.original as VendorViewModel
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
    <Hash>e8e1cb15b0d7a8dd245cbf52397ea0c9</Hash>
</Codenesium>*/