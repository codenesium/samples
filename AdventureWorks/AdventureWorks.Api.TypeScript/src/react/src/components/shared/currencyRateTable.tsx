import React, { Component, FormEvent } from 'react';
import axios from 'axios';
import { Constants, ApiRoutes, ClientRoutes } from '../../constants';
import * as Api from '../../api/models';
import CurrencyRateMapper from '../currencyRate/currencyRateMapper';
import CurrencyRateViewModel from '../currencyRate/currencyRateViewModel';
import { Form, Input, Button, Spin, Alert } from 'antd';
import { WrappedFormUtils } from 'antd/es/form/Form';
import ReactTable from 'react-table';

interface CurrencyRateTableComponentProps {
  currencyRateID: number;
  apiRoute: string;
  history: any;
  match: any;
}

interface CurrencyRateTableComponentState {
  loading: boolean;
  loaded: boolean;
  errorOccurred: boolean;
  errorMessage: string;
  filteredRecords: Array<CurrencyRateViewModel>;
}

export class CurrencyRateTableComponent extends React.Component<
  CurrencyRateTableComponentProps,
  CurrencyRateTableComponentState
> {
  state = {
    loading: false,
    loaded: true,
    errorOccurred: false,
    errorMessage: '',
    filteredRecords: [],
  };

  handleEditClick(e: any, row: CurrencyRateViewModel) {
    this.props.history.push(ClientRoutes.CurrencyRates + '/edit/' + row.id);
  }

  handleDetailClick(e: any, row: CurrencyRateViewModel) {
    this.props.history.push(ClientRoutes.CurrencyRates + '/' + row.id);
  }

  componentDidMount() {
    this.setState({ ...this.state, loading: true });

    axios
      .get(this.props.apiRoute, {
        headers: {
          'Content-Type': 'application/json',
        },
      })
      .then(
        resp => {
          let response = resp.data as Array<
            Api.CurrencyRateClientResponseModel
          >;

          console.log(response);

          let mapper = new CurrencyRateMapper();

          let currencyRates: Array<CurrencyRateViewModel> = [];

          response.forEach(x => {
            currencyRates.push(mapper.mapApiResponseToViewModel(x));
          });
          this.setState({
            ...this.state,
            filteredRecords: currencyRates,
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
                Header: 'CurrencyRates',
                columns: [
                  {
                    Header: 'AverageRate',
                    accessor: 'averageRate',
                    Cell: props => {
                      return <span>{String(props.original.averageRate)}</span>;
                    },
                  },
                  {
                    Header: 'CurrencyRateDate',
                    accessor: 'currencyRateDate',
                    Cell: props => {
                      return (
                        <span>{String(props.original.currencyRateDate)}</span>
                      );
                    },
                  },
                  {
                    Header: 'CurrencyRateID',
                    accessor: 'currencyRateID',
                    Cell: props => {
                      return (
                        <span>{String(props.original.currencyRateID)}</span>
                      );
                    },
                  },
                  {
                    Header: 'EndOfDayRate',
                    accessor: 'endOfDayRate',
                    Cell: props => {
                      return <span>{String(props.original.endOfDayRate)}</span>;
                    },
                  },
                  {
                    Header: 'FromCurrencyCode',
                    accessor: 'fromCurrencyCode',
                    Cell: props => {
                      return (
                        <a
                          href=""
                          onClick={e => {
                            e.preventDefault();
                            this.props.history.push(
                              ClientRoutes.Currencies +
                                '/' +
                                props.original.fromCurrencyCode
                            );
                          }}
                        >
                          {String(
                            props.original.fromCurrencyCodeNavigation.toDisplay()
                          )}
                        </a>
                      );
                    },
                  },
                  {
                    Header: 'ModifiedDate',
                    accessor: 'modifiedDate',
                    Cell: props => {
                      return <span>{String(props.original.modifiedDate)}</span>;
                    },
                  },
                  {
                    Header: 'ToCurrencyCode',
                    accessor: 'toCurrencyCode',
                    Cell: props => {
                      return (
                        <a
                          href=""
                          onClick={e => {
                            e.preventDefault();
                            this.props.history.push(
                              ClientRoutes.Currencies +
                                '/' +
                                props.original.toCurrencyCode
                            );
                          }}
                        >
                          {String(
                            props.original.toCurrencyCodeNavigation.toDisplay()
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
                              row.original as CurrencyRateViewModel
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
                              row.original as CurrencyRateViewModel
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
    <Hash>45d43185a0bd9fe5ddd1a7a3ab61ee4a</Hash>
</Codenesium>*/