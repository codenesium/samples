import React, { Component, FormEvent } from 'react';
import axios from 'axios';
import { Constants, ApiRoutes, ClientRoutes } from '../../constants';
import * as Api from '../../api/models';
import TransactionHistoryArchiveMapper from '../transactionHistoryArchive/transactionHistoryArchiveMapper';
import TransactionHistoryArchiveViewModel from '../transactionHistoryArchive/transactionHistoryArchiveViewModel';
import { Form, Input, Button, Spin, Alert } from 'antd';
import { WrappedFormUtils } from 'antd/es/form/Form';
import ReactTable from "react-table";

interface TransactionHistoryArchiveTableComponentProps {
  transactionID:number,
  apiRoute:string;
  history: any;
  match: any;
}

interface TransactionHistoryArchiveTableComponentState {
  loading: boolean;
  loaded: boolean;
  errorOccurred: boolean;
  errorMessage: string;
  filteredRecords : Array<TransactionHistoryArchiveViewModel>;
}

export class  TransactionHistoryArchiveTableComponent extends React.Component<
TransactionHistoryArchiveTableComponentProps,
TransactionHistoryArchiveTableComponentState
> {
  state = {
    loading: false,
    loaded: true,
    errorOccurred: false,
    errorMessage: '',
    filteredRecords:[]
  };

handleEditClick(e:any, row: TransactionHistoryArchiveViewModel) {
  this.props.history.push(ClientRoutes.TransactionHistoryArchives + '/edit/' + row.id);
}

handleDetailClick(e:any, row: TransactionHistoryArchiveViewModel) {
  this.props.history.push(ClientRoutes.TransactionHistoryArchives + '/' + row.id);
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
          let response = resp.data as Array<Api.TransactionHistoryArchiveClientResponseModel>;

          console.log(response);

          let mapper = new TransactionHistoryArchiveMapper();
          
          let transactionHistoryArchives:Array<TransactionHistoryArchiveViewModel> = [];

          response.forEach(x =>
          {
              transactionHistoryArchives.push(mapper.mapApiResponseToViewModel(x));
          });
          this.setState({
            ...this.state,
            filteredRecords: transactionHistoryArchives,
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
                    Header: 'TransactionHistoryArchives',
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
                      return <span>{String(props.original.productID)}</span>;
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
                        Cell: row => (<div>
					    <Button
                          type="primary" 
                          onClick={(e:any) => {
                            this.handleDetailClick(
                              e,
                              row.original as TransactionHistoryArchiveViewModel
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
                              row.original as TransactionHistoryArchiveViewModel
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
    <Hash>4fcd10b8607a1771dbdb20a3cbb9786d</Hash>
</Codenesium>*/