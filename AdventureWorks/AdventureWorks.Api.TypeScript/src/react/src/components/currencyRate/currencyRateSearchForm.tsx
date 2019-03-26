import React, { Component, ReactElement, ReactHTMLElement } from 'react';
import axios, { AxiosError, AxiosResponse } from 'axios';
import { Redirect } from 'react-router-dom';
import * as Api from '../../api/models';
import CurrencyRateMapper from './currencyRateMapper';
import { Constants, ApiRoutes, ClientRoutes } from '../../constants';
import ReactTable from 'react-table';
import CurrencyRateViewModel from './currencyRateViewModel';
import 'react-table/react-table.css';
import { Form, Button, Input, Row, Col, Alert, Spin } from 'antd';
import { WrappedFormUtils } from 'antd/es/form/Form';
import * as GlobalUtilities from '../../lib/globalUtilities';

interface CurrencyRateSearchComponentProps {
  form: WrappedFormUtils;
  history: any;
  match: any;
}

interface CurrencyRateSearchComponentState {
  records: Array<CurrencyRateViewModel>;
  filteredRecords: Array<CurrencyRateViewModel>;
  loading: boolean;
  loaded: boolean;
  errorOccurred: boolean;
  errorMessage: string;
  searchValue: string;
  deleteSubmitted: boolean;
  deleteSuccess: boolean;
  deleteResponse: string;
}

export default class CurrencyRateSearchComponent extends React.Component<
  CurrencyRateSearchComponentProps,
  CurrencyRateSearchComponentState
