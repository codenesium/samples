import React, { Component, FormEvent } from 'react';
import axios from 'axios';
import { Constants, ApiRoutes, ClientRoutes } from '../../constants';
import * as Api from '../../api/models';
import SaleMapper from '../sale/saleMapper';
import SaleViewModel from '../sale/saleViewModel';
import { Form, Input, Button, Spin, Alert } from 'antd';
import { WrappedFormUtils } from 'antd/es/form/Form';
import ReactTable from "react-table";

interface SaleTableComponentProps {
  id:number,
  apiRoute:string;
  history: any;
  match: any;
}

interface SaleTableComponentState {
  loading: boolean;
  loaded: boolean;
  errorOccurred: boolean;
  errorMessage: string;
  filteredRecords : Array<SaleViewModel>;
}

export class  SaleTableComponent extends React.Component<
SaleTableComponentProps,
SaleTableComponentState
> {
  state = {
    loading: false,
    loaded: true,
    errorOccurred: false,
    errorMessage: '',
    filteredRecords:[]
  };

handleEditClick(e:any, row: SaleViewModel) {
  this.props.history.push(ClientRoutes.Sales + '/edit/' + row.id);
}

handleDetailClick(e:any, row: SaleViewModel) {
  this.props.history.push(ClientRoutes.Sales + '/' + row.id);
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
          let response = resp.data as Array<Api.SaleClientResponseModel>;

          console.log(response);

          let mapper = new SaleMapper();
          
          let sales:Array<SaleViewModel> = [];

          response.forEach(x =>
          {
              sales.push(mapper.mapApiResponseToViewModel(x));
          });
          this.setState({
            ...this.state,
            filteredRecords: sales,
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
                    Header: 'Sales',
                    columns: [
					  {
                      Header: 'IpAddress',
                      accessor: 'ipAddress',
                      Cell: (props) => {
                      return <span>{String(props.original.ipAddress)}</span>;
                      }           
                    },  {
                      Header: 'Notes',
                      accessor: 'note',
                      Cell: (props) => {
                      return <span>{String(props.original.note)}</span>;
                      }           
                    },  {
                      Header: 'SaleDate',
                      accessor: 'saleDate',
                      Cell: (props) => {
                      return <span>{String(props.original.saleDate)}</span>;
                      }           
                    },  {
                      Header: 'TransactionId',
                      accessor: 'transactionId',
                      Cell: (props) => {
                        return <a href='' onClick={(e) => { e.preventDefault(); this.props.history.push(ClientRoutes.Transactions + '/' + props.original.transactionId); }}>
                          {String(
                            props.original.transactionIdNavigation.toDisplay()
                          )}
                        </a>
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
                              row.original as SaleViewModel
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
                              row.original as SaleViewModel
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
    <Hash>d3be9d6cb9eb0049453bd5e9bbd1619f</Hash>
</Codenesium>*/