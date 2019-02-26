import React, { Component, FormEvent } from 'react';
import axios from 'axios';
import { Constants, ApiRoutes, ClientRoutes } from '../../constants';
import * as Api from '../../api/models';
import TransactionHistoryMapper from '../transactionHistory/transactionHistoryMapper';
import TransactionHistoryViewModel from '../transactionHistory/transactionHistoryViewModel';
import { Form, Input, Button, Spin, Alert } from 'antd';
import { WrappedFormUtils } from 'antd/es/form/Form';
import ReactTable from "react-table";

interface TransactionHistoryTableComponentProps {
  transactionID:number,
  apiRoute:string;
  history: any;
  match: any;
}

interface TransactionHistoryTableComponentState {
  loading: boolean;
  loaded: boolean;
  errorOccurred: boolean;
  errorMessage: string;
  filteredRecords : Array<TransactionHistoryViewModel>;
}

export class  TransactionHistoryTableComponent extends React.Component<
TransactionHistoryTableComponentProps,
TransactionHistoryTableComponentState
> {
  state = {
    loading: false,
    loaded: true,
    errorOccurred: false,
    errorMessage: '',
    filteredRecords:[]
  };

handleEditClick(e:any, row: TransactionHistoryViewModel) {
  this.props.history.push(ClientRoutes.TransactionHistories + '/edit/' + row.id);
}

 handleDetailClick(e:any, row: TransactionHistoryViewModel) {
   this.props.history.push(ClientRoutes.TransactionHistories + '/' + row.id);
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
          let response = resp.data as Array<Api.TransactionHistoryClientResponseModel>;

          console.log(response);

          let mapper = new TransactionHistoryMapper();
          
          let transactionHistories:Array<TransactionHistoryViewModel> = [];

          response.forEach(x =>
          {
              transactionHistories.push(mapper.mapApiResponseToViewModel(x));
          });
          this.setState({
            ...this.state,
            filteredRecords: transactionHistories,
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
                    Header: 'TransactionHistories',
                    columns: [
					  {
                      Header: 'ActualCost',
                      accessor: 'actualCost',
                      Cell: (props) => {
                      return <span>{String(props.original.actualCost)}</span>;
                      }           
                    },  {
                      Header: 'ModifiedDate',
                      accessor: 'modifiedDate',
                      Cell: (props) => {
                      return <span>{String(props.original.modifiedDate)}</span>;
                      }           
                    },  {
                      Header: 'ProductID',
                      accessor: 'productID',
                      Cell: (props) => {
                        return <a href='' onClick={(e) => { e.preventDefault(); this.props.history.push(ClientRoutes.Products + '/' + props.original.productID); }}>
                          {String(
                            props.original.productIDNavigation.toDisplay()
                          )}
                        </a>
                      }           
                    },  {
                      Header: 'Quantity',
                      accessor: 'quantity',
                      Cell: (props) => {
                      return <span>{String(props.original.quantity)}</span>;
                      }           
                    },  {
                      Header: 'ReferenceOrderID',
                      accessor: 'referenceOrderID',
                      Cell: (props) => {
                      return <span>{String(props.original.referenceOrderID)}</span>;
                      }           
                    },  {
                      Header: 'ReferenceOrderLineID',
                      accessor: 'referenceOrderLineID',
                      Cell: (props) => {
                      return <span>{String(props.original.referenceOrderLineID)}</span>;
                      }           
                    },  {
                      Header: 'TransactionDate',
                      accessor: 'transactionDate',
                      Cell: (props) => {
                      return <span>{String(props.original.transactionDate)}</span>;
                      }           
                    },  {
                      Header: 'TransactionID',
                      accessor: 'transactionID',
                      Cell: (props) => {
                      return <span>{String(props.original.transactionID)}</span>;
                      }           
                    },  {
                      Header: 'TransactionType',
                      accessor: 'transactionType',
                      Cell: (props) => {
                      return <span>{String(props.original.transactionType)}</span>;
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
                              row.original as TransactionHistoryViewModel
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
                              row.original as TransactionHistoryViewModel
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
    <Hash>74856bff4c5f50e79253f001dd274cea</Hash>
</Codenesium>*/