> {
  state = {
    deleteSubmitted: false,
    deleteSuccess: false,
    deleteResponse: '',
    records: new Array<CurrencyRateViewModel>(),
    filteredRecords: new Array<CurrencyRateViewModel>(),
    searchValue: '',
    loading: false,
    loaded: true,
    errorOccurred: false,
    errorMessage: '',
  };

  componentDidMount() {
    this.loadRecords();
  }

  handleEditClick(e: any, row: CurrencyRateViewModel) {
    this.props.history.push(
      ClientRoutes.CurrencyRates + '/edit/' + row.currencyRateID
    );
  }

  handleDetailClick(e: any, row: CurrencyRateViewModel) {
    this.props.history.push(
      ClientRoutes.CurrencyRates + '/' + row.currencyRateID
    );
  }

  handleCreateClick(e: any) {
    this.props.history.push(ClientRoutes.CurrencyRates + '/create');
  }

  handleDeleteClick(e: any, row: Api.CurrencyRateClientResponseModel) {
    axios
      .delete(
        Constants.ApiEndpoint +
          ApiRoutes.CurrencyRates +
          '/' +
          row.currencyRateID,
        {
          headers: GlobalUtilities.defaultHeaders(),
        }
      )
      .then(resp => {
        this.setState({
          ...this.state,
          deleteResponse: 'Record deleted',
          deleteSuccess: true,
          deleteSubmitted: true,
        });
        this.loadRecords(this.state.searchValue);
      })
      .catch((error: AxiosError) => {
        GlobalUtilities.logError(error);
        this.setState({
          ...this.state,
          deleteResponse: 'Error deleting record',
          deleteSuccess: false,
          deleteSubmitted: true,
        });
      });
  }

  handleSearchChanged(e: React.FormEvent<HTMLInputElement>) {
    this.loadRecords(e.currentTarget.value);
  }

  loadRecords(query: string = '') {
    this.setState({ ...this.state, searchValue: query });
    let searchEndpoint =
      Constants.ApiEndpoint + ApiRoutes.CurrencyRates + '?limit=100';

    if (query) {
      searchEndpoint += '&query=' + query;
    }

    axios
      .get<Array<Api.CurrencyRateClientResponseModel>>(searchEndpoint, {
        headers: GlobalUtilities.defaultHeaders(),
      })
      .then(response => {
        let viewModels: Array<CurrencyRateViewModel> = [];
        let mapper = new CurrencyRateMapper();

        response.data.forEach(x => {
          viewModels.push(mapper.mapApiResponseToViewModel(x));
        });

        this.setState({
          records: viewModels,
          filteredRecords: viewModels,
          loading: false,
          loaded: true,
          errorOccurred: false,
          errorMessage: '',
        });
      })
      .catch((error: AxiosError) => {
        GlobalUtilities.logError(error);
        this.setState({
          records: new Array<CurrencyRateViewModel>(),
          filteredRecords: new Array<CurrencyRateViewModel>(),
          loading: false,
          loaded: true,
          errorOccurred: true,
          errorMessage: 'Error from API',
        });
      });
  }

  filterGrid() {}

  render() {
    if (this.state.loading) {
      return <Spin size="large" />;
    } else if (this.state.errorOccurred) {
      return <Alert message={this.state.errorMessage} type="error" />;
    } else if (this.state.loaded) {
      let errorResponse: JSX.Element = <span />;

      if (this.state.deleteSubmitted) {
        if (this.state.deleteSuccess) {
          errorResponse = (
            <Alert
              message={this.state.deleteResponse}
              type="success"
              style={{ marginBottom: '25px' }}
            />
          );
        } else {
          errorResponse = (
            <Alert
              message={this.state.deleteResponse}
              type="error"
              style={{ marginBottom: '25px' }}
            />
          );
        }
      }

      return (
        <div>
          {errorResponse}
          <Row>
            <Col span={8} />
            <Col span={8}>
              <Input
                placeholder={'Search'}
                id={'search'}
                onChange={(e: any) => {
                  this.handleSearchChanged(e);
                }}
              />
            </Col>
            <Col span={8}>
              <Button
                style={{ float: 'right' }}
                type="primary"
                onClick={(e: any) => {
                  this.handleCreateClick(e);
                }}
              >
                +
              </Button>
            </Col>
          </Row>
          <br />
          <br />
          <ReactTable
            data={this.state.filteredRecords}
            columns={[
              {
                Header: 'Currency Rate',
                columns: [
                  {
                    Header: 'Average Rate',
                    accessor: 'averageRate',
                    Cell: props => {
                      return <span>{String(props.original.averageRate)}</span>;
                    },
                  },
                  {
                    Header: 'Currency Rate Date',
                    accessor: 'currencyRateDate',
                    Cell: props => {
                      return (
                        <span>{String(props.original.currencyRateDate)}</span>
                      );
                    },
                  },
                  {
                    Header: 'End Of Day Rate',
                    accessor: 'endOfDayRate',
                    Cell: props => {
                      return <span>{String(props.original.endOfDayRate)}</span>;
                    },
                  },
                  {
                    Header: 'From Currency Code',
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
                            props.original.fromCurrencyCodeNavigation &&
                              props.original.fromCurrencyCodeNavigation.toDisplay()
                          )}
                        </a>
                      );
                    },
                  },
                  {
                    Header: 'Modified Date',
                    accessor: 'modifiedDate',
                    Cell: props => {
                      return <span>{String(props.original.modifiedDate)}</span>;
                    },
                  },
                  {
                    Header: 'To Currency Code',
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
                            props.original.toCurrencyCodeNavigation &&
                              props.original.toCurrencyCodeNavigation.toDisplay()
                          )}
                        </a>
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
                        &nbsp;
                        <Button
                          type="danger"
                          onClick={(e: any) => {
                            this.handleDeleteClick(
                              e,
                              row.original as CurrencyRateViewModel
                            );
                          }}
                        >
                          <i className="far fa-trash-alt" />
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

export const WrappedCurrencyRateSearchComponent = Form.create({
  name: 'CurrencyRate Search',
})(CurrencyRateSearchComponent);


/*<Codenesium>
    <Hash>9afd01f857086542632d1c605f641c20</Hash>
</Codenesium>*/