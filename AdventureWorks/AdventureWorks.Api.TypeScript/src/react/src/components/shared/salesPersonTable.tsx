import React, { Component, FormEvent } from 'react';
import axios, { AxiosError, AxiosResponse } from 'axios';
import { Constants, ApiRoutes, ClientRoutes } from '../../constants';
import * as Api from '../../api/models';
import SalesPersonMapper from '../salesPerson/salesPersonMapper';
import SalesPersonViewModel from '../salesPerson/salesPersonViewModel';
import { Form, Input, Button, Spin, Alert } from 'antd';
import { WrappedFormUtils } from 'antd/es/form/Form';
import ReactTable from 'react-table';
import * as GlobalUtilities from '../../lib/globalUtilities';

interface SalesPersonTableComponentProps {
  apiRoute: string;
  history: any;
  match: any;
}

interface SalesPersonTableComponentState {
  loading: boolean;
  loaded: boolean;
  errorOccurred: boolean;
  errorMessage: string;
  filteredRecords: Array<SalesPersonViewModel>;
}

export class SalesPersonTableComponent extends React.Component<
  SalesPersonTableComponentProps,
  SalesPersonTableComponentState
> {
  state = {
    loading: false,
    loaded: true,
    errorOccurred: false,
    errorMessage: '',
    filteredRecords: [],
  };

  handleEditClick(e: any, row: SalesPersonViewModel) {
    this.props.history.push(
      ClientRoutes.SalesPersons + '/edit/' + row.businessEntityID
    );
  }

  handleDetailClick(e: any, row: SalesPersonViewModel) {
    this.props.history.push(
      ClientRoutes.SalesPersons + '/' + row.businessEntityID
    );
  }

  componentDidMount() {
    this.loadRecords();
  }

  loadRecords() {
    this.setState({ ...this.state, loading: true });

    axios
      .get<Array<Api.SalesPersonClientResponseModel>>(this.props.apiRoute, {
        headers: GlobalUtilities.defaultHeaders(),
      })
      .then(response => {
        GlobalUtilities.logInfo(response);

        let mapper = new SalesPersonMapper();

        let salesPersons: Array<SalesPersonViewModel> = [];

        response.data.forEach(x => {
          salesPersons.push(mapper.mapApiResponseToViewModel(x));
        });

        this.setState({
          ...this.state,
          filteredRecords: salesPersons,
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
                Header: 'SalesPersons',
                columns: [
                  {
                    Header: 'Bonus',
                    accessor: 'bonus',
                    Cell: props => {
                      return <span>{String(props.original.bonus)}</span>;
                    },
                  },
                  {
                    Header: 'Commission Pct',
                    accessor: 'commissionPct',
                    Cell: props => {
                      return (
                        <span>{String(props.original.commissionPct)}</span>
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
                    Header: 'Rowguid',
                    accessor: 'rowguid',
                    Cell: props => {
                      return <span>{String(props.original.rowguid)}</span>;
                    },
                  },
                  {
                    Header: 'Sales Last Year',
                    accessor: 'salesLastYear',
                    Cell: props => {
                      return (
                        <span>{String(props.original.salesLastYear)}</span>
                      );
                    },
                  },
                  {
                    Header: 'Sales Quota',
                    accessor: 'salesQuota',
                    Cell: props => {
                      return <span>{String(props.original.salesQuota)}</span>;
                    },
                  },
                  {
                    Header: 'Sales Y T D',
                    accessor: 'salesYTD',
                    Cell: props => {
                      return <span>{String(props.original.salesYTD)}</span>;
                    },
                  },
                  {
                    Header: 'Territory I D',
                    accessor: 'territoryID',
                    Cell: props => {
                      return (
                        <a
                          href=""
                          onClick={e => {
                            e.preventDefault();
                            this.props.history.push(
                              ClientRoutes.SalesTerritories +
                                '/' +
                                props.original.territoryID
                            );
                          }}
                        >
                          {String(
                            props.original.territoryIDNavigation &&
                              props.original.territoryIDNavigation.toDisplay()
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
                              row.original as SalesPersonViewModel
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
                              row.original as SalesPersonViewModel
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
    <Hash>6d9cf63f026c275193aea9770d971ed5</Hash>
</Codenesium>*/