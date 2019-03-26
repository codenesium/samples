import React, { Component, FormEvent } from 'react';
import axios, { AxiosError, AxiosResponse } from 'axios';
import { Constants, ApiRoutes, ClientRoutes } from '../../constants';
import * as Api from '../../api/models';
import SaleMapper from '../sale/saleMapper';
import SaleViewModel from '../sale/saleViewModel';
import { Form, Input, Button, Spin, Alert } from 'antd';
import { WrappedFormUtils } from 'antd/es/form/Form';
import ReactTable from 'react-table';
import * as GlobalUtilities from '../../lib/globalUtilities';

interface SaleTableComponentProps {
  apiRoute: string;
  history: any;
  match: any;
}

interface SaleTableComponentState {
  loading: boolean;
  loaded: boolean;
  errorOccurred: boolean;
  errorMessage: string;
  filteredRecords: Array<SaleViewModel>;
}

export class SaleTableComponent extends React.Component<
  SaleTableComponentProps,
  SaleTableComponentState
> {
  state = {
    loading: false,
    loaded: true,
    errorOccurred: false,
    errorMessage: '',
    filteredRecords: [],
  };

  handleEditClick(e: any, row: SaleViewModel) {
    this.props.history.push(ClientRoutes.Sales + '/edit/' + row.id);
  }

  handleDetailClick(e: any, row: SaleViewModel) {
    this.props.history.push(ClientRoutes.Sales + '/' + row.id);
  }

  componentDidMount() {
    this.loadRecords();
  }

  loadRecords() {
    this.setState({ ...this.state, loading: true });

    axios
      .get<Array<Api.SaleClientResponseModel>>(this.props.apiRoute, {
        headers: GlobalUtilities.defaultHeaders(),
      })
      .then(response => {
        GlobalUtilities.logInfo(response);

        let mapper = new SaleMapper();

        let sales: Array<SaleViewModel> = [];

        response.data.forEach(x => {
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
      })
      .catch((error: AxiosError) => {
        GlobalUtilities.logError(error);

        if (error.response && error.response.status == 422) {
          this.setState({
            ...this.state,
            errorOccurred: false,
            errorMessage: '',
          });
        } else {
          this.setState({
            ...this.state,
            errorOccurred: true,
            errorMessage: 'Error Occurred',
          });
        }
      });
  }

  render() {
    let message: JSX.Element = <div />;
    if (this.state.errorOccurred) {
      message = <Alert message={this.state.errorMessage} type="error" />;
    }

    if (this.state.loading) {
      return <Spin size="large" />;
    } else if (this.state.errorOccurred) {
      return <Alert message={this.state.errorMessage} type="error" />;
    } else if (this.state.loaded) {
      return (
        <div>
          {message}
          <ReactTable
            data={this.state.filteredRecords}
            defaultPageSize={10}
            columns={[
              {
                Header: 'Sales',
                columns: [
                  {
                    Header: 'Amount',
                    accessor: 'amount',
                    Cell: props => {
                      return <span>{String(props.original.amount)}</span>;
                    },
                  },
                  {
                    Header: 'CutomerId',
                    accessor: 'cutomerId',
                    Cell: props => {
                      return <span>{String(props.original.cutomerId)}</span>;
                    },
                  },
                  {
                    Header: 'Note',
                    accessor: 'note',
                    Cell: props => {
                      return <span>{String(props.original.note)}</span>;
                    },
                  },
                  {
                    Header: 'PetId',
                    accessor: 'petId',
                    Cell: props => {
                      return (
                        <a
                          href=""
                          onClick={e => {
                            e.preventDefault();
                            this.props.history.push(
                              ClientRoutes.Pets + '/' + props.original.petId
                            );
                          }}
                        >
                          {String(
                            props.original.petIdNavigation &&
                              props.original.petIdNavigation.toDisplay()
                          )}
                        </a>
                      );
                    },
                  },
                  {
                    Header: 'SaleDate',
                    accessor: 'saleDate',
                    Cell: props => {
                      return <span>{String(props.original.saleDate)}</span>;
                    },
                  },
                  {
                    Header: 'SalesPersonId',
                    accessor: 'salesPersonId',
                    Cell: props => {
                      return (
                        <span>{String(props.original.salesPersonId)}</span>
                      );
                    },
                  },
                  {
                    Header: 'Actions',
                    minWidth: 150,
                    Cell: row => (
                      <div>
                        <Button
                          type="primary"
                          onClick={(e: any) => {
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
                          onClick={(e: any) => {
                            this.handleEditClick(
                              e,
                              row.original as SaleViewModel
                            );
                          }}
                        >
                          <i className="fas fa-edit" />
                        </Button>
                      </div>
                    ),
                  },
                ],
              },
            ]}
          />
        </div>
      );
    } else {
      return null;
    }
  }
}


/*<Codenesium>
    <Hash>c6259f2b31aafb28c10df8ca4dfca2dc</Hash>
</Codenesium>*/