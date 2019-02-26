import React, { Component, FormEvent } from 'react';
import axios from 'axios';
import { Constants, ApiRoutes, ClientRoutes } from '../../constants';
import * as Api from '../../api/models';
import SaleTicketMapper from '../saleTicket/saleTicketMapper';
import SaleTicketViewModel from '../saleTicket/saleTicketViewModel';
import { Form, Input, Button, Spin, Alert } from 'antd';
import { WrappedFormUtils } from 'antd/es/form/Form';
import ReactTable from 'react-table';

interface SaleTicketTableComponentProps {
  id: number;
  apiRoute: string;
  history: any;
  match: any;
}

interface SaleTicketTableComponentState {
  loading: boolean;
  loaded: boolean;
  errorOccurred: boolean;
  errorMessage: string;
  filteredRecords: Array<SaleTicketViewModel>;
}

export class SaleTicketTableComponent extends React.Component<
  SaleTicketTableComponentProps,
  SaleTicketTableComponentState
> {
  state = {
    loading: false,
    loaded: true,
    errorOccurred: false,
    errorMessage: '',
    filteredRecords: [],
  };

  handleEditClick(e: any, row: SaleTicketViewModel) {
    this.props.history.push(ClientRoutes.SaleTickets + '/edit/' + row.id);
  }

  handleDetailClick(e: any, row: SaleTicketViewModel) {
    this.props.history.push(ClientRoutes.SaleTickets + '/' + row.id);
  }

  componentDidMount() {
    this.loadRecords();
  }

  loadRecords() {
    this.setState({ ...this.state, loading: true });

    axios
      .get(this.props.apiRoute, {
        headers: {
          'Content-Type': 'application/json',
        },
      })
      .then(
        resp => {
          let response = resp.data as Array<Api.SaleTicketClientResponseModel>;

          console.log(response);

          let mapper = new SaleTicketMapper();

          let saleTickets: Array<SaleTicketViewModel> = [];

          response.forEach(x => {
            saleTickets.push(mapper.mapApiResponseToViewModel(x));
          });
          this.setState({
            ...this.state,
            filteredRecords: saleTickets,
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
                Header: 'SaleTickets',
                columns: [
                  {
                    Header: 'SaleId',
                    accessor: 'saleId',
                    Cell: props => {
                      return (
                        <a
                          href=""
                          onClick={e => {
                            e.preventDefault();
                            this.props.history.push(
                              ClientRoutes.Sales + '/' + props.original.saleId
                            );
                          }}
                        >
                          {String(props.original.saleIdNavigation.toDisplay())}
                        </a>
                      );
                    },
                  },
                  {
                    Header: 'TicketId',
                    accessor: 'ticketId',
                    Cell: props => {
                      return (
                        <a
                          href=""
                          onClick={e => {
                            e.preventDefault();
                            this.props.history.push(
                              ClientRoutes.Tickets +
                                '/' +
                                props.original.ticketId
                            );
                          }}
                        >
                          {String(
                            props.original.ticketIdNavigation.toDisplay()
                          )}
                        </a>
                      );
                    },
                  },
                  {
                    Header: 'Actions',
                    Cell: row => (
                      <div>
                        <Button
                          type="primary"
                          onClick={(e: any) => {
                            this.handleDetailClick(
                              e,
                              row.original as SaleTicketViewModel
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
                              row.original as SaleTicketViewModel
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
    <Hash>0c9a4514005b2b6c0d45d18b97d53f15</Hash>
</Codenesium>*/